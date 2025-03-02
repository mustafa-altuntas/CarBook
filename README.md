# CarBook Car Rental Project

CarBook Car Rental Project is a Web API and MVC application developed individually to facilitate car rental processes. Designed using ASP.NET Core 8.0, this project has been built with modern software architectures and best practices in mind.

## Project Features
- **Onion Architecture**: The project is designed according to the principles of Onion Architecture to ensure an independent and sustainable structure.
- **CQRS and Mediator Design Patterns**: Command Query Responsibility Segregation (CQRS) and Mediator design patterns are used for business logic and data management, enhancing modularity and testability.
- **User Authorization**: User and role-based authorization is securely managed with JWT (JSON Web Token).

## Application Functions
- **Car Rental**: Users can view available cars based on selected dates and locations.
- **Admin Panel**: A separate interface is provided for administrators, allowing CRUD (Create, Read, Update, Delete) operations for all transactions.
- **Detailed Car Information**: Users can access car prices, features, and user reviews.
- **Blog and Contact**: Users can comment on blog posts and send messages via the contact form.

## Project Structure
| Layer | Description |
|--------|------------|
| **CarBook.Domain** | Contains core entities and business logic. |
| **CarBook.Application** | Includes DTOs, enums, CQRS, Mediator, and Repository design patterns. |
| **CarBook.Persistence** | Implements repository classes and database operations. |
| **CarBook.WebApi** | Contains API methods for external communication. |
| **CarBook.Dto** | Includes DTO structures compatible with the front-end. |
| **CarBook.WebUI** | Contains the user interface designed with MVC, along with a separate section for the admin panel. |

## Technologies Used
- **ASP.NET Core 8**
- **Web API**
- **Onion Architecture**
- **CQRS Pattern**
- **Mediator Pattern**
- **Repository Pattern**
- **MSSQL**
- **Bootstrap**
- **JWT (JSON Web Token)**
- **SignalR**
- **Fluent Validation**
- **HTML / CSS / JavaScript**




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


