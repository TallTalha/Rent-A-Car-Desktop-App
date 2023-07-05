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

--########  Listing operations ##########

--### ALL INFO ABOUT VEHICLE
--Query of idle vehicles. / TR : Sadece kullanýma açýk olan araçlarý listeler, (müþteriler için yazýldý.)
GO
 CREATE PROCEDURE ListAllCarCust 
	
	AS
	SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 -- Boþta araç varsa listele / list idle vehicles
GO
USE RentACarDatabase
EXEC ListAllCarCust

SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, 
                     MvS.Fiyat from Modeller_ve_Siniflar as MvS join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID join Araba_Markalari as
                     A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID join Vites_Tipleri as V_Tip on
                    MvS.Vites_ID = V_Tip.Vites_ID join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID where MvS.Pasif_Adet > 0 and A_Snf.Sinif_Adi IN ('SUV','Lüks')
                    and V_Tip.Vites_Adi IN ('Düz','Benzin') and Y_Tip.Yakit_Adi IN ('Benzin')


 --List all car with informations. / TR: Kullanýma açýkta olsa kapalýda olsa bütün bilgileri listeler. (Personeller için)
CREATE PROCEDURE ListAllCarEmp 
	
	
		as	
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret, MvS.Aktif_Adet, MvS.Pasif_Adet, MvS.Toplam_Adet 
		from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		
GO

USE RentACarDatabase
EXEC ListAllCarEmp

-- ### CONSTRICT -> BRAND_ID ###
 
 --Vehicle listing by parameter(BRAND_ID) for customer / TR: Parametre olarak girilen marka id'sine göre gerekli araç bilgilerini listeler. (Müþteriler için.)
 CREATE PROCEDURE ListByBrandCust(@BRAND_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 and A_Mar.Marka_ID = @BRAND_ID -- Lists by car Brand id given as a parameter
GO

 --Vehicle listing by parameter(BRAND_ID) for employee / TR: Parametre olarak girilen marka id'sine göre bütün araç bilgilerini listeler. (Personel için.)
CREATE PROCEDURE ListByBrandEmp(@BRAND_ID int) 
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret, MvS.Aktif_Adet, MvS.Pasif_Adet, MvS.Toplam_Adet 
		from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where A_Mar.Marka_ID = @BRAND_ID -- Lists by car brand id given as a parameter

GO
-- ### CONSTRICT -> CLASS_ID ###
 
 --Vehicle listing by parameter(Class_ID) for customer / TR: Parametre olarak girilen sýnýf id'sine göre gerekli araç bilgilerini listeler. (Müþteriler için.)
 CREATE PROCEDURE ListByClassCust(@CLASS_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 and A_Snf.Sinif_ID = @CLASS_ID -- Lists by car class id given as a parameter
 
GO

 --Vehicle listing by parameter(Class_ID) for employee / TR: Parametre olarak girilen sýnýf id'sine göre bütün araç bilgilerini listeler. (Personel için.)
CREATE PROCEDURE ListByClassEmp(@CLASS_ID int) 
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret, MvS.Aktif_Adet, MvS.Pasif_Adet, MvS.Toplam_Adet 
		from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where A_Snf.Sinif_ID = @CLASS_ID -- Lists by car class id given as a parameter
GO
 ----#### CONSTRICT -> MODEL_ID ###
 --Vehicle listing by parameter(Model_ID) for customer / TR: Parametre olarak girilen model id'sine göre gerekli araç bilgilerini listeler. (Müþteriler için.)
 CREATE PROCEDURE ListByModelCust(@Model_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 and A_Mod.Model_ID = @Model_ID -- Lists by car model id given as a parameter

GO

 --Vehicle listing by parameter(Model_ID) for employee / TR: Parametre olarak girilen model id'sine göre bütün araç bilgilerini listeler. (Personel için.)
CREATE PROCEDURE ListByModelEmp(@Model_ID int) 
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret, MvS.Aktif_Adet, MvS.Pasif_Adet, MvS.Toplam_Adet 
		from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where A_Mod.Model_ID = @Model_ID -- Lists by car model id given as a parameter

GO
 ----#### CONSTRICT -> GEAR_ID ###
  --Vehicle listing by parameter(GEAR_ID) for customer / TR: Parametre olarak girilen vites id'sine göre gerekli araç bilgilerini listeler. (Müþteriler için.)
 CREATE PROCEDURE ListByGearCust(@GEAR_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 and V_Tip.Vites_ID = @GEAR_ID -- Lists by car gear id given as a parameter

GO

  --Vehicle listing by parameter(GEAR_ID) for employee / TR: Parametre olarak girilen vites id'sine göre gerekli araç bilgilerini listeler. (Personel için.)
 CREATE PROCEDURE ListByGearEmp(@GEAR_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where V_Tip.Vites_ID = @GEAR_ID  -- Lists by car gear id given as a parameter

GO

 ----#### CONSTRICT -> FUEL_ID ###
  --Vehicle listing by parameter(FUEL_ID) for customer / TR: Parametre olarak girilen yakýt id'sine göre gerekli araç bilgilerini listeler. (Müþteriler için.)
 CREATE PROCEDURE ListByFuelCust(@FUEL_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where MvS.Pasif_Adet > 0 and Y_Tip.Yakit_ID = @FUEL_ID -- Lists by car fuel id given as a parameter

GO

  --Vehicle listing by parameter(FUEL_ID) for employee / TR: Parametre olarak girilen yakýt id'sine göre gerekli araç bilgilerini listeler. (Personel için.)
 CREATE PROCEDURE ListByFuelEmp(@FUEL_ID int)
	
	AS
	RETURN 
		SELECT Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt, MvS.Fiyat as Ücret from Modeller_ve_Siniflar as MvS 
		join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID
		where Y_Tip.Yakit_ID = @FUEL_ID  -- Lists by car fuel id given as a parameter

GO



	 

--######### Making a list of specific vehicles with license plates according to certain features. / TR: Araç kayýtlarýný spesifik niteliklere göre listeleme. ##########

-- List Only Active Vehicles for employee / TR : Sadece kullanýmda olan aktif araçlarý listeler. Bu listeleme için durum niteliði aktif olan araçlar listelenmeli.
 CREATE PROCEDURE ListActiveCarEmp
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Durum = 'Aktif' -- Lists by activity

GO

-- List Only Passive Vehicles for employee / TR : Sadece kullanýmda olmayan pasif araçlarý listeler. Bu listeleme için durum niteliði pasif olan araçlar listelenmeli.
 CREATE PROCEDURE ListPassiveCarEmp
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Durum = 'Pasif' -- Lists by passivity
GO

  -- List Only specific Brand_ID Vehicles, for employee / TR : Sadece marka id'si girilen araçlarý listeler. 
 CREATE PROCEDURE ListCarByBrandEmp(@BRAND_ID int)
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Marka_ID = @BRAND_ID -- Lists by BRAND_ID

GO

  -- List Only specific MODEL_ID Vehicles, for employee / TR : Sadece model id'si girilen araçlarý listeler. 
 CREATE PROCEDURE ListCarByModelEmp(@MODEL_ID int)
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Model_ID = @MODEL_ID -- Lists by MODEL_ID

GO

 -- List Only specific CLASS_ID Vehicles, for employee / TR : Sadece sýnýf id'si girilen araçlarý listeler. 
 CREATE PROCEDURE ListCarByClassEmp(@CLASS_ID int)
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Sinif_ID = @CLASS_ID -- Lists by CLASS_ID

GO

 -- List Only specific GEAR_ID Vehicles, for employee / TR : Sadece vites id'si girilen araçlarý listeler. 
 CREATE PROCEDURE ListCarByGearEmp(@GEAR_ID int)
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Vites_ID = @GEAR_ID -- Lists by GEAR_ID

GO

 -- List Only specific FUEL_ID Vehicles, for employee / TR : Sadece yakýt id'si girilen araçlarý listeler. 
 CREATE PROCEDURE ListCarByFuelEmp(@FUEL_ID int)
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Yakit_ID = @FUEL_ID -- Lists by FUEL_ID

GO

 -- List Only first two digits of plate Vehicles, for employee / TR : Sadece ilk iki hanesi girilen parametre ile ayný olan plakalý araçlarý listeler. 
 CREATE PROCEDURE ListCarByPlateF2Emp(@Plate_xx nvarchar(2))
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Plaka like '@Plate_xx%' -- Lists by first two digits of plate

GO

 -- List Only specific plate vehicle, for employee / TR : Plaka bilgisi parametre olarak girilir, girilen plaka ile ayný olan plakalý araç listelenir.
 CREATE PROCEDURE ListCarByPlateEmp(@Plate nvarchar(8))
	
	AS
	RETURN 
		SELECT Plaka, Marka_Adi as Marka, Model_Adi as Model , Sinif_Adi as Sýnýf, Vites_Adi as Vites, Yakit_Adi as Yakýt from Arabalar as A
		join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
		join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID
		join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID
		join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID
		join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID
		where A.Plaka = '@Plate' -- Lists by first two digits of plate

GO