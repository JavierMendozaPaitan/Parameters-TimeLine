
/* TO UPDATE EMPLOYEE*/    
create procedure spUpdateDevice
(    
@Id int,    
@SerialNumber nvarchar(50),    
@Status nvarchar(50),    
@StartDate Date,    
@EndDate Date  
)    
as    
begin    
    update Device     
    set SerialNumber=@SerialNumber,Status=@Status,StartDate=@StartDate,EndDate=@EndDate    
    where Id=@Id    
end    

