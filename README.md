# PostApi
Back end for Post Office application that displays information about shipments and allows creating new shipments.

## Pre-installation

First create a database server in MSSQL or connect to an existing one. In that server create s database with the following name:

```
PO_DB
```

After creating the database, execute the following query:

```
USE [PO_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipment](
	[ShipmentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ShipmentNumber] AS 'ABC-' + RIGHT('00000' + CAST(ShipmentId AS VARCHAR(5)), 7) PERSISTED UNIQUE,
	[Airport] [nvarchar](3) NOT NULL,
	[FlightNumber] [nvarchar](6) NOT NULL,
	[FlightDate] [date] NOT NULL
)
GO

INSERT INTO [dbo].[Shipment]
([Airport], [FlightNumber], [FlightDate]) VALUES
('TLL', 'AB1234', '2020-12-12'),
('RIX', 'CD5678', '2020-12-18')
GO

CREATE TABLE [dbo].[ParcelBag](
	[PBagId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BagNumber] AS 'PBAG' + RIGHT('00000000' + CAST(PBagId AS VARCHAR(8)), 10) PERSISTED UNIQUE,
	[FK_ShipmentId] [int] FOREIGN KEY REFERENCES Shipment(ShipmentId)
);
GO

INSERT INTO [dbo].[ParcelBag]
([FK_ShipmentId]) VALUES 
(1),
(2)
GO

CREATE TABLE [dbo].[Parcel](
	[ParcelId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ParcelNumber] AS 'AB' + RIGHT('00000' + CAST(ParcelId AS VARCHAR(5)) + 'CD', 7) PERSISTED UNIQUE,
	[RecipientName] [nvarchar](100) NOT NULL,
	[Destination] [nvarchar](2) NOT NULL,
	[Weight] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[FK_PBagId] [int] FOREIGN KEY REFERENCES ParcelBag(PBagId)
);
GO

INSERT INTO [dbo].[Parcel]
([RecipientName], [Destination], [Weight], [Price], [FK_PBagId]) VALUES 
('Tallin Post Office', 'EE', 0.1, 10.10, 1),
('Riga Airport', 'LV', 0.5, 5.5, 1),
('Helsinki Port', 'FI', 0.2, 8.8, 2)
GO

CREATE TABLE [dbo].[LetterBag](
	[LBagId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BagNumber] AS 'LBAG' + RIGHT('00000000' + CAST(LBagId AS VARCHAR(8)), 10) PERSISTED UNIQUE,
	[LetterCount] [int] NOT NULL,
	[Weight] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[FK_ShipmentId] [int] FOREIGN KEY REFERENCES Shipment(ShipmentId)
);
GO

INSERT INTO [dbo].[LetterBag]
([LetterCount], [Weight], [Price], [FK_ShipmentId]) VALUES
(10, 0.9, 10, 1),
(2, 0.1, 5, 2),
(20, 1.9, 20, 2)
GO
```

The query will create the needed tables and fill them with test data.

## Installation and start

### Using Visual Studio

- Clone this repository,
- Open the project in Visual Studio,
- Start the project by pressing Ctrl + F5.

### Using other code editors

- Clone this repository
- Open the project in a terminal window
- In terminal navigate to the project folder:
```
cd PostApi
```
- Run the project by executing the following command:
```
dotnet run
```

## Front end
Continue with instructions from the front end repository [here](https://github.com/martinhorn1/PostOffice).
