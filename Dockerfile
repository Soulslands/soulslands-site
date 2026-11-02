# Build. The SDK runs on the build machine's own architecture and
# cross-compiles for the target one, so building the arm64 image (Raspberry
# Pi) on an x64 PC or in CI needs no emulation.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY src/Soulslands.Web/Soulslands.Web.csproj src/Soulslands.Web/
RUN dotnet restore src/Soulslands.Web/Soulslands.Web.csproj -a $TARGETARCH
COPY src/ src/
RUN dotnet publish src/Soulslands.Web/Soulslands.Web.csproj -c Release -a $TARGETARCH --self-contained false -o /app --no-restore

# Run
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
# The aspnet image already listens on 8080.
ENV Database__Provider=Postgres
EXPOSE 8080
USER app
HEALTHCHECK --interval=30s --timeout=5s --retries=3 CMD ["dotnet", "Soulslands.Web.dll", "--healthcheck"]
ENTRYPOINT ["dotnet", "Soulslands.Web.dll"]
