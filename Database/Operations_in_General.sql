--USE RentACarDatabase

-- ###############IN TURKISH
-- M��terilerin, personelin ve y�neticinin yetkileri farkl� olaca��ndan bu 3 varl��a  �zel i�lemler tan�mlanmal�.
-- Bu i�lemler sorgu, hesaplama ve "UPDATE,DELETE,INSERT..." gibi veri manip�lasyonlar� olmak �zere 3 ana gruba ayr�l�r.

-- " CREATE,UPDATE,READ,DELETE,INSERT " ��lemlerini Stored Procedures " CRETAE PROCEDURE... " ile tan�mlayaca��z.
--  D�nd�r�lmesi gerekli olan hesaplamalar� Fonksiyolar " CREATE FUNCTION... " ile tan�mlayaca��z.

-- �nce i� kurallar� �er�evesinde d���nebildi�im b�t�n operasyonlar� haz�rlayaca��m sonras�nda geri bildirimler ile operasyonlar� geni�letece�im veya daraltaca��m.
-- Operasyon ve yetkileri g�rebilece�imiz d�� bir plan olu�turmak s�reci optimize eder.

--#M��teri Operasyonlar�; 
--Modeller ve S�n�flar tablosunu okuyabilmek. 
--M��teri �demeyi tamamlad�ktan sonra bir araba kayd�n�n durum �zelli�ini aktif olarak de�i�itirebilir (Bu vesileyle, modeller ve s�n�flar tablosundaki pasif ve aktif ara� say�s� de�i�ecektir).
--Sadece m��teriye ait olan takip formalar�n�n m��teri taraf�ndan okunmas� sa�lan�r, bu okumada hizmetine sunulan arac�n �zellikerinide g�rebilmeli.
--M��terinin belirlerdi�i tarihe ula��nca arac�n durumu otomatik olarak bir fonksiyon ile pasif duruma ge�er.

--#Personel Operasyonlar�;
--Personel, personel ve y�netici tablosu haricindeki tablolarda yetki alanlar�n s�n�rlar�na g�re veri manip�lasyonu yapabilmesi sa�lan�r.

--#Y�netici Operasyonlar�;
--Y�netici, b�t�n tablolarda y�neticinin yetki alanlar�n s�n�rlar�na g�re veri manip�lasyonu yapabilmesi sa�lan�r.
  

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