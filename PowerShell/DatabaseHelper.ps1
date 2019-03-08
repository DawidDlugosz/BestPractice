function ExecuteSqlScriptsFromPackage
{
    Param(
        [string]$scriptPath,
        [string]$sqlServerName,
        [string]$mainDatabaseName,
        [string]$secondDatabaseName,
        [string]$sqlScriptsOutputFileLocation
    )

    if(-not (Test-Path $scriptPath))
    {
        Write-Host "----------------------------------------------"
        Write-Host "------------ STEP NOT EXECUTED ---------------"
        Write-Host "Location with scripts not exist: '$($scriptPath)'"
    }
    else
    {
        $scriptsFilter = "*.sql"
        foreach($f in Get-ChildItem -path $scriptPath -Filter $scriptsFilter | sort-object)
        {
            $databaseName = GetDatabaseName "$($f.fullname)" $mainDatabaseName $secondDatabaseName
            ExecuteSqlScript $sqlServerName $databaseName "$($f.fullname)" $sqlScriptsOutputFileLocation
        }
    }
}

function GetDatabaseName 
{
    param (
        [string]$sqlScriptFileName,
        [string]$firstDatabaseName,
        [string]$secondDatabaseName
    )

    $databaseName = "---"
    $isDatabaseInFileName = $sqlScriptFileName -match "\.+(?<DatabaseName>[a-zA-Z_]+)\.sql"
    if($isDatabaseInFileName)
    {
        if($matches["DatabaseName"] -eq "MyMainDatabaseName") { $databaseName = $firstDatabaseName }
        else { $databaseName = $secondDatabaseName }
    }
    else { $databaseName = $firstDatabaseName }
    return $databaseName
}

function ExecuteSqlScript
{
    param(
        [string]$sqlServerName,
        [string]$databaseName,
        [string]$scriptLocation,
        [string]$outPutFileLocation
    )

    $sqlScriptFileName = Split-Path -Leaf $scriptLocation
    Write-Host "$($sqlScriptFileName) on $($databaseName) - $($sqlServerName)"
    Invoke-Sqlcmd -QueryTimeout 600 -inputfile $scriptLocation -serverinstance $sqlServerName -database $databaseName -Verbose -AbortOnError -ErrorAction:Stop | Out-File -FilePath "$($outPutFileLocation)\$($sqlScriptFileName).out" -Append
    Write-Host "Executed OK - $(Get-Date)"
    Write-Host ""
}