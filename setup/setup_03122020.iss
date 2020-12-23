#define AppVer GetFileVersion('C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe')
#define MyAppExeNameLIC "EuroActivator.exe"
#define MyAppExeName "Euroformulations4.exe"
#define MyAppName "EuroFormulations 4"
 

[Files]
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Spreadsheet.dll"; DestDir: "{app}"; Flags: ignoreversion noregerror regtypelib
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Spreadsheet.xml"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Document.dll"; DestDir: "{app}"; Flags: ignoreversion noregerror regtypelib
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Document.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\ef.log"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Ionic.Zip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\QRCoder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Mono.Security.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\mylogo.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\DotNetFramework4.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Npgsql.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\postgresql-9.5.1-1-mod.zip"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\TeamViewerQS_it-idcnc6t3cc.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\vcredist_x86.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Post_Installer.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\Select.exe"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\i1Pro.exe"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\i1Pro.dll"; DestDir: "{app}\include"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4SQC.docx"; DestDir: "{app}\include"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4ColorantsPaints.docx"; DestDir: "{app}\include"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4PackagingSize.docx"; DestDir: "{app}\include"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4Statistics.docx"; DestDir: "{app}\include"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4ViewCustomer.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\config.ef4"; DestDir: "{app}\include"; Flags: ignoreversion onlyifdoesntexist; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\language.ini"; DestDir: "{app}\include"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\regioni.sql"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\dcscdrv.dll"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\spettrocolore.png"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EuroActivator.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EuroActivator.exe.config"; DestDir: "{app}"; Flags: ignoreversion
;Source: "..\Euroformulations4\bin\Release\template\a4_full_formula.docx"; DestDir: "{app}\template"; Flags: onlyifdoesntexist
;Source: "..\Euroformulations4\bin\Release\template\label_8.9_4.1.docx"; DestDir: "{app}\template"; Flags: onlyifdoesntexist
;Source: "..\Euroformulations4\bin\Release\template\a4_full_formula_no_price.docx"; DestDir: "{app}\template"; Flags: onlyifdoesntexist
;Source: "..\Euroformulations4\bin\Release\template\a4_full_formula_no_logo.docx"; DestDir: "{app}\template"; Flags: onlyifdoesntexist
;Source: "..\Euroformulations4\bin\Release\template\customer.docx"; DestDir: "{app}\template"; Flags: onlyifdoesntexist
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Bookmarks_guide_eng.pdf"; DestDir: "{app}"; Flags: ignoreversion
;Source: "..\Euroformulations4\bin\Release\template\ManualTemplate\a4_full_formula_ounce.docx"; DestDir: "{app}\template\ManualTemplate"; Flags: onlyifdoesntexist
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\apidsp_windows.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\apidsp_windows_x64.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_net_windows.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_rt.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_windows_102849.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_windows_x64_102849.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\formula_test.ef4"; DestDir: "{app}\driver\"; Flags: ignoreversion; Permissions: everyone-full
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Printer.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Printer.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\sqlcube.zip"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\S22.Imap.dll"; DestDir: "{app}"; Flags: ignoreversion

;CUBE DRIVER
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftbusui.dll"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftcserco.dll"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftd2xx.lib"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftd2xx64.dll"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftdibus.sys"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftlang.dll"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftser2k.sys"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\amd64\ftserui2.dll"; DestDir: "{app}\include\driver\cube\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftbusui.dll"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftcserco.dll"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftd2xx.lib"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftd2xx.dll"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftdibus.sys"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftlang.dll"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftser2k.sys"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\i386\ftserui2.dll"; DestDir: "{app}\include\driver\cube\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\ftdibus.cat"; DestDir: "{app}\include\driver\cube"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\ftdibus.inf"; DestDir: "{app}\include\driver\cube"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\ftdiport.cat"; DestDir: "{app}\include\driver\cube"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\cube\ftdiport.inf"; DestDir: "{app}\include\driver\cube"; Flags: ignoreversion

;IONEPRO DRIVER
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\ionepro\i1.sys"; DestDir: "{app}\include\driver\ionepro"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\ionepro\i1_driver.cat"; DestDir: "{app}\include\driver\ionepro"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\ionepro\i1_pro.inf"; DestDir: "{app}\include\driver\ionepro"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\ionepro\i1_x64.sys"; DestDir: "{app}\include\driver\ionepro"; Flags: ignoreversion

;SPYDER/SELECT DRIVER
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\amd64\dcscusb.sys"; DestDir: "{app}\include\driver\spyder\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\amd64\WdfCoInstaller01007.dll"; DestDir: "{app}\include\driver\spyder\amd64"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\i386\dcscusb.sys"; DestDir: "{app}\include\driver\spyder\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\i386\WdfCoInstaller01007.dll"; DestDir: "{app}\include\driver\spyder\i386"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\dcscusb.cat"; DestDir: "{app}\include\driver\spyder"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\spyder\dcscusb.inf"; DestDir: "{app}\include\driver\spyder"; Flags: ignoreversion

;DRIVER INSTALLER
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\DriverInstaller.exe"; DestDir: "{app}\include\driver"; Flags: ignoreversion

[Dirs]
Name: "{app}"; Permissions: everyone-full
Name: "{app}\cluster"; Permissions: everyone-full
Name: "{app}\template"; Permissions: everyone-full
Name: "{app}\update"; Permissions: everyone-full
Name: "{app}\template\ManualTemplate"; Permissions: everyone-full
Name: "{app}\include\driver"; Permissions: everyone-full

;DRIVER DIRS
Name: "{app}\include\driver\cube"; Permissions: everyone-full
Name: "{app}\include\driver\cube\amd64"; Permissions: everyone-full
Name: "{app}\include\driver\cube\i386"; Permissions: everyone-full
Name: "{app}\include\driver\ionepro"; Permissions: everyone-full
Name: "{app}\include\driver\spyder"; Permissions: everyone-full
Name: "{app}\include\driver\spyder\amd64"; Permissions: everyone-full
Name: "{app}\include\driver\spyder\i386"; Permissions: everyone-full

[Setup]
AppVersion={#AppVer}
VersionInfoVersion={#AppVer}
OutputBaseFilename=EuroFormulations {#AppVer}
VersionInfoProductVersion= {#AppVer}
VersionInfoProductTextVersion={#AppVer}
SetupIconFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\install.ico
AppName=EuroFormulations 4
AppCopyright=Opensource
AppId={{5701A3D5-40D7-4602-986D-468397A317C6}
LicenseFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EULA.txt
VersionInfoCompany=Opensource
VersionInfoDescription=Tinting System Management
VersionInfoProductName=Opensource
MinVersion=0,5.01sp3
InternalCompressLevel=ultra
DefaultDirName={pf}\EuroFormulations4.0
DefaultGroupName=EuroFormulations4
DisableWelcomePage = no
OutputDir=C:\EUROCOLORI\Euroformulations4\Release
LanguageDetectionMethod=none
ShowUndisplayableLanguages=true
ShowLanguageDialog = true
AppPublisher=Opensource
UninstallDisplayName=Unistall EuroFormulations4
VersionInfoTextVersion=Tinting System Management
VersionInfoCopyright=Opensource
Compression=lzma/ultra
WizardImageFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\ef4v.bmp
WizardSmallImageFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\WizModernSmallImage-IS.bmp
ChangesAssociations=True
AppPublisherURL=Opensource
AppSupportURL=Opensource
AppUpdatesURL=Opensource
PrivilegesRequired=poweruser
DisableDirPage = no

[Icons]
Name: "{userdesktop}\EuroFormulations 4"; Filename: "{app}\Euroformulations4.exe"; IconFilename: "{app}\Euroformulations4.exe"; IconIndex: 0
Name: "{group}\EuroFormulations4"; Filename: "{app}\Euroformulations4.exe"; IconFilename: "{app}\Euroformulations4.exe"; IconIndex: 0

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

[INI]
Filename: {app}\include\language.ini; Section: DEFAULT; Key: linguapredefinita; String: {language}; Tasks: ; Languages: 

[Registry]
Root: HKLM; Subkey: "Software\Classes\.eflic"; ValueType: String; ValueData: "EuroFormulations4"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\DefaultIcon"; ValueType: String; ValueData: "{app}\{#MyAppExeNameLIC},0"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\Shell\Open"; ValueName: Icon; ValueType: String; ValueData: "{app}\{#MyAppExeNameLIC}"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Classes\.eflic\Shell\Open\Command"; ValueType: String; ValueData: """{app}\{#MyAppExeNameLIC}"" ""%1"""; Flags: uninsdeletekey

[code]
function FrameworkIsNotInstalled: Boolean;
begin
    Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'Software\Microsoft\.NETFramework\policy\v4.0');
end;
#IFDEF UNICODE
  #DEFINE AW "W"
#ELSE
  #DEFINE AW "A"
#ENDIF
type
  INSTALLSTATE = Longint;
const
  INSTALLSTATE_INVALIDARG = -2;  // An invalid parameter was passed to the function.
  INSTALLSTATE_UNKNOWN = -1;     // The product is neither advertised or installed.
  INSTALLSTATE_ADVERTISED = 1;   // The product is advertised but not installed.
  INSTALLSTATE_ABSENT = 2;       // The product is installed for a different user.
  INSTALLSTATE_DEFAULT = 5;      // The product is installed for the current user.

  VC_2005_REDIST_X86 = '{A49F249F-0C91-497F-86DF-B2585E8E76B7}';
  VC_2005_REDIST_X64 = '{6E8E85E8-CE4B-4FF5-91F7-04999C9FAE6A}';
  VC_2005_REDIST_IA64 = '{03ED71EA-F531-4927-AABD-1C31BCE8E187}';
  VC_2005_SP1_REDIST_X86 = '{7299052B-02A4-4627-81F2-1818DA5D550D}';
  VC_2005_SP1_REDIST_X64 = '{071C9B48-7C32-4621-A0AC-3F809523288F}';
  VC_2005_SP1_REDIST_IA64 = '{0F8FB34E-675E-42ED-850B-29D98C2ECE08}';
  VC_2005_SP1_ATL_SEC_UPD_REDIST_X86 = '{837B34E3-7C30-493C-8F6A-2B0F04E2912C}';
  VC_2005_SP1_ATL_SEC_UPD_REDIST_X64 = '{6CE5BAE9-D3CA-4B99-891A-1DC6C118A5FC}';
  VC_2005_SP1_ATL_SEC_UPD_REDIST_IA64 = '{85025851-A784-46D8-950D-05CB3CA43A13}';

  VC_2008_REDIST_X86 = '{FF66E9F6-83E7-3A3E-AF14-8DE9A809A6A4}';
  VC_2008_REDIST_X64 = '{350AA351-21FA-3270-8B7A-835434E766AD}';
  VC_2008_REDIST_IA64 = '{2B547B43-DB50-3139-9EBE-37D419E0F5FA}';
  VC_2008_SP1_REDIST_X86 = '{9A25302D-30C0-39D9-BD6F-21E6EC160475}';
  VC_2008_SP1_REDIST_X64 = '{8220EEFE-38CD-377E-8595-13398D740ACE}';
  VC_2008_SP1_REDIST_IA64 = '{5827ECE1-AEB0-328E-B813-6FC68622C1F9}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_X86 = '{1F1C2DFC-2D24-3E06-BCB8-725134ADF989}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_X64 = '{4B6C7001-C7D6-3710-913E-5BC23FCE91E6}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_IA64 = '{977AD349-C2A8-39DD-9273-285C08987C7B}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_X86 = '{9BE518E6-ECC6-35A9-88E4-87755C07200F}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_X64 = '{5FCE6D76-F5DC-37AB-B2B8-22AB8CEDB1D4}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_IA64 = '{515643D1-4E9E-342F-A75A-D1F16448DC04}';

  VC_2010_REDIST_X86 = '{196BB40D-1578-3D01-B289-BEFC77A11A1E}';
  VC_2010_REDIST_X64 = '{DA5E371C-6333-3D8A-93A4-6FD5B20BCC6E}';
  VC_2010_REDIST_IA64 = '{C1A35166-4301-38E9-BA67-02823AD72A1B}';
  VC_2010_SP1_REDIST_X86 = '{F0C3E5D1-1ADE-321E-8167-68EF0DE699A5}';
  VC_2010_SP1_REDIST_X64 = '{1D8E6291-B0D5-35EC-8441-6616F567A0F7}';
  VC_2010_SP1_REDIST_IA64 = '{88C73C1C-2DE5-3B01-AFB8-B46EF4AB41CD}';

  // Microsoft Visual C++ 2012 x86 Minimum Runtime - 11.0.61030.0 (Update 4) 
  VC_2012_REDIST_MIN_UPD4_X86 = '{BD95A8CD-1D9F-35AD-981A-3E7925026EBB}';
  VC_2012_REDIST_MIN_UPD4_X64 = '{CF2BEA3C-26EA-32F8-AA9B-331F7E34BA97}';
  // Microsoft Visual C++ 2012 x86 Additional Runtime - 11.0.61030.0 (Update 4) 
  VC_2012_REDIST_ADD_UPD4_X86 = '{B175520C-86A2-35A7-8619-86DC379688B9}';
  VC_2012_REDIST_ADD_UPD4_X64 = '{37B8F9C7-03FB-3253-8781-2517C99D7C00}';

  // Visual C++ 2013 Redistributable 12.0.21005
  VC_2013_REDIST_X86_MIN = '{13A4EE12-23EA-3371-91EE-EFB36DDFFF3E}';
  VC_2013_REDIST_X64_MIN = '{A749D8E6-B613-3BE3-8F5F-045C84EBA29B}';

  VC_2013_REDIST_X86_ADD = '{F8CFEB22-A2E7-3971-9EDA-4B11EDEFC185}';
  VC_2013_REDIST_X64_ADD = '{929FBD26-9020-399B-9A7A-751D61F0B942}';

  // Visual C++ 2015 Redistributable 14.0.23026
  VC_2015_REDIST_X86_MIN = '{A2563E55-3BEC-3828-8D67-E5E8B9E8B675}';
  VC_2015_REDIST_X64_MIN = '{0D3E9E15-DE7A-300B-96F1-B4AF12B96488}';

  VC_2015_REDIST_X86_ADD = '{BE960C1C-7BAD-3DE6-8B1A-2616FE532845}';
  VC_2015_REDIST_X64_ADD = '{BC958BD2-5DAC-3862-BB1A-C1BE0790438D}';

function MsiQueryProductState(szProduct: string): INSTALLSTATE; 
  external 'MsiQueryProductState{#AW}@msi.dll stdcall';

function VCVersionInstalled(const ProductID: string): Boolean;
begin
  Result := MsiQueryProductState(ProductID) = INSTALLSTATE_DEFAULT;
end;

function VCRedistNeedsInstall: Boolean;
begin
  Result := not (VCVersionInstalled(VC_2010_REDIST_X86) and 
    VCVersionInstalled(VC_2010_SP1_REDIST_X86));
end;

[Run]
Filename: "{app}\DotNetFramework4.exe"; Parameters: "/noreboot /passive"; Description: "Install Microsoft .NET Framework 4.0"; Check: FrameworkIsNotInstalled
Filename: "{app}\vcredist_x86.exe"; Parameters: "/passive"; Check: VCRedistNeedsInstall
Filename: {app}\Post_Installer.bat; Flags:waituntilterminated runhidden;
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent