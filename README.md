⭐ Introductio
---------------------------------------------------------------------------------------------------------------------------------

Proje Asp Core Mvc ile yazılmıs Entities, DataAccess, Business ve MVCUI katmanlarından oluşan kitap projesidir.

---------------------------------------------------------------------------------------------------------------------------------
⭐Katmanlar

***Entities Layer*** 

Proje boyunca kullandığım ana sınıflarımı burada tutuyorum.

![entities1](https://user-images.githubusercontent.com/69785776/147384077-93c649a8-b22e-4a62-b25a-d59c1336c2f3.png)

***Data Access Layer***

Bu katmanda veritabanı işlemlerimi yapıyorum.Veri cekme silme güncelleme... gibi.ORM olarak Entity Framework Core kullandım.Veritabanını da code first yapısıyla olusturdum.

![data2](https://user-images.githubusercontent.com/69785776/147384380-e2042c91-41ce-43d7-9829-5e007a9e3f76.png)

***Business Layer***

Bu katmanda data access tarafından verileri cekiyorum ve burda validasyonlarını yapıp Uı'a gönderiyorum veya uı dan gelen verileri validasyona sokup data katmanına gönderiyorum

![busines](https://user-images.githubusercontent.com/69785776/147384651-7deec68f-ceab-4fc7-a69a-e6033bfbd5a2.PNG)

***WebUI Layer***

Presentation olarak geçen bu katmanda businesstan gelen veriyi  controller view model yapısını kulanıyorum. Entitilere direk ulasmak yerine model sınıfında kendi entitilerimi yazıp controllerda auto mapping kütüphanesiyle mappleme yapıyorum.Kullanıcı işlemleri için AspNetCore.Identity kütüphanesini kullandım.Projede controllerlar büyüdükçe daha karmasık yapı oluşacağı için areas yapısıyla bir nevi proje icinde proje olusturup daha yönetilebilir yapı kuruyorum.

![uı1](https://user-images.githubusercontent.com/69785776/147385582-2d0648e1-9426-49e6-bfd8-d3e9843b747e.png)
