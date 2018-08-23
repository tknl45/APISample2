#此指令會初始化新的建置階段，並設定其餘指令的基底映像。
FROM registry.access.redhat.com/dotnet/dotnet-20-runtime-rhel7

#WORKDIR 指令會設定任何其餘 RUN、CMD、ENTRYPOINT、COPY 和 ADD Dockerfile 指令的工作目錄。 如果目錄不存在，則會建立它。 在此情況下，WORKDIR 會設定為應用程式目錄。
WORKDIR /app
#設定內部port
EXPOSE 8080

RUN dotnet restore -r rhel.7-x64
RUN sudo dotnet publish -f netcoreapp2.0 -c Release -o ./app -r rhel.7-x64 --self-contained false /p:MicrosoftNETPlatformLibrary=Microsoft.NETCore.App


# 複製app全部的檔案
COPY app/ .

# 執行服務
CMD ["dotnet", "APISample.dll"]
