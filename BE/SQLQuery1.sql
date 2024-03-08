--create database student_management
create table department
(
	ID int IDENTITY(1,1) primary key not null,
	name_depart nvarchar(50) not null
	)

create table classes(
	ID int IDENTITY(1,1) primary key not null,
	name_class nvarchar(50) not null,
	id_depart int not null,
	CONSTRAINT fk_id_department
  FOREIGN KEY (id_depart)
  REFERENCES department (ID)
)
create table students(
	ID int primary key not null,
	student_name Nvarchar(50) not null,
	date_of_birth date,
	town Nvarchar(50),
	id_classes int not null,
	CONSTRAINT fk_id_classes
	  FOREIGN KEY (id_classes)
	  REFERENCES classes (ID)
	)
create table Courses(
	ID int IDENTITY(1,1) primary key not null,
	courses_name Nvarchar(50) not null,
	
	)
create table stu_cour(
	id_student int not null,
	id_courses int not null,
	point_process float,
	point_test float,
	number int not null,
	PRIMARY KEY (id_student, id_courses, number),
    FOREIGN KEY (id_student) REFERENCES students(ID),
    FOREIGN KEY (id_courses) REFERENCES Courses(ID)
	)


insert into department (name_depart) values
(N'Công Nghệ Thông Tin'),
(N'Kinh Tế Vận Tải'),
(N'Điện Diện Tử');

insert into classes(name_class, id_depart) values
(N'CNTT1',1),
(N'CNTT2',1),
(N'CNTT3',1),
(N'KTVT1',2),
(N'DDT',3);

select * from classes
delete students where ID = 20120005
update students set student_name = N'Đoàn Thị Mai Anh', town = N'Nam Đinh' where ID = 20
insert into students(ID,student_name,town,date_of_birth,id_classes) values
(201200084, N'Phạm Công A', N'Nam Định', '2002-04-18',1),
(201200088, N'Phạm Công b', N'Nam Định', '2002-04-19',2),
(201200087, N'Phạm Công c', N'Nam Định', '2002-04-20',5);

insert into Courses(courses_name) values
(N'Triết'),
(N'Tin đại cương'),
(N'Thể dục');


insert into stu_cour(id_student,id_courses,point_process,point_test, number) values
--(201200084,1,8,9,1),
--(201200084,1,8,9,2),
(201200088,1,'','',1);
select students.ID, students.student_name,classes.name_class,Courses.courses_name, stu_cour.number, stu_cour.point_process,stu_cour.point_test,
(stu_cour.point_process * 0.4 + stu_cour.point_test *0.6) as diemkt
from classes inner join students on classes.ID = students.id_classes
				right join stu_cour on students.ID = stu_cour.id_student
				left join Courses on Courses.ID= stu_cour.id_courses
				where students.ID=201200084
create table account (
ID int Identity(1,1) not null,
id_students int not null,
password nvarchar(255) not null,
email nvarchar(50),
roler int ,
Foreign key (id_students) REFERENCES students(ID)
)