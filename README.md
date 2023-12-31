# TimeLineSchedule
This project Is written by .NET8 and it is For displaying the Classes Of university on the TV or anything like airport flies Schedule board
********
this application using repository pattern and it has 3 layers
Datalayer: for store Context and Models (Entity)
Core : for Interface and Implementation classes this classes are using context and provide the logic of the project to avoid using context directly in controller
Web: the main project that is store controller and views 
********
dependency and libraries:
Entity Framework Core , 
MD.PersianDateTimePicker for Persian Date picker
HangFire: in this project I'm using HangFire library that execute some Scheduling Job in the background
excelDataReader: after admin Imports excel file , application read the excel file and stores data from excel into ClassData table in database:
I put My own ExcelFile Here so you can use this structure
*********************
for running this project you should have .NET8 requirement or Visual Studio 2022 version 17.8 or above
for create a database you should add a migration in datalayer project like this: Add-migration InitTBL


