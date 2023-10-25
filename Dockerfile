FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app

COPY . .

RUN apt-get update -y && apt-get install -y dotnet-sdk-5.0

RUN dotnet restore
RUN dotnet build -c Release -o out

CMD ["dotnet", "out/SeuApp.dll"]
