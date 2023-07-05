--USE RentACarDatabase

-- ###############IN TURKISH
-- Müþterilerin, personelin ve yöneticinin yetkileri farklý olacaðýndan bu 3 varlýða  özel iþlemler tanýmlanmalý.
-- Bu iþlemler sorgu, hesaplama ve "UPDATE,DELETE,INSERT..." gibi veri manipülasyonlarý olmak üzere 3 ana gruba ayrýlýr.

-- " CREATE,UPDATE,READ,DELETE,INSERT " Ýþlemlerini Stored Procedures " CRETAE PROCEDURE... " ile tanýmlayacaðýz.
--  Döndürülmesi gerekli olan hesaplamalarý Fonksiyolar " CREATE FUNCTION... " ile tanýmlayacaðýz.

-- Önce iþ kurallarý çerçevesinde düþünebildiðim bütün operasyonlarý hazýrlayacaðým sonrasýnda geri bildirimler ile operasyonlarý geniþleteceðim veya daraltacaðým.
-- Operasyon ve yetkileri görebileceðimiz dýþ bir plan oluþturmak süreci optimize eder.

--#Müþteri Operasyonlarý; 
--Modeller ve Sýnýflar tablosunu okuyabilmek. 
--Müþteri ödemeyi tamamladýktan sonra bir araba kaydýnýn durum özelliðini aktif olarak deðiþitirebilir (Bu vesileyle, modeller ve sýnýflar tablosundaki pasif ve aktif araç sayýsý deðiþecektir).
--Sadece müþteriye ait olan takip formalarýnýn müþteri tarafýndan okunmasý saðlanýr, bu okumada hizmetine sunulan aracýn özellikerinide görebilmeli.
--Müþterinin belirlerdiði tarihe ulaþýnca aracýn durumu otomatik olarak bir fonksiyon ile pasif duruma geçer.

--#Personel Operasyonlarý;
--Personel, personel ve yönetici tablosu haricindeki tablolarda yetki alanlarýn sýnýrlarýna göre veri manipülasyonu yapabilmesi saðlanýr.

--#Yönetici Operasyonlarý;
--Yönetici, bütün tablolarda yöneticinin yetki alanlarýn sýnýrlarýna göre veri manipülasyonu yapabilmesi saðlanýr.
  

--###############IN ENGLISH
-- Since the authorizations of customers, personnel and managers will be different, operations specific to these 3 entities should be defined.
-- These operations are divided into 3 main groups as query, calculation and data manipulations such as "UPDATE, DELETE, INSERT...".

--I will define  " CREATE,UPDATE,READ,DELETE,INSERT " operations with "Stored Procedures" / " CRETAE PROCEDURE.. ".
--I will define the calculations that need to be returned with the "Functions" / " CREATE FUNCION... ".

-- First, I will prepare all the operations I can think of within the framework of business rules, then I will expand or narrow the operations with feedback.
-- Creating an external picture of operations and authorizations optimizes the process.

--#Customer Operations;
--To be able to read the Models and Classes table.
--The customer can actively change the status attribute of a car registration after completing the payment (Hereby, the number of passive/active vehicles in the models and classes table will change).
--Only the tracking forms belonging to the customer can be read by the customer, in this reading he should be able to see the features of the vehicle offered to his service.
--When the customer reaches the date set, the vehicle's status automatically switches to a passive state with a function.

---#Employee Operations;
--It is ensured that data manipulation can be made according to the limits of the authorized areas in the tables other than the employee, personnel and manager table.

--#Administrator Operations;
--Administrator, in all tables, allows the administrator to manipulate data according to the limits of the areas of authority.