#include ReadReg(HKEY_LOCAL_MACHINE,'Software\Sherlock Software\InnoTools\Downloader','ScriptPath','');
#define AppVer '1.0.0.0'
#define MyAppExeName "Euroformulations4.exe"
#define MyAppExeNameLIC "EuroActivator.exe"
#define MyAppName "EuroFormulations 4"
 

[Setup]
AppName=EuroFormulations 4
AppVerName=EuroFormulations 4
DefaultDirName={pf}\EuroFormulations4.0
DefaultGroupName=EuroFormulations4
DisableWelcomePage = no
OutputDir=C:\EUROCOLORI\Euroformulations4\Release
OutputBaseFilename=installer
SetupIconFile=C:\EUROCOLORI\Euroformulations4\res\ef4_icon.ico
VersionInfoVersion={#AppVer}
VersionInfoProductVersion= {#AppVer}
VersionInfoProductTextVersion={#AppVer}
AppCopyright=Copyright (C) Eurocolori s.r.l.
AppId={{5701A3D5-40D7-4602-986D-468397A317C6}
LicenseFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EULA.txt
VersionInfoCompany=Eurocolori s.r.l.
VersionInfoDescription=Tinting System Management
VersionInfoProductName=EuroFormulations 4
MinVersion=0,5.01sp3
InternalCompressLevel=ultra
LanguageDetectionMethod=none
ShowUndisplayableLanguages=true
ShowLanguageDialog = true
AppPublisher=Eurocolori s.r.l.
UninstallDisplayName=Unistall EuroFormulations4
VersionInfoTextVersion=Tinting System Management
VersionInfoCopyright=Eurocolori s.r.l.
Compression=lzma/ultra
WizardImageFile=C:\EUROCOLORI\Euroformulations4\res\ef4v2.bmp
WizardSmallImageFile=C:\EUROCOLORI\Euroformulations4\res\ef4_icon.bmp
ChangesAssociations=True
AppPublisherURL=www.eurocolori.com
AppSupportURL=www.euroformulations.com
AppUpdatesURL=www.euroformulations.com
PrivilegesRequired=poweruser

#include <idp.iss>
WizardImageStretch=False

[Icons]
Name: "{userdesktop}\EuroFormulations 4"; Filename: "{app}\Euroformulations4.exe"; IconFilename: "{app}\Euroformulations4.exe"; IconIndex: 0
Name: "{group}\EuroFormulations4"; Filename: "{app}\Euroformulations4.exe"; IconFilename: "{app}\Euroformulations4.exe"; IconIndex: 0

[UninstallDelete]
Type: files; Name: "{app}\setup.exe"

[Files]
Source: "C:\EUROCOLORI\Euroformulations4\setup\utils\innoextract.exe"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\setup\utils\initializer.bat"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\setup\utils\unzip.exe"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\setup\utils\unzip32.dll"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\setup\utils\auto_config.ef4"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full

[Dirs]
Name: "{app}"; Permissions: everyone-full

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "it"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "cn"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
Name: "cz"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "ru"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "pl"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "es"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "sr"; MessagesFile: "compiler:Languages\SerbianLatin.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"
 

[Registry]
Root: HKLM; Subkey: "Software\Classes\.eflic"; ValueType: String; ValueData: "EuroFormulations4"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\DefaultIcon"; ValueType: String; ValueData: "{app}\{#MyAppExeNameLIC},0"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\Shell\Open"; ValueName: Icon; ValueType: String; ValueData: "{app}\{#MyAppExeNameLIC}"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\Shell\Open\Command"; ValueType: String; ValueData: """{app}\{#MyAppExeNameLIC}"" ""%1"""; Flags: uninsdeletekey

[Code]
 var
        inputpage: TInputQueryWizardPage;
        passkey: String;
        response:string;
        responsedb:string;
        ResultCode: Integer;


procedure InitializeWizard();
begin
    inputpage:=CreateInputQueryPage(wpWelcome, 'Installation Password', '','Enter your password for automatic EuroFormulations4 download:');
    inputpage.add('', false);    
end;

function NextButtonClick(CurPageID: Integer): Boolean; 
var
  WinHttpReq: Variant;
begin
      result:=true;
      if CurPageID=inputpage.id then begin
             
             passkey := inputpage.values[0];

             WinHttpReq := CreateOleObject('WinHttp.WinHttpRequest.5.1');
             WinHttpReq.Open('POST', 'https://www.euroformulations.com/_remoteHTTPFunctions/auto_exe_db_link.php', False);
             WinHttpReq.Send('0;' + passkey);
             if WinHttpReq.Status <> 200 then
             begin
               result := false
               MsgBox('HTTP Error: ' + IntToStr(WinHttpReq.Status) + ' ' + WinHttpReq.StatusText, mbError, MB_OK);
             end
             else begin
               response := WinHttpReq.ResponseText
               WinHttpReq := CreateOleObject('WinHttp.WinHttpRequest.5.1');
               WinHttpReq.Open('POST', 'https://www.euroformulations.com/_remoteHTTPFunctions/auto_exe_db_link.php', False);
               WinHttpReq.Send('1;' + passkey);
               if WinHttpReq.Status <> 200 then
               begin
                 result := false
                 MsgBox('HTTP Error: ' + IntToStr(WinHttpReq.Status) + ' ' + WinHttpReq.StatusText, mbError, MB_OK);
               end
               else begin
                 responsedb := WinHttpReq.ResponseText

                 if((response = '-1') or (responsedb = '-1')) then begin
                    MsgBox('Password is not valid. Retry', mbError, MB_OK);
                    result := false;
                 end else begin
                    result := true;
                    idpAddFile(response, ExpandConstant('{tmp}\ef4_autosetup.exe'));
                    idpAddFile(responsedb, ExpandConstant('{tmp}\ef4_autodb.zip'));
                    idpAddFile('https://www.euroformulations.com/_remoteHTTPFunctions/auto_cluster.zip', ExpandConstant('{tmp}\ef4_cluster.zip'));
                    idpDownloadAfter(wpReady);
                  end;
               end;
             end;

      end  else if CurPageID=5 then begin

      end    
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
     
    if CurStep = ssInstall then 
    begin
        if(CreateDir(ExpandConstant('{app}'))) then begin
          FileCopy(ExpandConstant('{tmp}\ef4_autosetup.exe'), ExpandConstant('{app}\auto_setup.exe'), false);
          FileCopy(ExpandConstant('{tmp}\ef4_autodb.zip'), ExpandConstant('{app}\auto_db.zip'), false);
          FileCopy(ExpandConstant('{tmp}\ef4_cluster.zip'), ExpandConstant('{app}\auto_cluster.zip'), false);
          SaveStringToFile(ExpandConstant('{app}') + '\auto_password.txt', passkey, True);
        end else begin
           if(ExpandConstant('{language}') = 'it') then begin
               MsgBox('Errore durante la creazione di cartelle. Riprovare', mbError, MB_OK);
           end else if(ExpandConstant('{language}') = 'ru') then begin
               MsgBox('Ошибка создания папок. Попробуйте еще раз.', mbError, MB_OK);
           end else begin
               MsgBox('Error during folder creation. Retry', mbError, MB_OK);
           end
        end 
    end  else if CurStep = ssPostInstall then begin
       SetIniString('DEFAULT', 'linguapredefinita', ExpandConstant('{language}'), ExpandConstant('{app}') + '\include\language.ini');
    end
end;

function FrameworkIsNotInstalled: Boolean;
begin
    Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'Software\Microsoft\.NETFramework\policy\v4.0');
end;

type
  INSTALLSTATE = Longint;
  
const
 VC_2013_REDIST_X86_MIN = '{13A4EE12-23EA-3371-91EE-EFB36DDFFF3E}';
  VC_2013_REDIST_X64_MIN = '{A749D8E6-B613-3BE3-8F5F-045C84EBA29B}';

  VC_2013_REDIST_X86_ADD = '{F8CFEB22-A2E7-3971-9EDA-4B11EDEFC185}';
  VC_2013_REDIST_X64_ADD = '{929FBD26-9020-399B-9A7A-751D61F0B942}';
     INSTALLSTATE_DEFAULT = 5;
  #IFDEF UNICODE
  #DEFINE AW "W"
#ELSE
  #DEFINE AW "A"
#ENDIF

function MsiQueryProductState(szProduct: string): INSTALLSTATE; 
  external 'MsiQueryProductState{#AW}@msi.dll stdcall';

function VCVersionInstalled(const ProductID: string): Boolean;
begin
  Result := MsiQueryProductState(ProductID) = INSTALLSTATE_DEFAULT;
end;

function VCRedistNeedsInstall: Boolean;
begin
  Result := not (VCVersionInstalled(VC_2013_REDIST_X86_MIN) and 
    VCVersionInstalled(VC_2013_REDIST_X86_ADD));
end;    

[Run]
Filename: "{app}\innoextract.exe"; Parameters: "auto_setup.exe -q -s --collisions overwrite"; Flags: waituntilterminated runhidden;
Filename: {app}\initializer.bat; Flags: waituntilterminated runhidden;
Filename: "{app}\DotNetFramework4.exe"; Parameters: "/noreboot /passive"; Description: "Install Microsoft .NET Framework 4.0"; Check: FrameworkIsNotInstalled;  Flags: waituntilterminated
Filename: "{app}\vcredist_x86.exe"; Parameters: "/passive"; Check: VCRedistNeedsInstall; Flags: waituntilterminated
Filename: {app}\Post_Installer.bat; Flags:waituntilterminated runhidden;
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent
