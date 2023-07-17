EXEC SP_MAESTRO_ACTAS_PARTIDO 'ELIMINAR_ACTA_PARTIDO', '<ActaPartido>
	<equipoGanador>Tuemeros</equipoGanador>
	<id>823</id>
</ActaPartido>'

EXEC SP_MAESTRO_ACTAS_PARTIDO 'ACTUALIZAR_ACTA_PARTIDO', N'
<ActaPartido xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<Id>823</Id>
	<CodActa>asdasd</CodActa>
	<FechaEmision>2023-07-17T00:04:26.128Z</FechaEmision>
	<HoraInicio/>
	<HoraFin/>
	<EquipoLocal>string</EquipoLocal>
	<EquipoRival>string</EquipoRival>
	<DuracionPartido>string</DuracionPartido>
	<NumGolEquipoLocal>0</NumGolEquipoLocal><NumGolEquipoRival>0</NumGolEquipoRival><TotTarjetaAmarillas>12</TotTarjetaAmarillas><TotTarjetaRojas>12</TotTarjetaRojas><EquipoGanador>string</EquipoGanador><IdPartido>0</IdPartido></ActaPartido>'

declare @p2 xml
set @p2=convert(xml,N'<ActaPartido xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><Id>823</Id><CodActa>asdasd</CodActa><FechaEmision>2023-07-17T00:04:26.128Z</FechaEmision><HoraInicio/><HoraFin/><EquipoLocal>string</EquipoLocal><EquipoRival>string</EquipoRival><DuracionPartido>string</DuracionPartido><NumGolEquipoLocal>0</NumGolEquipoLocal><NumGolEquipoRival>0</NumGolEquipoRival><TotTarjetaAmarillas>12</TotTarjetaAmarillas><TotTarjetaRojas>12</TotTarjetaRojas><EquipoGanador>string</EquipoGanador><IdPartido>0</IdPartido></ActaPartido>')
exec SP_MAESTRO_ACTAS_PARTIDO @Transaccion='ACTUALIZAR_ACTA_PARTIDO',@dataXml=@p2

select * from acta_partido
--- wrong
update acta_partido set hora_inicio_partido = '', hora_FIN_partido = '', duracion_partido = 'string', FECHA_EMISION_ACTA = '2023-07-18T00:04:26.128Z' where id_acta_partido = 823



--UPDATE ACTA_PARTIDO SET ESTADO = 'A' WHERE ID_ACTA_PARTIDO = 823