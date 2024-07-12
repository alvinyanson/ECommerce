# E-commerce Website

## Overview

This application is a simplified E-commerce website that allows users to browse, search for, and purchase products. It features user registration and authentication, category management, product listings and details, and a shopping cart.

## Features

### User Registration and Authentication
- **User Registration:** Users can create accounts with proper validation for input fields.
- **User Authentication:** Enable login functionality using an Identity provider to ensure secure user authentication and authorization.

### Category Management
- **Create, Update, Delete Categories:** Admins can manage product categories through an intuitive interface.
- **List Categories:** Categories are displayed on the website, making it easy for users to browse through them.

### Product Listings and Details
- **Paginated Product Listings:** Display a list of products with their images, names, prices, and brief descriptions.
- **Product Search:** Users can search for products by name or category.
- **Product Details Page:** Each product has a dedicated page showing more detailed information.

### Shopping Cart
- **Add to Cart:** Users can add products to their shopping cart.
- **Manage Cart Items:** Users can view and manage items in their cart, update quantities, or remove items.
- **Total Cost Display:** The total cost of items in the shopping cart is displayed to the user.

### Challenges Encountered Along the Implementation

### 1. Scaffolding Identity
While scaffolding the Identity provider, I encountered version issues that required downgrading from 8.0.6 to 8.0.4 in order to build the project.

### 2. Passing the State from View (Custom User Input) to Controller
To pass the state from view to controller for custom user input, I used an AJAX request and returned the partial view with the updated model to preserve the view.
For example, when adding a product, it could belong to multiple categories. I created a custom user input which behaves as a multi-select.

### 3. Deploying to Azure and Migrating Database to Azure
While deploying to Azure and migrating the database, I faced a 500 error when accessing the site. I enabled App Service Logs and discovered the error 'System.Data.SqlClient.SqlException: Invalid object name 'dbo.Projects''. After extensive investigation, I realized the issue was a missing table. I attempted to migrate my local database using Microsoft Data Migration Assistant and Azure Data Studio, but both failed due to version issues. Finally, I ran 'update database' in Package Manager Console, ensuring the ConnectionString pointed to Azure SQL Database, and this resolved the problem.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure Account](https://azure.microsoft.com/en-us/get-started/azure-portal)

### Installation
1. **Clone the repository:**
    ```bash
    git clone https://github.com/alvinyanson/ECommerce.git
    cd ecommerce-website
    ```

2. **Setup the database:**
    - Update the `appsettings.json` with your SQL Server connection string.
    - Look for the "DefaultConnection" property and update it to match your server name.   It should look like the same below after you configure it:
      ```bash
      "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ECommerceWeb;Trusted_Connection=True;TrustServerCertificate=True"
      ```
    
    - Open Package Manage Console and run the following commands to apply migrations. (Make sure the selected project is ECommerce.DataAccess project)
      ```bash
      update database
      ```

3. **Run the application:**

### Usage
- Access the application at `http://localhost:7208` (visual studio will open your app automatically)
- Register a new user account or log in with existing credentials.
- Browse through product categories, search for products, and add them to your shopping cart.
- Manage your cart and proceed to checkout.

## Technologies Used
- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server**
- **Identity Provider for Authentication**

- ## UML Class Diagram
- [Class Diagram](https://lucid.app/lucidchart/8f1367ee-01e7-4ddb-b45b-a88eb09cf1f8/view)
