<h1>Mini Restaurant Management System</h1>

This system is built using .NET Core Web Api. This standalone system allows us to manage category related to menu items.
Furthermore, we can manage menu items and save order and details including invoice.

## Technologies Used

- ASP .NET Core Web API
- Entity Framework Core
- SQL Server
- N Layer & Vertical Slice architecture
- Swagger for better API documentation

## Database Setup

```sql
CREATE DATABASE MiniRestaurantManagementSystem;

USE [MiniRestaurantManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Category]    Script Date: 8/8/2024 5:17:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [nvarchar](50) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_MenuItem]    Script Date: 8/8/2024 5:17:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_MenuItem](
	[MenuItemId] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemCode] [nvarchar](50) NOT NULL,
	[CategoryCode] [nvarchar](50) NOT NULL,
	[MenuItemName] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Tbl_MenuItem] PRIMARY KEY CLUSTERED 
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 8/8/2024 5:17:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Order_Detail]    Script Date: 8/8/2024 5:17:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Order_Detail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[MenuItemCode] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Tbl_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

```

## Running the Application

1. Clone the repository:
	```
	
	git clone https://github.com/yourusername/doctor-appointment-booking.git
	cd doctor-appointment-booking
	
	```

2. Configure SQL Server Db Connection in ``` appsettings.json ```:
	```
	
	{
	  "Logging": {
	    "LogLevel": {
	      "Default": "Information",
	      "Microsoft.AspNetCore": "Warning"
	    }
	  },
	  "AllowedHosts": "*",
	  "ConnectionStrings": {
	    "DbConnection": "Server=.;Database=MiniRestaurantManagementSystem;User ID=sa;Password=sa@123;Trusted_Connection=True;TrustServerCertificate=True;"
	  }
	}
	
	```

3. Run the application:
	```
	dotnet run
	```

 4. Open your browser and navigate to ``` https://localhost:7146/swagger ``` to view API documentation.


## API Endpoints

### Category Endpoints

* Get Category List
	- GET ``` /api/Category ```

* Get Category by ID
	- GET ``` /api/Category/id/2 ```

* Get Category By Code
	- GET ``` /api/Category/categoryCode/01J4RG0WVJSCFFCXGEZ9TKAY4B ```

* Add Category
	- POST ``` /api/Category ```
 	- Request Body:


		```
		{
		    "CategoryName": "test"
		}
		```

* Delete Category
  	- DELETE ``` /api/Category/4 ```

### Menu Items Endpoints

* Get Menu Item List
  	- GET ``` /api/MenuItem ```
 
* Get Menu Item List by Category Code
  	- GET ``` /api/MenuItem/categoryCode/01J4RG0WVJSCFFCXGEZ9TKAY4B ```
 
* Get Menu Item By Id
  	- GET ``` /api/MenuItem/id/2 ```
 
* Add Menu Item
	- POST ``` /api/MenuItem ```
 	- Request Body:


 		```
		{
		    "CategoryCode": "01J4RG0WVJSCFFCXGEZ9TKAY4B",
		    "MenuItemName": "Vanilla Drik",
		    "Price": 10000
		}
		```
 
* Update Menu Item
	- PUT ``` /api/MenuItem/2 ```
 	- Request Body:


 		```
		{
		    "CategoryCode": "01J4RG0WVJSCFFCXGEZ9TKAY4B",
		    "MenuItemName": "Vanilla Drik",
		    "Price": 10000
		}
		```

* Delete Menu Item
	- DELETE ``` /api/MenuItem/3 ```
