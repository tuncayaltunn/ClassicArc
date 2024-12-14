using System;
using Core.Entities.Concrete;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Ürün eklendi";
		public static string ProductNameInvalid = "Ürün ismi geçersiz";
		public static string MaintenanceTime = "Bakım zamanı";
		public static string ProductListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Şifre yanlış";
        internal static string SuccessfulLogin = "Başarılı giriş yapıldı";
        internal static string UserAlreadyExists = "Kullanıcı zaten var";
        internal static string AccessTokenCreated = "Access Token oluşturuldu";
    }
}

