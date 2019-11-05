using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonThreadSafeSingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //NON Safe thread operation. The instance is not locked!
            //This time, It doesn't matter if we are going to use the "sealed Singleton Design Pattern".
            //because of the Parallel Tread operation there will be 2 instances created of the Singleton sealed class
            Parallel.Invoke(
                () => getStudentName(),
                () => getProfessorName()
                );

            Console.ReadKey();
        }

        private static void getStudentName()
        {
            Singleton printStudentName = Singleton.GetInstance;
            printStudentName.GetName("Vancho Dimitrov");
        }

        private static void getProfessorName()
        {
            Singleton printProfessorName = Singleton.GetInstance;
            printProfessorName.GetName("Ana Dimitrova");
        }

        //Singleton sealed Design Pattern
        public sealed class Singleton
        {
            public static int counter = 0;
            public static Singleton instance = null;

            public static Singleton GetInstance
            {
                get
                {
                    if (instance == null)//because the multithread operation passes instance==null this is not thread safe
                        instance = new Singleton();
                    return instance;
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
