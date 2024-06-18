FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/EmployeeManagementSystem.Web.Host/EmployeeManagementSystem.Web.Host.csproj", "src/EmployeeManagementSystem.Web.Host/"]
COPY ["src/EmployeeManagementSystem.Web.Core/EmployeeManagementSystem.Web.Core.csproj", "src/EmployeeManagementSystem.Web.Core/"]
COPY ["src/EmployeeManagementSystem.Application/EmployeeManagementSystem.Application.csproj", "src/EmployeeManagementSystem.Application/"]
COPY ["src/EmployeeManagementSystem.Core/EmployeeManagementSystem.Core.csproj", "src/EmployeeManagementSystem.Core/"]
COPY ["src/EmployeeManagementSystem.EntityFrameworkCore/EmployeeManagementSystem.EntityFrameworkCore.csproj", "src/EmployeeManagementSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/EmployeeManagementSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EmployeeManagementSystem.Web.Host", "src/EmployeeManagementSystem.Web.Host"]
COPY ["src/EmployeeManagementSystem.Web.Core", "src/EmployeeManagementSystem.Web.Core"]
COPY ["src/EmployeeManagementSystem.Application", "src/EmployeeManagementSystem.Application"]
COPY ["src/EmployeeManagementSystem.Core", "src/EmployeeManagementSystem.Core"]
COPY ["src/EmployeeManagementSystem.EntityFrameworkCore", "src/EmployeeManagementSystem.EntityFrameworkCore"]
WORKDIR "/src/src/EmployeeManagementSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EmployeeManagementSystem.Web.Host.dll"]
