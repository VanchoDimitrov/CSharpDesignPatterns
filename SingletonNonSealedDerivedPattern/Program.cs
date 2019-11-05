using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonNonSealedDerivedPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //we call the Singleton from the derived class

            Singleton.DerivedSingleton derivedObject = new Singleton.DerivedSingleton();
            derivedObject.GetName("Vancho Dimitrov");

            derivedObject.GetName("Ana Dimitrov");

            Singleton.DerivedSingleton derivedObject2 = new Singleton.DerivedSingleton();//if we call another instance it will be instance 2, this time.
            derivedObject2.GetName("Vancho Dimitrov");


            Console.ReadKey();
        }

        //non sealed Singleton class
        //if we make this class "sealed" we can't derived which is a violation of the SIngleton Design Pattern
        public class Singleton
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

            public Singleton()
            {
                counter++;
                Console.WriteLine("Counter: {0}", counter);
            }

            public void GetName(string name)
            {
                Console.WriteLine("Name: {0}", name);
            }

            //derived class from Singleton. Class must be inside the Singleton class
            public class DerivedSingleton : Singleton
            {

            }
        }
    }
}
