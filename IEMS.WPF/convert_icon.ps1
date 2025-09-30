# Enhanced script to create high-quality ICO file from PNG
Add-Type -AssemblyName System.Drawing
Add-Type -AssemblyName System.Drawing.Imaging

$sourcePath = "C:\Users\SP\Development\IEMSSchoolManagementSystem\IEMS.WPF\New_round_logo_new_color.png"
$icoPath = "C:\Users\SP\Development\IEMSSchoolManagementSystem\IEMS.WPF\school.ico"

Write-Host "Creating high-quality icon from better source image..."

# Load the source image
$sourceImage = [System.Drawing.Image]::FromFile($sourcePath)
Write-Host "Source image loaded"

# Create multiple sizes for better quality
$sizes = @(256, 128, 64, 48, 32, 16)

foreach ($size in $sizes) {
    Write-Host "Processing ${size}x${size} size..."

    $bitmap = New-Object System.Drawing.Bitmap($size, $size)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)

    # Set highest quality rendering
    $graphics.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
    $graphics.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
    $graphics.PixelOffsetMode = [System.Drawing.Drawing2D.PixelOffsetMode]::HighQuality
    $graphics.CompositingQuality = [System.Drawing.Drawing2D.CompositingQuality]::HighQuality

    # Draw the image
    $graphics.DrawImage($sourceImage, 0, 0, $size, $size)

    # Save the largest size as ICO
    if ($size -eq 256) {
        $icon = [System.Drawing.Icon]::FromHandle($bitmap.GetHicon())
        $fs = [System.IO.File]::Create($icoPath)
        $icon.Save($fs)
        $fs.Close()
    }

    $graphics.Dispose()
    $bitmap.Dispose()
}

$sourceImage.Dispose()
Write-Host "High-quality icon created successfully at: $icoPath"