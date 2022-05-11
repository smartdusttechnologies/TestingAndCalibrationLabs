insert into TestingCategoryLookup1(Name,Descrpition,Position,IsDeleted) values ('SOMEONE','shreesmartdusttech','1','0');

insert into TestingCategoryLookup1(Name,Descrpition,ParentId,Position,IsDeleted) values ('SOMEONE2','shreesmartdusttech',(Select SCOPE_IDENTITY()),'1','0');

insert into TestingCategoryLookup1(Name,Descrpition,ParentId,Position,IsDeleted) values ('SOMEONE3','shreesmartdusttech',(Select SCOPE_IDENTITY()),'1','0');