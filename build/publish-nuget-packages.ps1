param([string] $version, [string] $key)

dotnet nuget push ./packages/IdentityServer8.Admin.BusinessLogic.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Admin.BusinessLogic.Identity.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Admin.BusinessLogic.Shared.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/IdentityServer8.Admin.EntityFramework.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Admin.EntityFramework.Extensions.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Admin.EntityFramework.Identity.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Admin.EntityFramework.Shared.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/IdentityServer8.Admin.EntityFramework.Configuration.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json
dotnet nuget push ./packages/IdentityServer8.Shared.Configuration.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json

dotnet nuget push ./packages/IdentityServer8.Admin.UI.$version.nupkg -k $key -s https://api.nuget.org/v3/index.json