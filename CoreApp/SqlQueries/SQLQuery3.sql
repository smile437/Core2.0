select getdate() as [now]
, convert(varchar(255), datepart(month, dateadd(month, 1, getdate()))) as [incorrect]
, right('0' + convert(varchar(255), datepart(month, dateadd(month, 1, getdate()))), 2) as [incorrect1]
, right('00' + convert(varchar(255), datepart(month, getdate())), 2) as [incorrect_str]
, right('000' + convert(varchar(255), datepart(year, getdate())), 4) + '-' + left('00' + convert(varchar(255), datepart(month, getdate())), 2) + '-01 00:00:00' as [lower_bound]
, right('000' + convert(varchar(255), datepart(year, dateadd(month, 1, getdate()))), 4) + '-' + left('0' + convert(varchar(255), datepart(month, dateadd(month, 1, getdate()))), 2) + '-01 00:00:00' as [upper_bound]
, convert
(
    datetime2,
    right('000' + convert(varchar(255), datepart(year, getdate())), 4) + '-' + right('0' + convert(varchar(255), datepart(month, getdate())), 2) + '-01 00:00:00'
) as [lower_bound_1]
, convert
(
    datetime2,
    right('000' + convert(varchar(255), datepart(year, dateadd(month, 1, getdate()))), 4) + '-' + right('0' + convert(varchar(255), datepart(month, dateadd(month, 1, getdate()))), 2) + '-01 00:00:00'
) as [upper_bound_1]