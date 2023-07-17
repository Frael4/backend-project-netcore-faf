insert into rol (NOMBRE_ROL, ESTADO) values ('USUARIO', 'A'), ('ARBITRO', 'A'), ('ADMINISTRADOR', 'A');
-- Insercion de 10 usuarios

set identity_insert usuario on
-- 1
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (204, 'Jose', 'Serrano', 'joseserrano', 'eljose23@gmail.com', '234', GETDATE() , NULL, NULL, 'A', 1);
        
-- 2
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (205, 'Albert', 'Wesker', 'albertwesker', 'wesker32@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 1);
        
-- 3
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (207, 'Daniel', 'Humberto', 'danielhumberto', 'danip12@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 2);
        
-- 4
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (209, 'Cynthia', 'Mieles', 'cynthiamieles', 'mieles@hotmail.com', '123', GETDATE() , NULL, NULL, 'A', 2);
        
-- 5
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (210, 'Cristian', 'Salazar', 'cristiansalazar', 'cris102@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 1);
        
-- 6
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (211, 'Mike', 'Valarezo', 'mikevalarezo', 'valarezop@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 1);
        
-- 7
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (212, 'Allison', 'Fernandez', 'allisonfernadez', 'Alli23@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 2);
        
-- 8
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (213, 'Gabriel', 'Dueñas', 'gabrielduenas', 'duenasp45@gmail.com', '123', GETDATE() , NULL, NULL, 'E', 1);
        
-- 9
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (214, 'Raul', 'Perez', 'raulperez', 'raul34@gmail.com', '123', GETDATE() , NULL, NULL, 'A', 1);
        
-- 10
INSERT INTO usuario
        (id_usuario, nombre, apellido, nombre_usuario, email, contrasenia, create_at, delete_at, updated_at, estado, rol_id_rol)
    VALUES
        (215, 'Kevin', 'Quezada', 'kevinquezada', 'kezadap32@hotmail.es', '123', GETDATE() , NULL, NULL, 'E', 1);
        
        
set identity_insert usuario off

-- Insercion de 8 arbitros
set identity_insert arbitro on

-- 1
INSERT INTO arbitro
        (id_arbitro, categoria, nombre, apellido, email, nombre_usuario, contrasenia, edad, nacionalidad, cantidad_partidos,
        create_at, delete_at, updated_at, estado)
    VALUES
        (302, 'Juvenil', 'Felipe', 'Vidal', 'vidal97@hotmail.com', 'FelipeVidal', '1245', 29, 'Español', 18,
            GETDATE(), NULL, NULL, 'A'),
           
        (303, 'Profesional', 'Albert', 'Wesker', 'wesker32@gmail.com', 'albertwesker', '1245', 21, 'Español', 10,
            GETDATE(), NULL, NULL, 'A'),
            
        (304, 'Juvenil', 'Daniel', 'Humberto', 'danip12@gmail.com', 'danielhumberto', '1245', 19, 'Uruguayo', 3,
            GETDATE(), NULL, NULL, 'A'),

        (305, 'Profesional', 'Cristian', 'Salazar', 'crisd45@hotmail.com', 'cristiansalazar', '1245', 26, 'Español', 20,
            GETDATE(), NULL, NULL, 'A'),

        (306, 'Juevenil', 'Mike', 'Valarezo', 'vidal97@hotmail.com', 'FelipeVidal', '1245', 29, 'Español', 24,
            GETDATE(), NULL, NULL, 'A'),
            
        (307, 'Profesional', 'Gabriel', 'Dueñas', 'duenasp45@gmail.com', 'gabrielduenas', '1245', 23, 'Español', 20,
            GETDATE(), NULL, NULL, 'I'),
            
        (308, 'Juvenil', 'Raul', 'Perez', 'raul34@gmail.com', 'raulperez', '1245', 19, 'Español', 5,
            GETDATE(), NULL, NULL, 'A'),
           
        (309, 'Profesional', 'Kevin', 'Quezada', 'kezadap32@hotmail.es', 'kevinquezada', '1245', 28, 'Español', 33,
            GETDATE(), NULL, NULL, 'I');
                        
set identity_insert arbitro off       

-- Insercion de 8 clubs
set identity_insert club on

-- 1
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (404, 'Osazuna FC', 'Ximenez', GETDATE(), null, NULL, 'A');
        

-- 2
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (405, 'Barcelona FC', 'Hurtado', GETDATE(), null, NULL, 'A');
        
        
-- 3
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (406, 'Villarancho FC', 'Santillan', GETDATE(), null, NULL, 'A');
        
        
-- 4
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (407, 'Valencia FC', 'Hidalgo', GETDATE(), null, NULL, 'A');
        
        
-- 5
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (408, 'Catalunia FC', 'Guevara', GETDATE(), null, NULL, 'A');
        
        
-- 6
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (409, 'Elche FC', 'Gomez', GETDATE(), null, NULL, 'A');
        
        
-- 7
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (410, 'Mallorca FC', 'Intriago', GETDATE(), null, NULL, 'A');
        
        
-- 8
INSERT INTO club
        (id_club, nombre, director, create_at, delete_at, updated_at, estado)
    VALUES
        (411, 'Andorra FC', 'Winstrong', GETDATE(), null, NULL, 'A');
        
set identity_insert club off

-- Insercion de 8 partidos
set identity_insert partido on

-- 1
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (501, 404, 411, 'A', concat('Osazuna FC' , ' VS ' , 'Andorra FC'));
    
-- 2
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (509, 409, 405, 'A', concat('Elche FC' , ' VS ' , 'Barcelona FC'));
    
-- 3
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (510, 406, 407, 'A', concat('Villarancho FC' , ' VS ' , 'Valencia FC'));
    
-- 4
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (511, 408, 409, 'A', concat('Catalunia FC' , ' VS ' , 'Elche FC'));
    
-- 5
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (512, 410, 411, 'A', concat('Mallorca FC' , ' VS ' , 'Andorra FC'));
    
-- 6
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (513, 404, 408, 'A', concat('Osazuna FC' , ' VS ' , 'Catalunia FC'));
    
-- 7
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (514, 411, 408, 'A', concat('Andorra FC' , ' VS ' , 'Catalunia FC'));
    
-- 8
INSERT INTO partido (id_partido, club_id_local, club_id_rival, ESTADO, partido_descripcion)
    VALUES (515, 409, 411, 'A', concat('Elche FC' , ' VS ' , 'Andorra FC'));
    

set identity_insert partido off

-- Insercion de 8 sorteos
set identity_insert sorteo on

-- 1
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (602, '2023-02-27', GETDATE(), NULL, NULL, 'A', 302, 501, 303);
        
-- 2
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (603, '2023-01-12', GETDATE(), NULL, NULL, 'A', 303, 509, 303);
        
        
-- 3
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (604, '2023-02-02', GETDATE(), NULL, NULL, 'A', 304, 510, 306);
        
        
-- 4
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (605, '2023-02-17', GETDATE(), NULL, NULL, 'A', 307, 512, 304);
        
        
-- 5
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (606, '2023-01-20', GETDATE(), NULL, NULL, 'A', 309, 511, 303);
        
        
-- 6
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (607, '2023-02-22', GETDATE(), NULL, NULL, 'A', 304, 513, 305);
        
        
-- 7
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (608, '2023-02-27', GETDATE(), NULL, NULL, 'A', 302, 514, 308);
        
        
-- 8
INSERT INTO sorteo
        (id_sorteo, fecha_sorteo, create_at, delete_at, update_at, estado, arbitro_id_arbitro, partido_id_partido, arbitro_id_sustituto)
    VALUES
        (609, '2023-01-24', GETDATE(), NULL, NULL, 'A', 302, 515, 307);
	

set identity_insert sorteo off

-- Insercion de 8 agendas
set identity_insert agenda on

-- 1
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (702, '2023-02-27', 'Madrid', '10:00:00', GETDATE(), NULL, NULL, 'A', 501);
        
        
-- 2
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (703, '2023-01-12', 'Barcelona', '09:00:00', GETDATE(), NULL, NULL, 'A', 509);
        
-- 3
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (704, '2023-02-02', 'Valencia', '12:00:00', GETDATE(), NULL, NULL, 'A', 510);
        
        
-- 4
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (705, '2023-01-20', 'Elche', '13:00:00', GETDATE(), NULL, NULL, 'A', 511);
        
        
-- 5
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (706, '2023-02-17', 'Andorra', '18:00:00', GETDATE(), NULL, NULL, 'A', 512);
        
        
-- 6
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (707, '2023-02-22', 'Catalunia', '21:00:00', GETDATE(), NULL, NULL, 'A', 513);
        
        
-- 7
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (708, '2023-02-27', 'Andorra', '09:00:00', GETDATE(), NULL, NULL, 'A', 514);
        
        
-- 8
INSERT INTO agenda
        (id_agenda, fecha_partido, lugar_partido, hora_partido, create_at, delete_at, updated_at, estado, partido_id_partido)
    VALUES
        (709, '2023-01-24', 'Elche', '19:00:00', GETDATE(), NULL, NULL, 'A', 515);
        

set identity_insert agenda off

-- Insercion de 8 actas de partidos
set identity_insert acta_partido on

-- 1
INSERT INTO acta_partido
        (id_acta_partido, codigo_acta, fecha_emision_acta, hora_inicio_partido, hora_fin_partido, equipo_local, equipo_rival, duracion_partido,
        num_gol_equipo_local, num_gol_equipo_rival, total_tarjeta_amarillas, total_tarjeta_rojas, equipo_ganador, create_at, delete_at, update_at, estado, partido_id_partido)

    VALUES
        (802, 2, '2023-02-16', '10:00:00', '11:34:00', 'Osazuna FC', 'club_Alemania', '01:34:00',
            2, 1, 1, 1, 'Osazuna FC', GETDATE(), NULL, NULL, 'A', 501),

        (803, 3, '2023-01-12', '09:00:00', '10:30:00', 'club_Argentina', 'Barcelona FC', '01:30:00',
            0, 1, 2, 1, 'Barcelona FC', GETDATE(), NULL, NULL, 'A', 509),
            
        (804, 4, '2023-02-02', '12:00:00', '13:34:00', 'Villarancho FC', 'Valencia FC', '01:34:00',
            1, 0, 4, 1, 'Villarancho FC', GETDATE(), NULL, NULL, 'A', 510),
            
        (805, 5, '2023-01-20', '13:00:00', '14:34:00', 'Catalunia FC', ' Elche FC', '01:34:00',
            2, 2, 3, 1, 'Empate', GETDATE(), NULL, NULL, 'A', 511),
            
        (806, 6, '2023-02-17', '18:00:00', '19:34:00', 'Mallorca FC', 'Andorra FC', '01:34:00',
            2, 0, 1, 2, 'Andorra FC', GETDATE(), NULL, NULL, 'A', 512),
            
        (807 ,7, '2023-02-22', '21:00:00', '22:30:00', 'Osazuna FC', 'Catalunia FC', '01:30:00',
            1, 3, 2, 1, 'Catalunia FC', GETDATE(), NULL, NULL, 'A', 513),
            
        (808 ,8, '2023-02-27', '09:00:00', '10:30:00', 'Andorra FC', 'Catalunia FC', '01:30:00',
            2, 3, 3, 1,'Catalunia FC', GETDATE(), NULL, NULL, 'A', 514),
            
        (809, 9, '2023-01-24', '19:00:00', '20:34:00', 'Elche FC ', 'club_Alemania', '01:34:00',
            2, 0, 1, 1, 'Elche FC', GETDATE(), NULL, NULL, 'A', 515);
            
set identity_insert acta_partido off

-- Insercion de 8 asistencias
set identity_insert asistencia on

-- 1
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (901, 'Osazuna FC VS club_Alemania', 'Madrid', '2023-02-16', 1, 'A', 302);
        
-- 2
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (902, 'club_Argentina VS Barcelona FC', 'Barcelona', '2023-01-12', 1, 'A', 303);
        
        
-- 3
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (903, 'Villarancho FC VS Valencia FC', 'Valencia', '2023-02-02', 1, 'A', 304);
        
        
-- 4
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (904, 'Catalunia FC VS Elche FC', 'Madrid', '2023-01-20', 1, 'A', 309);
        
        
-- 5
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (905, 'Mallorca FC VS Andorra FC', 'Andorra', '2023-02-16', 1, 'A', 307);
        
        
-- 6
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (906, 'Osazuna FC VS Catalunia FC', 'Catalunia', '2023-02-22', 1, 'A', 303);
        
        
-- 7
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (907, 'Andorra FC VS Catalunia FC', 'Andorra', '2023-02-27', 1, 'A', 302);
        
        
-- 8
INSERT INTO asistencia
        (id_asistencia, partido, lugar, fecha_encuentro, asistencia, estado, arbitro_id_arbitro)
    VALUES
        (908, 'Elche FC VS club_Alemania', 'Elche', '2023-01-24', 1, 'A', 302);
        
set identity_insert asistencia off


