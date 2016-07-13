#!/bin/sh

SCRIPTDIR="$(dirname "$0")"

#Call the other script
cd "$SCRIPTDIR"
"./bin/release/netcoreapp1.0/osx.10.11-x64/publish/Tweets10"