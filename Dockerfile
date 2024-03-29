FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY . .

#RUN dotnet restore Alunos_Backup.csproj
RUN dotnet restore Alunos.csproj
RUN dotnet build -c Release -o out Alunos.csproj


CMD ["dotnet", "out/Alunos.dll"]
