using CarBook.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Persistence
{
    public static class SeedData
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {

            }
        }

        public static List<About> GetAbouts()
        {
            var abouts = new List<About>
            {
                new About
                {
                    Title = "Hakkımızda",
                    Description = "Firmamız, 2005 yılından bu yana müşterilerine kaliteli hizmet sunmayı ilke edinmiştir. Uzman ekibimiz ve geniş ürün yelpazemiz ile sizlere en iyi hizmeti sunmak için çalışıyoruz.",
                    ImageUrl = "https://example.com/images/about-us.jpg"
                },
                new About
                {
                    Title = "Misyonumuz",
                    Description = "Misyonumuz, müşterilerimize en kaliteli ürün ve hizmetleri sunarak onların memnuniyetini sağlamak ve sektörde lider bir firma olmaktır.",
                    ImageUrl = "https://example.com/images/mission.jpg"
                },
                new About
                {
                    Title = "Vizyonumuz",
                    Description = "Vizyonumuz, yenilikçi çözümlerle müşterilerimizin ihtiyaçlarını karşılamak ve sürdürülebilir bir büyüme sağlamaktır.",
                    ImageUrl = "https://example.com/images/vision.jpg"
                }
            };
            return abouts;
        }
        public static List<Service> GetServices()
        {
            var services = new List<Service>
        {
            new Service
            {
                ServiceID = 1,
                Title = "Hızlı Teslimat",
                Description = "Siparişlerinizi en kısa sürede teslim ediyoruz.",
                IconUrl = "https://example.com/icons/fast-delivery.png"
            },
            new Service
            {
                ServiceID = 2,
                Title = "7/24 Müşteri Desteği",
                Description = "Her zaman yanınızdayız! 7/24 müşteri desteği sunuyoruz.",
                IconUrl = "https://example.com/icons/customer-support.png"
            },
            new Service
            {
                ServiceID = 3,
                Title = "Uygun Fiyatlar",
                Description = "Kaliteli hizmeti uygun fiyatlarla sunuyoruz.",
                IconUrl = "https://example.com/icons/affordable-prices.png"
            },
            new Service
            {
                ServiceID = 4,
                Title = "Güvenli Ödeme",
                Description = "Güvenli ödeme yöntemleri ile alışveriş yapın.",
                IconUrl = "https://example.com/icons/secure-payment.png"
            },
            new Service
            {
                ServiceID = 5,
                Title = "Kolay İade",
                Description = "Kolay ve hızlı iade süreci ile güvenli alışveriş.",
                IconUrl = "https://example.com/icons/easy-return.png"
            },
            new Service
            {
                ServiceID = 6,
                Title = "Geniş Ürün Yelpazesi",
                Description = "Farklı ihtiyaçlarınıza uygun geniş ürün yelpazesi.",
                IconUrl = "https://example.com/icons/wide-range.png"
            }
        };
            return services;
        }
        public static List<SocialMedia> GetSocialMedias()
        {
            var socialMedias = new List<SocialMedia>
            {
                new SocialMedia
                {
                    SocialMediaId = 1,
                    Name = "Facebook",
                    Url = "https://www.facebook.com/example",
                    Icon = "fab fa-facebook-f"
                },
                new SocialMedia
                {
                    SocialMediaId = 2,
                    Name = "Twitter",
                    Url = "https://www.twitter.com/example",
                    Icon = "fab fa-twitter"
                },
                new SocialMedia
                {
                    SocialMediaId = 3,
                    Name = "Instagram",
                    Url = "https://www.instagram.com/example",
                    Icon = "fab fa-instagram"
                },
                new SocialMedia
                {
                    SocialMediaId = 4,
                    Name = "LinkedIn",
                    Url = "https://www.linkedin.com/company/example",
                    Icon = "fab fa-linkedin-in"
                },
                new SocialMedia
                {
                    SocialMediaId = 5,
                    Name = "YouTube",
                    Url = "https://www.youtube.com/example",
                    Icon = "fab fa-youtube"
                },
                new SocialMedia
                {
                    SocialMediaId = 6,
                    Name = "WhatsApp",
                    Url = "https://wa.me/1234567890",
                    Icon = "fab fa-whatsapp"
                }
            };
            return socialMedias;
        }
        public static Banner GetBanner()
        {
            var banner = new Banner
            {
                Title = "Araç Kiralama Hizmeti",
                Description = "Uygun fiyatlarla güvenilir araç kiralama hizmeti sunuyoruz. Hemen rezervasyon yapın!",
                VideoDescription = "Araç kiralama sürecimizi anlatan tanıtım videosu.",
                VideoUrl = "https://www.youtube.com/watch?v=example1"
            };
            return banner;
        }
        public static FooterAddress GetFooterAddress()
        {
            var footerAddress = new FooterAddress
            {
                Description = "Ana Ofis",
                Address = "1234 Sokak, No: 56, İstanbul, Türkiye",
                Phone = "+90 212 123 45 67",
                Email = "info@arackiralama.com"
            };
            return footerAddress;
        }
        public static List<Contact> GetContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact
                {

                    Name = "Ahmet Yılmaz",
                    Email = "ahmet.yilmaz@example.com",
                    Subject = "Araç Kiralama Süreci",
                    Message = "Araç kiralamak için gerekli belgeler nelerdir?",
                    SendDate = new DateTime(2023, 10, 1)
                },
                new Contact
                {

                    Name = "Ayşe Kaya",
                    Email = "ayse.kaya@example.com",
                    Subject = "Fiyat Bilgisi",
                    Message = "Ekonomik sınıf bir araç için günlük kira bedeli ne kadar?",
                    SendDate = new DateTime(2023, 10, 2)
                },
                new Contact
                {

                    Name = "Mehmet Demir",
                    Email = "mehmet.demir@example.com",
                    Subject = "Teslimat Noktası",
                    Message = "Aracı havaalanından teslim alabilir miyim?",
                    SendDate = new DateTime(2023, 10, 3)
                },
                new Contact
                {

                    Name = "Fatma Şahin",
                    Email = "fatma.sahin@example.com",
                    Subject = "Sigorta Kapsamı",
                    Message = "Kiraladığım aracın sigortası kaza durumunda neyi kapsar?",
                    SendDate = new DateTime(2023, 10, 4)
                },
                new Contact
                {

                    Name = "Emre Koç",
                    Email = "emre.koc@example.com",
                    Subject = "Uzun Dönem Kiralama",
                    Message = "3 aylık araç kiralama için özel indirimleriniz var mı?",
                    SendDate = new DateTime(2023, 10, 5)
                },
                new Contact
                {

                    Name = "Zeynep Arslan",
                    Email = "zeynep.arslan@example.com",
                    Subject = "Çocuk Koltuğu",
                    Message = "Araçla birlikte çocuk koltuğu temin edebilir miyim?",
                    SendDate = new DateTime(2023, 10, 6)
                },
                new Contact
                {

                    Name = "Canan Öztürk",
                    Email = "canan.ozturk@example.com",
                    Subject = "İptal Politikası",
                    Message = "Rezervasyonumu iptal edersem ücret iadesi alabilir miyim?",
                    SendDate = new DateTime(2023, 10, 7)
                },
                new Contact
                {

                    Name = "Burak Çelik",
                    Email = "burak.celik@example.com",
                    Subject = "Yakıt Politikası",
                    Message = "Aracı dolu depo ile mi teslim almalıyım?",
                    SendDate = new DateTime(2023, 10, 8)
                }
            };
            return contacts;
        }
        public static List<Testimonial> GetTestimonials()
        {
            var testimonials = new List<Testimonial>
            {
                new Testimonial {  Name = "Ahmet Yılmaz", Title = "Müşteri", Comment = "Harika bir hizmet deneyimi yaşadım, kesinlikle tavsiye ederim!", ImageUrl = "https://example.com/ahmet.jpg" },
                new Testimonial {  Name = "Ayşe Kaya", Title = "CEO", Comment = "Ürünlerin kalitesi ve müşteri hizmetleri gerçekten etkileyici.", ImageUrl = "https://example.com/ayse.jpg" },
                new Testimonial {  Name = "Mehmet Demir", Title = "Yazılım Geliştirici", Comment = "Kullanımı kolay ve çok işlevsel bir ürün, teşekkürler!", ImageUrl = "https://example.com/mehmet.jpg" },
                new Testimonial {  Name = "Fatma Şahin", Title = "Öğretmen", Comment = "Bu ürün sayesinde işlerim çok daha kolaylaştı, çok memnunum.", ImageUrl = "https://example.com/fatma.jpg" },
                new Testimonial {  Name = "Emre Koç", Title = "Girişimci", Comment = "Müşteri desteği çok hızlı ve çözüm odaklı, tebrikler!", ImageUrl = "https://example.com/emre.jpg" },
                new Testimonial {  Name = "Zeynep Arslan", Title = "Tasarımcı", Comment = "Tasarımlarımı bu ürünle daha profesyonel hale getirdim, teşekkürler!", ImageUrl = "https://example.com/zeynep.jpg" },
                new Testimonial {  Name = "Canan Öztürk", Title = "Doktor", Comment = "Hizmet kalitesi ve güvenilirliği için teşekkür ederim.", ImageUrl = "https://example.com/canan.jpg" },
                new Testimonial {  Name = "Burak Çelik", Title = "Mühendis", Comment = "Teknik destek ekibi çok bilgili ve yardımsever, harika bir deneyim!", ImageUrl = "https://example.com/burak.jpg" },
                new Testimonial {  Name = "Selin Yıldız", Title = "Öğrenci", Comment = "Ödevlerimi bu ürünle çok daha hızlı tamamlayabiliyorum, teşekkürler!", ImageUrl = "https://example.com/selin.jpg" },
                new Testimonial {  Name = "Cemal Aydın", Title = "Satış Danışmanı", Comment = "Ürünün sunduğu özellikler işimi kolaylaştırdı, çok memnunum.", ImageUrl = "https://example.com/cemal.jpg" },
                new Testimonial {  Name = "Elif Korkmaz", Title = "Pazarlama Uzmanı", Comment = "Pazarlama stratejilerimizi bu ürünle daha etkili hale getirdik.", ImageUrl = "https://example.com/elif.jpg" },
                new Testimonial {  Name = "Hakan Yılmaz", Title = "Finans Danışmanı", Comment = "Finansal raporlamaları bu ürünle çok daha kolay yapıyorum.", ImageUrl = "https://example.com/hakan.jpg" },
                new Testimonial {  Name = "Gizem Akın", Title = "İç Mimar", Comment = "Tasarımlarımı bu ürünle daha detaylı ve özgün hale getirdim.", ImageUrl = "https://example.com/gizem.jpg" },
                new Testimonial {  Name = "Murat Özdemir", Title = "Yönetici", Comment = "Ekip olarak bu ürünü kullanmaktan çok memnunuz, teşekkürler!", ImageUrl = "https://example.com/murat.jpg" },
                new Testimonial {  Name = "Seda Erdem", Title = "Editör", Comment = "İçerik yönetimi bu ürünle çok daha kolay ve keyifli hale geldi.", ImageUrl = "https://example.com/seda.jpg" }
            };
            return testimonials;
        }
    }
}
