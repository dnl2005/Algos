using System;

/// <summary>
/// Программа для нахождения минимального произведения пары элементов массива,
/// которое делится на 15. Алгоритм имеет линейную сложность O(n).
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    static void Main()
    {
        // Ввод исходных данных
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Поиск минимального произведения, делящегося на 15
        int? minProduct = FindMinProductDivisibleBy15(arr);

        // Вывод результата
        if (minProduct.HasValue)
            Console.WriteLine($"Минимальное произведение, делящееся на 15: {minProduct.Value}");
        else
            Console.WriteLine("Подходящих пар не найдено.");
    }

    /// <summary>
    /// Находит минимальное произведение двух различных элементов массива,
    /// которое делится на 15.
    /// </summary>
    /// <param name="arr">Массив целых чисел.</param>
    /// <returns>Минимальное произведение или null, если пары нет.</returns>
    static int? FindMinProductDivisibleBy15(int[] arr)
    {
        // Минимальные числа с различными признаками кратности
        int? min3 = null;  // минимальное число, кратное 3
        int? min5 = null;  // минимальное число, кратное 5
        int? min15 = null; // минимальное число, кратное 15
        int? minAny = null; // минимальное число без условий

        foreach (int x in arr)
        {
            // Обновляем минимальные значения по категориям
            if (x % 3 == 0 && (min3 == null || x < min3)) min3 = x;
            if (x % 5 == 0 && (min5 == null || x < min5)) min5 = x;
            if (x % 15 == 0 && (min15 == null || x < min15)) min15 = x;
            if (minAny == null || x < minAny) minAny = x;
        }

        // Проверяем возможные комбинации, которые дают произведение, кратное 15
        int? minProduct = null;

        // 3 × 5 = 15
        if (min3.HasValue && min5.HasValue && min3 != min5)
            minProduct = min3.Value * min5.Value;

        // 15 × любое = 15k
        if (min15.HasValue && minAny.HasValue && (min15 != minAny))
        {
            int prod = min15.Value * minAny.Value;
            if (minProduct == null || prod < minProduct) minProduct = prod;
        }

        // Если все комбинации дают один и тот же элемент (например, оба кратны 15)
        // Проверим, если в массиве больше одного элемента, равного min15
        if (min15.HasValue)
        {
            int countMin15 = 0;
            foreach (int x in arr)
                if (x == min15.Value) countMin15++;

            if (countMin15 > 1)
            {
                int prod = min15.Value * min15.Value;
                if (minProduct == null || prod < minProduct) minProduct = prod;
            }
        }

        return minProduct;
    }
}