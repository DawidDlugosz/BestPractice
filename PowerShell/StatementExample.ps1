<# full help #>
help dir -Full

<# to discover command #>
Get-Command *service*

<# information about drive #>
Get-PSDrive -PSProvider 'FileSystem'

<# information aobut environment params #>
Get-ChildItem env:
Get-ChildItem c:\ | more

<# return content of file #>
Get-Content .\file.txt

<# information about available method and property #>
Get-Service | Get-Member

Get-Module -ListAvailable