use ProductDb 
go 

select p.* 
from Products p 
where p.IsAvailable = 1
and 
(
	select count(pc.categorycode) 
	from ProductCategory pc 
	where pc.ProductCode = p.Code
) > 1
go 