
/* TO CREATE NEW EMPLOYEE*/
create procedure spAddNewDevice    
(    
@SerialNumber nvarchar(50),    
@Status nvarchar(50),    
@StartDate Date,    
@EndDate Date    
)    
as    
begin    
    insert into Device(SerialNumber,Status,StartDate,EndDate)    
    values(@SerialNumber,@Status,@StartDate,@EndDate)    
end    

