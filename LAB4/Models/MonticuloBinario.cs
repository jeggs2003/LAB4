namespace LAB4.Models
{
    public class MonticuloBinario
    {
        private List<int> heap;

        public MonticuloBinario()
        {
            heap = new List<int>();
        }

        /* public int Size()
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
         }*/
        public void ola()
        {

        }


        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }

        public class MinHeap
        {
            private Node root;

            public MinHeap()
            {
                root = null;
            }

            public void Add(int value)
            {
                Node newNode = new Node(value);
                if (root == null)
                {
                    root = newNode;
                }
                else
                {
                    Queue<Node> queue = new Queue<Node>();
                    queue.Enqueue(root);

                    while (queue.Count > 0)
                    {
                        Node current = queue.Dequeue();
                        if (current.left == null)
                        {
                            current.left = newNode;
                            break;
                        }
                        else if (current.right == null)
                        {
                            current.right = newNode;
                            break;
                        }
                        else
                        {
                            queue.Enqueue(current.left);
                            queue.Enqueue(current.right);
                        }
                    }

                    MinHeapifyUp(newNode);
                }
            }

            public int RemoveMin()
            {
                if (root == null)
                {
                    throw new InvalidOperationException("The heap is empty.");
                }

                int min = root.value;

                if (root.left == null)
                {
                    root = null;
                }
                else
                {
                    Queue<Node> queue = new Queue<Node>();
                    queue.Enqueue(root);

                    Node deepestNode = null;
                    while (queue.Count > 0)
                    {
                        deepestNode = queue.Dequeue();
                        if (deepestNode.left != null)
                        {
                            queue.Enqueue(deepestNode.left);
                        }
                        if (deepestNode.right != null)
                        {
                            queue.Enqueue(deepestNode.right);
                        }
                    }

                    root.value = deepestNode.value;
                    if (deepestNode == root)
                    {
                        root = null;
                    }
                    else
                    {
                        Node parent = FindParent(deepestNode);
                        if (parent.left == deepestNode)
                        {
                            parent.left = null;
                        }
                        else
                        {
                            parent.right = null;
                        }

                        MinHeapifyDown(root);
                    }
                }

                return min;
            }

            private void MinHeapifyUp(Node node)
            {
                Node current = node;
                Node parent = FindParent(current);

                while (parent != null && current.value < parent.value)
                {
                    Swap(current, parent);
                    current = parent;
                    parent = FindParent(current);
                }
            }

            private void MinHeapifyDown(Node node)
            {
                Node current = node;

                while (current != null)
                {
                    Node minChild = FindMinChild(current);
                    if (minChild != null && minChild.value < current.value)
                    {
                        Swap(current, minChild);
                        current = minChild;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(Node node1, Node node2)
            {
                int temp = node1.value;
                node1.value = node2.value;
                node2.value = temp;
            }

            private Node FindParent(Node node)
            {
                if (node == root)
                {
                    return null;
                }

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    Node current = queue.Dequeue();
                    if (current.left == node || current.right == node)
                    {
                        return current;
                    }
                    else
                    {
                        if (current.left != null)
                        {
                            queue.Enqueue(current.left);
                        }
                        if (current.right != null)
                        {
                            queue.Enqueue(current.right);
                        }
                    }
                }

                return null; // Si no se encuentra el padre, retorna null
            }

            private Node FindMinChild(Node node)
            {
                if (node == null)
                {
                    return null;
                }

                Node minChild = null;

                if (node.left != null && node.right != null)
                {
                    minChild = (node.left.value < node.right.value) ? node.left : node.right;
                }
                else if (node.left != null)
                {
                    minChild = node.left;
                }
                else if (node.right != null)
                {
                    minChild = node.right;
                }

                return minChild;
            }

            public bool Contains(int value)
            {
                return FindNode(root, value) != null;
            }

            private Node FindNode(Node node, int value)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.value == value)
                {
                    return node;
                }

                Node leftResult = FindNode(node.left, value);
                if (leftResult != null)
                {
                    return leftResult;
                }

                Node rightResult = FindNode(node.right, value);
                if (rightResult != null)
                {
                    return rightResult;
                }

                return null;
            }
        }
    }
}
