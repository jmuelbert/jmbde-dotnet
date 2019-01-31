#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:80"

until dotnet ef database update; do
	echo >&2 "SQL Server is starting up"
	sleep 1
done

echo >&2 "SQL Server is up - executing command"
exec $run_cmd
