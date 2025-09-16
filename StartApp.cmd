@echo off
title IEMS School Management System
echo ==========================================
echo   IEMS School Management System
echo ==========================================
echo.

cd /d "%~dp0"

if exist "publish_new\IEMS.WPF.exe" (
    echo Starting application...
    start "" "publish_new\IEMS.WPF.exe"
    echo.
    echo Application started! Check for the window.
    timeout /t 3
) else (
    echo Publishing application first...
    call dotnet publish IEMS.WPF\IEMS.WPF.csproj -c Release -r win-x64 --self-contained false -o publish_new
    echo.
    echo Starting application...
    start "" "publish_new\IEMS.WPF.exe"
    echo.
    echo Application started! Check for the window.
    timeout /t 3
)