Drop Table FaceLog
Create Table FaceLog(
id Int Identity(1,1) Primary Key,
name Varchar(100),
image Varchar(Max),
CreatedDate DateTime Default(GetDate()) Not Null
)
