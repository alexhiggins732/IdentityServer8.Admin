param([string] $packagesVersions)

$templateNuspecPath = "template-publish/IdentityServer8.Admin.Templates.nuspec"
nuget pack $templateNuspecPath -NoDefaultExcludes

dotnet.exe new --uninstall IdentityServer8.Admin.Templates

$templateLocalName = "IdentityServer8.Admin.Templates.$packagesVersions.nupkg"
dotnet.exe new -i $templateLocalName

dotnet.exe new skoruba.is4admin --name MyProject --title MyProject --adminemail 'admin@skoruba.com' --adminpassword 'Pa$$word123' --adminrole MyRole --adminclientid MyClientId --adminclientsecret MyClientSecret --dockersupport true