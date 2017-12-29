use ProductDb
go

Select p.*
From Products as p
Where p.IsAvailable=0
And p.DeliveryDate > convert
(
    datetime2,
    right('000' + convert(varchar(255), datepart(year, getdate())), 4) + '-' + right('0' + convert(varchar(255), datepart(month, getdate())), 2) + '-01 00:00:00'
) 
and p.DeliveryDate < convert
(
    datetime2,
    right('000' + convert(varchar(255), datepart(year, dateadd(month, 1, getdate()))), 4) + '-' + right('0' + convert(varchar(255), datepart(month, dateadd(month, 1, getdate()))), 2) + '-01 00:00:00'
) 
go 