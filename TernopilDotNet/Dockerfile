FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY TernopilDotNet/TernopilDotNet.csproj TernopilDotNet/
RUN dotnet restore TernopilDotNet/TernopilDotNet.csproj
COPY . .
WORKDIR /src/TernopilDotNet
RUN dotnet build TernopilDotNet.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TernopilDotNet.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TernopilDotNet.dll"]
