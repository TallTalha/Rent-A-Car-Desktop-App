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

--########  Updating operations ##########
GO

CREATE PROCEDURE changeStateActive(@Plaka nvarchar(8))

AS

UPDATE Arabalar  SET Durum = 'Aktif' WHERE Plaka = '@Plaka' 

GO

CREATE PROCEDURE changeStatePassive(@Plaka nvarchar(8))
AS
UPDATE Arabalar  SET Durum = 'Pasif' WHERE Plaka = '@Plaka' 

GO
DROP PROCEDURE changeStateActiveAndUpdate
go

CREATE PROCEDURE changeStateActiveAndUpdate(@Plaka nvarchar(8))

AS
DECLARE @BRAND_ID int = (SELECT a.Marka_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @MODEL_ID int = (SELECT a.Model_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @CLASS_ID int = (SELECT a.Sinif_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @GEAR_ID int = (SELECT a.Vites_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @FUEL_ID int = (SELECT a.Yakit_ID FROM Arabalar as a where a.Plaka = @Plaka)
UPDATE Arabalar  SET Durum = 'Aktif' WHERE Plaka = @Plaka
UPDATE Modeller_ve_Siniflar SET Aktif_Adet+=1 , Pasif_Adet -=1 WHERE Model_ID=@MODEL_ID and Sinif_ID=@CLASS_ID and Vites_ID=@GEAR_ID and Yakit_ID=@FUEL_ID 

GO

EXEC changeStateActiveAndUpdate '34ANZ002'
UPDATE Arabalar  SET Durum = 'Aktif' WHERE Plaka = '34ANZ001'
UPDATE Arabalar  SET Durum = 'Aktif' WHERE Plaka = '34ANZ001'

GO
USE RentACarDatabase
DROP PROCEDURE changeStatePassiveAndUpdate
go
CREATE PROCEDURE changeStatePassiveAndUpdate(@Plaka nvarchar(8))
AS
DECLARE @BRAND_ID int = (SELECT a.Marka_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @MODEL_ID int = (SELECT a.Model_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @CLASS_ID int = (SELECT a.Sinif_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @GEAR_ID int = (SELECT a.Vites_ID FROM Arabalar as a where a.Plaka = @Plaka)
DECLARE @FUEL_ID int = (SELECT a.Yakit_ID FROM Arabalar as a where a.Plaka = @Plaka)
UPDATE Arabalar  SET Durum = 'Pasif' WHERE Plaka = @Plaka
UPDATE Modeller_ve_Siniflar SET Aktif_Adet-=1 , Pasif_Adet +=1 WHERE Model_ID=@MODEL_ID and Sinif_ID=@CLASS_ID and Vites_ID=@GEAR_ID and Yakit_ID=@FUEL_ID

GO

EXEC changeStatePassiveAndUpdate '34ANZ001'
EXEC changeStatePassiveAndUpdate '34ANZ002'
EXEC changeStatePassiveAndUpdate '34ANZ003'

DELETE FROM Takip_Formlarý
UPDATE Araba_Modelleri SET Model_Adi='AMG GT-63' WHERE Model_ID=40 and Marka_ID=29

go
CREATE PROCEDURE getPlateOfSelectedCar(@BRAND_ID int,@MODEL_ID int, @CLASS_ID int, @GEAR_ID int, @FUEL_ID int, @PLATE nvarchar(8) OUTPUT)
AS
RETURN
SET @PLATE = (SELECT TOP 1 a.Plaka FROM Arabalar as a WHERE a.Marka_ID=@BRAND_ID and a.Model_ID = @MODEL_ID and a.Sinif_ID = @CLASS_ID and a.Vites_ID =  @GEAR_ID and a.Yakit_ID = @FUEL_ID and a.Durum = 'Pasif')

GO
--DECLARE @a nvarchar(8)
--EXEC  getPlateOfSelectedCar 1,1,1,1,1,a
--EXEC changeStateActiveAndUpdate a
DROP PROCEDURE getPlateWithAttOfSelectedCar
GO

CREATE PROCEDURE getPlateWithAttOfSelectedCar( @BRAND_NAME nvarchar(20),@MODEL_NAME nvarchar(20), @CLASS_NAME nvarchar(15), @GEAR_NAME nvarchar(10), @FUEL_NAME nvarchar(10) )
AS
DECLARE @BRAND_ID int = (SELECT a.Marka_ID FROM Araba_Markalari as a where a.Marka_Adi = @BRAND_NAME)
DECLARE @MODEL_ID int = (SELECT a.Model_ID FROM Araba_Modelleri as a where a.Model_Adi = @MODEL_NAME)
DECLARE @CLASS_ID int = (SELECT a.Sinif_ID FROM Araba_Siniflari as a where a.Sinif_Adi = @CLASS_NAME)
DECLARE @GEAR_ID int = (SELECT a.Vites_ID FROM Vites_Tipleri as a where a.Vites_Adi = @GEAR_NAME)
DECLARE @FUEL_ID int = (SELECT a.Yakit_ID FROM Yakit_Tipleri as a where a.Yakit_Adi = @FUEL_NAME)
SELECT TOP 1 Plaka FROM Arabalar as a WHERE a.Marka_ID=@BRAND_ID and a.Model_ID = @MODEL_ID and a.Sinif_ID = @CLASS_ID and a.Vites_ID = @GEAR_ID and a.Yakit_ID = @FUEL_ID and a.Durum = 'Pasif'

GO
declare @result nvarchar(8)
EXEC getPlateWithAttOfSelectedCar 'Fiat','Egea','Ekonomi','Düz','Benzin'
SELECT TOP 1 Plaka FROM Arabalar as a WHERE a.Marka_ID=21 and a.Model_ID = 13 and a.Sinif_ID = 1 and a.Vites_ID = 1 and a.Yakit_ID = 1 and a.Durum = 'Pasif'


CREATE PROCEDURE changePropOfSelectedCar(@PLATE nvarchar(8),@BRAND_ID int,@MODEL_ID int, @CLASS_ID int, @GEAR_ID int, @FUEL_ID int)
AS
RETURN
UPDATE Arabalar  SET  Marka_ID=@BRAND_ID , Model_ID = @MODEL_ID , Sinif_ID = @CLASS_ID , Vites_ID =  @GEAR_ID , Yakit_ID = @FUEL_ID WHERE Plaka = '@PLATE'

GO




