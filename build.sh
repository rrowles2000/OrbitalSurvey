#!/usr/bin/env bash
# Rebuilds OrbitalSurvey.dll against the installed KSP2 Redux runtime (csc-only, no Unity editor).
# Compiles against the unmodified game assemblies (the mod reaches private members via reflection).
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"
KSP2="${KSP2:-$HOME/.steam/steam/steamapps/common/Kerbal Space Program 2}"
MANAGED="$KSP2/KSP2_x64_Data/Managed"
CSC="${CSC:-$(find -L "$HOME/.steam/steam/steamapps/common" -path '*wine/mono*Roslyn/csc.exe' 2>/dev/null | sort | tail -1 || true)}"
[ -f "$CSC" ] || { echo "csc.exe not found; set CSC=" >&2; exit 1; }
STAGE=obj/refs
rm -rf obj && mkdir -p "$STAGE"
cp "$MANAGED"/*.dll "$STAGE/"
{
  echo "-target:library -nostdlib+ -unsafe -langversion:9.0 -optimize+ -nologo"
  echo "-nowarn:0618,0612,0672,0169,0649,0414,0108,0114,0162,0168,0219"
  echo "-out:obj/OrbitalSurvey.dll"
  for dll in "$STAGE"/*.dll; do echo "-r:\"$dll\""; done
  find Assets/OrbitalSurvey/Code Generated -name '*.cs' | sort | sed 's/.*/"&"/'
} > obj/csc.rsp
mono "$CSC" @obj/csc.rsp
echo "Built obj/OrbitalSurvey.dll"
