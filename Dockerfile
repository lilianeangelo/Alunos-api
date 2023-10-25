FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY ./app /app
RUN dotnet restore
RUN dotnet publish -c Release -o out
CMD ["dotnet", "out/SeuApp.dll"]
