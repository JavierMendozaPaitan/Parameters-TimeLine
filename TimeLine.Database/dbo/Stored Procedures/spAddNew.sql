
/* TO CREATE NEW EMPLOYEE*/
create procedure spAddNew    
(    
@Name nvarchar(50),    
@Position nvarchar(50),    
@Office nvarchar(50),    
@Age int,    
@Salary int    
)    
as    
begin    
    insert into Employee(Name,Position,Office,Age,Salary)    
    values(@Name,@Position,@Office,@Age,@Salary)    
end    

