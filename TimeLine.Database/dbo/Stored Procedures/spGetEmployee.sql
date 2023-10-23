
/* TO GET EMPLOYEE BY ID */
create procedure spGetEmployee    
(    
@Id int    
)    
as    
begin    
    select * from Employee  where Id=@Id    
end    

