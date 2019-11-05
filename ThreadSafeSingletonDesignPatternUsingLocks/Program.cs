using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeSingletonDesignPatternUsingLocks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Safe thread operation
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
            Singleton studentName = Singleton.GetInstance;
            studentName.GetName("Vancho Dimitrov");
        }


        private static void getProfessorName()
        {
            Singleton professorName = Singleton.GetInstance;
            professorName.GetName("Ana Dimitrova");
        }

        public sealed class Singleton
        {
            public static int counter = 0;
            private static readonly object Instancelock = new object();
            public static Singleton instance = null;

            public static Singleton GetInstance
            {
                get
                {
                    if (instance == null)//we need to check for another null instance to improve performance. Very important! If we don't add that the program slows down.
                    {
                        lock (Instancelock)
                        {
                            if (instance == null)
                                instance = new Singleton();
                            return instance;
                        }
                    }
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
