#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0.14-bullseye-slim-amd64 AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://*:5000"
EXPOSE 5000/tcp
ENV ASPNETCORE_ENVIRONMENT docker

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProyectoBack.csproj", "ProyectoBack/"]
RUN dotnet restore "ProyectoBack/ProyectoBack.csproj"

WORKDIR "/src/ProyectoBack"
COPY . .
RUN dotnet build "ProyectoBack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProyectoBack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoBack.dll"]
#FROM microsoft/dotnet:latest
#COPY . /app
#WORKDIR /app
#
#RUN dotnet restore
#RUN dotnet build
#
#EXPOSE 5000/tcp
#ENV ASPNETCORE_URLS http://*:5000
#ENV ASPNETCORE_ENVIRONMENT docker
#
#ENTRYPOINT dotnet run