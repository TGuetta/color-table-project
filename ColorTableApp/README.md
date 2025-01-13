# **Color Table Management App**

A simple web application for managing a table of colors with Create, Read, Update, and Delete (CRUD) functionality. Built using ASP.NET Core (C#) with Razor Pages, Entity Framework Core, and SQLite.

---

## **Features**

- **Add New Colors:** Input color name, price, display order, and stock status.
- **Edit Existing Colors:** Modify details of colors.
- **Delete Colors:** Safely delete any color.
- **Data Validation:** Prevent invalid inputs like negative prices.
- **Responsive Design:** Styled with Bootstrap for mobile and desktop compatibility.

---

## **Technologies Used**

### **Frontend**

- **HTML5** and **CSS3**
- **jQuery** (AJAX for dynamic updates)
- **Bootstrap 5**

### **Backend**

- **C#** with **ASP.NET Core Razor Pages**
- **Entity Framework Core**
- **SQLite**

### **Tools**

- **Visual Studio Code**
- **.NET CLI**

---

## **Setup and Run Instructions**

### **Prerequisites**

- Install the [.NET SDK](https://dotnet.microsoft.com/download)
- Install [SQLite](https://www.sqlite.org/download.html)

### **Steps**

1. Clone the repository:
   ```bash
   git clone https://github.com/TGuetta/color-table-project.git
   cd color-table-project/ColorTableApp
   ```
2. Build the project:

   dotnet build

3. Run the application:

   dotnet run

4. Open the app in your browser at http://localhost:5225.

# ** Folder Structure **

ColorTableApp/
├── Pages/ # Razor Pages for CRUD operations
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ ├── Delete.cshtml
│ ├── Index.cshtml
├── Models/ # Data models
│ └── ColorItem.cs
├── Data/ # Database files
│ ├── AppDbContext.cs
│ └── Colors.db
├── wwwroot/ # Static files (CSS, JS, Bootstrap)
├── Program.cs # App entry point
├── README.md # Documentation
