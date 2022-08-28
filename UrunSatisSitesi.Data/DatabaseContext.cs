using Microsoft.EntityFrameworkCore;
using UrunSatisSitesi.Entities;

namespace UrunSatisSitesi.Data
{
    //Bu sınıfta framework kullanacağımız için Solution kısmından runSatisSitesi.Data projesine sağ tıklayıp manage packages menüsünde tıklıyoruz. Açılan pencerede Browse sekmesine tıklayıp "Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools" paketlerini yüklüyoruz.
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        //Katmanlı mimaride bir katman (UrunSatisSitesi.Data katmanı gibi) başka bir katmana erişecekse bunu solutions kısmında projenin altındali dependencies bölümüne sağ tıklayıp add project reference diyerek açılan pencereden ilgili katmanı (UrunSatisSitesi.Entities gibi) yandaki check e tik koyarak kaydet deyip işlemi tamamlayabiliriz. Veya aşağıda yaptığımız gibi Appuser db set ini yazıp çıkan ampulden add project reference menüsüne tıklayıp bu işlemin yapılmasını sağlayabiliriz. Yalnız bu noktada dikkat etmemiz gereken nokta yazım yanlışı yapmamak! visual studio bulamayabilir yanlış yazarsak.
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        //DBset leri oluşturduktan sonra aşağıdakş metodu override yapıp bir boşluk bırakıp on yazıp gelen seçeneklerden OnConfiguring i seçip enter a basarak oluşturuyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Burada optionsBuilder ı kullanarak sql server ayarlarımızı belirleyebiliyoruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=UrunSatisSitesi"); //bu metot ile uygulamada sql server kullanacağımızı belirttik.
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI : Data annotations taki tablo ve property özelliklerini yapılandırabileceğimiz bir diğer yöntemdir.
            modelBuilder.Entity<AppUser>().Property(a => a.Name) //Entitilerimizden appuser ın propertilerinden Name alanı için 
            .IsRequired() // Bu property yi zorunlu alan yap
            .HasColumnType("varchar(50)") // Name alanının sql deki kolon tipi varchar(50) olsun
            .HasMaxLength(50) //kolon karakter uzunluğu
            ;
            modelBuilder.Entity<AppUser>().Property(s => s.Surname).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(s => s.Email).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(p => p.Phone).HasColumnType("nvarchar(15)");
            modelBuilder.Entity<AppUser>().Property(un => un.Username).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(p => p.Password).IsRequired().HasColumnType("nvarchar(50)");
            // FluentAPI ile veritabanını oluşturduktan sonra ilk kaydı ekleme
            modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = 1,
                Username ="Admin",
                Password ="123",
                Email = "admin@urunsatissitesi.com",
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                Surname = "Administrator",

            }) ;
            base.OnModelCreating(modelBuilder);
        }

    }
}
