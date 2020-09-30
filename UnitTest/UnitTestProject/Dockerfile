#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UnitTest/UnitTestProject/UnitTestProject.csproj", "UnitTest/UnitTestProject/"]
COPY ["JediAcademyBack/JediAcademy.Back.Api/JediAcademy.Back.Api.csproj", "JediAcademyBack/JediAcademy.Back.Api/"]
COPY ["JediAcademyBack/JediAcademy.Back.Infrastructure/JediAcademy.Back.Infrastructure.csproj", "JediAcademyBack/JediAcademy.Back.Infrastructure/"]
COPY ["JediAcademyBack/JediAcademy.Back.Application/JediAcademy.Back.Application.csproj", "JediAcademyBack/JediAcademy.Back.Application/"]
COPY ["JediAcademyBack/JediAcademy.Back.Domain/JediAcademy.Back.Domain.csproj", "JediAcademyBack/JediAcademy.Back.Domain/"]
COPY ["JediAcademyFront/JediAcademy.Presentation/JediAcademy.Presentation.csproj", "JediAcademyFront/JediAcademy.Presentation/"]
COPY ["StarWars.Api/StarWars.Api.csproj", "StarWars.Api/"]
RUN dotnet restore "UnitTest/UnitTestProject/UnitTestProject.csproj"
COPY . .
WORKDIR "/src/UnitTest/UnitTestProject"
RUN dotnet build "UnitTestProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTestProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTestProject.dll"]