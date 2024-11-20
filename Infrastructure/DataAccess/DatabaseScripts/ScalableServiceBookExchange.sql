USE master
DROP DATABASE ScalableServiceBookExchange
CREATE DATABASE ScalableServiceBookExchange
USE ScalableServiceBookExchange
CREATE TABLE ExchangeRequests (
    RequestId INT PRIMARY KEY IDENTITY(1,1),
    RequestTypeId INT NOT NULL, -- "exchange" or "lend/borrow"
    SenderBookId NVARCHAR(50) NOT NULL,
    ReceiverBookId NVARCHAR(50), -- not required for lend/borrow
    SenderUserId NVARCHAR(50) NOT NULL,
    ReceiverUserId NVARCHAR(50) NOT NULL,
    DeliveryMethodId INT NOT NULL,
    ExchangeDuration INT,
    PaymentMethodId INT, -- Optional for exchange
    StatusId INT NOT NULL
);

CREATE TABLE RequestTypes (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO RequestTypes (Id, Name) VALUES
(1, 'Exchange'),
(2, 'lend/borrow');

CREATE TABLE DeliveryMethods (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO DeliveryMethods (Id, Name) VALUES
(1, 'InPerson'),
(2, 'Courier'),
(3, 'PostalService');

CREATE TABLE PaymentMethods (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO PaymentMethods (Id, Name) VALUES
(1, 'Online'),
(2, 'OnDelivery');

CREATE TABLE Statuses (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO Statuses (Id, Name) VALUES
(1, 'Pending'),
(2, 'Accepted'),
(3, 'Rejected'),
(4, 'Modified');

ALTER TABLE ExchangeRequests
ADD CONSTRAINT FK_RequestTypes_RequestType
FOREIGN KEY (RequestTypeId) REFERENCES RequestTypes(Id);

ALTER TABLE ExchangeRequests
ADD CONSTRAINT FK_ExchangeRequests_DeliveryMethod
FOREIGN KEY (DeliveryMethodId) REFERENCES DeliveryMethods(Id);

ALTER TABLE ExchangeRequests
ADD CONSTRAINT FK_ExchangeRequests_PaymentMethod
FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethods(Id);

ALTER TABLE ExchangeRequests
ADD CONSTRAINT FK_ExchangeRequests_Status
FOREIGN KEY (StatusId) REFERENCES Statuses(Id);
GO

-- lookup stored procedures
CREATE PROCEDURE GetRequestTypes
AS
BEGIN
    SELECT * FROM RequestTypes;
END
GO

CREATE PROCEDURE GetDeliveryMethods
AS
BEGIN
    SELECT * FROM DeliveryMethods;
END
GO

CREATE PROCEDURE GetPaymentMethods
AS
BEGIN
    SELECT * FROM PaymentMethods;
END
GO

CREATE PROCEDURE GetStatuses
AS
BEGIN
    SELECT * FROM Statuses;
END
GO

-- book exchange stored procedures
CREATE PROCEDURE GetExchangeRequestById
    @RequestId INT
AS
BEGIN
    SELECT * FROM ExchangeRequests WHERE RequestId = @RequestId;
END
GO

CREATE PROCEDURE GetAllExchangeRequestsByUserId
    @UserId NVARCHAR(50)
AS
BEGIN
    SELECT * FROM ExchangeRequests WHERE ReceiverUserId = @UserId OR SenderUserId = @UserId;
END
GO


CREATE PROCEDURE AddExchangeRequest
    @RequestTypeId INT,
    @SenderBookId NVARCHAR(50),
    @ReceiverBookId NVARCHAR(50),
    @SenderUserId NVARCHAR(50),
    @ReceiverUserId NVARCHAR(50),
    @DeliveryMethodId INT,
    @ExchangeDuration INT,
    @PaymentMethodId INT,
    @StatusId INT
AS
BEGIN
    DECLARE @InsertedRequestIds TABLE (RequestId INT);

    INSERT INTO ExchangeRequests (RequestTypeId, SenderBookId, ReceiverBookId, SenderUserId, ReceiverUserId, DeliveryMethodId, ExchangeDuration, PaymentMethodId, StatusId)
    OUTPUT INSERTED.RequestId INTO @InsertedRequestIds
    VALUES (@RequestTypeId, @SenderBookId, @ReceiverBookId, @SenderUserId, @ReceiverUserId, @DeliveryMethodId, @ExchangeDuration, @PaymentMethodId, @StatusId);

    SELECT RequestId FROM @InsertedRequestIds;
END
GO



CREATE PROCEDURE UpdateExchangeRequest
    @RequestId INT,
    @RequestTypeId INT,
    @SenderBookId NVARCHAR(50),
    @ReceiverBookId NVARCHAR(50),
    @SenderUserId NVARCHAR(50),
    @ReceiverUserId NVARCHAR(50),
    @DeliveryMethodId INT,
    @ExchangeDuration INT,
    @PaymentMethodId INT,
    @StatusId INT
AS
BEGIN
    UPDATE ExchangeRequests
    SET RequestTypeId = @RequestTypeId, SenderBookId = @SenderBookId, ReceiverBookId = @ReceiverBookId, SenderUserId = @SenderUserId, ReceiverUserId = @ReceiverUserId, DeliveryMethodId = @DeliveryMethodId, ExchangeDuration = @ExchangeDuration, PaymentMethodId = @PaymentMethodId, StatusId = @StatusId
    WHERE RequestId = @RequestId;
END
GO

