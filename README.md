### Docker Simple

>Yasin & �mer


git clone -b master https://github.com/selek55/SimpleDocker.git 

> Api

docker build . -t api:latest --no-cache

docker run -d -p 6500:80 -p 6501:443 api

> Web

docker build . -t web:latest --no-cache

docker run -d -p 80:80 -p 443:443 web

> Websi Ayarlar�

WeatherForecastService.cs dosyam�z�n i�inde 

BaseAddress = new Uri("http://34.70.167.135:6500/");

sizin Apiyi yay�nlad���n�z sunucu olmas� gerekir.