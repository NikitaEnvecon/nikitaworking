::
::
:: This batch files executes the IFS Data Migration Excel Add-In (32-bit) Setup
::
::

@ECHO OFF

ECHO.
ECHO Searching for IFS Data Migration Excel Add-In (32-bit) Setup...

IF NOT EXIST ..\install\setup.exe GOTO :no_installer

GOTO install

:no_installer

ECHO.
ECHO There is no setup file (setup.exe) in ..\install!
ECHO Make sure that your build is successfull
ECHO and that the Setup program and MSI file(s) resides in the
ECHO correct directory.
ECHO.

PAUSE

GOTO end

:install

ECHO.
ECHO setup.exe found. Installing...
ECHO.

..\install\setup.exe

ECHO.
ECHO Done.
ECHO.

:end
