FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY ["CodeChallenge.WebApi/*.csproj", "./CodeChallenge.WebApi/"]
COPY ["CodeChallenge.Persistence/*.csproj", "./CodeChallenge.Persistence/"]
COPY ["CodeChallenge.Domain/*.csproj", "./CodeChallenge.Domain/"]
COPY ["CodeChallenge.Application/*.csproj", "./CodeChallenge.Application/"]
COPY ["CodeChallenge.Tools/*.csproj", "./CodeChallenge.Tools/"]
COPY ["CodeChallenge.Cross/*.csproj", "./CodeChallenge.Cross/"]

#
RUN dotnet restore "CodeChallenge.WebApi/CodeChallenge.WebApi.csproj"
#
# copy everything else and build app
COPY ["CodeChallenge.WebApi/.", "./CodeChallenge.WebApi/"]
COPY ["CodeChallenge.Persistence/.", "./CodeChallenge.Persistence/"]
COPY ["CodeChallenge.Domain/.", "./CodeChallenge.Domain/"]
COPY ["CodeChallenge.Application/.", "./CodeChallenge.Application/"]
COPY ["CodeChallenge.Tools/.", "./CodeChallenge.Tools/"]
COPY ["CodeChallenge.Cross/.", "./CodeChallenge.Cross/"]

#
WORKDIR /app/CodeChallenge.WebApi
RUN dotnet publish -c Release -o out
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
#
COPY --from=build /app/CodeChallenge.WebApi/out ./
ENTRYPOINT ["dotnet", "CodeChallenge.WebApi.dll"]
