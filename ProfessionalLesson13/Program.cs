//Завдання 2

//Створіть два методи, які виконуватимуться у межах паралельних завдань.
//Організуйте виклик цих методів за допомогою Invoke таким чином,
//щоб основний потік програми (метод Main) не зупинив виконання.
using System.Reflection;

namespace ProfessionalLesson13
{
    internal class Program
    {
        static void Method1()
        {
            Console.WriteLine("{0} from task {1} from thread {2} started", MethodInfo.GetCurrentMethod().Name, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("{0} from task {1} from thread {2} finished", MethodInfo.GetCurrentMethod().Name, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        }
        static void Method2()
        {
            Console.WriteLine("{0} from task {1} from thread {2} started", MethodInfo.GetCurrentMethod().Name, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("{0} from task {1} from thread {2} finished", MethodInfo.GetCurrentMethod().Name, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        }
      
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            Thread instance1 = new Thread(Method1);
            Thread instance2 = new Thread(Method2);
            ParallelOptions paralel = new ParallelOptions();
            paralel.MaxDegreeOfParallelism = 3;
            Parallel.Invoke(paralel, instance1.Start, instance2.Start);
            Thread.Sleep(1000);
            Console.WriteLine("_________________________________-");
            
        }
    }


}