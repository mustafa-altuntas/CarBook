using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Persistence
{
    public static class SeedData
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CarBookContext>();
                context.Database.Migrate();
                if (context.Abouts.Any()) return;

                context.Abouts.AddRange(GetAbouts());
                context.Services.AddRange(GetServices());
                context.SocialMedias.AddRange(GetSocialMedias());
                context.Banners.AddRange(GetBanner());
                context.FooterAddresses.AddRange(GetFooterAddress());
                context.Contacts.AddRange(GetContacts());
                context.Testimonials.AddRange(GetTestimonials());
                context.Categories.AddRange(GetCategories());
                context.Authors.AddRange(GetAuthors());
                context.TagClouds.AddRange(GetTagClouds());
                context.SaveChanges();


                context.Blogs.AddRange(GetBlogs());
                context.SaveChanges(); 

                context.TagCloudBlogs.AddRange(GetTagCloudBlogs());
                context.Comments.AddRange(GetComments());
                context.SaveChanges();
            }
        }

        public static List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Araç Kiralama Rehberi" },
                new Category { CategoryId = 2, Name = "Seyahat ve Rotalar" },
                new Category { CategoryId = 3, Name = "Araç Bakım ve İpuçları" },
                new Category { CategoryId = 4, Name = "Yasal Düzenlemeler" },
                new Category { CategoryId = 5, Name = "Sigorta ve Güvence" },
                new Category { CategoryId = 6, Name = "Elektrikli ve Hibrit Araçlar" }
            };
            return categories;
        }
        public static List<Author> GetAuthors()
        {
            var authors = new List<Author>()
            {
                new Author
            {
                AuthorID = 1,
                Name = "Ahmet Yılmaz",
                ImageUrl = "https://example.com/images/ahmet.jpg",
                Description = "Uzun yıllardır otomotiv sektöründe içerik üretmektedir.",
            },
                new Author
                {
                    AuthorID = 2,
                    Name = "Elif Demir",
                    ImageUrl = "https://example.com/images/elif.jpg",
                    Description = "Araç kiralama, sigorta ve yolculuk güvenliği konularında yazılar yazıyor.",
                },
                new Author
                {
                    AuthorID = 3,
                    Name = "Mehmet Koca",
                    ImageUrl = "https://example.com/images/mehmet.jpg",
                    Description = "Elektrikli ve hibrit araçlar hakkında kapsamlı analizler yapmaktadır.",
                },
                new Author
            {
                AuthorID = 4,
                Name = "Zeynep Kaya",
                ImageUrl = "https://example.com/images/zeynep.jpg",
                Description = "Yolculuk planlama, rota önerileri ve araç kiralama ipuçları üzerine yazılar yazmaktadır.",
            }
            };
            return authors;
        }

        public static List<Comment> GetComments()
        {
            var comments = new List<Comment>()
            {
                new Comment
                {
                    CommentID = 1,
                    Name = "Ali Veli",
                    Email = "ali.veli@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Description = "Çok faydalı bir içerik olmuş, araç kiralama konusunda kafamdaki sorular netleşti. Teşekkürler!",
                    BlogID = 1
                },
                new Comment
                {
                    CommentID = 2,
                    Name = "Ayşe Yılmaz",
                    Email = "ayse.yilmaz@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-9),
                    Description = "Araç sigortaları hakkında daha fazla bilgi alabilir miyiz? Detaylı bir yazı bekliyoruz.",
                    BlogID = 1
                },
                new Comment
                {
                    CommentID = 3,
                    Name = "Mehmet Demir",
                    Email = "mehmet.demir@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-8),
                    Description = "Elektrikli araç kiralama hakkında yazılanları çok beğendim, çok açıklayıcıydı.",
                    BlogID = 1
                },
                new Comment
                {
                    CommentID = 4,
                    Name = "Zeynep Kaya",
                    Email = "zeynep.kaya@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-7),
                    Description = "Kiralık araçlarla uzun yol deneyimleri hakkında bir blog yazısı paylaşabilir misiniz?",
                    BlogID = 1
                },
                new Comment
                {
                    CommentID = 5,
                    Name = "Burak Özkan",
                    Email = "burak.ozkan@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-6),
                    Description = "SUV kiralamak istiyorum, uzun yol için önerdiğiniz modeller var mı?",
                    BlogID = 2
                },
                new Comment
                {
                    CommentID = 6,
                    Name = "Emine Arslan",
                    Email = "emine.arslan@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                    Description = "Fiyat-performans açısından en uygun araç kiralama seçenekleri nelerdir?",
                    BlogID = 2
                },
                new Comment
                {
                    CommentID = 7,
                    Name = "Serkan Doğan",
                    Email = "serkan.dogan@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-4),
                    Description = "Araç teslim ederken nelere dikkat etmek gerekiyor? Ekstra ücret çıkmaması için ipuçları paylaşır mısınız?",
                    BlogID = 2
                },
                new Comment
                {
                    CommentID = 8,
                    Name = "Gizem Kılıç",
                    Email = "gizem.kilic@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-3),
                    Description = "Lüks araç kiralama deneyimimi paylaşmak isterim, çok güzel bir süreçti!",
                    BlogID = 2
                },
                new Comment
                {
                    CommentID = 9,
                    Name = "Hakan Yıldırım",
                    Email = "hakan.yildirim@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    Description = "Kısa süreli kiralama ile uzun süreli kiralama arasındaki farkları anlatan bir içerik paylaşabilir misiniz?",
                    BlogID = 3
                },
                new Comment
                {
                    CommentID = 10,
                    Name = "Melis Çelik",
                    Email = "melis.celik@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    Description = "Araç kiralarken kredi kartı zorunlu mu? Alternatif ödeme yöntemleri hakkında bilgi verir misiniz?",
                    BlogID = 3
                },
                new Comment
                {
                    CommentID = 11,
                    Name = "Emine Arslan",
                    Email = "emine.arslan@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                    Description = "Fiyat-performans açısından en uygun araç kiralama seçenekleri nelerdir?",
                    BlogID = 3
                },
                new Comment
                {
                    CommentID = 12,
                    Name = "Serkan Doğan",
                    Email = "serkan.dogan@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-4),
                    Description = "Araç teslim ederken nelere dikkat etmek gerekiyor? Ekstra ücret çıkmaması için ipuçları paylaşır mısınız?",
                    BlogID = 3
                },
                new Comment
                {
                    CommentID = 13,
                    Name = "Gizem Kılıç",
                    Email = "gizem.kilic@example.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-3),
                    Description = "Lüks araç kiralama deneyimimi paylaşmak isterim, çok güzel bir süreçti!",
                    BlogID = 3
                }
            };
            return comments;
        }

        public static List<TagCloud> GetTagClouds()
        {
            var tagClouds = new List<TagCloud>()
            {
                new TagCloud
                {
                    TagCloudID = 1,
                    Title = "Araç Kiralama"
                },
                new TagCloud
                {
                    TagCloudID = 2,
                    Title = "Ekonomik Araçlar"
                },
                new TagCloud
                {
                    TagCloudID = 3,
                    Title = "Lüks Araç Kiralama"
                },
                new TagCloud
                {
                    TagCloudID = 4,
                    Title = "SUV ve 4x4 Araçlar"
                },
                new TagCloud
                {
                    TagCloudID = 5,
                    Title = "Elektrikli Araçlar"
                },
                new TagCloud
                {
                    TagCloudID = 6,
                    Title = "Günlük Kiralama"
                },
                new TagCloud
                {
                    TagCloudID = 7,
                    Title = "Uzun Dönem Kiralama"
                },
                new TagCloud
                {
                    TagCloudID = 8,
                    Title = "Araç Sigortaları"
                },
                new TagCloud
                {
                    TagCloudID = 9,
                    Title = "Araç Kiralama İpuçları"
                },
                new TagCloud
                {
                    TagCloudID = 10,
                    Title = "Havalimanı Araç Kiralama"
                }
            };
            return tagClouds;
        }

        public static List<TagCloudBlog> GetTagCloudBlogs()
        {
            var tagCloudBlogs = new List<TagCloudBlog>()
            {
                new TagCloudBlog
                {
                    TagCloudID = 1,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 1,
                    BlogID = 2

                },
                new TagCloudBlog
                {
                    TagCloudID = 1,
                    BlogID = 3

                },
                new TagCloudBlog
                {
                    TagCloudID = 2,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 2,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 2,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 3,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 3,
                    BlogID = 1

                },
                new TagCloudBlog
                {
                    TagCloudID = 3,
                    BlogID = 1

                }

            };
            return tagCloudBlogs;
        }
        public static List<Blog> GetBlogs()
        {
            var categories = GetCategories();
            var authors = GetAuthors();
            var tagClouds = GetTagClouds();
            var comments = GetComments();
            var blogs = new List<Blog>()
            {
                new Blog
                {
                    BlogID = 1,
                    Title = "Araç Kiralarken Dikkat Edilmesi Gerekenler",
                    CoverImageUrl = "https://example.com/images/car-rental-tips.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-30),
                    Description = @"Araç kiralarken karşılaşabileceğiniz en önemli sorunlar ve dikkat etmeniz gereken ipuçları.
                    Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir. 
                ",
                    CategoryID = categories[0].CategoryId,
                    AuthorID = authors[0].AuthorID

                },
                new Blog
                {
                    BlogID = 2,
                    Title = "Uzun Yol İçin En İdeal Kiralık Araçlar",
                    CoverImageUrl = "https://example.com/images/long-trip-cars.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-25),
                                        CategoryID = categories[1].CategoryId,
                    AuthorID = authors[0].AuthorID,
                    Description = @"Uzun yolculuklar için yakıt tasarruflu ve konforlu kiralık araç önerileri. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 3,
                    Title = "Havalimanı Araç Kiralama: Avantajları ve Dezavantajları",
                    CoverImageUrl = "https://example.com/images/airport-car-rental.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-20),
                                        CategoryID = categories[2].CategoryId,
                    AuthorID = authors[0].AuthorID,
                    Description = @"Havalimanında araç kiralamanın avantajları, dezavantajları ve en uygun fiyatlı seçenekler. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 4,
                    Title = "Elektrikli Araç Kiralama: Bilmeniz Gerekenler",
                    CoverImageUrl = "https://example.com/images/electric-car-rental.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-15),
                                        CategoryID = categories[0].CategoryId,
                    AuthorID = authors[1].AuthorID,
                    Description = @"Elektrikli araç kiralama hakkında bilinmesi gerekenler ve şarj istasyonu rehberi. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 5,
                    Title = "Kiralık SUV vs. Sedan: Hangisini Seçmelisiniz?",
                    CoverImageUrl = "https://example.com/images/suv-vs-sedan.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                                        CategoryID = categories[0].CategoryId,
                    AuthorID = authors[1].AuthorID,
                    Description = @"SUV ve Sedan araçların avantajları ve hangi durumda hangi aracı tercih etmelisiniz? Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 6,
                    Title = "Araç Kiralama Sigortası: Hangi Paket Size Uygun?",
                    CoverImageUrl = "https://example.com/images/car-insurance.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-7),
                                        CategoryID = categories[0].CategoryId,
                    AuthorID = authors[1].AuthorID,
                    Description = @"Araç kiralarken karşılaşabileceğiniz sigorta seçenekleri ve en iyi paketi seçme rehberi. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 7,
                    Title = "Günlük vs. Uzun Dönem Araç Kiralama: Hangisi Daha Avantajlı?",
                    CoverImageUrl = "https://example.com/images/short-long-term-rental.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                                        CategoryID = categories[3].CategoryId,
                    AuthorID = authors[2].AuthorID,
                    Description = @"Günlük ve uzun dönem araç kiralamanın avantajları ve dezavantajları. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 8,
                    Title = "Lüks Araç Kiralama: En Popüler Modeller ve Fiyatlar",
                    CoverImageUrl = "https://example.com/images/luxury-car-rental.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-3),
                    CategoryID = categories[3].CategoryId,
                    AuthorID=authors[3].AuthorID,
                    Description = @"Lüks araç kiralamada en popüler modeller ve fiyat karşılaştırmaları. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 9,
                    Title = "Araç Kiralama Sürecinde Yapılan 5 Büyük Hata",
                    CoverImageUrl = "https://example.com/images/rental-mistakes.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    CategoryID = categories[3].CategoryId,
                    AuthorID=authors[3].AuthorID,
                    Description = @"Araç kiralama sürecinde sık yapılan hatalar ve bu hatalardan nasıl kaçınabilirsiniz? Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

1.Kiralama Şirketi Seçimi
Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
2.Araç Seçimi ve Rezervasyon
İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
3.Sözleşme ve Sigorta
Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
4.Araç Teslimatı ve İade
Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
5.Ek Öneriler
Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."
                },
                new Blog
                {
                    BlogID = 10,
                    Title = "Araç Kiralama İçin En İyi Sezon Ne Zaman?",
                    CoverImageUrl = "https://example.com/images/best-season-rental.jpg",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    CategoryID = categories[3].CategoryId,
                    AuthorID=authors[3].AuthorID,
                    Description = @"Araç kiralamak için en uygun zaman dilimi ve sezonluk fiyat değişimleri. Araç Kiralarken Dikkat Edilmesi Gerekenler: Sorunsuz Bir Kiralama Deneyimi İçin İpuçları
                        Araç kiralama, seyahatlerimizde veya günlük hayatımızda büyük kolaylık sağlayan bir hizmettir. Ancak, sorunsuz bir kiralama deneyimi için dikkat edilmesi gereken bazı önemli noktalar bulunmaktadır. Bu makalede, araç kiralarken nelere dikkat etmeniz gerektiğini ele alacağız.

                        1.Kiralama Şirketi Seçimi
                        Güvenilirlik: Öncelikle, güvenilir ve tanınmış bir kiralama şirketi seçmek önemlidir. Şirketin müşteri yorumlarını ve değerlendirmelerini inceleyerek karar verebilirsiniz.
                        Fiyat Karşılaştırması: Farklı şirketlerin fiyatlarını karşılaştırarak bütçenize en uygun seçeneği belirleyebilirsiniz.
                        Müşteri Hizmetleri: Kiralama sürecinde ve sonrasında yaşanabilecek sorunlara karşı iyi bir müşteri hizmetleri desteği sunan şirketleri tercih edin.
                        2.Araç Seçimi ve Rezervasyon
                        İhtiyaçlarınıza Uygun Araç: Kiralayacağınız aracın, seyahat amacınıza ve kişi sayısına uygun olmasına dikkat edin.
                        Erken Rezervasyon: Özellikle yoğun dönemlerde erken rezervasyon yaparak istediğiniz aracı bulma şansınızı artırabilirsiniz.
                        Araç Özellikleri: Araçta istediğiniz özelliklerin(klima, navigasyon, otomatik vites vb.) bulunduğundan emin olun.
                        3.Sözleşme ve Sigorta
                        Sözleşmeyi Dikkatlice Okuyun: Kiralama sözleşmesini dikkatlice okuyarak tüm koşulları anladığınızdan emin olun.
                        Sigorta Kapsamı: Sigorta kapsamını ve olası hasar durumlarında nelerin karşılandığını öğrenin.Ek sigorta seçeneklerini değerlendirebilirsiniz.
                        Gizli Ücretler: Sözleşmede belirtilmeyen veya sonradan eklenen gizli ücretlere karşı dikkatli olun.
                        4.Araç Teslimatı ve İade
                        Aracı Kontrol Edin: Aracı teslim alırken, çizik, ezik gibi hasarları kontrol edin ve bunları sözleşmeye işletin.
                        Yakıt Durumu: Aracın yakıt durumunu kontrol edin ve teslim alırken depodaki yakıt seviyesini not edin.
                        İade Koşulları: Aracı iade ederken, yakıt seviyesinin aynı olmasına ve hasarsız teslim edilmesine dikkat edin.
                        Fotoğraf ve Video Kaydı: Aracı teslim alırken ve iade ederken, olası sorunlara karşı fotoğraf veya video kaydı alabilirsiniz.
                        5.Ek Öneriler
                        Ehliyet ve Kimlik: Araç kiralarken ehliyet ve kimliğinizin yanınızda olduğundan emin olun.
                        Kredi Kartı: Çoğu kiralama şirketi, depozito için kredi kartı talep etmektedir.
                        Trafik Kuralları: Kiraladığınız araçla trafik kurallarına uymaya özen gösterin.
                        Yol Yardımı: Kiralama şirketinin yol yardım hizmeti sunup sunmadığını öğrenin.
                        Araç kiralama, doğru adımları takip ederek keyifli ve sorunsuz bir deneyim haline gelebilir."

                }
            };
            return blogs;
        }






        #region Other
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
                    SendDate = new DateTime(2023, 10, 1).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Ayşe Kaya",
                    Email = "ayse.kaya@example.com",
                    Subject = "Fiyat Bilgisi",
                    Message = "Ekonomik sınıf bir araç için günlük kira bedeli ne kadar?",
                    SendDate = new DateTime(2023, 10, 2).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Mehmet Demir",
                    Email = "mehmet.demir@example.com",
                    Subject = "Teslimat Noktası",
                    Message = "Aracı havaalanından teslim alabilir miyim?",
                    SendDate = new DateTime(2023, 10, 3).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Fatma Şahin",
                    Email = "fatma.sahin@example.com",
                    Subject = "Sigorta Kapsamı",
                    Message = "Kiraladığım aracın sigortası kaza durumunda neyi kapsar?",
                    SendDate = new DateTime(2023, 10, 4).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Emre Koç",
                    Email = "emre.koc@example.com",
                    Subject = "Uzun Dönem Kiralama",
                    Message = "3 aylık araç kiralama için özel indirimleriniz var mı?",
                    SendDate = new DateTime(2023, 10, 5).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Zeynep Arslan",
                    Email = "zeynep.arslan@example.com",
                    Subject = "Çocuk Koltuğu",
                    Message = "Araçla birlikte çocuk koltuğu temin edebilir miyim?",
                    SendDate = new DateTime(2023, 10, 6).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Canan Öztürk",
                    Email = "canan.ozturk@example.com",
                    Subject = "İptal Politikası",
                    Message = "Rezervasyonumu iptal edersem ücret iadesi alabilir miyim?",
                    SendDate = new DateTime(2023, 10, 7).ToUniversalTime()
                },
                new Contact
                {

                    Name = "Burak Çelik",
                    Email = "burak.celik@example.com",
                    Subject = "Yakıt Politikası",
                    Message = "Aracı dolu depo ile mi teslim almalıyım?",
                    SendDate = new DateTime(2023, 10, 8).ToUniversalTime()
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


        #endregion

    }
}
