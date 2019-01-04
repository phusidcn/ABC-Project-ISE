CREATE DATABASE QLChiTieu
GO

USE QLChiTieu
GO
--------create table--------
CREATE TABLE Users(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Ten nvarchar(50) NOT NULL,
	UserName varchar(50) NOT NULL UNIQUE,
	PWHash BINARY(64) NOT NULL,
	Ngay_Sinh date
)

CREATE TABLE Vi
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TEN nvarchar(50) NOT NULL,
	SO_TIEN INT NOT NULL,
	----ID_USER INT NOT NULL
)

CREATE TABLE USER_VI
(
	ID_USER INT NOT NULL,
	ID_VI INT NOT NULL,
	CONSTRAINT PK_USERVI PRIMARY KEY(ID_USER, ID_VI)
)

CREATE TABLE HEO
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TEN nvarchar(50) NOT NULL,
	MUC_DICH nvarchar(150) NOT NULL,
	MUC_TIEU INT NOT NULL,
	HIEN_TAI INT NOT NULL,
	NGAY_KT DATE NOT NULL,
	ID_USER INT NOT NULL
)

CREATE TABLE SO_GIAO_DICH
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	--ID_USER INT NOT NULL,
	ID_VI INT NOT NULL,
	NHOM INT NOT NULL,
	SO_TIEN INT NOT NULL, --VÌ LÀ TIỀN VIỆT NÊN DÙNG INT
	GHI_CHU nvarchar(150) null,
	NGAY DATE
)

------- Có nên tạo bảng User-Vi với User-Giaodich không????

CREATE TABLE USER_GIAO_DICH
(
	ID_GIAO_DICH INT,
	ID_USER INT,
	CONSTRAINT PK_USERGD PRIMARY KEY(ID_GIAO_DICH, ID_USER)
)

CREATE TABLE Nhom
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TEN nvarchar(20) NOT NULL,
	LOAI nvarchar(20) NOT NULL,
	ICON nvarchar(20) NOT NULL
)

CREATE TABLE SO_NO
(
	STT INT IDENTITY NOT NULL,
	ID_GIAO_DICH INT NOT NULL,
	LOAI nvarchar(20) NOT NULL,
	PERSON nvarchar(25) NOT NULL,
	NGAY DATE NOT NULL,
	CONSTRAINT PK_SN PRIMARY KEY(STT, ID_GIAO_DICH)
)

Create table Ngan_Sach
(
	ID INT IDENTITY PRIMARY KEY,
	Ten INT NOT NULL,
	IdNhom INT NOT NULL,
	SoTien INT NOT NULL,
	SoTienConLai INT NOT NULL,
	PhanTram decimal(3,2) NOT NULL,
	Ngay_Bat_Dau DATE NULL,
	Ngay_Ket_Thuc DATE NULL
)


Create table USER_Ngan_Sach
(
	IdNganSach INT NOT NULL,
	IdUser INT NOT NULL
	CONSTRAINT PK_U_N_S PRIMARY KEY(IdNganSach,IdUser)
)

---FOREIGN KEY
ALTER TABLE USER_VI ADD CONSTRAINT FK_USER_VI_USER FOREIGN KEY(ID_USER) REFERENCES Users(ID)
ALTER TABLE USER_VI ADD CONSTRAINT FK_USER_VI_VI FOREIGN KEY(ID_VI) REFERENCES Vi(ID)

ALTER TABLE SO_GIAO_DICH ADD CONSTRAINT FK_SOGD_VI FOREIGN KEY(ID_VI) REFERENCES Vi(ID)
ALTER TABLE SO_GIAO_DICH ADD CONSTRAINT FK_SOGD_NHOM FOREIGN KEY(NHOM) REFERENCES Nhom(ID)

ALTER TABLE USER_GIAO_DICH ADD CONSTRAINT FK_USERGD_USERS FOREIGN KEY(ID_USER) REFERENCES Users(ID)
ALTER TABLE USER_GIAO_DICH ADD CONSTRAINT FK_USERGD_GIAO_DICH FOREIGN KEY(ID_GIAO_DICH) REFERENCES SO_GIAO_DICH(ID)

ALTER TABLE SO_NO ADD CONSTRAINT FK_SO_NO_GIAO_DICH FOREIGN KEY(ID_GIAO_DICH) REFERENCES SO_GIAO_DICH(ID) 

ALTER TABLE HEO ADD CONSTRAINT FK_HEO_USER FOREIGN KEY(ID_USER) REFERENCES Users(ID)

ALTER TABLE USER_Ngan_Sach ADD CONSTRAINT FK_UserNganSach_Users FOREIGN KEY(IdUser) REFERENCES Users(ID)
ALTER TABLE USER_Ngan_Sach ADD CONSTRAINT FK_UserNganSach_NganSach FOREIGN KEY(IdNganSach) REFERENCES Ngan_Sach(ID)

create procedure dbo.uspAddUser
    @pUsername VARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pTen NVARCHAR(50) = NULL,
	@pDob date = NULL,
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO dbo.[Users] (Ten, UserName, PWHash, Ngay_Sinh)
        VALUES(@pTen, @pUsername , HASHBYTES('SHA2_512', @pPassword), @pDob)

        SET @responseMessage='Success'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END

create procedure dbo.uspModifyPassWord
	@pId INT,
	@nPassword NVARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		update Users
		set PWHash = HASHBYTES('SHA2_512',@nPassword)
		where id = @pId
		set @responseMessage='successful'
	end try 
	begin catch
		set @responseMessage='error'
	END CATCH
end
--- procedure login

CREATE PROCEDURE dbo.uspLogin
    @pUsername VARCHAR(50),
    @pPassword NVARCHAR(50),
    @responseMessage NVARCHAR(250)='' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 ID FROM [dbo].[Users] WHERE UserName=@pUsername)
    BEGIN
        SET @userID=(SELECT ID FROM [dbo].[Users] WHERE UserName=@pUsername AND PWHash=HASHBYTES('SHA2_512', @pPassword))

       IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
       ELSE 
           SET @responseMessage='User successfully logged in'
    END
    ELSE
       SET @responseMessage='Invalid login'

END

create procedure dbo.uspModifyUserName
	@pId INT,
	@nUsername NVARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		update Users
		set UserName=@nUsername
		where id = @pId
		set @responseMessage='successful'
	end try 
	begin catch
		set @responseMessage='error'
	END CATCH
end
