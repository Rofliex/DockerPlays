@echo off
cmd /c docker container run -it --rm ^
-e LOG_FOLDER=/app/logs ^
-v %USERPROFILE%\.aspnet\Logs:/app/logs rofliex/dotnet_logreader:latest
pause