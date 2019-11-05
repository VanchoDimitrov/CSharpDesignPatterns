using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLazyOrEagerLoadingDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton instance in created on runtime and only once. Counter =1
            //This is thread safe by the way
            Parallel.Invoke(
                () => getStudent(),
                () => getProfessir()
                );

            Console.ReadKey();
        }

        private static void getStudent()
        {
            Singleton student = Singleton.singleInstance;
            student.GetName("Vancho Dimitrov");
        }

        private static void getProfessir()
        {
            Singleton professor = Singleton.singleInstance;
            professor.GetName("Ana Dimitrova");
        }

        //this is NON Lazy or Eager Loading design pattern
        //Instance loads in memory and CLR takes care of everything for us, for the initialization and the thread safety
        public sealed class Singleton
        {
            public static int counter = 0;
            public static readonly Singleton singleInstance = new Singleton();

            public static Singleton GetInstance
            {
                get
                {
                    return singleInstance;
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
}
