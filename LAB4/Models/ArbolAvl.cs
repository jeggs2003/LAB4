using LAB4.Models;
namespace LAB4.Models
{
	public class ArbolAvl<T>  
	{
		public int Altura { get; set; }

		public Pacientes valor { get; set; }	

		public ArbolAvl<T> SubarbolDerecho { get; set; }

		public ArbolAvl<T> SubarbolIzquierdo { get; set; }

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
					SubarbolIzquierdo = new ArbolAvl<T>() { valor = valor };
				else
					SubarbolIzquierdo.Agregar(valor);
			}
			else if (comparacion > 0)
			{
				if (SubarbolDerecho == null)
					SubarbolDerecho = new ArbolAvl<T>() { valor = valor };
				else
					SubarbolDerecho.Agregar(valor);
			}
		}


		public ArbolAvl(Pacientes valor, ArbolAvl<T> SubarbolDerecho, ArbolAvl<T> SubarbolIzquierdo)
		{
			this.valor = valor;
			SubarbolDerecho = SubarbolDerecho;
			SubarbolIzquierdo = SubarbolIzquierdo;
		}


		private ArbolAvl<T> Rotar(ArbolAvl<T> subarbol, bool rotarderecha)
		{

			var temporal = new ArbolAvl<T>();

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

		private void ActualizarAltura(ArbolAvl<T> subarbol)
		{
			if (subarbol != null)
				subarbol.Altura = Mayor(subarbol.SubarbolDerecho.Altura, subarbol.SubarbolIzquierdo.Altura);
			Altura = -1;

		}




	}
}
