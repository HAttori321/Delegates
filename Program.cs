namespace Delegates
{
    internal class Program
    {
        delegate int CalculateOperation(int[] array);
        delegate void ModifyOperation(int[] array);
        static void Main(string[] args)
        {
            int[] array = { -1, 2, -3, 4, -5, 6, -7, 8, -9, 10 };
            Console.WriteLine("Choose operation type : ");
            Console.WriteLine("1. Calculate operation");
            Console.WriteLine("2. Modify operation");
            int operationType = int.Parse(Console.ReadLine());
            if (operationType == 1)
            {
                Console.WriteLine("Choose calculate operation : ");
                Console.WriteLine("1. Count negative elements");
                Console.WriteLine("2. Calculate sum of all elements");
                Console.WriteLine("3. Count prime numbers");
                int calculateOperation = int.Parse(Console.ReadLine());
                CalculateOperation calculateDelegate = null;
                switch (calculateOperation)
                {
                    case 1:
                        calculateDelegate = CountNegativeElements;
                        break;
                    case 2:
                        calculateDelegate = CalculateSum;
                        break;
                    case 3:
                        calculateDelegate = CountPrimeNumbers;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        return;
                }
                int result = calculateDelegate(array);
                Console.WriteLine("Result: " + result);
            }
            else if (operationType == 2)
            {
                Console.WriteLine("Choose modify operation : ");
                Console.WriteLine("1. Replace negative elements with 0");
                Console.WriteLine("2. Sort array");
                Console.WriteLine("3. Move even elements to the beginning");
                int modifyOperation = int.Parse(Console.ReadLine());
                ModifyOperation modifyDelegate = null;
                switch (modifyOperation)
                {
                    case 1:
                        modifyDelegate = ReplaceNegativeWithZero;
                        break;
                    case 2:
                        modifyDelegate = SortArray;
                        break;
                    case 3:
                        modifyDelegate = MoveEvenElementsToBeginning;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        return;
                }
                modifyDelegate(array);
                Console.WriteLine("Modified array : " + string.Join(", ", array));
            }
            else
            {
                Console.WriteLine("Invalid operation type");
            }
        }
        static int CountNegativeElements(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    count++;
            }
            return count;
        }
        static int CalculateSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        static int CountPrimeNumbers(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                    count++;
            }
            return count;
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void ReplaceNegativeWithZero(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    array[i] = 0;
            }
        }
        static void SortArray(int[] array)
        {
            Array.Sort(array);
        }
        static void MoveEvenElementsToBeginning(int[] array)
        {
            Array.Sort(array, delegate (int x, int y)
            {
                if (x % 2 == y % 2) return 0;
                if (x % 2 == 0) return -1;
                return 1;
            });
        }
    }
}