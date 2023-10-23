
/* TO DELETE EMPLOYEE*/    
create procedure spDeleteDevice   
(    
@Id int    
)    
as    
begin    
    delete from Device where Id=@Id    
end    