CREATE TABLE [dbo].[Location] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [AddrLine1] NVARCHAR (MAX) NOT NULL,
    [AddrLine2] NVARCHAR (MAX) NULL,
    [City]      NVARCHAR (MAX) NOT NULL,
    [Postcode]  NVARCHAR (MAX) NOT NULL,
    [Country]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Contact] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NULL,
    [Phone]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Appointment] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Recurring]   BIT            NOT NULL,
    [FK_Location] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LOCATION_CONSTRAINT] FOREIGN KEY ([FK_Location]) REFERENCES [dbo].[Location] ([Id])
);

CREATE TABLE [dbo].[Tutorial] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Recurring]   BIT            NOT NULL,
    [Lecturer]    NVARCHAR (MAX) NULL,
    [Lab]         NVARCHAR (MAX) NULL,
    [FK_LOCATION] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_LOCATION]) REFERENCES [dbo].[Location] ([Id])
);

CREATE TABLE [dbo].[Task] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Recurring]   BIT            NOT NULL,
    [Finished]    BIT            NOT NULL,
    [FK_LOCATION] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_LOCATION]) REFERENCES [dbo].[Location] ([Id])
);

CREATE TABLE [dbo].[Lecture] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Recurring]   BIT            NOT NULL,
    [Lecturer]    NVARCHAR (MAX) NULL,
    [FK_LOCATION] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_LOCATION]) REFERENCES [dbo].[Location] ([Id])
);

CREATE TABLE [dbo].[Contact-Tutorial] (
    [Contact_Id]  INT NOT NULL,
    [Tutorial_Id] INT NOT NULL,
    CONSTRAINT [COMPOUND_PK_TUTORIAL] PRIMARY KEY CLUSTERED ([Contact_Id] ASC, [Tutorial_Id] ASC),
    CONSTRAINT [FK_CONTACT_CONSTRAINT_TUTORIAL] FOREIGN KEY ([Contact_Id]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_Tutorial_CONSTRAINT] FOREIGN KEY ([Tutorial_Id]) REFERENCES [dbo].[Tutorial] ([Id])
);

CREATE TABLE [dbo].[Contact-Task] (
    [Contact_Id] INT NOT NULL,
    [Task_Id]    INT NOT NULL,
    CONSTRAINT [COMPOUND_PK_TASK] PRIMARY KEY CLUSTERED ([Contact_Id] ASC, [Task_Id] ASC),
    CONSTRAINT [FK_CONTACT_CONSTRAINT_TASK] FOREIGN KEY ([Contact_Id]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_Task_CONSTRAINT] FOREIGN KEY ([Task_Id]) REFERENCES [dbo].[Task] ([Id])
);

CREATE TABLE [dbo].[Contact-Lecture] (
    [Contact_Id] INT NOT NULL,
    [Lecture_Id] INT NOT NULL,
    CONSTRAINT [COMPOUND_PK_LECTURE] PRIMARY KEY CLUSTERED ([Contact_Id] ASC, [Lecture_Id] ASC),
    CONSTRAINT [FK_CONTACT_CONSTRAINT_LECTURE] FOREIGN KEY ([Contact_Id]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_Lecture_CONSTRAINT] FOREIGN KEY ([Lecture_Id]) REFERENCES [dbo].[Lecture] ([Id])
);

CREATE TABLE [dbo].[Contact-Appointment] (
    [Contact_Id]     INT NOT NULL,
    [Appointment_Id] INT NOT NULL,
    CONSTRAINT [COMPOUND_PK] PRIMARY KEY CLUSTERED ([Contact_Id] ASC, [Appointment_Id] ASC),
    CONSTRAINT [FK_CONTACT_CONSTRAINT] FOREIGN KEY ([Contact_Id]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_APPOINTMENT_CONSTRAINT] FOREIGN KEY ([Appointment_Id]) REFERENCES [dbo].[Appointment] ([Id])
);
