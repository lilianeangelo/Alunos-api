FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app

COPY . .

RUN dotnet restore Alunos_Backup.csproj
RUN dotnet restore Alunos.csproj
RUN dotnet build -c Release -o out

CMD ["dotnet", "out/SeuApp.dll"]
