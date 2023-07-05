USE RentACarDatabase
--I will define  " CREATE,UPDATE,READ,DELETE,INSERT " operations with "Stored Procedures" / " CRETAE PROCEDURE.. ".
--I will define the calculations that need to be returned with the "Functions" / " CREATE FUNCION... ".

--#Customer Operations;--------------------------------------------------
--To be able to read the Models and Classes table.
--The customer can actively change the status attribute of a car registration after completing the payment (Hereby, the number of passive/active vehicles in the models and classes table will change).
--Only the tracking forms belonging to the customer can be read by the customer, in this reading he should be able to see the features of the vehicle offered to his service.
--When the customer reaches the date set, the vehicle's status automatically switches to a passive state with a function.
---#Employee Operations;-------------------------------------------------
--It is ensured that data manipulation can be made according to the limits of the authorized areas in the tables other than the employee, personnel and manager table.
--#Administrator Operations;---------------------------------------------
--Administrator, in all tables, allows the administrator to manipulate data according to the limits of the areas of authority.

--########  Inserting operations ##########
GO
--INSERTING CUSTOMER / TR: Müþteri ekleme talimatý
CREATE PROCEDURE insertCustomer(@TCKN char(11),@NAME char(25), @LNAME char(15), @PASSW nvarchar(20), @PHONE char(10) )
	AS
	INSERT INTO Musteriler(TCKN,Musteri_Adi,Musteri_Soyadi,Musteri_Sifre,Musteri_Telefon)
	VALUES (@TCKN,@NAME,@LNAME,@PASSW,@PHONE) 

GO
DROP PROCEDURE insertVehicle
GO
--INSERTING NEW VEHICLE / TR: Yeni aracý araç tablosuna ekleme talimatý
CREATE PROCEDURE insertVehicle(@PLATE nvarchar(8),@BRAND_ID int,@MODEL_ID int, @CLASS_ID int, @GEAR_ID int, @FUEL_ID int)
	AS
	INSERT INTO Arabalar(Plaka,Marka_ID,Model_ID,Sinif_ID,Vites_ID,Yakit_ID,Durum) -- TR: Tabloyu oluþtururken durum niteliðinin default deðerini pasif olarak ayarlayabilirdik. DEFAULT('Pasif')
	VALUES(@PLATE,@BRAND_ID,@MODEL_ID,@CLASS_ID,@GEAR_ID,@FUEL_ID,'Pasif') --We could have set the default value of the state attribute to passive when creating the table. DEFAULT('Passive')
	
	UPDATE Modeller_ve_Siniflar  SET Toplam_Adet +=1,Pasif_Adet +=1 where  Model_ID =  @MODEL_ID and Sinif_ID = @CLASS_ID and Vites_ID = @GEAR_ID and Yakit_ID = @FUEL_ID
	
GO
DROP PROCEDURE insertEmployee
GO
--INTERING NEW EMPLOYEE / TR: Yeni personeli personel tablosuna ekleme talimatý
CREATE PROCEDURE insertEmployee(@NAME char(25), @LNAME char(15), @PASSW nvarchar(20), @PHONE char(10))
	AS
	INSERT INTO Personeller(Personel_Adi,Personel_Soyadi,Personel_Sifre,Personel_Telefon)
	VALUES (@NAME,@LNAME,@PASSW,@PHONE)
GO 
USE RentACarDatabase
EXEC insertEmployee 'Talha Burak','Aydýn','1q2w3e','5050000000'

GO
--INTERING NEW MANAGER / TR: Yeni yöneticiyi yönetici tablosuna ekleme talimatý
CREATE PROCEDURE insertManagaer(@EMP_ID int,@NAME char(25),@LNAME char(20))
	AS
	INSERT INTO Yoneticiler(Personel_ID,Yonetici_Adi,Yonetici_Soyadi)
	VALUES (@EMP_ID,@NAME,@LNAME)
GO 

CREATE PROCEDURE insertClass(@CLASS_NAME nvarchar(15) )
	
	AS
	INSERT INTO Araba_Siniflari(Sinif_Adi)
	VALUES (@CLASS_NAME)
GO 

CREATE PROCEDURE insertGearType(@GEAR_NAME nvarchar(10))
	
		AS
	INSERT INTO Vites_Tipleri(Vites_Adi)
	VALUES (@GEAR_NAME)
GO 

CREATE PROCEDURE insertFuelType(@FUEL_NAME nvarchar(10))
	
		AS
	INSERT INTO Yakit_Tipleri(Yakit_Adi)
	VALUES (@FUEL_NAME)
GO 

CREATE PROCEDURE insertBrand(@CAR_BRAND nvarchar(20))
	
		AS
	INSERT INTO Araba_Markalari(Marka_Adi)
	VALUES (@CAR_BRAND)
GO 

CREATE PROCEDURE insertModel(@CAR_BRAND int,@CAR_MODEL nvarchar(20))
	
		AS
	INSERT INTO Araba_Modelleri(Marka_ID,Model_Adi)
	VALUES (@CAR_BRAND,@CAR_MODEL)
GO 

CREATE PROCEDURE insertModelsAndClasses(@MODEL_ID int,@CLASS_ID int,@GEAR_ID int,@FUEL_ID int, @PRICE int)
	
		AS
	INSERT INTO Modeller_ve_Siniflar(Model_ID,Sinif_ID,Vites_ID,Yakit_ID,Fiyat,Aktif_Adet,Pasif_Adet,Toplam_Adet)
	VALUES (@MODEL_ID,@CLASS_ID,@GEAR_ID,@FUEL_ID,@PRICE,0,0,0)
GO
USE RentACarDatabase
DROP PROCEDURE insertTrackingForm

GO
CREATE PROCEDURE insertTrackingForm(@CUSTOMER_ID int,@TCKN char(11),@PLATE nvarchar(8),@Purchase_Date DATE,@Return_Date DATE,@Service_Fee int)
	AS
	INSERT INTO Takip_Formlarý(Musteri_ID,Musteri_TCKN,Plaka,Alis_Tarihi,Ýade_Tarihi,Hizmet_Bedeli)	
	VALUES(@CUSTOMER_ID ,@TCKN ,@PLATE ,@Purchase_Date ,@Return_Date ,@Service_Fee )

	

GO

EXEC insertBrand 'Fiat'
EXEC insertBrand 'Citroen'
EXEC insertBrand 'Honda'
EXEC insertBrand 'Renault'
EXEC insertBrand 'Dacia'
EXEC insertBrand 'Opel'
EXEC insertBrand 'Hyundai'
EXEC insertBrand 'BMW'
EXEC insertBrand 'Mercedes'
EXEC insertBrand 'Ford'



SELECT * FROM Araba_Markalari

EXEC insertModel 21,'Egea'
EXEC insertModel 21,'Fiorino'
EXEC insertModel 21,'Doblo'
EXEC insertModel 21,'Linea'
SELECT * FROM Araba_Markalari
SELECT * FROM Araba_Modelleri


EXEC insertModel 22,'Elysee'
EXEC insertModel 22,'C3'
EXEC insertModel 22,'C5'

EXEC insertModel 23,'Civic'

EXEC insertModel 24,'Megane'
EXEC insertModel 24,'Clio'
EXEC insertModel 24,'Symbol'

EXEC insertModel 25,'Sandero'
EXEC insertModel 25,'Duster'
EXEC insertModel 25,'Lodgy'

EXEC insertModel 26,'Corsa'
EXEC insertModel 26,'Insignia'
EXEC insertModel 26,'Astra'
EXEC insertModel 26,'Mokka'

EXEC insertModel 27,'i20'
EXEC insertModel 27,'Accent'

EXEC insertModel 28,'3.20'
EXEC insertModel 28,'5.20'
EXEC insertModel 28,'X5'
EXEC insertModel 28,'Z4'

EXEC insertModel 29,'AMG C63'
EXEC insertModel 29,'AMG A45'
EXEC insertModel 29,'AMG S63'
EXEC insertModel 29,'GT 63'

EXEC insertModel 30,'Fiesta'
EXEC insertModel 30,'Mustang'
EXEC insertModel 30,'Focus'
EXEC insertModel 30,'Kuga'

EXEC insertGearType 'Düz'
EXEC insertGearType 'Otomatik'

SELECT * FROM Vites_Tipleri

EXEC insertFuelType 'Benzin'
EXEC insertFuelType 'Dizel'

SELECT * FROM Yakit_Tipleri 

EXEC insertClass 'Ekonomi' --1
EXEC insertClass 'Medium'	--2
EXEC insertClass 'Lüks' --3
EXEC insertClass 'SUV'	--4
EXEC insertClass '7+'	--5

SELECT * FROM Araba_Siniflari 
SELECT * FROM Araba_Modelleri
SELECT * FROM Modeller_ve_Siniflar
--5 : 7+
EXEC insertModelsAndClasses 26,5,1,2,560
--4 : SUV
EXEC insertModelsAndClasses 25,4,1,2,540
EXEC insertModelsAndClasses 25,4,2,1,580
EXEC insertModelsAndClasses 25,4,2,2,580
EXEC insertModelsAndClasses 30,4,2,1,760
EXEC insertModelsAndClasses 19,4,2,2,920
EXEC insertModelsAndClasses 35,4,2,2,2500
EXEC insertModelsAndClasses 44,4,1,1,1600

--3 : Lüks
EXEC insertModelsAndClasses 28,3,2,2,860
EXEC insertModelsAndClasses 33,3,1,1,1800
EXEC insertModelsAndClasses 34,3,1,2,2300
EXEC insertModelsAndClasses 36,3,1,1,2600
EXEC insertModelsAndClasses 37,3,2,1,3000
EXEC insertModelsAndClasses 38,3,2,2,2450
EXEC insertModelsAndClasses 39,3,2,2,5400
EXEC insertModelsAndClasses 40,3,2,1,8000
EXEC insertModelsAndClasses 42,3,1,1,3500


--2 : Medium
EXEC insertModelsAndClasses 41,2,1,2,450
EXEC insertModelsAndClasses 43,2,1,1,420
EXEC insertModelsAndClasses 15,2,1,1,350
EXEC insertModelsAndClasses 24,2,1,1,390
EXEC insertModelsAndClasses 18,2,2,1,490
EXEC insertModelsAndClasses 22,2,2,1,530
EXEC insertModelsAndClasses 32,2,2,2,430
EXEC insertModelsAndClasses 13,2,2,2,540
EXEC insertModelsAndClasses 21,2,2,1,560
EXEC insertModelsAndClasses 20,2,1,1,680
EXEC insertModelsAndClasses 26,2,1,2,500
EXEC insertModelsAndClasses 29,2,1,1,550

--1 : Ekonomi

EXEC insertModelsAndClasses 17,1,1,1,480
EXEC insertModelsAndClasses 13,1,1,1,480
EXEC insertModelsAndClasses 22,1,1,1,480
EXEC insertModelsAndClasses 24,1,1,1,480
EXEC insertModelsAndClasses 13,1,1,2,500
EXEC insertModelsAndClasses 14,1,1,1,520
EXEC insertModelsAndClasses 27,1,2,1,520
EXEC insertModelsAndClasses 31,1,2,1,530
EXEC insertModelsAndClasses 23,1,1,1,300
EXEC insertModelsAndClasses 16,1,1,1,370


EXEC insertVehicle '34ANZ001',21,13,1,1,1
EXEC insertVehicle '34ANZ002',21,13,1,1,1
EXEC insertVehicle '34ANZ003',21,13,1,1,1

EXEC insertVehicle '34ANZ004',21,13,1,1,2
EXEC insertVehicle '34ANZ005',21,13,1,1,2
EXEC insertVehicle '34ANZ006',21,13,1,1,2

EXEC insertVehicle '34ANZ007',21,13,2,2,2
EXEC insertVehicle '34ANZ008',21,13,2,2,2
EXEC insertVehicle '34ANZ009',21,13,2,2,2
EXEC insertVehicle '34ANZ010',21,13,2,2,2
EXEC insertVehicle '34ANZ011',21,13,2,2,2

EXEC insertVehicle '34ANZ012',21,14,1,1,1
EXEC insertVehicle '34ANZ013',21,14,1,1,1
EXEC insertVehicle '34ANZ014',21,14,1,1,1

EXEC insertVehicle '34ANZ015',21,15,2,1,1
EXEC insertVehicle '34ANZ016',21,15,2,1,1
EXEC insertVehicle '34ANZ017',21,15,2,1,1

EXEC insertVehicle '34ANZ018',21,16,1,1,1
EXEC insertVehicle '34ANZ019',21,16,1,1,1
EXEC insertVehicle '34ANZ020',21,16,1,1,1

EXEC insertVehicle '34ANZ021',22,17,1,1,1
EXEC insertVehicle '34ANZ022',22,17,1,1,1
EXEC insertVehicle '34ANZ023',22,17,1,1,1

EXEC insertVehicle '34ANZ024',22,18,2,2,1
EXEC insertVehicle '34ANZ025',22,18,2,2,1
EXEC insertVehicle '34ANZ026',22,18,2,2,1

EXEC insertVehicle '34ANZ027',22,19,4,2,2
EXEC insertVehicle '34ANZ028',22,19,4,2,2
EXEC insertVehicle '34ANZ029',22,19,4,2,2

EXEC insertVehicle '34ANZ030',22,19,4,2,2

EXEC insertVehicle '34ANZ031',23,20,2,1,1
EXEC insertVehicle '34ANZ032',23,20,2,1,1
EXEC insertVehicle '34ANZ033',23,20,2,1,1

EXEC insertVehicle '34ANZ034',24,21,2,2,1
EXEC insertVehicle '34ANZ035',24,21,2,2,1
EXEC insertVehicle '34ANZ036',24,21,2,2,1
EXEC insertVehicle '34ANZ037',24,21,2,2,1
EXEC insertVehicle '34ANZ038',24,21,2,2,1
EXEC insertVehicle '34ANZ039',24,21,2,2,1

EXEC insertVehicle '34ANZ040',24,22,1,1,1
EXEC insertVehicle '34ANZ041',24,22,1,1,1

EXEC insertVehicle '34ANZ042',24,22,2,2,1
EXEC insertVehicle '34ANZ043',24,22,2,2,1

EXEC insertVehicle '34ANZ044',24,23,1,1,1
EXEC insertVehicle '34ANZ045',24,23,1,1,1
EXEC insertVehicle '34ANZ046',24,23,1,1,1

EXEC insertVehicle '34ANZ047',25,24,1,1,1
EXEC insertVehicle '34ANZ048',25,24,1,1,1
EXEC insertVehicle '34ANZ049',25,24,1,1,1

EXEC insertVehicle '34ANZ050',25,25,4,1,2
EXEC insertVehicle '34ANZ051',25,25,4,2,1
EXEC insertVehicle '34ANZ052',25,25,4,2,2

EXEC insertVehicle '34ANZ053',25,26,2,1,2
EXEC insertVehicle '34ANZ054',25,26,2,1,2
EXEC insertVehicle '34ANZ055',25,26,5,1,2
EXEC insertVehicle '34ANZ056',25,26,5,1,2

EXEC insertVehicle '34ANZ057',26,27,1,2,1
EXEC insertVehicle '34ANZ058',26,27,1,2,1


EXEC insertVehicle '34ANZ059',26,28,3,2,2
EXEC insertVehicle '34ANZ060',26,28,3,2,2
EXEC insertVehicle '34ANZ061',26,28,3,2,2

EXEC insertVehicle '34ANZ062',26,29,2,1,1
EXEC insertVehicle '34ANZ063',26,29,2,1,1
EXEC insertVehicle '34ANZ064',26,29,2,1,1

EXEC insertVehicle '34ANZ065',26,30,4,2,1
EXEC insertVehicle '34ANZ066',26,30,4,2,1

EXEC insertVehicle '34ANZ067',27,31,1,2,1
EXEC insertVehicle '34ANZ068',27,31,1,2,1
EXEC insertVehicle '34ANZ069',27,31,1,2,1

EXEC insertVehicle '34ANZ070',27,32,2,2,2
EXEC insertVehicle '34ANZ071',27,32,2,2,2
EXEC insertVehicle '34ANZ071',27,32,2,2,2

EXEC insertVehicle '34ANZ072',28,33,3,1,1
EXEC insertVehicle '34ANZ073',28,33,3,1,1
EXEC insertVehicle '34ANZ074',28,33,3,1,1

EXEC insertVehicle '34ANZ075',28,34,3,1,2
EXEC insertVehicle '34ANZ076',28,34,3,1,2
EXEC insertVehicle '34ANZ077',28,34,3,1,2

EXEC insertVehicle '34ANZ078',28,35,4,2,2
EXEC insertVehicle '34ANZ079',28,35,4,2,2
EXEC insertVehicle '34ANZ080',28,35,4,2,2

EXEC insertVehicle '34ANZ081',28,36,3,1,1
EXEC insertVehicle '34ANZ082',28,36,3,1,1

EXEC insertVehicle '34ANZ083',29,37,3,2,1
EXEC insertVehicle '34ANZ084',29,37,3,2,1

EXEC insertVehicle '34ANZ085',29,38,3,2,2
EXEC insertVehicle '34ANZ086',29,38,3,2,2

EXEC insertVehicle '34ANZ087',29,39,3,2,2
EXEC insertVehicle '34ANZ088',29,39,3,2,2

EXEC insertVehicle '34ANZ089',29,40,3,2,1

EXEC insertVehicle '34ANZ090',30,41,2,1,2
EXEC insertVehicle '34ANZ091',30,41,2,1,2
EXEC insertVehicle '34ANZ092',30,41,2,1,2
EXEC insertVehicle '34ANZ093',30,41,2,1,2
EXEC insertVehicle '34ANZ094',30,41,2,1,2
EXEC insertVehicle '34ANZ095',30,41,2,1,2
EXEC insertVehicle '34ANZ096',30,41,2,1,2
EXEC insertVehicle '34ANZ097',30,41,2,1,2

EXEC insertVehicle '34ANZ098',30,42,3,1,1
EXEC insertVehicle '34ANZ099',30,42,3,1,1

EXEC insertVehicle '34ANZ100',30,43,2,1,1
EXEC insertVehicle '34ANZ101',30,43,2,1,1
EXEC insertVehicle '34ANZ102',30,43,2,1,1
EXEC insertVehicle '34ANZ103',30,43,2,1,1
EXEC insertVehicle '34ANZ104',30,43,2,1,1

EXEC insertVehicle '34ANZ105',30,44,4,1,1
EXEC insertVehicle '34ANZ106',30,44,4,1,1
EXEC insertVehicle '34ANZ107',30,44,4,1,1
EXEC insertVehicle '34ANZ108',30,44,4,1,1

EXEC insertVehicle '34ANZ109',25,24,2,1,1

SELECT * FROM Arabalar

select * from Modeller_ve_Siniflar


--SELECT COUNT(*)FROM Arabalar as a GROUP BY a.Model_ID,a.Sinif_ID,a.Vites_ID,a.Yakit_ID

SELECT * FROM Modeller_ve_Siniflar

SELECT * FROM Arabalar

USE RentACarDatabase

ALTER TABLE Yoneticiler
DROP COLUMN Yonetici_Adi;
ALTER TABLE Yoneticiler
DROP COLUMN Yonetici_Soyadi;


INSERT INTO Yoneticiler(Personel_ID) VALUES(100)

SELECT TOP 1 Personel_ID FROM Personeller ORDER BY Personel_ID DESC

























