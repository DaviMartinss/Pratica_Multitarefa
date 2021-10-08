using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace WorkingWithTasks
{
    class Program
    {
        static void MethodA()
        {
            WriteLine("Metodo de partida A...");
            Thread.Sleep(3000);
            WriteLine("Método finalizado A");
        }

        static void MethodB()
        {
            WriteLine("Metodo de partida B...");
            Thread.Sleep(2000);
            WriteLine("Método finalizado B");
        }
            
        static void MethodC()
        {
            WriteLine("Metodo de partida C...");
            Thread.Sleep(2000);
            WriteLine("Método finalizado C");
        }

        static decimal CallWebService()
        {
            WriteLine("iniciando chamada para serviço web ...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Chamada finalizada para serviço web");

            return 89.99M;
        }  

        static string CallStoredProcedure(decimal amount){

            WriteLine("Iniciando chamada para Stored Procedure... ");
            Thread.Sleep((new Random()).Next(2000, 4000)); 
            WriteLine("Finalizando a chamada para stored procedure.");

            return $"12 produtos custam mais que{amount:C}.";

        }
            
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            
            /*
            WriteLine ("Executando métodos de forma síncrona em um thread." );
            MethodA();
            MethodB();
            MethodC();
            */
            
            /*
            WriteLine("Executando métodos de forma assíncrona em vários threads");

            Task taskA = new Task(MethodA);
            taskA.Start();

            Task taskB = Task.Factory.StartNew(MethodB);

            Task taskC = Task.Run(new Action(MethodC));

            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);
            */

            
            WriteLine("Passar o resultado de uma tarefa como entrada para outra.");

            var taskCallWebServiceAndThenStoredProcedure =
                Task.Factory.StartNew(CallWebService)
                    .ContinueWith(previousTask =>
                        CallStoredProcedure(previousTask.Result));

            WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");
            
            WriteLine ($"{timer.ElapsedMilliseconds:#,##0} ms decorridos");
            
        }
    }
}
