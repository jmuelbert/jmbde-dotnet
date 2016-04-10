cd $PSScriptRoot

$repoFolder = $PSScriptRoot
$env:REPO_FOLDER = $repoFolder

$jmbdeBuildZip="https://github.com/jmuelbert/jmbde-aspnet/archive/dev.zip"
if ($env:JMBDEBUILD_ZIP)
{
    $koreBuildZip=$env:JMBDEBUILD_ZIP
}

$buildFolder = ".build"
$buildFile="$buildFolder\JMBDEBuild.ps1"

if (!(Test-Path $buildFolder)) {
    Write-Host "Downloading JMBDEBuild from $jmbdeBuildZip"    
    
    $tempFolder=$env:TEMP + "\JMBDEBuild-" + [guid]::NewGuid()
    New-Item -Path "$tempFolder" -Type directory | Out-Null

    $localZipFile="$tempFolder\jmbdebuild.zip"
    
    Invoke-WebRequest $jmbdeBuildZip -OutFile $localZipFile
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    [System.IO.Compression.ZipFile]::ExtractToDirectory($localZipFile, $tempFolder)
    
    New-Item -Path "$buildFolder" -Type directory | Out-Null
    copy-item "$tempFolder\**\build\*" $buildFolder -Recurse

    # Cleanup
    if (Test-Path $tempFolder) {
        Remove-Item -Recurse -Force $tempFolder
    }
}

&"$buildFile" $args