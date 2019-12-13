### Docker Simple

>Yasin & Ömer


git clone -b master https://github.com/selek55/SimpleDocker.git 


docker build . -t api:latest --no-cache

docker run -d -p 5000:80 -p 5001:443 api