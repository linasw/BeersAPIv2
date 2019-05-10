FROM microsoft/dotnet:sdk AS builder
WORKDIR /app
COPY ./ ./

# Restore solution packages
RUN dotnet restore BeersApi.sln

# Build project
RUN dotnet publish BeersApi/BeersApi.csproj -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=builder /app/BeersApi/out .

ENTRYPOINT ["dotnet", "BeersApi.dll"]