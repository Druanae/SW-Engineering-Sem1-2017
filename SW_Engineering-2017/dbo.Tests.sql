CREATE TABLE [dbo].[Tests] (
    [Test_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Patient_ID] INT           NOT NULL,
    [Results]    VARCHAR (MAX) NOT NULL,
    [date] DATE NOT NULL, 
    PRIMARY KEY CLUSTERED ([Test_ID] ASC),
    FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patients] ([Patient_ID])
	
	
);

