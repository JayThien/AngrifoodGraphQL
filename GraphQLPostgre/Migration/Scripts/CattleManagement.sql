CREATE SCHEMA IF NOT EXISTS master_data;

CREATE TABLE IF NOT EXISTS master_data.AspNetRoles (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "Name" character varying(256) NULL,
  "CreatedDate" bigint NULL,
  "CreatedByUserId" int NULL,
  "CreatedByUserName" character varying(250) NULL,
  "UpdatedDate" bigint NULL,
  "UpdatedByUserId" int NULL,
  "UpdatedByUserName" character varying(250) NULL
);

CREATE TABLE IF NOT EXISTS master_data.AspNetUserRoles (
  "UserId" int NOT NULL,
  "RolesId" int NOT NULL
);

CREATE TABLE IF NOT EXISTS master_data.AspNetUsers (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "UserName" character varying(256) NULL,
  "NormalizedUserName" character varying(256) NULL,
  "Email" character varying(256) NULL,
  "NormalizedEmail" character varying(256) NULL,
  "EmailConfirmed" bit NULL,
  "PasswordHash" character varying(250) NULL,
  "SecurityStamp" character varying(250) NULL,
  "ConcurrencyStamp" character varying(250) NULL,
  "PhoneNumber" character varying(250) NULL,
  "PhoneNumberConfirmed" bit NULL,
  "TwoFactorEnabled" bit NULL,
  "LockoutEnd" bigint NULL,
  "LockoutEnabled" bit NULL,
  "AccessFailedCount" int NULL,
  "AvatarURL" character varying(250) null,
  "Status" bit NULL,
  "CreatedDate" bigint NULL,
  "CreatedByUserId" int NULL,
  "CreatedByUserName" character varying(250) NULL,
  "UpdatedDate" bigint NULL,
  "UpdatedByUserId" int NULL,
  "UpdatedByUserName" character varying(250) NULL,
  "NetResetCode" character varying(250) NULL,
  "ResetCode" character varying(250) NULL
);

CREATE TABLE IF NOT EXISTS master_data.Farmer (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "Code" character varying(20) NULL,
  "Name" character varying(50) NULL,
  "FullName" character varying(100) NULL,
  "PhoneNumber" character varying(15) NULL,
  "Address" character varying(250) NULL,
  "Birthday" date NULL,
  "Email" character varying(256) NULL,
  "Gender" character varying(10) NULL,
  "Status" character varying(50) NULL,
  "IdentificationNo" character varying(20) NULL,
  "IssuedOn" date NULL,
  "IssuedBy" character varying(256) NULL,
  "AccountNumber" character varying(20) NULL,
  "Bank" character varying(256) NULL,
  "BankBranch" character varying(256) NULL,
  "UserId" int NULL
);

CREATE TABLE IF NOT EXISTS master_data.TypeOfCattle (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "Code" character varying(10) NULL,
  "Name" character varying(100) NULL
);

CREATE TABLE IF NOT EXISTS master_data.Cattle (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "ByreId" int NOT NULL,
  "MotherId" int NULL,
  "FatherId" int NULL,
  "Name" character varying(50) NULL,
  "Code" character varying(20) NULL,
  "Birthday" date NULL,
  "DateBuy" date NULL,
  "ReproductionDateNearest" date NULL,
  "Gender" character varying(10) NULL,
  "TypeOfCattleId" int NULL
);

CREATE TABLE IF NOT EXISTS master_data.Byre (
  "Id" SERIAL PRIMARY KEY NOT NULL,
  "Code" character varying(10) NULL,
  "Name" character varying(100) NULL,
  "QuantityCattle" int NULL,
  "FarmerId" int NULL
);

ALTER TABLE master_data.AspNetUserRoles ADD FOREIGN KEY ("UserId") REFERENCES master_data.AspNetUsers ("Id");

ALTER TABLE master_data.AspNetUserRoles ADD FOREIGN KEY ("RolesId") REFERENCES master_data.AspNetRoles ("Id");

ALTER TABLE master_data.Farmer ADD FOREIGN KEY ("UserId") REFERENCES master_data.AspNetUsers ("Id");

ALTER TABLE master_data.Byre ADD FOREIGN KEY ("FarmerId") REFERENCES master_data.Farmer ("Id");

alter table master_data.Cattle add foreign key ("ByreId") references master_data.Byre ("Id");

ALTER TABLE master_data.Cattle ADD FOREIGN KEY ("TypeOfCattleId") REFERENCES master_data.TypeOfCattle ("Id");
