nuget install Grpc.Tools -Verbosity Quiet

if ($LASTEXITCODE -ne 0)
{
	throw "Nuget is not on the PATH."
}

Push-Location grpc*\tools

Get-ChildItem ..\..\..\protos | Select FullName | ForEach-Object {

    $protoFullPath = $_.FullName

    $directoryName = [System.IO.Path]::GetDirectoryName($_.FullName)

    Invoke-Expression "windows_x86\protoc.exe '$protoFullPath' --proto_path '$directoryName' --csharp_out ../../../GeneratedCode --grpc_out ../../../GeneratedCode --plugin=protoc-gen-grpc=windows_x86/grpc_csharp_plugin.exe"
}

Pop-Location

Remove-Item Grpc.Tools* -Recurse -Force 