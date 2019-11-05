using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton firstInstance = Singleton.GetInstance;
            firstInstance.GetName("Vancho Dimitrov");

            Singleton secondInstance = Singleton.GetInstance; //no matter that we create another instance of the SIngleton class. The class is called only once.
            secondInstance.GetName("Ana Dimitrova");

            Console.ReadKey();
        }
    }

    //Singleton sealed class. We instantiate only one instance of the class at runtime.
    public sealed class Singleton
    {
        public static int counter = 0;
        public static Singleton instance = null;

        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        //this reads only the instance number=1 because it is a sealed class
        public Singleton()
        {
            counter++;
            Console.WriteLine("Counter {0}", counter.ToString());
        }

        public void GetName(string name)
        {
            Console.WriteLine("Name and Last Name: {0}", name.ToString());
        }
    }
}
