$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\IdentityServer8.Admin.BusinessLogic\IdentityServer8.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.BusinessLogic.Identity\IdentityServer8.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.BusinessLogic.Shared\IdentityServer8.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Shared.Configuration\IdentityServer8.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\IdentityServer8.Admin.EntityFramework\IdentityServer8.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.EntityFramework.Extensions\IdentityServer8.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.EntityFramework.Identity\IdentityServer8.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.EntityFramework.Shared\IdentityServer8.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\IdentityServer8.Admin.EntityFramework.Configuration\IdentityServer8.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\IdentityServer8.Admin.UI\IdentityServer8.Admin.UI.csproj -c Release -o $packagesOutput