namespace LAB4.Models
{
     static public class MonticuloBinario
    {
         static public List<MonticuloBinarioNode> heap;

         static MonticuloBinario()
        {
            heap = new List<MonticuloBinarioNode>();
        }

        static public int Count
        {
            get { return heap.Count; }
        }

        static public void Enqueue(int priority, Pacientes paciente)
        {
            MonticuloBinarioNode node = new MonticuloBinarioNode(priority, paciente);
            heap.Add(node);
            int i = heap.Count - 1;
            while (i > 0)
            {
                int parentIndex = (i - 1) / 2;
                if (heap[parentIndex].Priority <= node.Priority)
                {
                    break;
                }
                heap[i] = heap[parentIndex];
                i = parentIndex;
            }
            heap[i] = node;
        }
        static public List<Pacientes> lispa = new List<Pacientes>();
        static public List<Pacientes> Salida()
        {
            
            Pacientes paci;
            for (int i = 0; i < heap.Count; i++)
            {
               paci = heap[i].Paciente;
                int pro = heap[i].Priority;
               lispa.Add(paci);
            }
            return lispa;
            
        }

         static public Pacientes Dequeue()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            MonticuloBinarioNode rootNode = heap[0];
            int lastIndex = heap.Count - 1;
            MonticuloBinarioNode lastNode = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            if (lastIndex > 0)
            {
                heap[0] = lastNode;
                int i = 0;
                while (i < lastIndex)
                {
                    int leftChildIndex = 2 * i + 1;
                    int rightChildIndex = 2 * i + 2;

                    if (rightChildIndex <= lastIndex && heap[rightChildIndex].Priority < heap[leftChildIndex].Priority)
                    {
                        if (heap[rightChildIndex].Priority < lastNode.Priority)
                        {
                            heap[i] = heap[rightChildIndex];
                            i = rightChildIndex;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (leftChildIndex <= lastIndex && heap[leftChildIndex].Priority < lastNode.Priority)
                    {
                        heap[i] = heap[leftChildIndex];
                        i = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                heap[i] = lastNode;
            }

            return rootNode.Paciente;
        }


        static public Pacientes Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty");
            }

            return heap[0].Paciente;
        }
    }
}
