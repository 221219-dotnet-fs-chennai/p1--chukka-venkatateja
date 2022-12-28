CREATE table Depment(
    DeptId int primary key,
    DeptName varchar(max),
    locat varchar(max),
);

CREATE table Employe(
    empId int primary key,
    FirstName varchar(max),
    lastName varchar(max),
    SSN BIGINT, 
    DeptId int FOREIGN key references Depment(DeptId)
) ;

create table EmplDetaills(
    empId int FOREIGN key references Employe(empId),
    salary int,
    addresss1 varchar(max),
    address2 varchar(max),
    city varchar(max),
    state varchar(max),
    country varchar(max)
);

insert into Depment(DeptId,DeptName,locat) VALUES(101,'Marketing','new york');
insert into Depment(DeptId,DeptName,locat) VALUES(102,'Marketing','new york');
insert into Depment(DeptId,DeptName,locat) VALUES(103,'Marketing','texas');
insert into Depment(DeptId,DeptName,locat) VALUES(105,'HR','new york');

insert into Employe(empId,FirstName,lastName,SSN,DeptId) VALUES(1001,'Tina','smith',718379627343,101);
insert into Employe(empId,FirstName,lastName,SSN,DeptId) VALUES(1002,'shak','husan',718379627349,101);
insert into Employe(empId,FirstName,lastName,SSN,DeptId) VALUES(1003,'raj','kiran',718379627343,102);
insert into Employe(empId,FirstName,lastName,SSN,DeptId) VALUES(1005,'priya','khan',718379627348,102);

insert into EmplDetaills(empid,salary,addresss1,address2,city,[state],country)values(1001,10000,'abc','bac','Nlm','new york','USA')
insert into EmplDetaills(empid,salary,addresss1,address2,city,[state],country)values(1002,16000,'abc','bac','Nlm','new york','USA')
insert into EmplDetaills(empid,salary,addresss1,address2,city,[state],country)values(1003,17000,'abc','bac','Nlm','texas','USA')
---ADDING OF TINASMITH---
insert into Employe(
    empId,FirstName,lastName,SSN,DeptId) 
           VALUES(1007,'Tina','smith',718379627349,102);
---list of all employees in Marketing dep----
select e.empId ,e.FirstName,e.lastname from  Employe e,Depment d where d.DeptName='Marketing';
SELECT COUNT(Depment.DeptId) AS 'TOTALEMPOLYEES' FROM Depment GROUP BY DeptId;
