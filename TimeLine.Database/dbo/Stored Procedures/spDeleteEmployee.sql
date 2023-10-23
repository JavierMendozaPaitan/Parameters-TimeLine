
/* TO DELETE EMPLOYEE*/    
create procedure spDeleteEmployee    
(    
@Id int    
)    
as    
begin    
    delete from Employee where Id=@Id    
end    