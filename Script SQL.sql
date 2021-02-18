USE [Empresa]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionario_Estados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionarios]'))
ALTER TABLE [dbo].[Funcionarios] DROP CONSTRAINT [FK_Funcionario_Estado]
GO

USE [Empresa]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionarios]') AND type in (N'U'))
DROP TABLE [dbo].[Funcionarios]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estados]') AND type in (N'U'))
DROP TABLE [dbo].[Estados]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Estados](
	[PK_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Sigla] [nvarchar](2) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[PK_Estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO Estados (Sigla, Nome) VALUES ('AC', 'Acre');
INSERT INTO Estados (Sigla, Nome) VALUES ('AL', 'Alagoas');
INSERT INTO Estados (Sigla, Nome) VALUES ('AP', 'Amap�');
INSERT INTO Estados (Sigla, Nome) VALUES ('AM', 'Amazonas');
INSERT INTO Estados (Sigla, Nome) VALUES ('BA', 'Bahia');
INSERT INTO Estados (Sigla, Nome) VALUES ('CE', 'Cear�');
INSERT INTO Estados (Sigla, Nome) VALUES ('DF', 'Distrito Federal');
INSERT INTO Estados (Sigla, Nome) VALUES ('ES', 'Esp�rito Santo');
INSERT INTO Estados (Sigla, Nome) VALUES ('GO', 'Goi�s');
INSERT INTO Estados (Sigla, Nome) VALUES ('MA', 'Maranh�o');
INSERT INTO Estados (Sigla, Nome) VALUES ('MT', 'Mato Grosso');
INSERT INTO Estados (Sigla, Nome) VALUES ('MS', 'Mato Grosso do Sul');
INSERT INTO Estados (Sigla, Nome) VALUES ('MG', 'Minas Gerais');
INSERT INTO Estados (Sigla, Nome) VALUES ('PA', 'Par�');
INSERT INTO Estados (Sigla, Nome) VALUES ('PB', 'Para�ba');
INSERT INTO Estados (Sigla, Nome) VALUES ('PR', 'Paran�');
INSERT INTO Estados (Sigla, Nome) VALUES ('PE', 'Pernambuco');
INSERT INTO Estados (Sigla, Nome) VALUES ('PI', 'Piau�');
INSERT INTO Estados (Sigla, Nome) VALUES ('RJ', 'Rio de Janeiro');
INSERT INTO Estados (Sigla, Nome) VALUES ('RN', 'Rio Grande do Norte');
INSERT INTO Estados (Sigla, Nome) VALUES ('RS', 'Rio Grande do Sul');
INSERT INTO Estados (Sigla, Nome) VALUES ('RO', 'Rond�nia');
INSERT INTO Estados (Sigla, Nome) VALUES ('RR', 'Roraima');
INSERT INTO Estados (Sigla, Nome) VALUES ('SC', 'Santa Catarina');
INSERT INTO Estados (Sigla, Nome) VALUES ('SP', 'S�o Paulo');
INSERT INTO Estados (Sigla, Nome) VALUES ('SE', 'Sergipe');
INSERT INTO Estados (Sigla, Nome) VALUES ('TO', 'Tocantins');

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Funcionarios](
	[PK_Funcionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Salario] [decimal](18, 2) NULL,
	[FK_Estado] [int] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[PK_Funcionario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Estado] FOREIGN KEY([FK_Estado])
REFERENCES [dbo].[Estado] ([PK_Estado])
GO

ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [FK_Funcionario_Estado]
GO