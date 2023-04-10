namespace LAB4.Models
{
    public class MonticuloBinarioNode
    {
        public int Priority { get; private set; }
        public Pacientes Paciente { get; private set; }

        public MonticuloBinarioNode(int priority, Pacientes paciente)
        {
            Priority = priority;
            Paciente = paciente;
        }
    }
}
