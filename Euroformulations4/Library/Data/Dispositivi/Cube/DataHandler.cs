using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DataHandler
{

    /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
    /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
    /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
    public static string ByteArrayToHexString(byte[] data)
    {
        StringBuilder sb = new StringBuilder(data.Length * 3);
        foreach (byte b in data)
            sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
        return sb.ToString().ToUpper();
    }


    /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
    /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
    /// <returns> Returns an array of bytes. </returns>
    public static byte[] HexStringToByteArray(string s)
    {
        s = s.Replace(" ", "");
        byte[] buffer = new byte[s.Length / 2];
        for (int i = 0; i < s.Length; i += 2)
            buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
        return buffer;
    }

    // Convert a four-byte array to a float 
    public static float BAToFloat(byte[] bytes)
    {
        return BitConverter.ToSingle(bytes.Reverse().ToArray(), 0);
    }

    // Convert a float to a four-byte array 
    public static byte[] FloatToBA(float num)
    {
        return BitConverter.GetBytes(num).Reverse().ToArray();
    }

    // Convert a two-byte array to a ushort
    public static ushort BAToUShort(byte[] bytes)
    {
        return BitConverter.ToUInt16(bytes.Reverse().ToArray(), 0);
    }

    // Convert a two-byte array to a ushort
    public static byte[] UShortToBA(ushort num)
    {
        return BitConverter.GetBytes(num).Reverse().ToArray(); ;
    }

    // Convert ushort array elements to a string
    public static string UShortArrayToString(ushort[] data)
    {
        StringBuilder sb = new StringBuilder(data.Length * 3);
        foreach (ushort b in data)
            sb.Append(Convert.ToString(b, 10) + " ");
        return sb.ToString();
    }


    public static ushort[] TrimClearData(ushort[] rawData)
    {
        return rawData.Skip(1).Take(3).Concat(rawData.Skip(5).Take(3)).Concat(rawData.Skip(9).Take(3)).ToArray();
    }


    public static float[] UShortArrayToFloatArray(ushort[] data)
    {
        float[] values = new float[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            values[i] = Convert.ToSingle(data[i]);
        }
        return values;
    }


    // create a byte array and copy the floats into it...
    public static byte[] FloatArrayToByteArray(float[] floatArray)
    {
        var byteArray = new byte[floatArray.Length * 4];
        Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);
        return byteArray;
    }

    // create a second float array and copy the bytes into it...
    public static float[] ByteArrayToFloatArray(byte[] byteArray)
    {
        var floatArray = new float[byteArray.Length / 4];
        Buffer.BlockCopy(byteArray, 0, floatArray, 0, byteArray.Length);
        return floatArray;
    }

    public static string ByteArrayToString(byte[] byteArray)
    {
        return System.Text.Encoding.Default.GetString(byteArray);
    }

    public static byte[] StringToByteArray(string str)
    {
        return System.Text.Encoding.Default.GetBytes(str);
    }

    public static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

    public static string GetString(byte[] bytes)
    {
        char[] chars = new char[bytes.Length / sizeof(char)];
        System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        return new string(chars);
    }

    //Simple Linear Regression Method - Line of Best Fit
    //Input List of double X and Y
    public static Dictionary<string, double> SimpleLR(List<double> X, List<double> Y)
    {
        ///Variable declarations            
        int num = 0; //use for List count
        double sumX = 0; //summation of x[i]
        double sumY = 0; //summation of y[i]
        double sum2X = 0; // summation of x[i]*x[i]
        double sum2Y = 0; // summation  of y[i]*y[i]
        double sumXY = 0; // summation of x[i] * y[i]  
        double denX = 0;
        double denY = 0;
        double top = 0;
        double corelation = 0; // holds Corelation
        double slope = 0; // holds slope(beta)
        double y_intercept = 0; //holds y-intercept (alpha)

        //Standard error variables
        double SSE = 0.0;
        double SSR = 0.0;
        double SST = 0.0;
        double Ybar = 0.0;
        double yhat = 0.0;
        double res = 0.0;
        double R2 = 0.0;
        double standardError = 0; //
        int n = 0;
        //End standard variable declaration
        Dictionary<string, double> result = new Dictionary<string, double>(); //Stores the final result
        //End variable declaration

        #region Computation begins

        num = X.Count;  //Since the X and Y list are of same length, so 
        // we can take the count of any one list 
        sumX = X.Sum();  //Get Sum of X list
        sumY = Y.Sum(); //Get Sum of Y list
        Ybar = sumY / num;
        X.ForEach(i => { sum2X += i * i; }); //Get sum of x[i]*x[i]           
        Y.ForEach(i => { sum2Y += i * i; }); //Get sum of y[i]*y[i]            
        sumXY = Enumerable.Range(0, num).Select(i => X[i] * Y[i]).Sum();//Get Summation of x[i] * y[i]

        //Find denx, deny,top
        denX = num * sum2X - sumX * sumX;
        denY = num * sum2Y - sumY * sumY;
        top = num * sumXY - sumX * sumY;

        //Find corelation, slope and y-intercept
        corelation = top / Math.Sqrt(denX * denY);
        slope = top / denX;
        y_intercept = (sumY - sumX * slope) / num;


        //Implementation of Standard Error
        SSE = Enumerable.Range(0, num).Aggregate(0.0, (sum, i) =>
        {
            yhat = y_intercept + (slope * X[i]);
            res = yhat - Y[i];
            n++;
            return sum + res * res;
        });

        if (n > 2)
        {
            standardError = SSE / (1.0 * n - 2.0);
            standardError = Math.Pow(standardError, 0.5);
        }
        else standardError = 0;

        //Implementation of R squared
        SSR = Enumerable.Range(0, num).Aggregate(0.0, (sum, i) =>
        {
            yhat = y_intercept + (slope * X[i]);
            res = yhat - Ybar;
            return sum + res * res;
        });

        SST = Enumerable.Range(0, num).Aggregate(0.0, (sum, i) =>
        {
            res = Y[i] - Ybar;
            return sum + res * res;
        });

        R2 = SSR / SST;

        #endregion

        //Add the computed value to the resultant dictionary
        result.Add("Gradient", slope);
        result.Add("Intercept", y_intercept);
        result.Add("R Squared", R2);
        result.Add("Corelation", corelation);
        result.Add("StandardError", standardError);
        return result;
    }



}
