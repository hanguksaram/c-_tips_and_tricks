using System;
using System.Reflection;

namespace c_sharp_tricks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TypedNode<String> stNode = new TypedNode<String>("kek");
            TypedNode<int> stInt = new TypedNode<int>(123, stNode);
            TypedNode<bool> stBool = new TypedNode<bool>(true, stInt);
            IterateThruLinkeList(stBool);
            Console.Read();
            
        }
        static void IterateThruLinkeList (Node TypedNode) {
            FieldInfo[] fields = TypedNode.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                if (field.GetType() == typeof(Node)) 
                    IterateThruLinkeList((Node) field.GetValue(TypedNode));
                else
                    Console.WriteLine(field.GetValue(TypedNode));
            }
        }
    }
    abstract class Node {
        Node nextNode;
        
        protected Node(Node next) {
            this.nextNode = next;
        }
    }
    internal class TypedNode<T> : Node {
        T value;

        public TypedNode(T value): this(value, null) {}
        public TypedNode(T value, Node next) : base(next)
        {  
            this.value = value; 
        }
    }
}
