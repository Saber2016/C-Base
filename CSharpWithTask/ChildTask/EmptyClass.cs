using System;
using System.Threading;
using System.Threading.Tasks;


namespace ChildTask
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Text { get; set; }
    }

    public class EmptyClass
    {

            static public Node GetNode()
            {
                Node root = new Node
                {
                    Left = new Node
                    {
                        Left = new Node
                        {
                            Text = "L-L"
                        },
                        Right = new Node
                        {
                            Text = "L-R"
                        },
                        Text = "L"
                    },
                    Right = new Node
                    {
                        Left = new Node
                        {
                            Text = "R-L"
                        },
                        Right = new Node
                        {
                            Text = "R-R"
                        },
                        Text = "R"
                    },
                    Text = "Root"
                };
                return root;
            }

            static public void DisplayTree(Node root)
            {
                var task = Task.Factory.StartNew(() => DisplayNode(root),
                                                CancellationToken.None,
                                                TaskCreationOptions.None,
                                                TaskScheduler.Default);
                task.Wait();
            }

            static void DisplayNode(Node current)
            {

                if (current.Left != null)
                    Task.Factory.StartNew(() => DisplayNode(current.Left),
                                                CancellationToken.None,
                                                TaskCreationOptions.AttachedToParent,
                                                TaskScheduler.Default);
                if (current.Right != null)
                    Task.Factory.StartNew(() => DisplayNode(current.Right),
                                                CancellationToken.None,
                                                TaskCreationOptions.AttachedToParent,
                                                TaskScheduler.Default);
                Console.WriteLine("当前节点的值为{0};处理的ThreadId={1}", current.Text, Thread.CurrentThread.ManagedThreadId);
            
        }
    }
}
