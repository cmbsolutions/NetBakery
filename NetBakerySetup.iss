#define MyAppName "NetBakery"
;#define MyAppVersion "2.0.738"
#define MyAppPublisher "CMBSolutions"
#define MyAppExeName "NetBakery.exe"
#define MyAppInstallerName "netbakerysetup.latest"
#define MyAppTarget "Release"
#define MyAppVersion RemoveFileExt(GetVersionNumbersString(MyAppName + '\bin\x64\' + MyAppTarget + '\' + MyAppExeName))

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{CABC0425-D58C-4630-89BA-D6FC5A037546}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppCopyright=CMBSolutions 2017-2022
VersionInfoVersion={#MyAppVersion}
DefaultDirName={autopf64}\{#MyAppPublisher}\{#MyAppName}
DisableDirPage=no
DefaultGroupName={#MyAppPublisher}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=Installer
; OutputBaseFilename={#MyAppName}Setup{#MyAppVersion}
OutputBaseFilename={#MyAppInstallerName}
SetupIconFile={#MyAppName}\netbakery.png.ico
Compression=lzma
SolidCompression=yes
UninstallDisplayName={#MyAppName} {#MyAppVersion}
UninstallDisplayIcon={app}\netbakery.png.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#MyAppName}\bin\x64\{#MyAppTarget}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppName}\bin\x64\{#MyAppTarget}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Flags: nowait postinstall; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"

[ThirdParty]
UseRelativePaths=True