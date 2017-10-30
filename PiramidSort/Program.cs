using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiramidSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {16,11,9,10,5,6,8,1,2,4 };

            Sort(ref array);

            foreach(int i in array)
            {
                Console.Write(i + " ");
            }
        }

        public static void Sort(ref int[] array)
        {

            int N = array.Length;

            //Создаём из массива сортирующее дерево
            //Максимальный элемент окажется в корне.
            for (int k = N / 2; k > 0; k--)
                downHeap(ref array, k, N);

            //Избавляемся от максимумов 
            //и перетряхиваем сортирующее дерево
            do
            {

                //Меняем максимум с последним элементом...
                int T = array[0];
                array[0] = array[N - 1];
                array[N - 1] = T;

                //... и перестравиваем сортирующее дерево
                //для неотсортированной части массива			
                N = N - 1;
                downHeap(ref array, 1, N);

            } while (N > 1); //До последнего элемента
        }

        public static void downHeap(ref int[] array,int k,int N)
        {

            //В корне поддерева
            //запоминаем родителя
            int T = array[k - 1];

            //Смотрим потомков в пределах ветки
            while (k <= N / 2)
            {

                int j = k + k;//Левый потомок

                //Если есть правый потомок, 
                //то сравниваем его с левым
                //и из них выбираем наибольший
                if ((j < N) && (array[j - 1] < array[j]))
                    j++;

                //Если родитель больше (или равен) наибольшего потомка...
                if (T >= array[j - 1])
                {

                    //... то значит всё в порядке в этой ветке		
                    break;

                }
                else
                { //Если родитель меньше наибольшего потомка...	

                    //... то потомок становится на место родителя
                    array[k - 1] = array[j - 1];
                    k = j;

                }
            }

            //Родитель в итоге меняется местами с наибольшим из потомков
            //(или остаётся на своём месте, если все потомки меньше его)
            array[k - 1] = T;

            foreach(int i in array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

        }
    }
}
