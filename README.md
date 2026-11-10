# QuickBite – Food Delivery Management System

A web-based food delivery application built using **ASP.NET Core 8 MVC, C#, Entity Framework Core and Microsoft SQL Server**. QuickBite allows customers to explore meals, customize their orders, apply promotional discounts, make payments and track their deliveries.

The application also demonstrates the practical implementation of several software design patterns, including Abstract Factory, Decorator, Strategy, Observer and Singleton.

---

 
---

## 📖 Project Overview

QuickBite is an MVC-based food delivery application designed to provide customers with a convenient online ordering experience.

Customers can choose between different restaurant styles, browse available meals, customize food items, manage their shopping cart and complete the checkout process.

The system also incorporates customer loyalty points, promotional codes, payment processing simulation, email notifications and order tracking.

An important objective of this project is to demonstrate how software design patterns can be integrated into a practical ASP.NET Core application to improve maintainability, flexibility and code reusability.

## ✨ Features

### 1. Restaurant Selection
- Choose between Fast Food, Premium and Healthy restaurant options.
- Different restaurant branding and packaging configurations.
- Restaurant-specific packaging costs and pricing adjustments.

### 2. Meal Management
- Browse available meals.
- View meal descriptions, categories, images and prices.
- Browse meals by category.
- Select additional meal customizations.

### 3. Meal Customization
Customers can personalize their meals with additional options, including:

- Extra Cheese
- Bacon
- Double Patty
- Extra Sauce
- Large Portion
- Gluten-Free Options

Additional customization costs are automatically included in the meal price.

### 4. Shopping Cart
- Add meals to the shopping cart.
- Update item quantities.
- Remove items from the cart.
- Support multiple customizations.
- Calculate order subtotals.

The shopping cart uses ASP.NET Core Session to maintain customer selections while navigating the application.

### 5. Checkout and Payments
- Enter customer contact information.
- Provide a delivery address.
- Apply promotional codes.
- Use customer loyalty points.
- Calculate delivery and discount amounts.
- Process simulated payments.
- Generate unique order numbers.
- Save payment transaction records.

**Promotional code:** `SAVE10` provides a 10% discount on the meal subtotal.

### 6. Customer Loyalty Programme
- Register customers automatically during checkout.
- Maintain customer loyalty points.
- Earn one loyalty point for every R10 spent.
- Redeem 100 loyalty points for a 10% discount.

### 7. Order Tracking
- Generate unique order references.
- View order confirmation details.
- Track order status.
- Simulate delivery progress.

Order statuses include:
- Paid
- Preparing
- Out for Delivery
- Delivered

### 8. Email Notifications
Customers receive email notifications when their order status changes.

Notifications include:
- Order confirmation.
- Payment confirmation.
- Food preparation updates.
- Delivery updates.
- Order completion notifications.

---

## 🍽️ Restaurant Options

QuickBite implements three restaurant configurations using the Abstract Factory design pattern.

| Restaurant | Brand | Packaging |
|---|---|---|
| Fast Food | FastBite | Cardboard box and plastic bag |
| Premium | Gourmet Express | Insulated box with cutlery |
| Healthy | GreenLeaf | Recyclable paper packaging |

Each restaurant configuration has its own packaging description, packaging cost, branding and pricing modifier.

---

## 🛠️ Technologies Used

### Backend
- C#
- ASP.NET Core 8
- ASP.NET Core MVC
- Entity Framework Core
- LINQ
- MailKit

### Frontend
- HTML5
- CSS3
- JavaScript
- Razor Views

### Database
- Microsoft SQL Server
- Entity Framework Core Code First
- Entity Framework Core Migrations

### Development Tools
- Visual Studio
- SQL Server Management Studio (SSMS)
- Git
- GitHub

### NuGet Packages
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- MailKit
- Newtonsoft.Json
- Microsoft.AspNetCore.Session

---

## 🧩 Design Patterns

One of the main objectives of QuickBite is demonstrating the implementation of software design patterns.

The application incorporates the following patterns:

| Design Pattern | Implementation | Purpose |
|---|---|---|
| Abstract Factory | `IThemeFactory`, `FastFoodFactory`, `PremiumFactory`, `HealthyFactory` | Creates different restaurant configurations. |
| Decorator | `IMealDecorator` and meal decorators | Dynamically adds meal customizations and additional costs. |
| Strategy | `IPriceStrategy`, `PromoCodeStrategy`, `CreditCardStrategy`, `SurgeDeliveryStrategy` | Provides interchangeable pricing calculations. |
| Observer | `IOrderObserver`, `OrderSubject`, `EmailNotifier` | Notifies customers when order statuses change. |
| Singleton | `Logger` | Provides a shared logging instance. |
| Factory / Creator | `IMealCreator`, `MealCreator` | Encapsulates meal object creation. |

### Abstract Factory Pattern
Creates different restaurant configurations without requiring the application to depend directly on individual restaurant implementations.

### Decorator Pattern
Allows customers to dynamically customize meals without creating separate classes for every possible meal combination.

### Strategy Pattern
Encapsulates pricing algorithms so different pricing rules can be applied independently.

### Observer Pattern
Automatically notifies registered observers when an order status changes. The email notification implementation sends updates to customers.

### Singleton Pattern
Provides a centralized logger through a single shared instance.

---

## 🏗️ Project Architecture

The application follows the Model-View-Controller (MVC) architectural pattern.

```text
FoodDeliveryAppMvc/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── MenuController.cs
│   ├── CartController.cs
│   ├── CheckoutController.cs
│   └── OrderController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── Domain/
│   │   ├── Customer.cs
│   │   ├── Meal.cs
│   │   ├── Order.cs
│   │   ├── OrderItem.cs
│   │   └── PaymentTransaction.cs
│   │
│   ├── Patterns/
│   │   ├── Singleton/
│   │   ├── Meal Decorators
│   │   ├── Restaurant Factories
│   │   ├── Pricing Strategies
│   │   └── Order Observers
│   │
│   └── ViewModels/
│       ├── CartViewModel.cs
│       ├── CheckoutViewModel.cs
│       ├── PaymentViewModel.cs
│       └── OrderTrackingViewModel.cs
│
├── Services/
│   ├── CartService.cs
│   ├── EmailService.cs
│   ├── IEmailService.cs
│   ├── FakePaymentGateway.cs
│   └── IPaymentGateway.cs
│
├── Views/
│   ├── Home/
│   ├── Menu/
│   ├── Cart/
│   ├── Checkout/
│   ├── Order/
│   └── Shared/
│
├── Migrations/
│
├── wwwroot/
│   ├── css/
│   └── js/
│
├── appsettings.json
├── Program.cs
└── FoodDeliveryAppMvc.csproj
```

---

## 🗄️ Database Structure

QuickBite uses Microsoft SQL Server as its relational database.

Entity Framework Core manages database interactions through `AppDbContext`.

The main database entities are:

| Entity | Description |
|---|---|
| Meal | Stores meal information, prices and availability. |
| Customer | Stores customer details and loyalty points. |
| Order | Stores customer orders and delivery information. |
| OrderItem | Stores individual meals associated with an order. |
| PaymentTransaction | Stores payment transaction information. |

Database relationships are managed through Entity Framework Core and configured using migrations.

---

## 🚀 Getting Started

Follow these instructions to download and run the project locally.

### Prerequisites

Make sure you have installed:

1. Visual Studio 2022 or later.
2. .NET 8 SDK.
3. Microsoft SQL Server.
4. SQL Server Management Studio (SSMS).
5. Git.

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/FoodDeliveryAppMvc.git
```

### 2. Open the Project

Open the solution in Visual Studio.

Locate:

```text
FoodDeliveryAppMvc/FoodDeliveryAppMvc.sln
```

Alternatively, open the `.csproj` file directly.

### 3. Restore NuGet Packages

Open the Package Manager Console in Visual Studio and execute:

```powershell
Update-Package -reinstall
```

Alternatively, use the terminal:

```bash
dotnet restore
```

### 4. Configure the Database

Open `appsettings.json` and update the SQL Server connection string.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=FoodDeliveryMVC;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name.

### 5. Apply Database Migrations

Open the Package Manager Console and execute:

```powershell
Update-Database
```

Alternatively, using the .NET CLI:

```bash
dotnet ef database update
```

This creates the database and applies the existing migrations.

### 6. Configure Email Settings

The application uses MailKit and SMTP to send customer notifications.

Configure the following settings using environment variables or a local secrets configuration:

- SMTP server
- SMTP port
- Sender email
- Sender password or application password
- SSL/TLS configuration

Never commit real email credentials or passwords to GitHub.

### 7. Run the Application

Using Visual Studio:

1. Set `FoodDeliveryAppMvc` as the startup project.
2. Select the HTTPS launch profile.
3. Click **Run** or press `F5`.

Alternatively:

```bash
dotnet run
```

Open the localhost URL displayed in the terminal.

---

## 🔐 Security and Configuration Notes

- Store SMTP credentials securely using User Secrets or environment variables.
- Do not commit database passwords or application passwords.
- Configure production SMTP credentials before deployment.
- Use HTTPS when deploying the application.
- The current payment gateway is a simulated implementation and is not connected to a real payment provider.

---

## 🔮 Future Improvements

Potential improvements for future versions include:

- Customer registration and authentication.
- Administrator dashboard.
- Restaurant and meal management dashboard.
- Real payment gateway integration.
- Delivery driver management.
- Real-time order tracking.
- Customer reviews and ratings.
- Advanced reporting and analytics.
- Improved validation and security.
- Automated unit and integration testing.

---
 
