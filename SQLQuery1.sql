--select 'drop table ' || table_name || ' cascade constraints;' from user_tables;


/******* System  *********/

CREATE TABLE "DATA_PROTECTION_KEYS" -- Keys mã hóa dữ liệu
(	
  ID int IDENTITY(1, 1) PRIMARY KEY,
  "FRIENDLY_NAME" nvarchar(4000), -- Tên key
  "XML" nvarchar(4000) -- Thông tin key
);

CREATE TABLE "IDENTITY_CLIENTS"  -- Cấu hình truy cập hệ thống
(	
  "IDENTITY_CLIENT_ID" nvarchar(900) PRIMARY KEY, -- Mã ứng dụng truy cập
  "DESCRIPTION" nvarchar(100) NOT NULL, -- Mô tả
  "SECRET_KEY" nvarchar(4000) NOT NULL, -- Mã bí mật
  "CLIENT_TYPE" BIGINT NOT NULL, -- Loại ứng dụng
  "IS_ACTIVE" SMALLINT DEFAULT 1 NOT NULL, -- Trạng thái hoạt động 
  "REFRESH_TOKEN_LIFE_TIME" BIGINT NOT NULL, -- Thời gian tồn tại của Refresh Token
  "ALLOWED_ORIGIN" nvarchar(1000)
);

CREATE TABLE "IDENTITY_REFRESH_TOKENS" -- Thông tin refresh token
(	
  "IDENTITY_REFRESH_TOKEN_ID" nvarchar(900) PRIMARY KEY, -- ID refresh token
  "IDENTITY" nvarchar(50) NOT NULL, -- Người dùng token
  "CLIENT_ID" nvarchar(4000) NOT NULL, -- mã ứng dụng truy cập
  "ISSUED_UTC" DATETIME2 (7) NOT NULL, -- Ngày cấp
  "EXPIRES_UTC" DATETIME2 (7) NOT NULL, -- Ngày hết hạn
  "REFRESH_TOKEN" nVARCHAR(4000) NOT NULL -- Mã refresh token
);

CREATE TABLE "PRIVILEGES" -- Quyền hạn sử dụng chức năng hệ thống
(
  "ID" nVARCHAR(50) PRIMARY KEY, -- Mã quyền hạn
  "NAME" nVARCHAR(250) NOT NULL, -- Tên quyền hạn
  "DESCRIPTION" nVARCHAR(4000), -- Mô tả
);

CREATE TABLE "ROLES" -- Nhóm người dùng
(
  ID int IDENTITY(1, 1) PRIMARY KEY,
  "NAME" nvarchar(250) NOT NULL, -- Tên người dùng
  "DESCRIPTION" nVARCHAR(4000), -- Mô tả
);

CREATE TABLE "USERS" -- Tài khoản người dùng hệ thống
(	
  ID int IDENTITY(1, 1) PRIMARY KEY,
  "USER_NAME" nVARCHAR(4000), -- Tên đăng nhập
  "NORMALIZED_USER_NAME" nVARCHAR(4000), -- Tên đăng nhập viết chữ thường
  "EMAIL" nVARCHAR(4000), -- Email
  "NORMALIZED_EMAIL" nVARCHAR(4000), -- Email viết chữ thường
  "EMAIL_CONFIRMED" bit NOT NULL, -- Xác nhận email
  "PASSWORD_HASH" nVARCHAR(4000), -- Mật khẩu mã hóa
  "SECURITY_STAMP" nVARCHAR(4000), -- Mã bảo mật thông tin tài khoản
  "CONCURRENCY_STAMP" nVARCHAR(4000), -- Mã bảo mật nhiều người đồng thời sử dụng tài khoản
  "PHONE_NUMBER" nVARCHAR(4000), -- Số điện thoại
  "PHONE_NUMBER_CONFIRMED" bit NOT NULL, -- Xác nhận SĐT
  "TWO_FACTOR_ENABLED" bit NOT NULL, -- Bảo mật 2 lớp
  "LOCKOUT_END" datetime, -- Thời gian hết hạn khóa tài khoản
  "LOCKOUT_ENABLED" bit NOT NULL, -- Khóa tài khoản
  "ACCESS_FAILED_COUNT" int NOT NULL, -- Số lần đăng nhập thất bại
  "FULL_NAME" nVARCHAR(250), -- Tên người dùng
  "IS_ADMINISTRATOR" bit NOT NULL, -- Tài khoản quản trị
  "DELETED_DATE" DATE NULL, -- Ngày xóa dữ liệu
  "DELETED_USER_ID" int REFERENCES "USERS"("ID") NULL -- Người xóa dữ liệu
);

CREATE TABLE "ROLE_PRIVILEGES" -- Quyền hạn nhóm người dùng
(
  "ROLE_ID" int, -- ID nhóm người dùng
        FOREIGN KEY (ROLE_ID) REFERENCES ROLES(ID),

  "PRIVILEGE_ID" nVARCHAR(50) REFERENCES "PRIVILEGES"("ID"), -- Mã quyền hạn
  PRIMARY KEY(ROLE_ID,PRIVILEGE_ID)
);

CREATE TABLE "USER_PRIVILEGES" -- Quyền hạn người dùng
(	
  "USER_ID" int REFERENCES "USERS"("ID"), -- ID người dùng
	"PRIVILEGE_ID" nVARCHAR(50) REFERENCES "PRIVILEGES"("ID"), -- Mã quyền hạn
  PRIMARY KEY("USER_ID","PRIVILEGE_ID")
);

CREATE TABLE "USER_ROLES" -- Người dùng thuộc nhóm
(	
  "USER_ID" int REFERENCES "USERS"("ID"), -- ID người dùng
	"ROLE_ID" int REFERENCES "ROLES"("ID"), -- ID nhóm người dùng
  PRIMARY KEY("USER_ID","ROLE_ID")
);

