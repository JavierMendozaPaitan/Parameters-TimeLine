
/* TO UPDATE EMPLOYEE*/    
create procedure spUpdateEmployee    
(    
@Id int,    
@Name nvarchar(50),    
@Position nvarchar(50),    
@Office nvarchar(50),    
@Age int,    
@Salary int    
)    
as    
begin    
    update Employee     
    set Name=@Name,Position=@Position,Office=@Office,Age=@Age,Salary=@Salary    
    where Id=@Id    
end    

