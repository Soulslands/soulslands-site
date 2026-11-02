# Benchmark fixtures

The three result files are copied unchanged from SoulslandsGame `docs/benchmark/examples/` at commit
`2e678adde3d9ff731a44a23e3ca78f5a24e1407c` (ADR-0002, format v1). They are illustrative, not measurements:
each says so in `notes`. `m2/raw/wander-build--aruto-linux-pc.ticks.csv.gz` is a tiny invented raw file
for the download route.

`m2/chunk-generation--aruto-linux-pc.json` is not an ADR example: it is the m0 chunk-generation example
with milestone `m2`, another commit and date, other numbers (the `gen.columns_per_s_per_core` threshold is
missed) and no raw files, so the history view (W-15) has one series measured in two milestones.

Never copy these files into `src/Soulslands.Web/WikiContent/benchmark/`: real results are published
there by wiki-writer. `scripts/check-benchmark-publish.sh` copies one only for the duration of a
`dotnet publish` and removes it afterwards.
