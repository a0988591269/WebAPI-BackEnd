# WebAPI-BackEnd

初次起專案時如未建立DB，請依以下步驟執行SQL指令

Step 1.
create Database EmployeeDB

Step 2.
create table dbo.Department(
	DepartmentId int identity(1,1),
	DepartmentName nvarchar(500)
)
insert into [dbo].[Department] values ('IT')
insert into [dbo].[Department] values ('Support')

Step 3.
create table dbo.Employee(
	EmployeeId int identity(1,1),
	EmployeeName nvarchar(500),
	Department nvarchar(500),
	DateOfJoin datetime2,
	PhotoFileName nvarchar(500)
)
insert into [dbo].[Employee] values ('Xuan','IT','2022-06-27 12:50:00','anonymous.png')
