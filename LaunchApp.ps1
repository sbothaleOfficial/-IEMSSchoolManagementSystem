# Launch IEMS School Management System
$appPath = Join-Path $PSScriptRoot "publish\IEMS.WPF.exe"

if (Test-Path $appPath) {
    Write-Host "Starting IEMS School Management System..." -ForegroundColor Green
    Start-Process -FilePath $appPath
} else {
    Write-Host "Application not found. Building and publishing..." -ForegroundColor Yellow
    dotnet publish .\IEMS.WPF\IEMS.WPF.csproj -c Release -r win-x64 --self-contained false -o .\publish

    if (Test-Path $appPath) {
        Write-Host "Starting IEMS School Management System..." -ForegroundColor Green
        Start-Process -FilePath $appPath
    } else {
        Write-Host "Failed to build application" -ForegroundColor Red
    }
}