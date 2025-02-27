Create Table Coupon (
					 Id Serial Primary Key,
                     ProductName varchar(24) Not Null,
                     Description Text,
                     Amount Int);
															
Insert into Coupon (ProductName, Description, Amount)
            Values ('IPhone X', 'IPhone Discount', 150);
			
Insert into Coupon (ProductName, Description, Amount)
            Values ('Samsung 20', 'Samsung Discount', 100)