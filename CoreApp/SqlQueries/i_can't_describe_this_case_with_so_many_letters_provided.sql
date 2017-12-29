use ProductDb 
go 

select top 3 c.*, iq.amount, iq.mean 
from 
(
	select top 3 c.Code, count(p.Code) as [amount], avg(p.Price) as [mean]
	from Categories c 
	inner join ProductCategory pc 
	on pc.CategoryCode = c.Code 
	inner join Products p 
	on pc.ProductCode = p.Code 
	and p.IsAvailable = 1
	group by c.Code
) iq
inner join Categories c 
on c.Code = iq.Code 
order by iq.mean desc 
go 