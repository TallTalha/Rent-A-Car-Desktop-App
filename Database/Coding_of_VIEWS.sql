USE RentACarDatabase
GO

CREATE VIEW ButunAraclarýnTablosu 
	AS (SELECT Plaka,Marka_Adi,Model_Adi,Sinif_Adi,Vites_Adi,Yakit_Adi,Durum FROM Arabalar as A 
                 join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
                 join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID 
                 join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID 
                 join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID 
                 join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID)

GO

SELECT * FROM ButunAraclarýnTablosu as a WHERE A.Plaka = '34ANZ001'

GO

CREATE VIEW ButunAktifAraclarýnTablosu 
	AS (SELECT Plaka,Marka_Adi,Model_Adi,Sinif_Adi,Vites_Adi,Yakit_Adi,Durum FROM Arabalar as A 
                 join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
                 join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID 
                 join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID 
                 join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID 
                 join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID WHERE Durum='Aktif')

GO

CREATE VIEW ButunPasifAraclarýnTablosu 
	AS (SELECT Plaka,Marka_Adi,Model_Adi,Sinif_Adi,Vites_Adi,Yakit_Adi,Durum FROM Arabalar as A 
                 join Araba_Modelleri A_Mod on A.Model_ID = A_Mod.Model_ID 
                 join Araba_Markalari as A_Mar on A.Marka_ID = A_Mar.Marka_ID 
                 join Araba_Siniflari as A_Snf on A.Sinif_ID = A_Snf.Sinif_ID 
                 join Vites_Tipleri as V_Tip on A.Vites_ID = V_Tip.Vites_ID 
                 join Yakit_Tipleri as Y_Tip on A.Yakit_ID = Y_Tip.Yakit_ID WHERE Durum='Pasif')

GO