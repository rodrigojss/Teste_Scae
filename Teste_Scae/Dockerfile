#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/aspnetcore:2.0-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1803 AS build
WORKDIR /src
COPY ["Teste_Scae/Teste_Scae.csproj", "Teste_Scae/"]
RUN dotnet restore "Teste_Scae/Teste_Scae.csproj"
COPY . .
WORKDIR "/src/Teste_Scae"
RUN dotnet build "Teste_Scae.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Teste_Scae.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Teste_Scae.dll"]