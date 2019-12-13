### Docker Simple

>Yasin & Ömer


git clone -b master https://github.com/selek55/SimpleDocker.git 

> api

docker build . -t api:latest --no-cache

docker run -d -p 5000:80 -p 5001:443 api

> web

docker build . -t web:latest

docker run -d -p 80:80 -p 443:443 web