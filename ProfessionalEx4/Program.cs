//Завдання 4

//Створіть масив чисел розмірністю 1000000 або більше.
//Використовуючи генератор випадкових чисел, проініціалізуйте цей масив значеннями.
//Створіть PLINQ запит, який дозволить отримати усі непарні числа з вихідного масиву.

namespace ProfessionalEx4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] ints = new int[1000000];
            Action<int> action = i => { ints[i] = random.Next(0, 1000); Console.WriteLine("Created numbres in array :"+ints[i]); };
            Parallel.For(0, ints.Length, action);

            ParallelQuery<int> query = from items in ints.AsParallel().OrderBy(i => i)
                                       where items % 2 != 0
                                       select items;
            foreach (int i in query)
            {
                Console.WriteLine("Sorted result: " + i);
            }
        }
    }
}