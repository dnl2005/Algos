using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");

        // Чтение и преобразование ввода в массив чисел
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        // Проверка на пустой массив
        if (numbers.Length == 0) return;

        // Находим минимальное и максимальное значение в массиве
        int min = numbers.Min();
        int max = numbers.Max();

        // Создаем массив для подсчета количества каждого элемента
        int[] count = new int[max - min + 1];

        // Подсчитываем количество вхождений каждого числа - O(n)
        foreach (int num in numbers)
            count[num - min]++; // Сдвигаем индексы для учета отрицательных чисел

        // Восстанавливаем отсортированный массив - O(n)
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            // Добавляем каждое число столько раз, сколько оно встречалось
            while (count[i] > 0)
            {
                numbers[index++] = i + min; // Возвращаем исходное значение числа
                count[i]--;
            }
        }

        // Выводим результат
        Console.WriteLine("Отсортированный массив: " + string.Join(" ", numbers));
    }
}