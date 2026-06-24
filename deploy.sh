#!/bin/bash
set -euo pipefail

echo "=== Cleaning up old postgres volumes ==="
# Remove volumes belonging to this project's compose stacks
docker volume ls -q | while read vol; do
  if docker volume inspect "$vol" --format '{{.Labels}}' 2>/dev/null | grep -q "aspire"; then
    # Check if it's postgres-related
    container=$(docker ps -a --filter "volume=$vol" --format "{{.Names}}" 2>/dev/null | head -1)
    if [[ "$container" == *postgres* ]] || docker volume inspect "$vol" --format '{{.Labels}}' 2>/dev/null | grep -qi "postgres"; then
      docker volume rm -f "$vol" 2>/dev/null && echo "  Removed volume: $vol" || true
    fi
  fi
done
# Also remove unnamed postgres volumes (anonymous volumes)
docker volume ls -q --filter "dangling=true" 2>/dev/null | while read vol; do
  if docker volume inspect "$vol" --format '{{.Mountpoint}}' 2>/dev/null | grep -q "postgres"; then
    docker volume rm -f "$vol" 2>/dev/null && echo "  Removed anonymous postgres volume: $vol" || true
  fi
done

echo "=== Deploying ==="
aspire deploy --output-path aspire-output --non-interactive "$@"
