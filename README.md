# API Sample


# Using

* .Net Core 2
* swagger
* NReco.Logging

# Function

1. 使用filter，統一回傳json格式。
2. 可以自動擷取錯誤轉成json回傳。


# json格式

> Result: 1 表示正確。-1 表示錯誤

> Data: 回傳物件

> Message: 訊息


# 執行

> dotnet run

# docker

> dotnet run

# 發行
> dotnet restore -r rhel.7-x64
> sudo dotnet publish -f netcoreapp2.0 -c Release -o ./app -r rhel.7-x64 --self-contained false /p:MicrosoftNETPlatformLibrary=Microsoft.NETCore.App
> docker build -t dotnet-20-apisample .
> docker run -p8080:8080 dotnet-20-apisample
## OLD
> dotnet publish -c Release -o ./app

# Docker

下載範例code

需要申請會員並有我同意才能用

編輯Dockerfile

編輯docker-compose.yaml 檔

編輯appsettings.json檔

確認連結有按照yaml檔修正

執行 docker-compose build

> docker-compose build

執行 docker-compose up

> docker-compose up
> docker-compose up -d (背景執行)

增加ap
> docker-compose scale sample=3







