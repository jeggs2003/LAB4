namespace LAB4.Models
{
	public class NodoAvl
	{
		public Pacientes Pacientes { get; set; }
		public NodoAvl SubarbolIzquierdo { get; set; }
		public NodoAvl SubarbolDerecho { get; set; }
	}
}
