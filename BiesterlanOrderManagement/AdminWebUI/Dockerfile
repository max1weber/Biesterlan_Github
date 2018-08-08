FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 58665
EXPOSE 44312

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY AdminWebUI/AdminWebUI.csproj AdminWebUI/
COPY Models/Models.csproj Models/
COPY Data/Data.csproj Data/
COPY Services/Services.csproj Services/
RUN dotnet restore AdminWebUI/AdminWebUI.csproj
COPY . .
WORKDIR /src/AdminWebUI
RUN dotnet build AdminWebUI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AdminWebUI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AdminWebUI.dll"]
