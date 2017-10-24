@ECHO OFF
IF "%~1"=="" GOTO ParamError
GOTO Continue
:ParamError
ECHO Target version folder has be be provided as a parameter
GOTO End
:Continue

cd %~1

del Ifs.Application.Fndmig.ExcelAddin.vsto

for /f "tokens=*" %%I in ('dir /b /a:-D /S') do if %%~xI==.deploy rename "%%~dI%%~pI%%~nI.deploy" "%%~nI" >NUL

echo '.deploy' extension removed from the files

cd ..

mage -u %~1\Ifs.Application.Fndmig.ExcelAddin.dll.manifest -FromDirectory %~1

echo Application manifest recreated
:End
pause