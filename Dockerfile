#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1809 AS build
WORKDIR /src
COPY ["CrudOperations/CrudOperations.csproj", "CrudOperations/"]
RUN dotnet restore "CrudOperations/CrudOperations.csproj"
COPY . .
WORKDIR "/src/CrudOperations"
RUN dotnet build "CrudOperations.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CrudOperations.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CrudOperations.dll"]