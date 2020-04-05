###   Collector   ###
[decimal]$version = 1.05
# MIT License
#
# Matthew D. Jordan, (C) 2020
# www.scenic-shop.com
#
# This script will collect multiple text files within a single directory and insert them into a single file.  This is most often used with Inventor iLogic routines, or Autocad Lisp routines.
#
# To use, include tags into the source code files that you want to collect.
#	'</Collector> : include this tag in the first line of each file you want to collect.
#	'</CollectorHeader> : Include this tag in the first line of header and main files.  This will ensure the file is placed at the top of the collected file.
#	'<CollectorPrepend>' or ;, whatever you want to insert at the front of the line.</CollectorPrepend> : include this line after any line of code to comment out that line at collection time.  Use this for module wrappers that help VS, but need to be removed for iLogic to work properly. The text between the tags will be used to prepend the current line.
#
# When ready to compile, run this powershell script to combine the files into a single file.  If running from the command line, you may need to issue the command:
#	powershell -ExecutionPolicy ByPass -File .\Collector.ps1
#
# The current directory name is used as the file name with an .iLogicVB extension.  This will overwrite a file with that name if it can access it.

	#Get directory name, compile file name
	$extension = ".iLogicVb"
	$directoryName = pwd | Select-Object | %{$_.ProviderPath.Split("\")[-1]}
	$outputFile = ((pwd).path + "\" + $directoryName + $extension)


#Test if compileFile is writable! Exit if not!
If (test-path -path $outputFile)
	{
	Try { [io.file]::OpenWrite($compileFile).close() 
	}
	Catch
		{ 
		Write-Warning "Unable to write to output file."
		exit
		}
	}

#get the files in the current directory (recursive)
$fileList = Get-ChildItem -Path $pwd -File -Recurse -Name

#test if the file is in the current directory, remove if not
If (test-path $compileFile) {
	Remove-Item -path $compileFile
}

#Create our temporary holding array, add the header...
[System.Collections.ArrayList]$dataArrayPrecollection = (("'This file has been auto-generated by Collector version " + $version), ("'Collection timestamp: " + (get-date -Uformat "%Y/%m/%d - %R")), "'2020 Matthew D. Jordan - https://github.com/jordanrobot","")


$fileList | ForEach-Object -process{

	If (test-path $_) {
	
		If ((Get-Content $_ -TotalCount 1) | Select-String -Pattern "<\/CollectorHeader>" -quiet) {
			#Write filename
			$dataArrayPrecollection += ("'" + $_.Path)
			#Write contents
			$dataArrayPrecollection += (Get-Content $_)
			#Write new line
			$dataArrayPrecollection += ""
		}
	}
}

$fileList | Sort-Object -Descending FullName | ForEach-Object -process{

	If (test-path $_) {
	
		If ((Get-Content $_ -TotalCount 1) | Select-String -Pattern "<\/Collector>" -quiet) {
			$dataArrayPrecollection += (Get-Content $_)
			$dataArrayPrecollection +=  ""
		}
	}
}

#Create the list to hold processed data
$dataArray = $list = New-Object Collections.Generic.List[String]

#Go through the list and process each line...
$dataArrayPrecollection | Foreach-object -Process {

	If ($_ -match "<CollectorPrepend>(.*)<\/CollectorPrepend>") {
		#Hide tag found, connect out line...
		($dataArray.Add($Matches.1 + $_))
		
	} Elseif ($_ -match "<\/Collector>") {
		#IlogicCollector tag found, skip this line
	}
	Else {
		#normal line, add to the file
		($dataArray.Add($_))
	}
}

#populate the collected file...
try
{
    $stream = [System.IO.StreamWriter]::new( $outputFile )
    $dataArray | ForEach-Object{ $stream.WriteLine( $_ ) }
}
finally
{
    $stream.close()
}