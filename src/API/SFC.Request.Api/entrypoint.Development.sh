#!/bin/sh

./src/API/SFC.Request.Api/entrypoint.Common.sh
dotnet run --project /app/src/API/SFC.Request.Api/SFC.Request.Api.csproj --no-launch-profile