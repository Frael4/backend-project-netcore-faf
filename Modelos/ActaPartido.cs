namespace Modelos
{
    public class ActaPartido
    {
        private int id;

        private string? codActa = "";

        private DateTime fechaEmision;

        private string? horaInicio = "";

        private string? horaFin = "";

        private string? equipoLocal = "";
        private string? equipoRival = "";
        private string? duracionPartido = "";
        private int? numGolEquipoLocal;
        private int? numGolEquipoRival;
        private int? totTarjetaAmarillas;
        private int? totTarjetaRojas;
        private string? equipoGanador = "";


        private int idPartido;

        public ActaPartido() { }

        public ActaPartido(int id, string codActa, DateTime fechaEmision, string horaInicio, string horaFin, string equipoLocal, string equipoRival, string duracionPartido, int numGolEquipoLocal, int numGolEquipoRival, int totTarjetaAmarillas, int totTarjetaRojas, string equipoGanador, int idPartido)
        {
            this.id = id;
            this.codActa = codActa;
            this.fechaEmision = fechaEmision;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.equipoLocal = equipoLocal;
            this.equipoRival = equipoRival;
            this.duracionPartido = duracionPartido;
            this.numGolEquipoLocal = numGolEquipoLocal;
            this.numGolEquipoRival = numGolEquipoRival;
            this.totTarjetaAmarillas = totTarjetaAmarillas;
            this.totTarjetaRojas = totTarjetaRojas;
            this.equipoGanador = equipoGanador;
            this.idPartido = idPartido;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string? CodActa
        {
            get { return codActa; }
            set { codActa = value; }
        }

        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public string? HoraInicio
        {
            get { return horaInicio; }
            set
            {
                horaInicio = value;
            }
        }

        public string? HoraFin
        {
            get { return horaFin; }
            set
            {
                horaFin = value;
            }
        }

        public string? EquipoLocal { get => equipoLocal; set => equipoLocal = value; }
        public string? EquipoRival { get => equipoRival; set => equipoRival = value; }
        public string? DuracionPartido { get => duracionPartido; set => duracionPartido = value; }
        public int? NumGolEquipoLocal { get => numGolEquipoLocal; set => numGolEquipoLocal = value; }
        public int? NumGolEquipoRival { get => numGolEquipoRival; set => numGolEquipoRival = value; }
        public int? TotTarjetaAmarillas { get => totTarjetaAmarillas; set => totTarjetaAmarillas = value; }
        public int? TotTarjetaRojas { get => totTarjetaRojas; set => totTarjetaRojas = value; }
        public string? EquipoGanador { get => equipoGanador; set => equipoGanador = value; }

        public int IdPartido
        {
            get { return idPartido; }
            set
            {
                idPartido = value;
            }
        }

        public override string ToString()
        {
            return "ID: " + id + " partido_id: " + idPartido + " codigo: " + codActa ;
        }
    }
}