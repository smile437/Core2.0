/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
update productdb.dbo.Products 
set deliverydate = getdate(), 
IsAvailable = 1
go 

SELECT TOP (1000) [Code]
      ,[DeliveryDate]
      ,[Description]
      ,[IsAvailable]
      ,[Price]
      ,[ProductTypeCode]
      ,[UnitCode]
  FROM [ProductDb].[dbo].[Products]
  go 