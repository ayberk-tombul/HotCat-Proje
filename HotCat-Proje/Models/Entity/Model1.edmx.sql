
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2022 16:03:14
-- Generated from EDMX file: C:\Users\90554\Desktop\Proje deneme\hotcat\HotCat-Proje\Models\Entity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotCat_TEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_employee_role_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[employee_role] DROP CONSTRAINT [FK_employee_role_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_employee_role_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[employee_role] DROP CONSTRAINT [FK_employee_role_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_order_products_Orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_products] DROP CONSTRAINT [FK_order_products_Orders];
GO
IF OBJECT_ID(N'[dbo].[FK_order_products_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_products] DROP CONSTRAINT [FK_order_products_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Employees1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Employees1];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Tables]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Tables];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_subCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_subCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_Receipt_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Receipt] DROP CONSTRAINT [FK_Receipt_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Receipt_Orders1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Receipt] DROP CONSTRAINT [FK_Receipt_Orders1];
GO
IF OBJECT_ID(N'[dbo].[FK_subCategories_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[subCategories] DROP CONSTRAINT [FK_subCategories_Categories];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[employee_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employee_role];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[order_products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_products];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Receipt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Receipt];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[subCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[subCategories];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tables];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [Category_Name] varchar(50)  NOT NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [First_Name] varchar(50)  NOT NULL,
    [Last_Name] varchar(50)  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [image] varchar(200)  NOT NULL
);
GO

-- Creating table 'order_products'
CREATE TABLE [dbo].[order_products] (
    [order_id] int  NOT NULL,
    [product_id] int  NOT NULL,
    [quantity] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Order_ID] int IDENTITY(1,1) NOT NULL,
    [employee_id] int  NOT NULL,
    [table_id] int  NOT NULL,
    [status] bit  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Product_Name] nvarchar(50)  NOT NULL,
    [Subcategory_id] int  NOT NULL,
    [price] float  NOT NULL,
    [product_stock] int  NOT NULL,
    [image] varchar(200)  NOT NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Receipt'
CREATE TABLE [dbo].[Receipt] (
    [ReceiptID] int IDENTITY(1,1) NOT NULL,
    [order_id] int  NOT NULL,
    [employee_id] int  NOT NULL,
    [price] float  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Roles_ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NOT NULL
);
GO

-- Creating table 'subCategories'
CREATE TABLE [dbo].[subCategories] (
    [Subcategory_ID] int IDENTITY(1,1) NOT NULL,
    [SubCategoryName] varchar(50)  NOT NULL,
    [category_id] int  NOT NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tables'
CREATE TABLE [dbo].[Tables] (
    [TableID] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'employee_role'
CREATE TABLE [dbo].[employee_role] (
    [Employees_EmployeeID] int  NOT NULL,
    [Roles_Roles_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [order_id], [product_id] in table 'order_products'
ALTER TABLE [dbo].[order_products]
ADD CONSTRAINT [PK_order_products]
    PRIMARY KEY CLUSTERED ([order_id], [product_id] ASC);
GO

-- Creating primary key on [Order_ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Order_ID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [ReceiptID] in table 'Receipt'
ALTER TABLE [dbo].[Receipt]
ADD CONSTRAINT [PK_Receipt]
    PRIMARY KEY CLUSTERED ([ReceiptID] ASC);
GO

-- Creating primary key on [Roles_ID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Roles_ID] ASC);
GO

-- Creating primary key on [Subcategory_ID] in table 'subCategories'
ALTER TABLE [dbo].[subCategories]
ADD CONSTRAINT [PK_subCategories]
    PRIMARY KEY CLUSTERED ([Subcategory_ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TableID] in table 'Tables'
ALTER TABLE [dbo].[Tables]
ADD CONSTRAINT [PK_Tables]
    PRIMARY KEY CLUSTERED ([TableID] ASC);
GO

-- Creating primary key on [Employees_EmployeeID], [Roles_Roles_ID] in table 'employee_role'
ALTER TABLE [dbo].[employee_role]
ADD CONSTRAINT [PK_employee_role]
    PRIMARY KEY CLUSTERED ([Employees_EmployeeID], [Roles_Roles_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [category_id] in table 'subCategories'
ALTER TABLE [dbo].[subCategories]
ADD CONSTRAINT [FK_subCategories_Categories]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_subCategories_Categories'
CREATE INDEX [IX_FK_subCategories_Categories]
ON [dbo].[subCategories]
    ([category_id]);
GO

-- Creating foreign key on [employee_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Employees1]
    FOREIGN KEY ([employee_id])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Employees1'
CREATE INDEX [IX_FK_Orders_Employees1]
ON [dbo].[Orders]
    ([employee_id]);
GO

-- Creating foreign key on [employee_id] in table 'Receipt'
ALTER TABLE [dbo].[Receipt]
ADD CONSTRAINT [FK_Receipt_Employees]
    FOREIGN KEY ([employee_id])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Receipt_Employees'
CREATE INDEX [IX_FK_Receipt_Employees]
ON [dbo].[Receipt]
    ([employee_id]);
GO

-- Creating foreign key on [order_id] in table 'order_products'
ALTER TABLE [dbo].[order_products]
ADD CONSTRAINT [FK_order_products_Orders]
    FOREIGN KEY ([order_id])
    REFERENCES [dbo].[Orders]
        ([Order_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [product_id] in table 'order_products'
ALTER TABLE [dbo].[order_products]
ADD CONSTRAINT [FK_order_products_Products]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_order_products_Products'
CREATE INDEX [IX_FK_order_products_Products]
ON [dbo].[order_products]
    ([product_id]);
GO

-- Creating foreign key on [table_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Tables]
    FOREIGN KEY ([table_id])
    REFERENCES [dbo].[Tables]
        ([TableID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Tables'
CREATE INDEX [IX_FK_Orders_Tables]
ON [dbo].[Orders]
    ([table_id]);
GO

-- Creating foreign key on [order_id] in table 'Receipt'
ALTER TABLE [dbo].[Receipt]
ADD CONSTRAINT [FK_Receipt_Orders1]
    FOREIGN KEY ([order_id])
    REFERENCES [dbo].[Orders]
        ([Order_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Receipt_Orders1'
CREATE INDEX [IX_FK_Receipt_Orders1]
ON [dbo].[Receipt]
    ([order_id]);
GO

-- Creating foreign key on [Subcategory_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_subCategories]
    FOREIGN KEY ([Subcategory_id])
    REFERENCES [dbo].[subCategories]
        ([Subcategory_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_subCategories'
CREATE INDEX [IX_FK_Products_subCategories]
ON [dbo].[Products]
    ([Subcategory_id]);
GO

-- Creating foreign key on [Employees_EmployeeID] in table 'employee_role'
ALTER TABLE [dbo].[employee_role]
ADD CONSTRAINT [FK_employee_role_Employees]
    FOREIGN KEY ([Employees_EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Roles_ID] in table 'employee_role'
ALTER TABLE [dbo].[employee_role]
ADD CONSTRAINT [FK_employee_role_Roles]
    FOREIGN KEY ([Roles_Roles_ID])
    REFERENCES [dbo].[Roles]
        ([Roles_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_employee_role_Roles'
CREATE INDEX [IX_FK_employee_role_Roles]
ON [dbo].[employee_role]
    ([Roles_Roles_ID]);
GO

INSERT INTO Employees (First_Name, Last_Name, Email, Password, image)
VALUES ('Admin','User','admin@admin','123456','sadasdasdas');


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------