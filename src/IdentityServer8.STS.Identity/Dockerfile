FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServer8.STS.Identity/IdentityServer8.STS.Identity.csproj", "src/IdentityServer8.STS.Identity/"]
COPY ["src/IdentityServer8.Shared.Configuration/IdentityServer8.Shared.Configuration.csproj", "src/IdentityServer8.Shared.Configuration/"]
COPY ["src/IdentityServer8.Admin.EntityFramework.Shared/IdentityServer8.Admin.EntityFramework.Shared.csproj", "src/IdentityServer8.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServer8.Admin.EntityFramework.Identity/IdentityServer8.Admin.EntityFramework.Identity.csproj", "src/IdentityServer8.Admin.EntityFramework.Identity/"]
COPY ["src/IdentityServer8.Admin.EntityFramework/IdentityServer8.Admin.EntityFramework.csproj", "src/IdentityServer8.Admin.EntityFramework/"]
COPY ["src/IdentityServer8.Admin.EntityFramework.Extensions/IdentityServer8.Admin.EntityFramework.Extensions.csproj", "src/IdentityServer8.Admin.EntityFramework.Extensions/"]
COPY ["src/IdentityServer8.Admin.EntityFramework.Configuration/IdentityServer8.Admin.EntityFramework.Configuration.csproj", "src/IdentityServer8.Admin.EntityFramework.Configuration/"]
COPY ["src/IdentityServer8.Shared/IdentityServer8.Shared.csproj", "src/IdentityServer8.Shared/"]
COPY ["src/IdentityServer8.Admin.BusinessLogic.Identity/IdentityServer8.Admin.BusinessLogic.Identity.csproj", "src/IdentityServer8.Admin.BusinessLogic.Identity/"]
COPY ["src/IdentityServer8.Admin.BusinessLogic.Shared/IdentityServer8.Admin.BusinessLogic.Shared.csproj", "src/IdentityServer8.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/IdentityServer8.STS.Identity/IdentityServer8.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer8.STS.Identity"
RUN dotnet build "IdentityServer8.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer8.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServer8.STS.Identity.dll"]