# Create first layers of runtime image
# use base image
# (approx 350mb)
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

# Create build image to build .netcore application
# (approx 2GB)
FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY TernopilDotNet/TernopilDotNet.csproj TernopilDotNet/
# restore nuget and tools dependencies
RUN dotnet restore TernopilDotNet/TernopilDotNet.csproj
COPY . .
WORKDIR /src/TernopilDotNet
# build .netcore application
RUN dotnet build TernopilDotNet.csproj -c Release -o /app

FROM build AS publish
# create output folder with .dlls, project dependencies
# and nuget dependencies ready for deployment to a hosting system 
RUN dotnet publish TernopilDotNet.csproj -c Release -o /app

# Finish creation of runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TernopilDotNet.dll"]
