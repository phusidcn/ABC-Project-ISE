CREATE DATABASE QLChiTieu
GO
USE QLChiTieu
GO
--------create table--------
CREATE TABLE Users(
	ID INT PRIMARY KEY,
	Ten nvarchar(50) NOT NULL,
	UserName varchar(50) NOT NULL UNIQUE,
	PWHash BINARY(64) NOT NULL,
	Ngay_Sinh date null
)

CREATE TABLE Vi
(
	ID INT PRIMARY KEY,
	TEN nvarchar(50) NOT NULL,
	SO_TIEN INT NOT NULL,
)

CREATE TABLE USER_VI
(
	ID_USER INT NOT NULL,
	ID_VI INT NOT NULL,
	CONSTRAINT PK_USERVI PRIMARY KEY(ID_USER, ID_VI)
)

CREATE TABLE HEO
(
	ID INT PRIMARY KEY,
	TEN nvarchar(50) NOT NULL,
	MUC_DICH nvarchar(150) NOT NULL,
	MUC_TIEU INT NOT NULL,
	HIEN_TAI INT NOT NULL,
	NGAY_KT DATE NULL,
	ID_USER INT NOT NULL
)

CREATE TABLE SO_GIAO_DICH
(
	ID INT PRIMARY KEY,
	ID_VI INT NOT NULL,
	ID_NHOM INT NOT NULL,
	SO_TIEN INT NOT NULL, --VÌ LÀ TIỀN VIỆT NÊN DÙNG INT
	GHI_CHU nvarchar(150) null,
	NguoiLQ nvarchar(50) null,
	NGAY DATE null
)

CREATE TABLE USER_GIAO_DICH
(
	ID_GIAO_DICH INT,
	ID_USER INT,
	CONSTRAINT PK_USERGD PRIMARY KEY(ID_GIAO_DICH, ID_USER)
)

CREATE TABLE Nhom
(
	ID INT PRIMARY KEY,
	TEN nvarchar(100) NOT NULL,
	ICON nvarchar(100) NOT NULL
)

CREATE TABLE SO_NO
(
	ID INT PRIMARY KEY,
	ID_VI INT NOT NULL,
	LOAI nvarchar(20) NOT NULL,
	SO_TIEN INT NOT NULL,
	Ghi_Chu nvarchar(50) null,
	PERSON nvarchar(25) NOT NULL,
	NGAY DATE NOT NULL,
	DaTra INT NOT NULL
)

CREATE TABLE SO_NO_USER
(
	ID_SO_NO INT NOT NULL,
	ID_USER INT NOT NULL,
	CONSTRAINT PK_NO_USER PRIMARY KEY(ID_SO_NO,ID_USER)
)

Go

---FOREIGN KEY
ALTER TABLE USER_VI ADD CONSTRAINT FK_USER_VI_USER FOREIGN KEY(ID_USER) REFERENCES Users(ID)
ALTER TABLE USER_VI ADD CONSTRAINT FK_USER_VI_VI FOREIGN KEY(ID_VI) REFERENCES Vi(ID)

ALTER TABLE SO_GIAO_DICH ADD CONSTRAINT FK_SOGD_VI FOREIGN KEY(ID_VI) REFERENCES Vi(ID)
ALTER TABLE SO_GIAO_DICH ADD CONSTRAINT FK_SOGD_NHOM FOREIGN KEY(ID_NHOM) REFERENCES Nhom(ID)

ALTER TABLE USER_GIAO_DICH ADD CONSTRAINT FK_USERGD_USERS FOREIGN KEY(ID_USER) REFERENCES Users(ID)
ALTER TABLE USER_GIAO_DICH ADD CONSTRAINT FK_USERGD_GIAO_DICH FOREIGN KEY(ID_GIAO_DICH) REFERENCES SO_GIAO_DICH(ID)

ALTER TABLE SO_NO ADD CONSTRAINT FK_SO_NO_VI FOREIGN KEY(ID_VI) REFERENCES Vi(ID) 

ALTER TABLE HEO ADD CONSTRAINT FK_HEO_USER FOREIGN KEY(ID_USER) REFERENCES Users(ID)

ALTER TABLE SO_NO_USER ADD CONSTRAINT FK_SO_NO_USER__SO_NO FOREIGN KEY(ID_SO_NO) REFERENCES SO_NO(ID)
ALTER TABLE SO_NO_USER ADD CONSTRAINT FK_SO_NO_USER__USER FOREIGN KEY(ID_USER) REFERENCES Users(ID)
Go


INSERT INTO Nhom(ID, TEN, ICON)
VALUES
(1, N'Nhu cầu thiết yếu', N'icon/Bill.png'),
(2,N'Giáo dục',N'icon/Education.png'),
(3, N'Hưởng thụ', N'icon/Health.png'),
(4, N'Tự do tài chính', N'icon/Gift.png'),
(5, N'Tiết kiệm dài hạn', N'icon/SaveMoney.png'),
(6, N'Giúp đỡ người khác', N'icon/FriendsAndLover.png'),
(7, N'Thu nhập', N'icon/Bonus.png');

Go

create procedure dbo.uspAddUser
    @pUsername VARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pTen NVARCHAR(50) = NULL,
	@pDob date = NULL,
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
	DECLARE @userID INT
	DECLARE @ngansachID INT
	SET @userID = (SELECT COUNT(*) FROM Users) + 1;
	SET @ngansachID = (SELECT COUNT(*) FROM USER_Ngan_Sach) +1;
    BEGIN TRY

        INSERT INTO dbo.[Users] (ID, Ten, UserName, PWHash, Ngay_Sinh)
        VALUES(@userID, @pTen, @pUsername , HASHBYTES('SHA2_512', @pPassword), @pDob)

        SET @responseMessage='Success'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END

go
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

go

create procedure dbo.uspModifyUserName
	@pId INT,
	@uPassword NVARCHAR(50),
	@nUsername NVARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	if exists (select id from [dbo].[Users] where PWHash = HASHBYTES('SHA2_512', @uPassword))
	Begin
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
		else
		set @responseMessage='incorrect password'
end	
go

create procedure dbo.uspModifyPassWord
	@pId INT,
	@oldPassword NVARCHAR(50),
	@newPassword NVARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	if exists (select id from [dbo].Users where PWHash = HASHBYTES('SHA2_512', @oldPassword))
	BEGIN TRY
		update Users
		set PWHash = HASHBYTES('SHA2_512',@newPassword)
		where id = @pId
		set @responseMessage='successful'
	end try 
	begin catch
		set @responseMessage='error'
	END CATCH
	else
		set @responseMessage='your password is incorrect'
end
go

--khoan cho vay: loai = 8,, Datra = 0 -> chua tra =1
create procedure dbo.uspThemKhoanVay
	@pId_User INT,
	@pId_Vi INT,
	@pPerson NVARCHAR(25),
	@pSoTien INT,
	@pGhiChu nvarchar(50) = null,
	@pNgayVay date = null,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
	DECLARE @id int
	set @id = (Select count(*) from SO_NO) + 1;
	Declare @TienVi INT
	set @TienVi = (select Vi.SO_TIEN from Vi Where Vi.ID = @pId_Vi)
    BEGIN TRY
		INSERT INTO dbo.[SO_NO](ID, ID_VI, LOAI, SO_TIEN, Ghi_Chu, PERSON, NGAY, DaTra)
		VALUES(@id, @pId_Vi, 8, @pSoTien, @pGhiChu,@pPerson, @pNgayVay,0)

		INSERT INTO dbo.[SO_NO_USER](ID_SO_NO,ID_USER)
		VALUES(@id, @pId_User)

		UPDATE dbo.Vi
		SET Vi.SO_TIEN = @TienVi + @pSoTien
		WHERE Vi.ID = @pId_Vi

        SET @responseMessage='Success'
    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH
END
go

--khoan cho vay: loai = 9,, Datra = 0 -> chua tra =1
create procedure dbo.uspThemKhoanChoVay
	@pId_User INT,
	@pId_Vi INT,
	@pPerson NVARCHAR(25),
	@pSoTien INT,
	@pGhiChu nvarchar(50) = null,
	@pNgayVay date = null,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
	DECLARE @id int
	set @id = (Select count(*) from SO_NO) + 1;
	Declare @TienVi INT
	set @TienVi = (select Vi.SO_TIEN from Vi Where Vi.ID = @pId_Vi)
	if (@pSoTien <= @TienVi)
	BEGIN
    BEGIN TRY
		INSERT INTO dbo.[SO_NO](ID, ID_VI, LOAI, SO_TIEN, Ghi_Chu, PERSON, NGAY, DaTra)
		VALUES(@id, @pId_Vi, 9, @pSoTien, @pGhiChu,@pPerson, @pNgayVay,0)

		INSERT INTO dbo.[SO_NO_USER](ID_SO_NO,ID_USER)
		VALUES(@id, @pId_User)

		UPDATE dbo.Vi
		SET Vi.SO_TIEN = @TienVi - @pSoTien
		WHERE Vi.ID = @pId_Vi

        SET @responseMessage='Success'
    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH
	END
	ELSE
		SET @responseMessage = N'Số tiền không đủ'
END
go

create procedure dbo.uspThemGiaoDich
	@pIdUser INT,
	@pVi INT,
	@pIdNhom INT, 
	@pSoTien INT,
	@pGhiChu NVARCHAR(50) = NULL,
	@pNguoiLienQuan NVARCHAR(50) = NULL,
	@pNgay date = NULL,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
	Declare @idGiaoDich INT
	set @idGiaoDich = (
					select count(*) 
					from SO_GIAO_DICH ) + 1;
	Declare @TienVi INT
	set @TienVi = (select Vi.SO_TIEN from Vi Where Vi.ID = @pVi)
	if (@pSoTien <= @TienVi)
	Begin
		BEGIN TRY
			INSERT INTO dbo.[SO_GIAO_DICH] (ID,ID_VI,ID_NHOM, SO_TIEN, GHI_CHU,NguoiLQ, NGAY)
			VALUES(@idGiaoDich,@pVi,@pIdNhom, @pSoTien , @pGhiChu, @pNguoiLienQuan, @pNgay)
		
			INSERT INTO dbo.[USER_GIAO_DICH](ID_GIAO_DICH, ID_USER)
			VALUES(@idGiaoDich, @pIdUser)

			Update Vi
			Set Vi.SO_TIEN = @TienVi - @pSoTien
			Where Vi.ID = @pVi

			SET @responseMessage='Success'
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() 
		END CATCH
	End
	else
		set @responseMessage=N'Số tiền của ví không đủ'
END
Go

create procedure dbo.uspThemTietKiem
	@pIdUser INT,
	@pTenKhoanTk NVARCHAR(100),
	@pMucDich NVARCHAR(100),
	@pMucTieu INT,
	@pNgayKT Date,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @IdTietKiem INT
	SET @IdTietKiem = (SELECT COUNT(*) FROM HEO)
	BEGIN TRY
		INSERT INTO HEO(ID,ID_USER,TEN,MUC_DICH,MUC_TIEU,HIEN_TAI,NGAY_KT)
		VALUES(@IdTietKiem,@pIdUser,@pTenKhoanTk,@pMucDich,@pMucTieu,0,@pNgayKT)

		SET @responseMessage = N'Success'
	END TRY
	BEGIN CATCH
		SET @responseMessage = N'Error'
	END CATCH
END

Go

create procedure dbo.uspThemKhoanTietKiem
	@pIdUser INT,
	@pIdKhoanTK INT,
	@pIdVi INT,
	@pSoTien INT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	Declare @idGiaoDich int
	Declare @TienVi int
	set @TienVi = (select Vi.SO_TIEN from Vi where Vi.ID = @pIdVi)
	set @idGiaoDich = (select count(*) from SO_GIAO_DICH) + 1;
	IF(@TienVi >= @pSoTien)
	BEGIN
		BEGIN TRY
			INSERT INTO SO_GIAO_DICH(ID, ID_VI,ID_NHOM,SO_TIEN,GHI_CHU,NguoiLQ,NGAY)
			VALUES(@idGiaoDich, @pIdVi,5,@pSoTien,N'Tiết kiểm',null, null)

			UPDATE Vi
			SET Vi.SO_TIEN = @TienVi - @pSoTien
			WHERE Vi.ID = @pIdVi

			UPDATE HEO
			SET HIEN_TAI = HIEN_TAI + @pSoTien
			WHERE HEO.ID = @pIdKhoanTK

			SET @responseMessage = N'Success'
		END TRY
		BEGIN CATCH
			SET @responseMessage = N'Error'
		END CATCH
	END
	ELSE
		SET @responseMessage = N'Ví không đủ tiền'
END
Go

CREATE procedure dbo.uspThemVi
	@pIdUser INT,
	@pTenVi NVARCHAR(25),
	@pSoTien INT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	DECLARE @IdVi INT 
	set @IdVi = (SELECT COUNT(*) FROM Vi) + 1;
	BEGIN TRY
		INSERT INTO Vi(ID, TEN, SO_TIEN)
		VALUES(@IdVi, @pTenVi, @pSoTien)

		INSERT INTO USER_VI(ID_USER, ID_VI)
		VALUES(@pIdUser,@pTenVi)

		set @responseMessage = 'Success'
	END TRY
	BEGIN CATCH
		Set @responseMessage = 'Error'
	END CATCH
END
GO

CREATE PROCEDURE dbo.uspTraNo
	@IdUser INT,
	@IdKhoanVay INT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	declare @idVi int
	DECLARE @SoTien int
	set @idVi = (SELECT SO_NO.ID_VI FROM SO_NO WHERE SO_NO.ID = @IdKhoanVay)
	set @SoTien = (Select SO_NO.SO_TIEN From SO_NO where SO_NO.ID = @IdKhoanVay)
	BEGIN TRY
		UPDATE SO_NO SET DaTra = 1 WHERE SO_NO.ID = @IdKhoanVay

		UPDATE Vi SET SO_TIEN = SO_TIEN - @SoTien where ID = @idVi

		SET @responseMessage = 'Success'
	END TRY
	BEGIN CATCH
		SET @responseMessage = 'Error'
	END CATCH
END
GO

CREATE PROCEDURE dbo.uspThuNo
	@IdUser INT,
	@IdKhoanChoVay INT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	declare @idVi int
	DECLARE @SoTien int
	set @idVi = (SELECT SO_NO.ID_VI FROM SO_NO WHERE SO_NO.ID = @IdKhoanChoVay)
	set @SoTien = (Select SO_NO.SO_TIEN From SO_NO where SO_NO.ID = @IdKhoanChoVay)
	BEGIN TRY
		UPDATE SO_NO SET DaTra = 1 WHERE SO_NO.ID = @IdKhoanChoVay

		UPDATE Vi SET SO_TIEN = SO_TIEN + @SoTien where ID = @idVi

		SET @responseMessage = 'Success'
	END TRY
	BEGIN CATCH
		SET @responseMessage = 'Error'
	END CATCH
END
Go