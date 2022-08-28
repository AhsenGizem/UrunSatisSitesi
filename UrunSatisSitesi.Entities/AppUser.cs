using System.ComponentModel.DataAnnotations;


namespace UrunSatisSitesi.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [Display(Name="Ad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="{0} Boş Geçilemez!"), EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Aktif?"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tatihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
