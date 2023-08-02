-- CREACIÓN DE LA TABLA ROL
DROP TABLE IF EXISTS ROL
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rol]') AND type in (N'U'))
CREATE TABLE [dbo].[rol]
(
  id_rol INT NOT NULL IDENTITY(1,1),
  nombre_rol VARCHAR(45) NOT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  updated_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  PRIMARY KEY (id_rol)
);

DROP TABLE IF EXISTS USUARIO
-- CREACIÓN DE LA TABLA USUARIO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
CREATE TABLE [dbo].[usuario]
(
  id_usuario INT NOT NULL IDENTITY(200,1),
  nombre VARCHAR(45) NOT NULL,
  apellido VARCHAR(45) NOT NULL,
  nombre_usuario VARCHAR(45) NOT NULL,
  email VARCHAR(45) NULL,
  contrasenia VARCHAR(45) NOT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  updated_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  rol_id_rol INT NOT NULL,
  PRIMARY KEY (id_usuario),
  CONSTRAINT fk_usuario_rol1 FOREIGN KEY (rol_id_rol)
    REFERENCES [dbo].[rol] (id_rol)
);

DROP TABLE IF EXISTS ARBITRO
-- CREACIÓN DE LA TABLA ARBITRO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[arbitro]') AND type in (N'U'))
CREATE TABLE [dbo].[arbitro]
(
  id_arbitro INT NOT NULL IDENTITY(300,1),
  categoria VARCHAR(45) NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  apellido VARCHAR(45) NOT NULL,
  email VARCHAR(45) NULL,
  nombre_usuario VARCHAR(45) NOT NULL,
  contrasenia VARCHAR(45) NOT NULL,
  edad INT NOT NULL,
  nacionalidad VARCHAR(45) NULL,
  cantidad_partidos INT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  updated_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  PRIMARY KEY (id_arbitro)
);


-- AÑADIR COLUMNA ROL_ID_ROL A LA TABLA ARBITRO
-- IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = N'ROL_ID_ROL' AND Object_ID = Object_ID(N'[dbo].[arbitro]'))
-- ALTER TABLE [dbo].[arbitro]
-- ADD ROL_ID_ROL INT;

DROP TABLE IF EXISTS CLUB
-- CREACIÓN DE LA TABLA CLUB
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[club]') AND type in (N'U'))
CREATE TABLE [dbo].[club]
(
  id_club INT NOT NULL IDENTITY(400,1),
  nombre VARCHAR(45) NOT NULL,
  director VARCHAR(45) NOT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  updated_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  PRIMARY KEY (id_club)
);

DROP TABLE IF EXISTS PARTIDO
-- CREACIÓN DE LA TABLA PARTIDO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partido]') AND type in (N'U'))
CREATE TABLE [dbo].[partido]
(
  id_partido INT NOT NULL IDENTITY(500,1),
  club_id_local INT NOT NULL,
  club_id_rival INT NOT NULL,
  partido_descripcion nvarchar(3000) null,
  estado VARCHAR(2) NULL,
  PRIMARY KEY (id_partido),
  CONSTRAINT fk_partido_club1 FOREIGN KEY (club_id_local)
    REFERENCES [dbo].[club] (id_club),
  CONSTRAINT fk_partido_club2 FOREIGN KEY (club_id_rival)
    REFERENCES [dbo].[club] (id_club)
);

-- AÑADIR COLUMNA PARTIDO_DESCRIPCION A LA TABLA PARTIDO
-- IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = N'PARTIDO_DESCRIPCION' AND Object_ID = Object_ID(N'[dbo].[partido]'))
-- ALTER TABLE [dbo].[partido]
-- ADD PARTIDO_DESCRIPCION VARCHAR(100);

DROP TABLE IF EXISTS SORTEO
-- CREACIÓN DE LA TABLA SORTEO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sorteo]') AND type in (N'U'))
CREATE TABLE [dbo].[sorteo]
(
  id_sorteo INT NOT NULL IDENTITY(600,1),
  fecha_sorteo DATETIME NOT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  update_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  arbitro_id_arbitro INT NOT NULL,
  partido_id_partido INT NOT NULL,
  arbitro_id_sustituto INT NOT NULL,
  PRIMARY KEY (id_sorteo),
  CONSTRAINT fk_sorteo_arbitro1 FOREIGN KEY (arbitro_id_arbitro)
    REFERENCES [dbo].[arbitro] (id_arbitro),
  CONSTRAINT fk_sorteo_partido1 FOREIGN KEY (partido_id_partido)
    REFERENCES [dbo].[partido] (id_partido),
  CONSTRAINT fk_sorteo_arbitro2 FOREIGN KEY (arbitro_id_sustituto)
    REFERENCES [dbo].[arbitro] (id_arbitro)
);


DROP TABLE IF EXISTS AGENDA
-- CREACIÓN DE LA TABLA AGENDA
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agenda]') AND type in (N'U'))
CREATE TABLE [dbo].[agenda]
(
  id_agenda INT NOT NULL IDENTITY(700,1),
  fecha_partido DATETIME NOT NULL,
  lugar_partido VARCHAR(45) NOT NULL,
  hora_partido TIME NOT NULL,
  sorteado char(2) null,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  updated_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  partido_id_partido INT NOT NULL,
  PRIMARY KEY (id_agenda),
  CONSTRAINT fk_agenda_partido1 FOREIGN KEY (partido_id_partido)
    REFERENCES [dbo].[partido] (id_partido)
);

-- AÑADIR COLUMNA SORTEADO A LA TABLA AGENDA
-- IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = N'SORTEADO' AND Object_ID = Object_ID(N'[dbo].[agenda]'))
-- ALTER TABLE [dbo].[agenda]
-- ADD SORTEADO VARCHAR(2);

DROP TABLE IF EXISTS ACTA_PARTIDO
-- CREACIÓN DE LA TABLA ACTA_PARTIDO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acta_partido]') AND type in (N'U'))
CREATE TABLE [dbo].[acta_partido]
(
  id_acta_partido INT NOT NULL IDENTITY(800,1),
  codigo_acta VARCHAR(50) NULL,
  fecha_emision_acta DATETIME  NULL,
  hora_inicio_partido TIME  NULL,
  hora_fin_partido TIME  NULL,
  equipo_local VARCHAR(45) NULL,
  equipo_rival VARCHAR(45) NULL,
  duracion_partido TIME  NULL,
  num_gol_equipo_local INT  NULL,
  num_gol_equipo_rival INT  NULL,
  total_tarjeta_amarillas INT NULL,
  total_tarjeta_rojas INT NULL,
  equipo_ganador VARCHAR(45) NOT NULL,
  create_at DATETIME NULL,
  delete_at DATETIME NULL,
  update_at DATETIME NULL,
  estado VARCHAR(2) NULL,
  partido_id_partido INT NOT NULL,
  PRIMARY KEY (id_acta_partido),
  CONSTRAINT fk_acta_partido_partido1 FOREIGN KEY (partido_id_partido)
    REFERENCES [dbo].[partido] (id_partido)
);

DROP TABLE IF EXISTS ASISTENCIA
-- CREACIÓN DE LA TABLA ASISTENCIA
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[asistencia]') AND type in (N'U'))
CREATE TABLE [dbo].[asistencia]
(
  id_asistencia INT NOT NULL IDENTITY(900,1),
  partido VARCHAR(45) NOT NULL,
  lugar VARCHAR(45) NOT NULL,
  fecha_encuentro DATETIME NOT NULL,
  asistencia TINYINT NOT NULL,
  estado VARCHAR(2) NULL,
  arbitro_id_arbitro INT NOT NULL,
  PRIMARY KEY (id_asistencia),
  CONSTRAINT fk_asistencia_arbitro1 FOREIGN KEY (arbitro_id_arbitro)
    REFERENCES [dbo].[arbitro] (id_arbitro)
);
