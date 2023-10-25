FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build -c Release -o out

CMD ["dotnet", "out/SeuApp.dll"]
