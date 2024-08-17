-- Create the Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    UserType NVARCHAR(50) NOT NULL CHECK (UserType IN ('Freelancer', 'Client')),
    CreatedDate DATETIME DEFAULT GETDATE()
);


-- Create the Services table
CREATE TABLE Services (
    ServiceId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Category NVARCHAR(100),
	Status NVARCHAR(20) CHECK (Status IN ('Active', 'Completed', 'Canceled')) DEFAULT 'Active',
	CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)

);


-- Create the Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    ServiceId INT NOT NULL,
    BuyerId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Accepted', 'Rejected')) DEFAULT 'Pending', -- Pending, Completed, Cancelled 
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    FOREIGN KEY (BuyerId) REFERENCES Users(UserId)
);


-- Create the Payments table
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentStatus NVARCHAR(50) NOT NULL, -- Paid, Failed  Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Accepted', 'Rejected')) DEFAULT 'Pending',
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);


-- Create the Reviews table
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1,1),
    ServiceId INT NOT NULL,
    BuyerId INT NOT NULL,
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    Comment NVARCHAR(MAX),
    ReviewDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    FOREIGN KEY (BuyerId) REFERENCES Users(UserId)
);


-- Create the Messages table
CREATE TABLE Messages (
    MessageId INT PRIMARY KEY IDENTITY(1,1),
    SenderId INT NOT NULL,
    ReceiverId INT NOT NULL,
    OrderId INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    SentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SenderId) REFERENCES Users(UserId),
    FOREIGN KEY (ReceiverId) REFERENCES Users(UserId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);
