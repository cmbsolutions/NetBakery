param($PathToProjectRoot)

#used to make it easier to spot the comments from the script in the Build Output window
$msgPrefix="   |   "

#useful when testing the script - simply point this to the root of a folder that contains a project
#and the script can be run via PowerShell or ISE without having to constantly build via VS
$defaultProjectRoot="./My Project"

write-output "$msgPrefix Beginning incrementBuildVersion.ps1"

function AssignVersionValue([string]$oldValue, [string]$newValue) {
    if ($newValue -eq $null -or $newValue -eq "") {
        $oldValue
    } else {
        #placeholder for other functionality, like incrementing, dates, etc..
        if ($newValue -eq "increment") {
            $newNum = 1
            try {
                $newNum = [System.Convert]::ToInt64($oldValue) + 1
            } catch {
                #do nothing
            }
            $newNum.ToString()
        } else {
            $newValue
        }
    }
}


function SetAssemblyFileVersion([string]$pathToFile, [string]$majorVer, [string]$minorVer, [string]$buildVer) {

    #load the file and process the lines
    $newFile = Get-Content $pathToFile -encoding "UTF8" | foreach-object {
        if ($_.StartsWith("<Assembly: AssemblyVersion") -or $_.StartsWith("<Assembly: AssemblyFileVersion") ) {
            $verStart = $_.IndexOf("(") + 1
            $verEnd = $_.IndexOf(")", $verStart) - 1
            $origVersion = $_.SubString($verStart+1, $verEnd-$verStart-1)
            
            $segments=$origVersion.Split(".")
            
            #default values for each segment
            $v1="1"
            $v2="0"
            $v3="0"
            
            #assign them based on what was found
            if ($segments.Length -gt 0) { $v1=$segments[0] }
            if ($segments.Length -gt 1) { $v2=$segments[1] } 
            if ($segments.Length -gt 2) { $v3=$segments[2] } 
            
            $v1 = AssignVersionValue $v1 $majorVer
            $v2 = AssignVersionValue $v2 $minorVer
            $v3 = AssignVersionValue $v3 $buildVer
            
            if ($v1 -eq $null) { throw "Major version CANNOT be blank!" }
            if ($v2 -eq $null) { throw "Minor version CANNOT be blank!" }
            
            $newVersion = "$v1.$v2"
            
            if ($v3 -ne $null) {
                $newVersion = "$newVersion.$v3"
            }

            write-host "$msgPrefix Setting BuildVersion to $newVersion"
            $_.Replace($origVersion, $newVersion)
        }  else {
            $_
        } 
    }
    
    $newfile | set-Content $assemblyInfoPath -encoding "UTF8"
}


if ($PathToProjectRoot -eq "" -or $PathToProjectRoot -eq $null) { $PathToProjectRoot=$defaultProjectRoot }
$PathToProjectRoot = $PathToProjectRoot.Trim("\")

#if you use another .net language, you will need to change this to support that.
$assemblyInfoPath = "$PathToProjectRoot\AssemblyInfo.vb"

# the values here can be whatever your heart desires
$major=$null # $null indicates that whatever value is currently in the file should be used as-is
$minor=$null 
$build="increment" # special token to increment whatever value it finds in that field

SetAssemblyFileVersion $assemblyInfoPath $major $minor $build

write-output "$msgPrefix Ending incrementBuildVersion.ps1"