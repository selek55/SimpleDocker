### Docker Simple

>Yasin & Ömer


git clone -b master https://github.com/selek55/SimpleDocker.git 

> Api

docker build . -t api:latest --no-cache

docker run -d -p 6500:80 -p 6501:443 api

> Web

docker build . -t web:latest --no-cache

docker run -d -p 80:80 -p 443:443 web


> Websi Ayarlarý

WeatherForecastService.cs dosyamýzýn içinde 

BaseAddress = new Uri("http://34.70.167.135:6500/");

sizin Apiyi yayýnladýðýnýz sunucu olmasý gerekir.


Docker CLI - Cheat Sheet (Kopya Kaðýdý)

Komut	Açýklamasý

docker images		Lokal registry’de mevcut bulunan Image’larý listeler

docker ps			Halihazýrda çalýþmakta olan Container’larý listeler

docker ps -a		Docker Daemon üzerindeki bütün Container’larý listeler

docker ps -aq		Docker Daemon üzerindeki bütün Container’larýn ID’lerini listeler

---

docker pull <repository_name>/<image_name>:<image_tag>	Belirtilen Image’ý lokal registry’ye indirir. Örnek: docker pull gsengun/jmeter3.0:1.7

docker top <container_id>	Ýlgili Container’da top komutunu çalýþtýrarak çýktýsýný gösterir

docker run -it <image_id|image_name> CMD	Verilen Image’dan terminal’i attach ederek bir Container oluþturur

docker pause <container_id>	Ýlgili Container’ý duraklatýr

docker unpause <container_id>	Ýlgili Container pause ile duraklatýlmýþ ise çalýþmasýna devam ettirilir

docker stop <container_id>	Ýlgili Container’ý durdurur

docker start <container_id>	Ýlgili Container’ý durdurulmuþsa tekrar baþlatýr

---
docker rm <container_id>	Ýlgili Container’ý kaldýrýr fakat iliþkili Volume’lara dokunmaz

docker rm -v <container_id>	Ýlgili Container’ý iliþkili Volume’lar ile birlikte kaldýrýr

docker rm -f <container_id>	Ýlgili Container’ý zorlayarak kaldýrýr. Çalýþan bir Container ancak -f ile kaldýrýlabilir

docker rmi <image_id|image_name>	Ýlgili Image’ý siler

docker rmi -f <image_id|image_name>	Ýlgili Image’ý zorlayarak kaldýrýr, baþka isimlerle Tag’lenmiþ Image’lar -f ile kaldýrýlabilir

---
docker info	Docker Daemon’la ilgili özet bilgiler verir

docker inspect <container_id>	Ýlgili Container’la ilgili detaylý bilgiler verir

docker inspect <image_id|image_name>	Ýlgili Image’la ilgili detaylý bilgiler verir

---
docker rm $(docker ps -aq)	Bütün Container’larý kaldýrýr

docker stop $(docker ps -aq)	Çalýþan bütün Container’larý durdurur

docker rmi $(docker images -aq)	Bütün Image’larý kaldýrýr

docker images -q -f dangling=true	Dangling (taglenmemiþ ve bir Container ile iliþkilendirilmemiþ) Image’larý listeler

docker rmi $(docker images -q -f dangling=true)	Dangling Image’larý kaldýrýr

---
docker volume ls -f dangling=true	Dangling Volume’larý listeler

docker volume rm $(docker volume ls -f dangling=true -q)	Danling Volume’larý kaldýrýr

---
docker logs <container_id>	Ýlgili Container’ýn terminalinde o ana kadar oluþan çýktýyý gösterir

docker logs -f <container_id>	Ýlgili Container’ýn terminalinde o ana kadar oluþan çýktýyý gösterir ve -f follow parametresi ile o andan sonra oluþan loglarý da göstermeye devam eder

---
docker exec <container_id> <command>	Çalýþan bir Container içinde bir komut koþturmak için kullanýlýr

docker exec -it <container_id> /bin/bash	Çalýþan bir Container içinde terminal açmak için kullanýlýr. Ýlgili Image’da /bin/bash bulunduðu varsayýmý ile

---
docker attach <container_id>	Önceden detached modda -d baþlatýlan bir Container’a attach olmak için kullanýlýr