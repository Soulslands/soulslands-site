#!/usr/bin/env bash
# Builds the static Soulslands site into dist/ (W-21): renders every public page of
# src/Soulslands.Web in memory (src/Soulslands.StaticExport), with _redirects, _headers and the
# wiki search index for Cloudflare Pages. Fails, naming the file, on a staff page in WikiContent/,
# a same-origin link without a file in dist/, a staff name or a server-only part in dist/.
#
# Runs where .NET is missing (Cloudflare Pages' build image): it then installs the SDK pinned in
# global.json with the vendored scripts/dotnet-install.sh (Microsoft, MIT) into $DOTNET_INSTALL_DIR
# (default ~/.dotnet). Needs bash, curl and ICU (libicu: the pages format Italian dates).
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

dotnet run --project "$root/src/Soulslands.StaticExport" -c Release -- \
    --out "$out" --wiki "$root/src/Soulslands.Web/WikiContent"

echo "build-static: dist pronta in $out ($(( $(date +%s) - started )) s)"
