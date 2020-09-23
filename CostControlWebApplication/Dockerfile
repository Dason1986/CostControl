#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

WORKDIR /app
EXPOSE 80

COPY publish /app 

#设置环境变量，修改.netCore 默认的80端口
ENV ASPNETCORE_URLS http://+:80
#ENV ConnectionStrings:DefaultConnection Server=localhost;User Id=root;Password=sasa;Database=CostControl

# 设置导出端口

ENTRYPOINT ["dotnet", "CostControlWebApplication.dll"]