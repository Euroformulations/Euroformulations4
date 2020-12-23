#define AppVer GetFileVersion('C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe')
;#define AppVer ReadIni("C:\EUROCOLORI\Euroformulations4\setup\setupSettings.ini", "InstallSettings", "version", "unknown")
#define MyAppExeNameLIC "EuroActivator.exe"
#define MyAppExeName "Euroformulations4.exe"
#define MyAppName "EuroFormulations 4"
 
[Files]

Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Spreadsheet.dll"; DestDir: "{app}"; Flags: ignoreversion noregerror regtypelib
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Spreadsheet.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Document.dll"; DestDir: "{app}"; Flags: ignoreversion noregerror regtypelib
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\GemBox.Document.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\ef.log"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Euroformulations4.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Ionic.Zip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\QRCoder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Mono.Security.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\mylogo.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Npgsql.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\TeamViewerQS_it-idcnc6t3cc.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\Select.exe"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\i1Pro.exe"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\i1Pro.dll"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4SQC.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4ColorantsPaints.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4PackagingSize.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4Statistics.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\A4ViewCustomer.docx"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\config.ef4"; DestDir: "{app}\include"; Flags: ignoreversion onlyifdoesntexist; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\language.ini"; DestDir: "{app}\include"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\regioni.sql"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\dcscdrv.dll"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\spettrocolore.png"; DestDir: "{app}\include"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EuroActivator.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EuroActivator.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\a4_full_formula.docx"; DestDir: "{app}\template"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\label_8.9_4.1.docx"; DestDir: "{app}\template"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\a4_full_formula_no_price.docx"; DestDir: "{app}\template"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\a4_full_formula_no_logo.docx"; DestDir: "{app}\template"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\customer.docx"; DestDir: "{app}\template"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Bookmarks_guide_eng.pdf"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\template\ManualTemplate\a4_full_formula_ounce.docx"; DestDir: "{app}\template\ManualTemplate"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\apidsp_windows.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\apidsp_windows_x64.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_net_windows.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_rt.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_windows_102849.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\hasp_windows_x64_102849.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\include\driver\formula_test.ef4"; DestDir: "{app}\driver\"; Flags: ignoreversion; Permissions: everyone-full
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Printer.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Printer.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\sqlcube.zip"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\Post_Installer.bat"; DestDir: "{app}"; Flags: ignoreversion
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
Name: "{app}\include\driver"; Permissions: everyone-full
Name: "{app}\template\ManualTemplate"; Permissions: everyone-full

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
OutputBaseFilename=setup
VersionInfoProductVersion={#AppVer}
VersionInfoProductTextVersion={#AppVer}
SetupIconFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\install.ico
AppName=EuroFormulations 4
AppCopyright=Copyright (C) Eurocolori s.r.l.
AppId={{5701A3D5-40D7-4602-986D-468397A317C6}
LicenseFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\EULA.txt
VersionInfoCompany=Eurocolori s.r.l.
VersionInfoDescription=Tinting System Management
VersionInfoProductName=EuroFormulations 4
MinVersion=0,5.01sp3
InternalCompressLevel=ultra
DefaultDirName={pf}\EuroFormulations4.0
DefaultGroupName=EuroFormulations4
DisableWelcomePage = no
OutputDir=C:\EUROCOLORI\Euroformulations4\Release
LanguageDetectionMethod=none
ShowUndisplayableLanguages=true
ShowLanguageDialog = true
AppPublisher=Eurocolori s.r.l.
UninstallDisplayName=Unistall EuroFormulations4
VersionInfoTextVersion=Tinting System Management
VersionInfoCopyright=Eurocolori s.r.l.
Compression=lzma/ultra
WizardImageFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\ef4v.bmp
WizardSmallImageFile=C:\EUROCOLORI\Euroformulations4\Euroformulations4\bin\Release\WizModernSmallImage-IS.bmp
ChangesAssociations=True
AppPublisherURL=www.eurocolori.com
AppSupportURL=www.euroformulations.com
AppUpdatesURL=www.euroformulations.com
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

[Run]
Filename: {app}\Post_Installer.bat; Flags:waituntilterminated runhidden;
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent
