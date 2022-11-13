@echo off
cmd /c docker build -f Dockerfile.baseBuildImage -t rofliex/dotnet_base_build:latest .
cmd /c docker build -f Dockerfile.baseRuntimeImage -t rofliex/dotnet_base_runtime:latest .
cmd /c docker build -f Dockerfile.WebApi -t rofliex/dotnet_webapi:latest .
cmd /c docker build -f Dockerfile.LogReader -t rofliex/dotnet_logreader:latest .
pause
