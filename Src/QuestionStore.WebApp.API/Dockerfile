#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Src/QuestionStore.WebApp.API/QuestionStore.WebApp.API.csproj", "Src/QuestionStore.WebApp.API/"]
COPY ["Src/QuestionStore.Core/QuestionStore.Core.csproj", "Src/QuestionStore.Core/"]
COPY ["Src/QuestionStore.Domain/QuestionStore.Domain.csproj", "Src/QuestionStore.Domain/"]
RUN dotnet restore "Src/QuestionStore.WebApp.API/QuestionStore.WebApp.API.csproj"
COPY . .
WORKDIR "/src/Src/QuestionStore.WebApp.API"
RUN dotnet build "QuestionStore.WebApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuestionStore.WebApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuestionStore.WebApp.API.dll"]