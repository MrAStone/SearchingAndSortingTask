using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SearchingAndSortingTask
{
    
    internal class Program
    {
       public static bool alreadySorted;
        public static bool dataCreated;


        // For each of the tasks you will need to provide evidence
        // Add screenshots for each of the tasks to your readme
        // You must include:
        // Each searching and sorting algorithm being run
        // Trying to sort an already sorted array
        // Trying to sort an array that has not had it's size set
        // trying to run binary search on an unsorted array
        static void Main(string[] args)
        {
            alreadySorted = false;
            dataCreated = false;
            Random rng = new Random();
            runCompare(rng);
            
        }
        /* You can change this to add more features if you want */
        static void menu()
        {
            Console.WriteLine("Alogorithm Comparerer");
            Console.WriteLine("=====================");
            Console.WriteLine("1: Set size of numerical Array");
            Console.WriteLine("2: Bubble Sort Time");
            Console.WriteLine("3: Merge sort time");
            Console.WriteLine("4: Linear Search time");
            Console.WriteLine("5: Binary Search time");
            Console.WriteLine("9: Quit");
            Console.Write("Enter Choice: ");

        }

        /* 
         * The main part of the program  you will need to follow the tasks
         * that are set
         * all tasks are written as comments in the code
        */
       
        static void runCompare(Random r)
        {
            int[] a = null;
            int size = 1;
            Stopwatch sw = new Stopwatch();
            int menuChoice;
            
            do
            {
                sw.Reset();

                menu();
                menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    /* You don't need to change this one */
                    case 1: 
                        Console.Write("Enter size of array to work with: ");
                        size = Convert.ToInt32(Console.ReadLine());
                        a = CreateArray(size, r);
                        dataCreated = true;
                        alreadySorted = false;
                        break;

                    case 2:
                        // add a check to see if both the data has been created and it is not already sorted
                        sw.Start();
                        BubbleSort(a); // you will need to write your own bubble sort
                        sw.Stop();
                        Console.WriteLine($"To BubbleSort an array with {size} values took {sw.ElapsedMilliseconds} millisecods");
                        alreadySorted = true;
                        break;
                    case 3:
                        // add a check to see if both the data has been created and it is not already sorted
                        sw.Start();
                        MergeSortRecursive(a, 0, a.Length - 1);
                        sw.Stop();
                        Console.WriteLine($"To MergeSort an array with {size} values took {sw.ElapsedMilliseconds} millisecods");
                        alreadySorted = true;
                        break;
                    case 4:
                        // Add option 4 and 5 tasks from the menu including the time taken
                        break;
                }

            } while (menuChoice != 9);
        }

        /* Do not change this, it will create an array of random numbers for you to use */
        static int[] CreateArray(int size, Random r)  
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = r.Next(1000, 100000);
            }
            return array;
        }
        

        static void BubbleSort(int[] a)
        {
            // Write the code to complete a bubble sort
        }


        /* DO NOT CHANGE ANY CODE BELOW THIS LINE */

        static void Merge(int[] a, int low, int mid, int high)
        {
            int i, j, k;
            int num1 = mid - low + 1;
            int num2 = high - mid;
            int[] L = new int[num1];
            int[] R = new int[num2];
            for (i = 0; i < num1; i++)
            {
                L[i] = a[low + i];
            }
            for (j = 0; j < num2; j++)
            {
                R[j] = a[mid + j + 1];
            }
            i = 0;
            j = 0;
            k = low;
            while (i < num1 && j < num2)
            {
                if (L[i] <= R[j])
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < num1)
            {
                a[k] = L[i];
                i++;
                k++;
            }
            while (j < num2)
            {
                a[k] = R[j];
                j++; k++;
            }
        }
        static void MergeSortRecursive(int[] a, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortRecursive(a, low, mid);
                MergeSortRecursive(a, mid + 1, high);
                Merge(a, low, mid, high);
            }
        }
    }
}
