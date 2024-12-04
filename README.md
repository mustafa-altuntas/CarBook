### CarBook Vehicle Rental Project

The **CarBook Vehicle Rental Project** was developed as part of Murat Yücedağ's Udemy course titled "Asp.Net Core Api 8.0 Onion Architecture with BookCar Project." This project is a Web API and MVC application built using ASP.NET Core 8.0, aimed at simplifying vehicle rental processes.

### Project Features
- **Onion Architecture**: The project is designed using Onion architecture principles, providing an independent and sustainable structure for the application.
- **CQRS and Mediator Patterns**: Command Query Responsibility Segregation (CQRS) and Mediator patterns are employed for business logic and data management, enhancing modularity and testability.
- **User Authorization**: User and role authorizations are securely managed using JWT (JSON Web Token).

### Application Functions
- **Vehicle Rental**: Users can view available vehicles based on selected dates and locations.
- **Admin Panel**: A separate interface for administrators allows CRUD operations on all functionalities.
- **Detailed Vehicle Information**: Access to detailed information about vehicle prices, features, and user reviews.
- **Blog and Contact**: Users can comment on blogs and send messages through a contact form.

### Project Structure
| Layer                  | Description                                                               |
|-----------------------|---------------------------------------------------------------------------|
| CarBook.Domain        | Contains core entities and business logic.                               |
| CarBook.Application    | Includes DTOs, enums, CQRS, Mediator, and repository design patterns.    |
| CarBook.Persistence    | Implements repository classes and database operations.                    |
| CarBook.WebApi        | Hosts API methods to facilitate communication with the outside world.    |
| CarBook.Dto           | Provides DTO structures that align with the frontend.                    |
| CarBook.WebUI         | User interface designed with MVC; includes a separate area for the admin panel. |

### Technologies Used
- **ASP.NET Core 8**
- **Web API**
- **Onion Architecture**
- **CQRS Pattern**
- **Mediator Pattern**
- **Repository Pattern**
- **MSSQL**
- **Bootstrap**
- **JWT**
- **SignalR**
- **Fluent Validation**
- **HTML/CSS/JavaScript**

