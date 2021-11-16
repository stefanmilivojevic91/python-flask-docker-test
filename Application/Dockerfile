FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Application/Application.csproj", "Application/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Boundary/Boundary.csproj", "Boundary/"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]
RUN dotnet restore "Application/Application.csproj"
COPY . .
WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]