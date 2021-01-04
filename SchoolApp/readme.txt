create table Student(
	StudentID int not null primary key identity,
	StudentName nvarchar(60) null,
	StudentState int null,
	StudentCity int null,
	StudentMarkes int not null,
	StudentPercentage decimal(10,2) null,
	CreatedOn datetime not null,
	LastModifiedOn datetime null
)
--drop table Student
select * from Student