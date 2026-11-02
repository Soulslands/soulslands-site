#!/bin/sh
# Nightly PostgreSQL dump, run by the "backup" service in docker-compose.yml.
set -eu
keep="${BACKUP_KEEP:-14}"
while true; do
    now=$(date -u +%s)
    next=$(date -u -d "$(date -u +%Y-%m-%d) 03:30" +%s)
    [ "$next" -le "$now" ] && next=$((next + 86400))
    sleep $((next - now))

    file="/backups/soulslands-$(date -u +%Y%m%d-%H%M).sql.gz"
    if pg_dump --no-owner | gzip > "$file.tmp"; then
        mv "$file.tmp" "$file"
        echo "backup written: $file"
    else
        rm -f "$file.tmp"
        echo "backup FAILED" >&2
    fi
    ls -1t /backups/soulslands-*.sql.gz 2>/dev/null | tail -n +$((keep + 1)) | xargs -r rm -f
done
