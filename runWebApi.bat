@echo off
cmd /c docker container run -it --rm ^
-p 8088:8088 -p 4343:4343 ^
-e ASPNETCORE_URLS="https://0.0.0.0:4343;http://0.0.0.0:8088" ^
-e ASPNETCORE_Kestrel__Certificates__Default__Password="123" ^
-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx ^
-e ASPNETCORE_ENVIRONMENT=Development ^
-e LOG_FOLDER=/app/logs ^
-v %USERPROFILE%\.aspnet\https:/https/ ^
-v %USERPROFILE%\.aspnet\Logs:/app/logs rofliex/dotnet_webapi:latest
pause