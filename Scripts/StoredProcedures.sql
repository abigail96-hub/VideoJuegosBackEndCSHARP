USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearVideojuego]    Script Date: 24/05/2024 03:35:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearVideojuego]
    @Titulo VARCHAR(45),
    @Descripcion VARCHAR(100),
	@Año SMALLINT,
	@Calificacion SMALLINT,
	@Estatus bit,
	@IdConsola SMALLINT,
	@IdGenero SMALLINT

AS

BEGIN
    INSERT INTO Videojuego (Titulo, Descripcion, Año, Calificacion, Estatus, IdConsola, IdGenero)
    VALUES (@Titulo, @Descripcion, @Año, @Calificacion, @Estatus, @IdConsola, @IdGenero);

	
    IF @@ROWCOUNT > 0
    BEGIN
        PRINT 'El videojuego se ha creado correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'Ha ocurrido un error al crear el videojuego.';
    END

END;


USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerVideojuego]    Script Date: 26/05/2024 08:53:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerVideojuego]

@IdVideojuego Smallint 
AS

BEGIN
    SELECT *
    FROM Videojuego  

	WHERE Idvideojuego = @IdVideojuego
	;
END;


USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerGeneros]    Script Date: 26/05/2024 08:54:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerGeneros]
AS
BEGIN

SELECT * FROM Genero

END;

USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerConsolas]    Script Date: 26/05/2024 08:55:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerConsolas]

AS 
BEGIN

SELECT * FROM Consola 

END;

USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarVideojuego]    Script Date: 26/05/2024 08:56:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarVideojuego]
    @IdVideojuego INT
AS
BEGIN
    DELETE FROM Videojuego
    WHERE IdVideojuego = @IdVideojuego;
END;

USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearVideojuego]    Script Date: 26/05/2024 08:57:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearVideojuego]
    @Titulo VARCHAR(45),
    @Descripcion VARCHAR(100),
	@Año SMALLINT,
	@Calificacion SMALLINT,
	@Estatus bit,
	@IdConsola SMALLINT,
	@IdGenero SMALLINT

AS

BEGIN

    INSERT INTO Videojuego (Titulo, Descripcion, Año, Calificacion, Estatus, IdConsola, IdGenero)
    VALUES (@Titulo, @Descripcion, @Año, @Calificacion, @Estatus, @IdConsola, @IdGenero);


END;


USE [Videojuego]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarVideojuego]    Script Date: 26/05/2024 08:58:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarVideojuego]
    @IdVideojuego INT,
    @Titulo VARCHAR(45) = NULL,
    @Descripcion VARCHAR(100) = NULL,
    @Año Smallint = NULL,
	@Calificacion Smallint = NULL,
	@Estatus bit = NULL,
	@IdConsola Smallint = NULL,
	@IdGenero Smallint = NULL
   
AS
BEGIN
    UPDATE Videojuego
    SET Titulo = COALESCE(@Titulo, Titulo),
        Descripcion = COALESCE(@Descripcion, Descripcion),
        Año = COALESCE(@Año, Año),
		Calificacion = COALESCE(@Calificacion, Calificacion),
		Estatus = COALESCE(@Estatus, Estatus),
		IdConsola = COALESCE(@IdConsola, IdConsola),
		IdGenero = COALESCE(@IdGenero, IdGenero)
    WHERE IdVideojuego = @IdVideojuego;

   
END;