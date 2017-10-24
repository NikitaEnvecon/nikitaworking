@echo off
setlocal
set FILE=%1 %2 %3 %4 %5 %6 %7 %8 %9
set FILE="%FILE%"

REM DEPLOYTARGET is set by main build script or IFS VisualStudio Addin Manager
set TARGET=%DEPLOYTARGET%\plugins

if not exist %TARGET% mkdir %TARGET%

echo Copy plugin %FILE% to %TARGET%
copy %FILE% "%TARGET%\" > nul
rem xcopy %FILE% "%TARGET%" /D > nul

goto end

:end
endlocal