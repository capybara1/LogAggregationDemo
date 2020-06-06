FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /project
COPY . ./
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Demo.dll"]