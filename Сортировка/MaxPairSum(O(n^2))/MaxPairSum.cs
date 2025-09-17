using System; // Подключаем стандартное пространство имён для работы с консолью и исключениями

public class MaxPairSumBruteForce
{
    /// <summary>
    /// Находит максимальную сумму двух элементов массива,
    /// которая больше заданного порога M и делится нацело на D.
    /// Используется полный перебор всех пар → сложность O(n^2).
    /// </summary>
    /// <param name="arr">Массив чисел</param>
    /// <param name="M">Минимальное значение суммы</param>
    /// <param name="D">Делитель (D > 1)</param>
    /// <returns>
    /// Nullable-кортеж (сумма, индекс1, индекс2),
    /// либо null, если подходящей пары нет.
    /// </returns>
    public static (int sum, int i, int j)? MaxPairSum(int[] arr, int M, int D)
    {
        // Проверка: делитель D должен быть больше 1
        if (D <= 1)
            throw new ArgumentException("D must be > 1");

        // Если элементов меньше двух → пары не может быть
        if (arr.Length < 2)
            return null;

        // bestSum — хранит наилучшую (максимальную) сумму
        // Nullable int нужен, чтобы удобно проверять "нашли ли хоть одну пару"
        int? bestSum = null;

        // bestPair — хранит индексы пары, которая дала bestSum
        (int i, int j) bestPair = (-1, -1);

        // Внешний цикл фиксирует первый элемент пары
        for (int i = 0; i < arr.Length; i++)
        {
            // Внутренний цикл берёт второй элемент (j > i),
            // чтобы не повторять пары и не складывать элемент сам с собой
            for (int j = i + 1; j < arr.Length; j++)
            {
                // Сумма текущей пары
                int sum = arr[i] + arr[j];

                // Проверяем условия:
                // 1) сумма должна быть больше M
                // 2) сумма должна делиться на D без остатка
                if (sum > M && sum % D == 0)
                {
                    // Если это первая подходящая пара (bestSum == null)
                    // или сумма больше текущего рекорда
                    if (bestSum == null || sum > bestSum)
                    {
                        // Обновляем лучший результат
                        bestSum = sum;
                        bestPair = (i, j);
                    }
                }
            }
        }

        // Если ни одной подходящей пары не найдено → возвращаем null
        if (bestSum == null)
            return null;

        // Возвращаем кортеж (сумма, индекс1, индекс2)
        return (bestSum.Value, bestPair.i, bestPair.j);
    }

    public static void Main()
    {
        // Исходный массив
        int[] arr = { 1, 2, 3, 4, 5, 6 };

        // Минимальное значение суммы
        int M = 7;

        // Делитель
        int D = 3;

        // Вызываем метод для поиска максимальной суммы
        var result = MaxPairSum(arr, M, D);

        // Проверяем, нашлась ли пара
        if (result != null)
        {
            // Извлекаем значения из nullable-кортежа
            Console.WriteLine($"Максимальная сумма: {result.Value.sum}");
            Console.WriteLine($"Индексы элементов: {result.Value.i}, {result.Value.j}");
            Console.WriteLine($"Элементы: {arr[result.Value.i]} и {arr[result.Value.j]}");
        }
        else
        {
            Console.WriteLine("Подходящей пары не найдено.");
        }
    }
}