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


Docker CLI - Cheat Sheet (Kopya Ka��d�)

Komut	A��klamas�

docker images		Lokal registry�de mevcut bulunan Image�lar� listeler

docker ps			Halihaz�rda �al��makta olan Container�lar� listeler

docker ps -a		Docker Daemon �zerindeki b�t�n Container�lar� listeler

docker ps -aq		Docker Daemon �zerindeki b�t�n Container�lar�n ID�lerini listeler

---

docker pull <repository_name>/<image_name>:<image_tag>	Belirtilen Image�� lokal registry�ye indirir. �rnek: docker pull gsengun/jmeter3.0:1.7

docker top <container_id>	�lgili Container�da top komutunu �al��t�rarak ��kt�s�n� g�sterir

docker run -it <image_id|image_name> CMD	Verilen Image�dan terminal�i attach ederek bir Container olu�turur

docker pause <container_id>	�lgili Container�� duraklat�r

docker unpause <container_id>	�lgili Container pause ile duraklat�lm�� ise �al��mas�na devam ettirilir

docker stop <container_id>	�lgili Container�� durdurur

docker start <container_id>	�lgili Container�� durdurulmu�sa tekrar ba�lat�r

---
docker rm <container_id>	�lgili Container�� kald�r�r fakat ili�kili Volume�lara dokunmaz

docker rm -v <container_id>	�lgili Container�� ili�kili Volume�lar ile birlikte kald�r�r

docker rm -f <container_id>	�lgili Container�� zorlayarak kald�r�r. �al��an bir Container ancak -f ile kald�r�labilir

docker rmi <image_id|image_name>	�lgili Image�� siler

docker rmi -f <image_id|image_name>	�lgili Image�� zorlayarak kald�r�r, ba�ka isimlerle Tag�lenmi� Image�lar -f ile kald�r�labilir

---
docker info	Docker Daemon�la ilgili �zet bilgiler verir

docker inspect <container_id>	�lgili Container�la ilgili detayl� bilgiler verir

docker inspect <image_id|image_name>	�lgili Image�la ilgili detayl� bilgiler verir

---
docker rm $(docker ps -aq)	B�t�n Container�lar� kald�r�r

docker stop $(docker ps -aq)	�al��an b�t�n Container�lar� durdurur

docker rmi $(docker images -aq)	B�t�n Image�lar� kald�r�r

docker images -q -f dangling=true	Dangling (taglenmemi� ve bir Container ile ili�kilendirilmemi�) Image�lar� listeler

docker rmi $(docker images -q -f dangling=true)	Dangling Image�lar� kald�r�r

---
docker volume ls -f dangling=true	Dangling Volume�lar� listeler

docker volume rm $(docker volume ls -f dangling=true -q)	Danling Volume�lar� kald�r�r

---
docker logs <container_id>	�lgili Container��n terminalinde o ana kadar olu�an ��kt�y� g�sterir

docker logs -f <container_id>	�lgili Container��n terminalinde o ana kadar olu�an ��kt�y� g�sterir ve -f follow parametresi ile o andan sonra olu�an loglar� da g�stermeye devam eder

---
docker exec <container_id> <command>	�al��an bir Container i�inde bir komut ko�turmak i�in kullan�l�r

docker exec -it <container_id> /bin/bash	�al��an bir Container i�inde terminal a�mak i�in kullan�l�r. �lgili Image�da /bin/bash bulundu�u varsay�m� ile

---
docker attach <container_id>	�nceden detached modda -d ba�lat�lan bir Container�a attach olmak i�in kullan�l�r