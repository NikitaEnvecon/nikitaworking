@echo off
setlocal
set FILE=%1 %2 %3 %4 %5 %6 %7 %8 %9
set FILE="%FILE%"

REM DEPLOYTARGET is set by main build script or IFS VisualStudio Addin Manager
set TARGET=%DEPLOYTARGET%

for %%I in (%FILE%) do set EXT=%%~xI
for %%I in (%FILE%) do set FILENAME=%%~nI

IF /I "%EXT%" == "" goto copyFOLDER

:copyDLL
echo Copy %FILENAME%%EXT% to %TARGET%
copy %FILE% "%TARGET%\"
rem xcopy %FILE% "%TARGET%" /D > nul
goto end

:copyFOLDER
echo Copy folder %1 to %TARGET%\%FILENAME%
xcopy %1 "%TARGET%\%FILENAME%" /E /C /I /Q /R /Y > nul
goto end

:end
endlocal