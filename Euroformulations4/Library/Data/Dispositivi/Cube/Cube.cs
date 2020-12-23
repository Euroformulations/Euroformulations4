using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.IO.Ports;


public class Cube
{
    public const byte Device_Power_Off = 0x00;
    public const byte Device_Rest = 0x01;
    public const byte Device_Ping = 0x02;

    private const byte Set_Calibration_Value = 0x03;
    private const byte Get_Calibration_Value = 0x04;
    private const byte Get_Calibration_Temperature = 0x05;
    private const byte Do_Calibration = 0x06;

    private const byte Get_Stored_Sample_Capacity = 0x20;
    private const byte Get_Total_Number_Of_Stored_Samples = 0x21;
    private const byte Get_Stored_Sample_Data = 0x22;
    private const byte Clear_All_Stored_Samples = 0x23;

    public const byte Get_Colour_Data = 0x40;
    public const byte Get_Temperature_Data = 0x41;
    public const byte Get_Brightness_Data = 0x46;
    public const byte Get_Light_Intensity = 0x47;

    public const byte Get_R_LED_Data = 0x48;
    public const byte Get_G_LED_Data = 0x49;
    public const byte Get_B_LED_Data = 0x4A;

    private const byte Set_Idle_Timer_Value = 0x50;
    private const byte Get_Idle_Timer_Value = 0x51;


    SerialPort cubeSerialPort = null;
    public String portName { get; set; }


    //class constructor - initial and configure COM Port
    public Cube()
    {

        this.cubeSerialPort = new SerialPort();
        this.cubeSerialPort.BaudRate = 38400;
        this.cubeSerialPort.Parity = System.IO.Ports.Parity.None;
        this.cubeSerialPort.StopBits = System.IO.Ports.StopBits.One;
        this.cubeSerialPort.DataBits = 8;
        this.cubeSerialPort.ReadTimeout = 1000;
        this.cubeSerialPort.WriteTimeout = 500;
        this.cubeSerialPort.Handshake = System.IO.Ports.Handshake.RequestToSend; //System.IO.Ports.Handshake.None; 
        this.cubeSerialPort.DataReceived += new SerialDataReceivedEventHandler(cubeSerialPort_DataReceived);

    }

    public bool isConnected()
    {
        bool connected = false;

        if (cubeSerialPort.IsOpen)
        {
            try
            {

                if (pingCube())
                {
                    //To check the connectivity
                    //To clear up send buffer in the cube. 
                    return true;
                }
                else if (pingCube())
                {
                    return true;

                }
                else
                {
                    cubeSerialPort.Close();
                    //Console.WriteLine("Cube is OFF");
                    return false;
                }
            }
            catch (TimeoutException)
            {
                //Console.WriteLine("timeout!!");
                return false;
            }
        }

        return connected;
    }


    //Open a COM Port connection and send a command to ping the Cube
    public bool Connect()
    {
        cubeSerialPort.Close();

        //Console.WriteLine(portName);
        //place holder function
        if (!cubeSerialPort.IsOpen && portName != null)
        {
            cubeSerialPort.PortName = portName;
            //Console.WriteLine("name is updated");
        }

        try
        {
            if (!cubeSerialPort.IsOpen)
            {

                cubeSerialPort.Open();
                //Console.WriteLine("port is open!!");
                //send command to ping the cube
                return isConnected();

            }
            else
            {

                //System.Console.WriteLine("Port is occupied");
                return false;
            }
        }
        catch (UnauthorizedAccessException)
        {

            //System.Console.WriteLine(exc.Message);
            //Console.WriteLine("error in connect()");
            return false;
        }
        catch (Exception)
        {
            //Console.WriteLine("error in connect()");
            return false;
        }


    }


    //Disconnect
    public bool Disconnect()
    {

        if (cubeSerialPort.IsOpen)
        {

            try
            {

                //unsubscribe async dataReceiver
                cubeSerialPort.DataReceived -= cubeSerialPort_DataReceived;
                cubeSerialPort.Close();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        return true;
    }


    //Send Data to the cube
    public bool serialWrite(byte[] data)
    {
        if (cubeSerialPort.IsOpen) cubeSerialPort.DiscardOutBuffer();
        try
        {
            cubeSerialPort.Write(data, 0, data.Length);
            Thread.Sleep(2);
        }
        catch
        {
            //Console.WriteLine("write timeout!!");

            return false;
        }

        return true;
    }



    //new serial Read method with time-out in-built. 
    private bool serialRead(byte[] readBuffer)
    {
        // If the com port has been closed, do nothing
        if (!cubeSerialPort.IsOpen) return false;

        int offset = 0;
        int bytesRead;
        int bytesExpected = readBuffer.Length;

        try
        {
            //Console.WriteLine("in read serial");

            while (bytesExpected > 0 &&
                (bytesRead = cubeSerialPort.Read(readBuffer, offset, bytesExpected)) > 0)
            {

                offset += bytesRead;
                bytesExpected -= bytesRead;
                //delay is handed by the serial port time out function
            }

        }
        catch (System.TimeoutException)
        {
            //Console.WriteLine("Read timeout!!!");
            readBuffer = null;
            return false;

        }
        catch (Exception)
        {
            readBuffer = null;
            return false;
        }
        return bytesExpected == 0;

    }


    //Synchronise serial communication, returns data received
    public byte[] syncSerialWrite(byte[] sendPackets)
    {
        //unsubscribe async dataReceiver for sync dataReceiver
        cubeSerialPort.DataReceived -= cubeSerialPort_DataReceived;
        byte[] receiveData = new byte[sendPackets.Length];
        if (cubeSerialPort.IsOpen) cubeSerialPort.DiscardInBuffer();
        //Console.WriteLine("send command");
        //Console.WriteLine(DataHandler.ByteArrayToHexString(sendPackets));
        serialWrite(sendPackets);
        serialRead(receiveData);
        //Console.WriteLine("Receive command");
        //Console.WriteLine(DataHandler.ByteArrayToHexString(receiveData));
        //subscribe async dataReceiver as sync dataReciever is complete
        cubeSerialPort.DataReceived += cubeSerialPort_DataReceived;
        return receiveData;
    }


    public delegate void SampleMonitor(float L, float A, float B);

    public static event SampleMonitor CubeSampled;

    //Asynchronous dataReceiver
    private void cubeSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        //Console.WriteLine("Data Received is fired");
        // If the com port has been closed, do nothing
        if (!cubeSerialPort.IsOpen) return;

        if ((sender as SerialPort).BytesToRead > 15)
        {

            // Obtain the number of bytes waiting in the port's buffer
            int mumOfBytes = ((SerialPort)sender).BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] readBuffer = new byte[mumOfBytes];


            try
            {

                // Read the data from the port and store it in our buffer
                int bytesRead = ((SerialPort)sender).Read(readBuffer, 0, mumOfBytes);

                //Attention         //Calibration complete aync data is not handle
                byte[] red = readBuffer.Skip(4).Take(4).ToArray();
                byte[] green = readBuffer.Skip(8).Take(4).ToArray();
                byte[] blue = readBuffer.Skip(12).Take(4).ToArray();

                //Console.WriteLine(DataHandler.ByteArrayToHexString(readBuffer));
                //Console.WriteLine(DataHandler.ByteArrayToHexString(red));
                //Console.WriteLine(DataHandler.ByteArrayToHexString(green));
                //Console.WriteLine(DataHandler.ByteArrayToHexString(blue));
                //Console.WriteLine(DataHandler.BAToFloat(red));
                //Console.WriteLine(DataHandler.BAToFloat(green));
                //Console.WriteLine(DataHandler.BAToFloat(blue));

                if (CubeSampled != null)
                {
                    //Raise an event
                    CubeSampled(DataHandler.BAToFloat(red), DataHandler.BAToFloat(green), DataHandler.BAToFloat(blue));

                }


            }
            catch (System.TimeoutException)
            {

            }
        }
    }



    //Power off the Cube
    public bool powerOffCube()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Device_Power_Off));
        byte[] pingBytes = { 0x7E, 0x20, 0x00, 0x00 };

        if (StructuralComparisons.StructuralEqualityComparer.Equals(receivedData, pingBytes))
        {

            return true;

        }
        else
        {

            return false;

        }
    }

    //Reset the Cube
    public bool resetCube()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Device_Rest));
        byte[] pingBytes = { 0x7E, 0x20, 0x01, 0x00 };

        if (StructuralComparisons.StructuralEqualityComparer.Equals(receivedData, pingBytes))
        {

            return true;

        }
        else
        {

            return false;

        }
    }

    //Ping the Cube
    public bool pingCube()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Device_Ping));
        byte[] pingBytes = { 0x7E, 0x20, 0x02, 0x00 };

        if (StructuralComparisons.StructuralEqualityComparer.Equals(receivedData, pingBytes))
        {

            return true;

        }
        else
        {

            return false;

        }
    }

    //Set Calibration Data from the EEPROM
    public bool setCalibValue(byte index, float value)
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Set_Calibration_Value, index, value));
        byte rxIndex = receivedData[4];
        float rxValue = DataHandler.BAToFloat(receivedData.Skip(5).Take(4).ToArray());

        if (rxIndex == index && rxValue == value)
        {

            return true;

        }
        else
        {

            return false;

        }

    }

    //Get Calibration Data from the EEPROM
    public float getCalibValue(byte index)
    {
        //ATTN
        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Calibration_Value, index, 0f));
        byte rxIndex = receivedData[4];
        float rxValue = DataHandler.BAToFloat(receivedData.Skip(5).Take(4).ToArray());

        if (rxIndex == index)
        {

            return rxValue;

        }
        else
        {

            return rxValue;

        }

    }


    public float getCalibTemp(byte index)
    {
        //ATTN
        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Calibration_Temperature, index, 0f));
        byte rxIndex = receivedData[4];
        float rxValue = DataHandler.BAToFloat(receivedData.Skip(5).Take(4).ToArray());

        if (rxIndex == index)
        {

            return rxValue;

        }
        else
        {

            return rxValue;

        }

    }

    //Do/Stop/Reset Calibration
    public byte doCalibration()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Do_Calibration, 1));
        byte rxStatus = receivedData[4];

        return rxStatus;

    }
    public byte stopCalibration()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Do_Calibration, 0));
        byte rxStatus = receivedData[4];

        return rxStatus;

    }
    public byte resetGreyscale()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Do_Calibration, 2));
        byte rxStatus = receivedData[4];

        return rxStatus;

    }

    //Get the storage capacity
    public byte getStoredCapacity()
    {
        //ATTN
        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Stored_Sample_Capacity, 0));
        byte num = receivedData[4];

        if (receivedData[3] == 0x00)
        {

            return num;

        }
        else
        {

            return 0;

        }

    }

    //Get the number of sample stored in the Cube
    public byte getTotalSamples()
    {
        //ATTN
        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Total_Number_Of_Stored_Samples, 0));
        byte num = receivedData[4];

        if (receivedData[3] == 0x00)
        {

            return num;

        }
        else
        {

            return 0;

        }

    }

    //Return stored colour 
    public float[] getSortedColour(byte index)
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Stored_Sample_Data, index));
        byte rxIndex = receivedData[4];
        float[] LAB = new float[3];

        if ((receivedData[3] == 0x00 || receivedData[3] == 0xF7) && rxIndex == index)
        {

            LAB[0] = DataHandler.BAToFloat(receivedData.Skip(5).Take(4).ToArray());
            LAB[1] = DataHandler.BAToFloat(receivedData.Skip(9).Take(4).ToArray());
            LAB[2] = DataHandler.BAToFloat(receivedData.Skip(13).Take(4).ToArray());

        }
        else
        {

            LAB[0] = 0;
            LAB[1] = 0;
            LAB[2] = 0;

        }

        return LAB;

    }


    //Clear ALL Samples that are stored in the Cube
    public bool clearCubeSamples()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Clear_All_Stored_Samples));
        byte[] pingBytes = { 0x7E, 0x20, 0x23, 0x00 };

        if (StructuralComparisons.StructuralEqualityComparer.Equals(receivedData, pingBytes))
        {

            return true;

        }
        else
        {

            return false;

        }

    }




    public float[] getLabData()
    {
        //Adjust Timeout to accommodate long sampling time 1.8sec
        cubeSerialPort.ReadTimeout = 3000;
        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Colour_Data));
        cubeSerialPort.ReadTimeout = 1000;
        byte[] red = receivedData.Skip(4).Take(4).ToArray();
        byte[] green = receivedData.Skip(8).Take(4).ToArray();
        byte[] blue = receivedData.Skip(12).Take(4).ToArray();
        float[] data = { DataHandler.BAToFloat(red), DataHandler.BAToFloat(green), DataHandler.BAToFloat(blue) };
        return data;

    }

    //Return a temperature value
    public float getTemperature()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Temperature_Data));
        byte[] temperature = receivedData.Skip(4).Take(receivedData.Length - 2).ToArray();
        return DataHandler.BAToFloat(temperature);

    }


    public float getBrightness()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Brightness_Data));
        byte[] brightness = receivedData.Skip(4).Take(4).ToArray();
        float data = DataHandler.BAToFloat(brightness);
        return data;

    }


    public ushort[] getAmbientLightData()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Light_Intensity));
        byte[] clear = receivedData.Skip(4).Take(2).ToArray();
        byte[] red = receivedData.Skip(6).Take(2).ToArray();
        byte[] green = receivedData.Skip(8).Take(2).ToArray();
        byte[] blue = receivedData.Skip(10).Take(2).ToArray();
        ushort[] data = { DataHandler.BAToUShort(clear), DataHandler.BAToUShort(red), DataHandler.BAToUShort(green), DataHandler.BAToUShort(blue) };
        return data;

    }

    public ushort[] getRedLEDData()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_R_LED_Data));
        byte[] clear = receivedData.Skip(4).Take(2).ToArray();
        byte[] red = receivedData.Skip(6).Take(2).ToArray();
        byte[] green = receivedData.Skip(8).Take(2).ToArray();
        byte[] blue = receivedData.Skip(10).Take(2).ToArray();
        ushort[] data = { DataHandler.BAToUShort(clear), DataHandler.BAToUShort(red), DataHandler.BAToUShort(green), DataHandler.BAToUShort(blue) };
        return data;

    }

    public ushort[] getGreenLEDData()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_G_LED_Data));
        byte[] clear = receivedData.Skip(4).Take(2).ToArray();
        byte[] red = receivedData.Skip(6).Take(2).ToArray();
        byte[] green = receivedData.Skip(8).Take(2).ToArray();
        byte[] blue = receivedData.Skip(10).Take(2).ToArray();
        ushort[] data = { DataHandler.BAToUShort(clear), DataHandler.BAToUShort(red), DataHandler.BAToUShort(green), DataHandler.BAToUShort(blue) };
        return data;

    }

    public ushort[] getBlueLEDData()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_B_LED_Data));
        byte[] clear = receivedData.Skip(4).Take(2).ToArray();
        byte[] red = receivedData.Skip(6).Take(2).ToArray();
        byte[] green = receivedData.Skip(8).Take(2).ToArray();
        byte[] blue = receivedData.Skip(10).Take(2).ToArray();
        ushort[] data = { DataHandler.BAToUShort(clear), DataHandler.BAToUShort(red), DataHandler.BAToUShort(green), DataHandler.BAToUShort(blue) };
        return data;

    }

    public ushort[] getRawData()
    {

        ushort[] Red = getRedLEDData();
        ushort[] Green = getGreenLEDData();
        ushort[] Blue = getBlueLEDData();
        ushort[] data = Red.Concat(Green).ToArray().Concat(Blue).ToArray();
        return data;

    }


    public bool setIdleTimer(ushort seconds)
    {

        ushort time = seconds;
        if (seconds < 30)
        {
            time = 30;
        }
        if (seconds > 480)
        {
            time = 480;
        }

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Set_Idle_Timer_Value, time));
        ushort rxValue = DataHandler.BAToUShort(receivedData.Skip(4).Take(2).ToArray());

        if (receivedData[3] == 0x00 && rxValue == time)
        {

            return true;

        }
        else
        {

            return false;

        }

    }


    public ushort getIdleTimer()
    {

        byte[] receivedData = syncSerialWrite(sendCommand(Cube.Get_Idle_Timer_Value));
        ushort rxValue = DataHandler.BAToUShort(receivedData.Skip(4).Take(2).ToArray());

        if (receivedData[3] == 0x00)
        {

            return rxValue;

        }
        else
        {

            return 0;

        }

    }



    public byte[] sendCommand(byte command)
    {

        byte[] packets = null;

        switch (command)
        {
            case Device_Power_Off:
                byte[] case1 = { 0x7E, 0x00, 0x00, 0x00 };
                packets = case1;
                break;
            case Device_Rest:
                byte[] case2 = { 0x7E, 0x00, 0x01, 0x00 };
                packets = case2;
                break;
            case Device_Ping:
                byte[] case3 = { 0x7E, 0x00, 0x02, 0x00 };
                packets = case3;
                break;
            case Clear_All_Stored_Samples:
                byte[] case4 = { 0x7E, 0x00, 0x23, 0x00 };
                packets = case4;
                break;
            case Get_Colour_Data:
                byte[] case5 = { 0x7E, 0x0C, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case5;
                break;
            case Get_Temperature_Data:
                byte[] case6 = { 0x7E, 0x04, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case6;
                break;
            case Get_Brightness_Data:
                byte[] case7 = { 0x7E, 0x04, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case7;
                break;
            case Get_Light_Intensity:
                byte[] case8 = { 0x7E, 0x08, 0x47, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case8;
                break;
            case Get_R_LED_Data:
                byte[] case9 = { 0x7E, 0x08, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case9;
                break;
            case Get_G_LED_Data:
                byte[] case10 = { 0x7E, 0x08, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case10;
                break;
            case Get_B_LED_Data:
                byte[] case11 = { 0x7E, 0x08, 0x4A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                packets = case11;
                break;
            case Get_Idle_Timer_Value:
                byte[] case12 = { 0x7E, 0x02, 0x51, 0x00, 0x00, 0x00 };
                packets = case12;
                break;
            default:
                throw new NotSupportedException();
        }
        return packets;

    }

    public byte[] sendCommand(byte command, byte pointer, float payload)
    {

        byte[] packets = new byte[9];
        packets[0] = 0x7E;
        packets[1] = 0x05;
        packets[2] = command;
        packets[3] = 0x00;
        packets[4] = pointer;
        byte[] byteArray = DataHandler.FloatToBA(payload);

        switch (command)
        {
            case Set_Calibration_Value:
                for (int i = 0; i < byteArray.Length; i++)
                {
                    packets[5 + i] = byteArray[i];
                }
                break;
            case Get_Calibration_Value:
                for (int i = 0; i < byteArray.Length; i++)
                {
                    packets[5 + i] = 0x00;
                }
                break;
            case Get_Calibration_Temperature:
                for (int i = 0; i < byteArray.Length; i++)
                {
                    packets[5 + i] = 0x00;
                }
                break;
            default:
                throw new NotSupportedException();
        }
        return packets;

    }

    public byte[] sendCommand(byte command, byte pointer)
    {

        byte[] packets = null;
        byte[] value1 = new byte[5];
        value1[0] = 0x7E;
        value1[1] = 0x01;
        value1[2] = command;
        value1[3] = 0x00;

        switch (command)
        {
            case Do_Calibration:
                value1[4] = pointer;
                packets = value1;
                break;
            case Get_Stored_Sample_Capacity:
                value1[4] = 0x00;
                packets = value1;
                break;
            case Get_Total_Number_Of_Stored_Samples:
                value1[4] = 0x00;
                packets = value1;
                break;
            case Get_Stored_Sample_Data:
                byte[] value2 = new byte[17];
                value2[0] = 0x7E;
                value2[1] = 0x0D;
                value2[2] = command;
                value2[3] = 0x00;
                value2[4] = pointer;
                for (int i = 0; i < 12; i++)
                {
                    value2[5 + i] = 0x00;
                }
                packets = value2;
                break;
            default:
                throw new NotSupportedException();
        }
        return packets;
    }

    public byte[] sendCommand(byte command, ushort payload)
    {

        byte[] packets = new byte[6];
        if (command == Set_Idle_Timer_Value)
        {

            packets[0] = 0x7E;
            packets[1] = 0x02;
            packets[2] = command;
            packets[3] = 0x00;

            byte[] value = DataHandler.UShortToBA(payload);
            for (int i = 0; i < value.Length; i++)
            {
                packets[4 + i] = value[i];
            }

        }
        return packets;

    }


    public float[] getUserGreyScale()
    {

        float[] data = new float[9];
        int offset = 78;
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = getCalibValue((byte)(offset + i));
        }
        return data;

    }

    public void setUserGreyScale(float[] data)
    {

        if (data.Length == 9)
        {
            int offset = 78;
            for (int i = 0; i < data.Length; i++)
            {
                setCalibValue((byte)(offset + i), data[i]);
            }
        }

    }


    public float[] getFactoryGreyScale()
    {

        float[] data = new float[9];
        int offset = 69;
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = getCalibValue((byte)(offset + i));
        }
        return data;

    }

    public void setFactoryGreyScale(float[] data)
    {

        if (data.Length == 9)
        {
            int offset = 69;
            for (int i = 0; i < data.Length; i++)
            {
                setCalibValue((byte)(offset + i), data[i]);
            }
        }

    }


    public float[] getFactoryColour()
    {

        float[] data = new float[18];
        int offset = 33;
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = getCalibValue((byte)(offset + i));
        }
        return data;

    }

    public void setFactoryColour(float[] data)
    {

        if (data.Length == 18)
        {
            int offset = 33;
            for (int i = 0; i < data.Length; i++)
            {
                setCalibValue((byte)(offset + i), data[i]);
            }
        }

    }


    public float[] getMasterColour()
    {

        float[] data = new float[33];
        int offset = 0;
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = getCalibValue((byte)(offset + i));
        }
        return data;

    }

    public void setMasterColour(float[] data)
    {

        if (data.Length == 33)
        {
            int offset = 0;
            for (int i = 0; i < data.Length; i++)
            {
                setCalibValue((byte)(offset + i), data[i]);
            }
        }
    }

}
