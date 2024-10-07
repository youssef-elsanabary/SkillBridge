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
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)

);

-- Create the Payments table
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentStatus NVARCHAR(50) NOT NULL CHECK (PaymentStatus IN ('Paid', 'Failed')),
    FOREIGN KEY (UserId) REFERENCES Users(UserId), 
    FOREIGN KEY (ContractId) REFERENCES Contracts(ContractId) 

);
-- Create the Contracts table
CREATE TABLE Contracts (
    ContractId INT PRIMARY KEY IDENTITY(1,1),
    ServiceId INT NOT NULL,
    UserId INT NOT NULL,
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Active', 'Completed', 'Cancelled')),
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
-- Create the Profiles table
CREATE TABLE Profiles (
    ProfileId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Name NVARCHAR(200),
    Image NVARCHAR(200),
    Description NVARCHAR(MAX),
    Bio NVARCHAR(MAX),
    Skills NVARCHAR(MAX),
    CvFile NVARCHAR(200),
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
-- Create the Proposals table
CREATE TABLE Proposals (
    ProposalId INT PRIMARY KEY IDENTITY(1,1),
    ServiceId INT NOT NULL,
    UserId INT NOT NULL,
    ProposalDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) CHECK (Status IN ('Pending', 'Accepted', 'Rejected')) DEFAULT 'Pending',
    FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
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
    FOREIGN KEY (ReceiverId) REFERENCES Users(UserId)
);
