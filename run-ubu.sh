#!/bin/sh

SCRIPTDIR="$(dirname "$0")"

#Call the other script
cd "$SCRIPTDIR"
"./bin/release/netcoreapp1.0/ubuntu.14.04-x64/publish/Tweets10"