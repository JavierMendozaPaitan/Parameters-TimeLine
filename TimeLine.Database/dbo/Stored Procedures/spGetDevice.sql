
/* TO GET EMPLOYEE BY ID */
create procedure spGetDevice   
(    
@Id int    
)    
as    
begin    
    select * from Device  where Id=@Id    
end    

