@ECHO OFF
IF "%~1"=="" GOTO ParamError
GOTO Continue
:ParamError
ECHO Target version folder has be be provided as a parameter
GOTO End
:Continue
cd %~1

for /f "tokens=*" %%I in ('dir /b /a:-D /S') do if %%~xI==.deploy rename "%%~dI%%~pI%%~nI.deploy" "%%~nI" >NUL

echo '.deploy' extension removed from the files

SET /P key=Certificate key file: 
SET /P pwd=Password:
IF "%key%"=="" GOTO KeyError
IF "%pwd%"=="" GOTO NoPwd
GOTO WithPwd
:KeyError
ECHO Enter Key File.
GOTO End
:NoPwd
mage -update Ifs.Application.Fndmig.ExcelAddin.dll.manifest -CertFile %key%
mage -update ..\..\Ifs.Application.Fndmig.ExcelAddin.vsto -appmanifest Ifs.Application.Fndmig.ExcelAddin.dll.manifest -CertFile %key%
GOTO Next
:WithPwd
mage -update Ifs.Application.Fndmig.ExcelAddin.dll.manifest -CertFile %key% -Password %pwd%
mage -update ..\..\Ifs.Application.Fndmig.ExcelAddin.vsto -appmanifest Ifs.Application.Fndmig.ExcelAddin.dll.manifest -CertFile %key% -Password %pwd%
:Next

for /f "tokens=*" %%I in ('dir /b /a:-D /S') do if not %%~xI==.cmd if not %%~xI==.deploy if not %%~xI==.vsto if not %%~xI==.manifest rename "%%~dI%%~pI%%~nI%%~xI" "%%~nI%%~xI.deploy" >NUL

echo '.deploy' extension added to the files


copy /y ..\..\Ifs.Application.Fndmig.ExcelAddin.vsto

:End
set "key="
set "pwd="

cd ..
pause
