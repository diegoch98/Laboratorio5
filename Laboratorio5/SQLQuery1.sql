CREATE TABLE Pais(
Id INTEGER PRIMARY KEY IDENTITY,
Nombre VARCHAR(200) NOT NULL,
Idioma VARCHAR(200) NOT NULL,
Continente NVARCHAR(100) NOT NULL
)
GO

INSERT INTO [dbo].[Pais] ([Nombre],[Idioma] ,[Continente])
VALUES('Costa Rica', 'Español', 'América'),
('Argentina', 'Español', 'América'),
('Canada', 'Inglés/Frances', 'América'),
('Francia', 'Frances', 'Europa'),
('España', 'Español', 'Europa')
GO

Select * From Pais