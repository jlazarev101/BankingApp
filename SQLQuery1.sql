CREATE TABLE [dbo].[CurrentAccount] (
    [CAccountNo]     BIGINT        IDENTITY (10000000, 1) NOT NULL,
    [AccountType]    NVARCHAR (20) NOT NULL,
    [SortCode]       INT           DEFAULT ((101010)) NOT NULL,
    [Balance]        FLOAT (53)    NOT NULL,
    [OverdraftLimit] INT           DEFAULT ((-50)) NOT NULL,
    [ClientID]       INT           NULL,
    PRIMARY KEY CLUSTERED ([CAccountNo] ASC)
);

CREATE TABLE [dbo].[CurrentAccountTransaction] (
    [CAccTransID]     INT           IDENTITY (1, 1) NOT NULL,
    [TransactionType] NVARCHAR (50) NOT NULL,
    [Amount]          FLOAT (53)    NOT NULL,
    [Sender]          NVARCHAR (50) NOT NULL,
    [Receiver]        NVARCHAR (50) NOT NULL,
    [CAccountNo]      BIGINT        NOT NULL,
    [ClientID]        INT           NULL,
    PRIMARY KEY CLUSTERED ([CAccTransID] ASC),
    CONSTRAINT [FK_CurrentAccountTransaction_CurrentAccount] FOREIGN KEY ([CAccountNo]) REFERENCES [dbo].[CurrentAccount] ([CAccountNo])
);

CREATE TABLE [dbo].[CurrentClientID] (
    [CurrentClientId] INT DEFAULT ((0)) NULL,
    [ClientID]        INT NOT NULL
);

CREATE TABLE [dbo].[LoginDetail] (
    [LoginDetailID] INT           IDENTITY (1, 1) NOT NULL,
    [Username]      NVARCHAR (50) NOT NULL,
    [PasswordAcc]   NVARCHAR (50) NOT NULL,
    [ClientID]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([LoginDetailID] ASC)
);


CREATE TABLE [dbo].[PersonalDetails] (
    [ClientID]  INT            IDENTITY (1000, 1) NOT NULL,
    [Firstname] NVARCHAR (50)  NOT NULL,
    [Surname]   NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (50)  NOT NULL,
    [Phone]     NVARCHAR (30)  NOT NULL,
    [Address1]  NVARCHAR (100) NOT NULL,
    [Address2]  NVARCHAR (100) NOT NULL,
    [City]      NVARCHAR (50)  NOT NULL,
    [County]    NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientID] ASC)
);

CREATE TABLE [dbo].[SavingsAccount] (
    [SAccountNo]     BIGINT        IDENTITY (20000000, 1) NOT NULL,
    [AccountType]    NVARCHAR (20) NOT NULL,
    [SortCode]       INT           DEFAULT ((101010)) NOT NULL,
    [Balance]        FLOAT (53)    NOT NULL,
    [OverdraftLimit] INT           DEFAULT ((0)) NOT NULL,
    [ClientID]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([SAccountNo] ASC)
);

CREATE TABLE [dbo].[SavingsAccountTransaction] (
    [SAccTransID]     INT           IDENTITY (1, 1) NOT NULL,
    [TransactionType] NVARCHAR (50) NOT NULL,
    [Amount]          FLOAT (53)    NOT NULL,
    [Sender]          NVARCHAR (50) NOT NULL,
    [Receiver]        NVARCHAR (50) NOT NULL,
    [SAccountNo]      NVARCHAR (50) NOT NULL,
    [ClientID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([SAccTransID] ASC)
);