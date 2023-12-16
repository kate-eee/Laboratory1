namespace Laba
{
    using System;
    using System.ComponentModel.Design;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int N = 10; // Размер массива

            // Создание и заполнение массива случайными вещественными числами
            double[] array = new double[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = random.NextDouble() * 100; // Генерация вещественного числа от 0 до 100
            }

            // 1. Вычисление произведения положительных элементов массива
            double productOfPositives = 1.0;
            foreach (double num in array)
            {
                if (num > 0)
                {
                    productOfPositives *= num;
                }
            }

            // 2. Вычисление суммы элементов массива до минимального элемента
            
            int? minElementIndex = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElementIndex is null)
                {
                    minElementIndex = i;
                } else if (array[i] < array[(int)minElementIndex])
                {
                    minElementIndex = i;
                }
            }
            double sumBeforeMin = 0.0;
            for (int i = 0; i < minElementIndex; i++)
            {
                sumBeforeMin += array[i];
            }

            // Упорядочивание элементов на четных и нечетных позициях
            var evenIndexes = array.Where((value, index) => index % 2 == 0).OrderBy(x => x).ToArray();
            var oddIndexes = array.Where((value, index) => index % 2 != 0).OrderBy(x => x).ToArray();

            // Вывод результатов
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine($"Произведение положительных элементов: {productOfPositives}");
            Console.WriteLine($"Сумма элементов до минимального элемента: {sumBeforeMin}");
            Console.WriteLine("Упорядоченные элементы на четных позициях:");
            Console.WriteLine(string.Join(", ", evenIndexes));
            Console.WriteLine("Упорядоченные элементы на нечетных позициях:");
            Console.WriteLine(string.Join(", ", oddIndexes));

            // ||-я часть, создание матрицы
            var matrix = new List<List<int>>();
            int width = random.Next(10) + 1;
            int length = random.Next(10) + 1;
            Console.WriteLine("Матрица:");
            for (int i = 0; i < width; i++)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < length; j++)
                {
                    matrix[i].Add(random.Next(10) * (int)Math.Pow(-1, random.Next(2)));
                }
                Console.WriteLine(string.Join(", ", matrix[i]));
            }

            Console.WriteLine("Количество отрицательных в каждой строке:");
            for (int i = 0; i < width; ++i)
            {
                bool hasZero = false;
                int count = 0;
                for (int j=0; j < length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        hasZero = true;
                    }
                    if (matrix[i][j] < 0)
                    {
                        ++count;
                    }
                }

                if (hasZero)
                {
                    Console.WriteLine(count);
                } else
                {
                    Console.WriteLine("-");
                }
            }

            var columnMinIndexes = new List<List<int>>();
            for (int i = 0; i < length; ++i) 
            {
                int? min = null;
                columnMinIndexes.Add(new List<int>());
                for (int j = 0; j < width; ++j)
                {
                    if (min == null)
                    {
                        min = matrix[j][i];
                    } else if (min > matrix[j][i])
                    {
                        min = matrix[j][i];
                    }
                }
                for (int j = 0; j < width; ++j)
                {
                    if (matrix[j][i] == min)
                    {
                        columnMinIndexes[i].Add(j);
                    }
                }
                
            }
            var rowMaxIndexes = new List<List<int>>();
            for (int i = 0; i < width; ++i)
            {
                int? max = null;
                rowMaxIndexes.Add(new List<int>());
                for (int j = 0; j < length; ++j)
                {
                    if (max == null)
                    {
                        max = matrix[i][j];
                    }
                    else if (max < matrix[i][j])
                    {
                        max = matrix[i][j];
                    }
                }
                for (int j = 0; j < length; ++j)
                {
                    if (matrix[i][j] == max)
                    {
                        rowMaxIndexes[i].Add(j);
                    }
                }
                
            }
            bool found = false;
            Console.WriteLine("Седловые точки:");
            for (int i = 0; i < columnMinIndexes.Count; ++i)
            {
                for (int j = 0; j < columnMinIndexes[i].Count; ++j)
                {
                    foreach (var e in rowMaxIndexes[columnMinIndexes[i][j]])
                    {
                        if (e == i)
                        {
                            found = true;
                            Console.WriteLine("Номер строки: " + columnMinIndexes[i][j] + " Номер столбца: " + i);
                        }
                    }
                }
            }

            if (!found)
            {
                Console.Out.WriteLine("отсутсвуют");
            }
        }
    }
}

