# CarBook Araç Kiralama Projesi

CarBook Araç Kiralama Projesi, araç kiralama süreçlerini kolaylaştırmak amacıyla bireysel olarak geliştirilmiş bir Web API ve MVC uygulamasıdır. ASP.NET Core 8.0 kullanılarak tasarlanan bu proje, modern yazılım mimarileri ve en iyi uygulama yöntemleri göz önünde bulundurularak inşa edilmiştir.

## Proje Özellikleri
- **Onion Architecture (Soğan Mimarisi)**: Proje, bağımsız ve süredırılebilir bir yapı sağlamak için Onion Architecture prensiplerine göre tasarlanmıştır.
- **CQRS ve Mediator Tasarım Desenleri**: İş mantığı ve veri yönetimi için Command Query Responsibility Segregation (CQRS) ve Mediator tasarım desenleri kullanılarak modülerlik ve test edilebilirlik artırılmıştır.
- **Kullanıcı Yetkilendirme**: Kullanıcı ve rol bazlı yetkilendirme JWT (JSON Web Token) ile güvenli bir şekilde yönetilmektedir.

## Uygulama İşlevleri
- **Araç Kiralama**: Kullanıcılar, seçilen tarihler ve konumlara göre uygun araçları görüntüleyebilir.
- **Yönetici Paneli**: Yöneticiler için ayrı bir arayüz sağlanmış olup tüm işlemler için CRUD (Create, Read, Update, Delete) işlemleri yapılabilir.
- **Detaylı Araç Bilgileri**: Araçların fiyatları, özellikleri ve kullanıcı yorumlarına erişim sağlanır.
- **Blog ve İletişim**: Kullanıcılar, blog yazılarına yorum yapabilir ve iletişim formu aracılığıyla mesaj gönderebilir.

## Proje Yapısı
| Katman | Açıklama |
|--------|------------|
| **CarBook.Domain** | Çekirdek varlıkları (entities) ve iş mantığını içerir. |
| **CarBook.Application** | DTO'lar, enums, CQRS, Mediator ve Repository tasarım desenlerini barındırır. |
| **CarBook.Persistence** | Repository sınıflarını ve veritabanı işlemlerini uygular. |
| **CarBook.WebApi** | Dış dünya ile iletişim sağlamak için API metodlarını barındırır. |
| **CarBook.Dto** | Ön yüz ile uyumlu DTO yapılarını içerir. |
| **CarBook.WebUI** | MVC ile tasarlanmış kullanıcı arayüzünü içerir; ayrıca yönetici paneli için ayrı bir alan bulunur. |

## Kullanılan Teknolojiler
- **ASP.NET Core 8**
- **Web API**
- **Onion Architecture (Soğan Mimarisi)**
- **CQRS Pattern**
- **Mediator Pattern**
- **Repository Pattern**
- **MSSQL**
- **Bootstrap**
- **JWT (JSON Web Token)**
- **SignalR**
- **Fluent Validation**
- **HTML / CSS / JavaScript**



