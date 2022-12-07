using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //Refactor edilecek
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda";

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandsListed = "Markalar listelendi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandNameInvalid = "Marka adı en az 2 karakter olmalı.";


        public static string CarAdded = "Araba eklendi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarNameOrDailyPriceInvalid = "Araba adı 2 karakterden fazla ve günlük fiyat 0'dan büyük olmalı.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorDeleted = "Renk silindi.";


        public static string UserAdded = "User eklendi.";
        public static string UserDeleted = "User silindi.";
        public static string UserUpdated = "User güncellendi.";


        public static string CustomerAdded = "Customer eklendi.";
        public static string CustomerDeleted = "Customer silindi.";
        public static string CustomerUpdated = "Customer güncellendi.";


        public static string RentalAdded = "Rental kaydı eklendi, araç kiralandı.";
        public static string RentalDeleted = "Rental silindi.";
        public static string RentalUpdated = "Rental güncellendi.";

        
        //public static string ReturnDateCannotBeNull = "Teslim tarihi mutlaka olmalıdır.";
        //public static string RentalDayLessThanZero = "Kiralanacak arabanın teslim ve alım tarihi sıfırdan büyük olmalıdır.";
        public static string RentalCarNotAvailable = "Kiralanacak araba daha teslim edilmemiş.";
        public static string FailedRentalDelete = "Teslim edilmemiş araç için kayıt silinemez.";


        //CarImage
        public static string CarImageLimitError = "Bir arabanın en fazla 5 resmi olabilir.";
        public static string NoInfo = "Böyle bir araç bilgisine ulaşılamadı.";

        public static string ImageUploaded = "Resim başarıyla yüklendi.";
        public static string ImageDeleted = "Resim başarıyla silindi.";
        public static string ImageUpdated = "Resim başarıyla güncellendi.";
        public static string NoImage = "Resim bulunamadı.";

        //JWT
        public static string AuthorizationDenied = "Bu sayfaya erişim izniniz yok.";

        public static string UserRegistered = "Kayıt başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre yanlış.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var.";
        public static string AccessTokenCreated = "Token oluşturuldu.";





    }
}
