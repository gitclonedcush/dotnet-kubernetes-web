FROM microsoft/dotnet:2.1-sdk-alpine AS builder
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/out KubernetesApp.csproj

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "KubernetesApp.dll"]