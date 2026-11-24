#!/usr/bin/env bash
# Builds the static Soulslands site into dist/ (W-21): renders every public page of
# src/Soulslands.Web in memory (src/Soulslands.StaticExport), with _redirects, _headers and the
# wiki search index for Cloudflare (Workers static assets, wrangler.jsonc). Fails, naming the file, on a staff page in WikiContent/,
# a same-origin link without a file in dist/, a staff name or a server-only part in dist/.
#
# Runs where .NET is missing (Cloudflare's build image): it then installs the SDK pinned in
# global.json with the vendored scripts/dotnet-install.sh (Microsoft, MIT) into $DOTNET_INSTALL_DIR
# (default ~/.dotnet). Needs bash and curl. ICU: the exporter carries its own on Linux x64
# (app-local ICU, Soulslands.StaticExport.csproj); without a system libicu the SDK itself runs in
# invariant mode, and the export stops with "ICU non disponibile" if Italian culture data are missing.
#
# Environment: SITE_BASE_URL (default https://soulslands.mahoroba.studio), STATIC_OUT (default
# dist/ in the repository), Studio__AccountUrl / Studio__StudioUrl (default the studio's hosts).
set -euo pipefail

root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"
started=$(date +%s)

export DOTNET_CLI_TELEMETRY_OPTOUT=1 DOTNET_NOLOGO=1 DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export SITE_BASE_URL="${SITE_BASE_URL:-https://soulslands.mahoroba.studio}"
out="${STATIC_OUT:-$root/dist}"

# The SDK and MSBuild abort at start without a system libicu; they need no culture data, so they then
# run in invariant mode. The exporter's runtimeconfig sets Invariant=false and loads its own ICU.
if ! { ldconfig -p 2>/dev/null | grep 'libicuuc\.so' >/dev/null; } \
    && ! compgen -G '/usr/lib/*/libicuuc.so.*' >/dev/null && ! compgen -G '/usr/lib*/libicuuc.so.*' >/dev/null; then
    echo "build-static: libicu non trovata nel sistema: SDK in modalità invariant, l'export usa l'ICU del progetto"
    export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
fi

# A dotnet that has the SDK global.json asks for (dotnet --version fails otherwise).
if ! command -v dotnet >/dev/null 2>&1 || ! dotnet --version >/dev/null 2>&1; then
    install_dir="${DOTNET_INSTALL_DIR:-$HOME/.dotnet}"
    if ! "$install_dir/dotnet" --version >/dev/null 2>&1; then
        echo "build-static: installo il .NET SDK di global.json in $install_dir"
        bash "$root/scripts/dotnet-install.sh" --jsonfile "$root/global.json" --install-dir "$install_dir" --no-path
    fi
    export DOTNET_ROOT="$install_dir"
    export PATH="$install_dir:$PATH"
fi
echo "build-static: .NET SDK $(dotnet --version), sito $SITE_BASE_URL"

dotnet build "$root/src/Soulslands.StaticExport" -c Release --nologo -v quiet
# The exporter runs without the SDK, and without the invariant switch the SDK may have needed: the
# environment variable would override its runtimeconfig and hide its own ICU.
env -u DOTNET_SYSTEM_GLOBALIZATION_INVARIANT \
    dotnet "$root/src/Soulslands.StaticExport/bin/Release/net10.0/Soulslands.StaticExport.dll" \
    --out "$out" --wiki "$root/src/Soulslands.Web/WikiContent"

echo "build-static: dist pronta in $out ($(( $(date +%s) - started )) s)"
