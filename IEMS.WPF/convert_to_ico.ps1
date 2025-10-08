Add-Type -AssemblyName System.Drawing

$pngPath = "C:\Users\SP\Development\IEMSSchoolManagementSystem\IEMS.WPF\Exact_color_logo.png"
$icoPath = "C:\Users\SP\Development\IEMSSchoolManagementSystem\IEMS.WPF\exact_color.ico"

# Load the PNG image
$png = [System.Drawing.Image]::FromFile($pngPath)

# Create a bitmap with icon size
$bitmap = New-Object System.Drawing.Bitmap($png, 256, 256)

# Get icon handle
$iconHandle = $bitmap.GetHicon()
$icon = [System.Drawing.Icon]::FromHandle($iconHandle)

# Save to file
$fileStream = New-Object System.IO.FileStream($icoPath, [System.IO.FileMode]::Create)
$icon.Save($fileStream)
$fileStream.Close()

# Clean up
$png.Dispose()
$bitmap.Dispose()

Write-Host "Icon created successfully at: $icoPath"
