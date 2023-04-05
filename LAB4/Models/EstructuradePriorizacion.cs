namespace LAB4.Models
{
    public class EstructuradePriorizacion
    {
        public void calculo(Pacientes pacientes)
        {
            string sexo = pacientes.Sexo;
            int edad = pacientes.Edad;
            string especializacion = pacientes.Especializacion;
            string ingreso = pacientes.Ingreso;
            int contSexo = 0, contEdad = 0, contEspecializacion = 0,
                contIngreso = 0, total = 0;
            //Condicional para el sexo
            if(sexo == "Masculino")
            {
                contSexo = 3;
            }
            else
            {
                contSexo = 5;
            }
            //Condicional para la edad
            if(edad >= 70)
            {
                contEdad = 10;
            }else if(edad >= 50 && edad <= 69)
            {
                contEdad = 8;
            }else if(edad >= 18 && edad <= 49)
            {
                contEdad = 3;
            }else if(edad >= 0 && edad <= 5)
            {
                contEdad = 8;
            }else if(edad >= 6 && edad <= 17)
            {
                contEdad = 5;
            }

            //Condicional para la especializacion
            if(especializacion == "Traumatologia interna")
            {
                contEspecializacion = 3;
            }else if(especializacion == "Traumatologia externa")
            {
                contEspecializacion = 8;
            }else if(especializacion == "Ginecologia")
            {
                contEspecializacion = 5;
            }else if(especializacion == "Cardiologia")
            {
                contEspecializacion = 10;
            }
            else
            {
                contEspecializacion = 8;
            }

            //Condicional para el ingreso
            if(ingreso == "Ambulancia")
            {
                contIngreso = 5;
            }
            else
            {
                contIngreso = 3;
            }

            //Suma de todas las prioridades para determinar cual va primero en la cola
            total = contSexo + contEdad + contEspecializacion + contIngreso;
            //Mandando el total a la clase add del monticulo que determinara el orden de ingreso a la cola
            MonticuloBinario.Node nodo = new MonticuloBinario.Node(total);
            MonticuloBinario.MinHeap minheap = new MonticuloBinario.MinHeap();
            minheap.Add(total);
        }
    }
}
