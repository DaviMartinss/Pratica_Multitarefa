using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace NestedAndChildTasks
{
    class Program
    {
        static void OuterMethod()
        { 
            WriteLine("Iniciando Outer method... ");
            
            var inner = Task.Factory.StartNew(InnerMethod,
                TaskCreationOptions.AttachedToParent);
            
            WriteLine("Outer method finalizado.");
        }

        static void InnerMethod()
        {

            WriteLine("Iniciando Inner method...");
            Thread.Sleep(2000);
            WriteLine("Inner method finalizado.");

        }

        static void Main(string[] args)
        {
            var outer = Task.Factory.StartNew(OuterMethod);
            outer.Wait();
            WriteLine("O aplicativo do console está parando.");
        }
    }
}
