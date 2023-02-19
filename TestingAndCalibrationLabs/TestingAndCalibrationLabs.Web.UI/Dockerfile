#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestingAndCalibrationLabs.Web.UI/TestingAndCalibrationLabs.Web.UI.csproj", "TestingAndCalibrationLabs.Web.UI/"]
COPY ["TestingAndCalibrationLabs.Business/TestingAndCalibrationLabs.Business.csproj", "TestingAndCalibrationLabs.Business/"]
RUN dotnet restore "TestingAndCalibrationLabs.Web.UI/TestingAndCalibrationLabs.Web.UI.csproj"
COPY . .
WORKDIR "/src/TestingAndCalibrationLabs.Web.UI"
RUN dotnet build "TestingAndCalibrationLabs.Web.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestingAndCalibrationLabs.Web.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestingAndCalibrationLabs.Web.UI.dll"]