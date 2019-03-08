function CreateNewLocation
{
    Param([string]$mainPath, [string]$newFolderLocation, [bool]$deleteIfExist=$true)

    try
    {
        $ErrorActionPreference = "Stop"

        if(-not (Test-Path $mainPath))
        {
            Write-Host "ERROR: Location '$($mainPath)' not exist"
            EXIT 1
        }

        $fullPath = "$($mainPath)\$($newFolderLocation)"

        if($deleteIfExist -and (Test-Path $fullPath))
        {
            Remove-Item $fullPath -Recurse
        }

        Write-Host "Creating location '$fullPath'"
        mkdir $fullPath -Force > $null
    }
    catch
    {
        Write-Host "ERROR: Unexpected error"
        Write-Host $_
        Write-Host $_.Exception.GeType().FullName

        Exit 1
    }
}

function UserAndMachineInfo
{
    try
    {
        Add-Type -assembly "System.DirectoryServices.AccountManagement"
        Write-Host "---------- User & Machine ------------------------"
        Write-Host "user name:          $([System.DirectoryServices.AccountManagement.UserPrincipal]::Current.Name)"
        Write-Host "user domain:        $($env:UserDomain)"
        Write-Host "computer name:      $($env:ComputerName)"
        
        Exit 1
    }    
    catch
    {
        Write-Host "ERROR: Unexpected error"
        Write-Host $_
        Write-Host $_.Exception.GeType().FullName

        Exit 1
    }
}


function CompressPackage 
{
    param ([string]$packageLocationToCompress, [string]$compressedPackageLocation)

    try
    {
        Write-Host ""
        Write-Host "---- ZIP: Compressing package -------"
        Write-Host "-------------------------------------"
        Write-Host "---- Source:        $($packageLocationToCompress)"
        Write-Host "---- Compressed:    $($compressedPackageLocation)"
        Write-Host ""

        Add-Type -Assembly "System.IO.Compression.FileSystem"

        if((Test-Path $compressedPackageLocation))
        {
            Remove-Item $compressedPackageLocation
        }
        [System.IO.Compression.ZipFile]::CreateFromDirectory($packageLocationToCompress, $compressedPackageLocation)

        Write-Host ""
        Write-Host "---- ZIP: COMPLETED -----------------"
        Write-Host "-------------------------------------"
    }
    catch
    {
        Write-Host "ERROR: Unexpected error"
        Write-Host $_
        Write-Host $_.Exception.GeType().FullName

        Exit 1
    }    
}

function GetVersionInfo
{
    param([string]$appLocation, [string]$libraryName)

    $version = Get-ChildItem -Path $appLocation -Recurse -Force | Where-Object { $_.Name -eq $libraryName } | Select-Object -ExpandProperty VersionInfo
    return $($version.ProductVersion)
}

CompressPackage "E:\\tmp\Test" "E:\\tmp\test.zip"
