#!/usr/bin/env bash
# Proves that published benchmark results reach the Docker image (SoulslandsGame ADR-0002):
# copies a test fixture result file and a raw file into
# src/Soulslands.Web/WikiContent/benchmark/<fixture milestone>/ only for the duration of a
# `dotnet publish`, checks that the publish output holds both at WikiContent/benchmark/...
# (the path the site reads: ContentRootPath/WikiContent), and removes the copy again, even on
# failure. Fixtures are illustrative, never real results: nothing is left in WikiContent/.
#
# Usage: scripts/check-benchmark-publish.sh   (from anywhere; needs the .NET 10 SDK)
set -euo pipefail

root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
fixtures="$root/tests/Soulslands.Web.Tests/Fixtures/Benchmark"
bench="$root/src/Soulslands.Web/WikiContent/benchmark"
milestone="m99" # no real milestone uses it
target="$bench/$milestone"
result="wander-build--aruto-linux-pc.json"
raw="raw/wander-build--aruto-linux-pc.ticks.csv.gz"

if [[ -e "$target" ]]; then
  echo "error: $target already exists; not touching it" >&2
  exit 2
fi

created_bench=0
[[ -d "$bench" ]] || created_bench=1
out="$(mktemp -d)"

cleanup() {
  rm -rf "$target" "$out"
  if [[ $created_bench == 1 ]]; then
    rmdir "$bench" 2>/dev/null || true
  fi
}
trap cleanup EXIT
trap 'exit 130' INT TERM

mkdir -p "$target/raw"
cp "$fixtures/m2/$result" "$target/$result"
cp "$fixtures/m2/$raw" "$target/$raw"
echo "copied fixture to ${target#"$root"/}"

dotnet publish "$root/src/Soulslands.Web/Soulslands.Web.csproj" -c Release -o "$out" --nologo -v quiet

status=0
for file in "$result" "$raw"; do
  published="$out/WikiContent/benchmark/$milestone/$file"
  if cmp -s "$fixtures/m2/$file" "$published"; then
    echo "ok: publish output has WikiContent/benchmark/$milestone/$file"
  else
    echo "MISSING: publish output lacks WikiContent/benchmark/$milestone/$file" >&2
    status=1
  fi
done

cleanup
trap - EXIT
leftover="$(git -C "$root" status --porcelain -- src/Soulslands.Web/WikiContent)"
if [[ -n "$leftover" ]]; then
  echo "error: WikiContent is not clean after the check:" >&2
  echo "$leftover" >&2
  status=1
else
  echo "ok: git status --porcelain src/Soulslands.Web/WikiContent is empty"
fi
exit $status
