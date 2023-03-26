namespace LAB4.Models
{
    public class MonticuloBinario
    {
        private List<int> heap;

        public MonticuloBinario()
        {
            heap = new List<int>();
        }

        public int Size()
        {
            return heap.Count;
        }

        public void Add(int value)
        {
            heap.Add(value);
            int current = heap.Count - 1;
            int parent = (current - 1) / 2;

            while (current > 0 && heap[parent] > heap[current])
            {
                int temp = heap[current];
                heap[current] = heap[parent];
                heap[parent] = temp;

                current = parent;
                parent = (current - 1) / 2;
            }
        }

        public int RemoveMin()
        {
            int min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int current = 0;
            while (current < heap.Count)
            {
                int leftChild = 2 * current + 1;
                int rightChild = 2 * current + 2;

                if (leftChild >= heap.Count)
                {
                    break;
                }

                int childToSwap = leftChild;
                if (rightChild < heap.Count && heap[rightChild] < heap[leftChild])
                {
                    childToSwap = rightChild;
                }

                if (heap[current] > heap[childToSwap])
                {
                    int temp = heap[current];
                    heap[current] = heap[childToSwap];
                    heap[childToSwap] = temp;

                    current = childToSwap;
                }
                else
                {
                    break;
                }
            }

            return min;
        }
    }
}
