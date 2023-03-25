using LAB4.Models;
namespace LAB4.Models
{
	public class ArbolAvl<Pacientes> where Pacientes : IComparable<Pacientes>
	{
		public int Altura { get; set; }

		public Pacientes valor { get; set; }	

		public ArbolAvl<Pacientes> SubarbolDerecho { get; set; }

		public ArbolAvl<Pacientes> SubarbolIzquierdo { get; set; }

		public ArbolAvl()
		{

		}


		public void Agregar(Pacientes valor)
		{
			if (valor == null)
				throw new ArgumentNullException(nameof(valor));

			if (this.valor == null)
			{
				this.valor = valor;
				return;
			}

			var comparacion = valor.CompareTo(this.valor);

			if (comparacion < 0)
			{
				if (SubarbolIzquierdo == null)
					SubarbolIzquierdo = new ArbolAvl<Pacientes>() { valor = valor };
				else
					SubarbolIzquierdo.Agregar(valor);
			}
			else if (comparacion > 0)
			{
				if (SubarbolDerecho == null)
					SubarbolDerecho = new ArbolAvl<Pacientes>() { valor = valor };
				else
					SubarbolDerecho.Agregar(valor);
			}
		}


		public ArbolAvl(Pacientes valor, ArbolAvl<Pacientes> SubarbolDerecho, ArbolAvl<Pacientes> SubarbolIzquierdo)
		{
			this.valor = valor;
			SubarbolDerecho = SubarbolDerecho;
			SubarbolIzquierdo = SubarbolIzquierdo;
		}


		private ArbolAvl<Pacientes> Rotar(ArbolAvl<Pacientes> subarbol, bool rotarderecha)
		{

			var temporal = new ArbolAvl<Pacientes>();

			if (rotarderecha)
			{
				temporal = subarbol.SubarbolDerecho;
				subarbol.SubarbolDerecho = temporal.SubarbolIzquierdo;
				temporal.SubarbolIzquierdo = subarbol;
			}
			else
			{
				temporal = subarbol.SubarbolIzquierdo;
				subarbol.SubarbolIzquierdo = temporal.SubarbolDerecho;
				temporal.SubarbolDerecho = subarbol;
			}
			
			return temporal;

		}

		private int Mayor(int altura1, int altura2)
		{
			if (altura1 > altura2)
				return altura1;
			else return altura2;
		}

		private void ActualizarAltura(ArbolAvl<Pacientes> subarbol)
		{
			if (subarbol != null)
				subarbol.Altura = Mayor(subarbol.SubarbolDerecho.Altura, subarbol.SubarbolIzquierdo.Altura);
			Altura = -1;

		}




	}
}
