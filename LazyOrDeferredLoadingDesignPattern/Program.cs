using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyOrDeferredLoadingDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread Sage!
            //Lazy or Deffered Loading pattern is delaying the initialization of the object until we need it.
            Parallel.Invoke(
                () => GetStudent(),
                () => GetProfessor()
                );

            Console.ReadKey();
        }

        private static void GetStudent()
        {
            Singleton student = Singleton.GetInstance;
            student.GetName("Vancho Dimitrov");
        }

        private static void GetProfessor()
        {
            Singleton professor = Singleton.GetInstance;
            professor.GetName("Ana Dimitrova");
        }
    }

    //Thread Safe!
    public sealed class Singleton
    {
        private static int counter = 0;
        private static readonly Lazy<Singleton> instanceLock = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance
        {
            get
            {
                return instanceLock.Value;
            }
        }

        public Singleton()
        {
            counter++;
            Console.WriteLine("Counter: {0}", counter);
        }

        public void GetName(string name)
        {
            Console.WriteLine("Name: {0}", name);
        }
    }
}
