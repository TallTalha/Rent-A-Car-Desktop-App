# Rent-A-Car-Desktop-App
Rent A Car uygulamasının veritabanını oluştururken temel aldığı talimatlar.
Instructions on which the Rent A Car application is based when creating its database.

# IN TURKISH
- Müşterilerin, personelin ve yöneticinin yetkileri farklı olacağından bu 3 varlığa  özel işlemler tanımlanmalı.
 Bu işlemler sorgu, hesaplama ve "UPDATE,DELETE,INSERT..." gibi veri manipülasyonları olmak üzere 3 ana gruba ayrılır.

- " CREATE,UPDATE,READ,DELETE,INSERT " İşlemlerini Stored Procedures " CRETAE PROCEDURE... " ile tanımlayacağız.
-   Döndürülmesi gerekli olan hesaplamaları Fonksiyolar " CREATE FUNCTION... " ile tanımlayacağız.

- Önce iş kuralları çerçevesinde düşünebildiğim bütün operasyonları hazırlayacağım sonrasında geri bildirimler ile operasyonları genişleteceğim veya daraltacağım.
-  Operasyon ve yetkileri görebileceğimiz dış bir plan oluşturmak süreci optimize eder.

### Müşteri Operasyonları;
- Modeller ve Sınıflar tablosunu okuyabilmek.
- Müşteri ödemeyi tamamladıktan sonra bir araba kaydının durum özelliğini aktif olarak değişitirebilir (Bu vesileyle, modeller ve sınıflar tablosundaki pasif ve aktif araç sayısı değişecektir).
- Sadece müşteriye ait olan takip formalarının müşteri tarafından okunması sağlanır, bu okumada hizmetine sunulan aracın özellikerinide görebilmeli.
- Müşterinin belirlerdiği tarihe ulaşınca aracın durumu otomatik olarak bir fonksiyon ile pasif duruma geçer.

### Personel Operasyonları;
- Personel, personel ve yönetici tablosu haricindeki tablolarda yetki alanların sınırlarına göre veri manipülasyonu yapabilmesi sağlanır.

### Yönetici Operasyonları;
- Yönetici, bütün tablolarda yöneticinin yetki alanların sınırlarına göre veri manipülasyonu yapabilmesi sağlanır.
  

# IN ENGLISH
- Since the authorizations of customers, personnel and managers will be different, operations specific to these 3 entities should be defined.
- These operations are divided into 3 main groups as query, calculation and data manipulations such as "UPDATE, DELETE, INSERT...".

- I will define  " CREATE,UPDATE,READ,DELETE,INSERT " operations with "Stored Procedures" / " CRETAE PROCEDURE.. ".
- I will define the calculations that need to be returned with the "Functions" / " CREATE FUNCION... ".

- First, I will prepare all the operations I can think of within the framework of business rules, then I will expand or narrow the operations with feedback.
- Creating an external picture of operations and authorizations optimizes the process.

### Customer Operations;
- To be able to read the Models and Classes table.
- The customer can actively change the status attribute of a car registration after completing the payment (Hereby, the number of passive/active vehicles in the models and classes table will change).
- Only the tracking forms belonging to the customer can be read by the customer, in this reading he should be able to see the features of the vehicle offered to his service.
- When the customer reaches the date set, the vehicle's status automatically switches to a passive state with a function.

### Employee Operations;
- It is ensured that data manipulation can be made according to the limits of the authorized areas in the tables other than the employee, personnel and manager table.

### Administrator Operations;
- Administrator, in all tables, allows the administrator to manipulate data according to the limits of the areas of authority.
