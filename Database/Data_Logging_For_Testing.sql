--#Creating the database
--CREATE DATABASE RentACarDatabase
USE RentACarDatabase


--#Creating the tables/entities of the car rental application

--table of car brands
CREATE TABLE Araba_Markalari ( -- EN: Car_Brands
	Marka_ID int IDENTITY(1,1) PRIMARY KEY, -- EN:Brand_ID  => TR:Marka_ID
	Marka_Adi nvarchar(20) not null -- EN: Brand_Name
)
--table of car models
CREATE TABLE Araba_Modelleri ( -- EN: Car_Models
	Model_ID int IDENTITY(1,1) PRIMARY KEY,
	Marka_ID int not null  FOREIGN KEY REFERENCES Araba_Markalari(Marka_ID), -- EN: Brand_ID 
	Model_Adi nvarchar(20) not null, -- EN: Model_Name
)
--table of car classes like: SUV,Sedan...
CREATE TABLE Araba_Siniflari ( -- EN: Car_Classes
	Sinif_ID int IDENTITY(1,1) PRIMARY KEY, -- EN:Class_ID 
	Sinif_Adi nvarchar(15) not null -- EN: Class_Name
)
--table of gear types
CREATE TABLE Vites_Tipleri ( -- EN: Gear_Types
	Vites_ID int IDENTITY(1,1) PRIMARY KEY,	-- EN: Gear_ID
	Vites_Adi nvarchar(10) not null		-- EN: Gear_Name
)
--table of fuel types
CREATE TABLE Yakit_Tipleri ( -- EN: Fuel_Types
	Yakit_ID int IDENTITY(1,1) PRIMARY KEY,	-- EN: Fuel_ID
	Yakit_Adi nvarchar(10) not null		-- EN: Fuel_Name
)
--Intersect table
CREATE TABLE Modeller_ve_Siniflar ( -- EN: Models_and_Classes
	Model_ID int  REFERENCES Araba_Modelleri(Model_ID) not null, 
	Sinif_ID int REFERENCES Araba_Siniflari(Sinif_ID) not null, 
	Vites_ID int REFERENCES Vites_Tipleri(Vites_ID) not null,
	Yakit_ID int REFERENCES Yakit_Tipleri(Yakit_ID) not null,
	PRIMARY KEY(Model_ID,Sinif_ID,Vites_ID,Yakit_ID),
	Fiyat float not null, --EN: Price
	Aktif_Adet int not null, --EN:Active_Number (Number of vehicles actively serving the customer.) (The above mentioned vehicle is mentioned, not all vehicles.)
	Pasif_Adet int not null, --EN: Passive_Number (Number of vehicles not actively serving the customer.) (The above mentioned vehicle is mentioned, not all vehicles.)
	Toplam_Adet int not null, --EN: Total_Number  (Number of all vehicles) (The above mentioned vehicle is mentioned, not all vehicles.)
)


CREATE TABLE Arabalar ( -- EN: Cars/Vehicles
	Plaka nvarchar(8) PRIMARY KEY, -- EN : Plate (Vehicle Plate)
	Marka_ID int  FOREIGN KEY REFERENCES Araba_Markalari(Marka_ID) not null, 
	Model_ID int  FOREIGN KEY REFERENCES Araba_Modelleri(Model_ID) not null, 
	Sinif_ID int FOREIGN KEY REFERENCES Araba_Siniflari(Sinif_ID) not null, 
	Vites_ID int FOREIGN KEY REFERENCES Vites_Tipleri(Vites_ID) not null,
	Yakit_ID int FOREIGN KEY REFERENCES Yakit_Tipleri(Yakit_ID) not null,
	Durum nvarchar(5) not null -- EN: State (Is the vehicle passive or active?) Aktif/Pasif
)

CREATE TABLE Musteriler ( -- EN: Customers
	Musteri_ID int IDENTITY(10000,1) not null, -- EN: Customer_ID 10000,10001...
	TCKN  char(11) not null, --EN: Citizenship_Number
	Musteri_Adi char(25) not null, -- EN: Customer_Name
	Musteri_Soyadi char(15) not null, -- EN: Customer_LastName
	Musteri_Sifre nvarchar(20) not null, -- EN: Customer_Password
	Musteri_Telefon char(10) not null, -- EN: Customer_PhoneNumber
	PRIMARY KEY(Musteri_ID,TCKN)
)

CREATE TABLE Takip_Formlarý ( -- EN: Tracking_Forms
	Takip_ID int IDENTITY(1,1) PRIMARY KEY, -- EN: Tracking_ID
	Musteri_ID int not null,
	Musteri_TCKN char(11) not null,
	Plaka nvarchar(8)  FOREIGN KEY REFERENCES Arabalar(Plaka) not null,
	Alis_Tarihi DATE not null, -- EN : Purchase_Date
	Ýade_Tarihi DATE not null, -- EN: Return_Date
	Hizmet_Bedeli float not null, -- EN: Service_Fee
	FOREIGN KEY (Musteri_ID, Musteri_TCKN) REFERENCES Musteriler (Musteri_ID,TCKN)
)

CREATE TABLE Personeller( --EN: Employees
	Personel_ID int IDENTITY(100,1) PRIMARY KEY, --EN: Employee_ID 100,101,102...
	Pesonel_Adi char(25) not null, --EN: Employee_Name
	Personel_Soyadi char(20) not null, --EN: Employee_LastName
	Personel_Sifre char(20) not null, --EN: Employee_Password
	Perosel_Telefon char(10) not null, -- EN: Employee_PhoneNumber
)

CREATE TABLE Yoneticiler ( --EN: Managers
	Yonetici_ID int IDENTITY(1,1) PRIMARY KEY, --EN: Manager_ID
	Personel_ID int FOREIGN KEY REFERENCES Personeller(Personel_ID) not null,
	Yonetici_Adi char(25) not null, --EN: Manager_Name
	Yonetici_Soyadi char(20) not null --EN: Manager_LastName
)

--All entity tables have been created.





