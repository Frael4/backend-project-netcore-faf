namespace Modelos
{
    public class ActaPartido
    {
        public int Id { get; set; }

        public string? CodActa { get; set; }

        public DateTime FechaEmision { get; set; }

        public string? HoraInicio { get; set; }

        public string? HoraFin { set; get; }

        public string? EquipoLocal { set; get; }
        public string? EquipoRival { set; get; }
        public int? NumGolEquipoLocal { get; set; }
        public int? NumGolEquipoRival { get; set; }
        public int? TotTarjetaAmarillas { set; get; }
        public int? TotTarjetaRojas { set; get; }
        public string? EquipoGanador { set; get; }
        public Partido? Partido { get; set; }

        public string? DuracionPartido { set; get; }
        #region
        public override string ToString()
        {
            return "ID: " + Id + " partido_id: " + " codigo: " + CodActa;
        }
        #endregion


    }
}