namespace DefaultNamespace;

public class QuickSort<T> where T : IComparable<T>
{
    /// <summary>
    /// Основной метод для сортировки массива.
    /// </summary>
    /// <param name="array">Массив для сортировки.</param>
    public void Sort(T[] array)
    {
        // проверка на пригодность входного массива
        if (array == null || array.Length <= 1) return;

        // вызов метода быстрой сортировки
        QuickSortRecursive(array, 0, array.Length - 1);
    }

    /// <summary>
    /// Рекурсивная функция быстрой сортировки.
    /// </summary>
    /// <param name="array">Массив для сортировки.</param>
    /// <param name="low">Начальный индекс подмассива.</param>
    /// <param name="high">Конечный индекс подмассива.</param>
    private void QuickSortRecursive(T[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);

            // Рекурсивная сортировка левой части
            QuickSortRecursive(array, low, pivotIndex - 1);

            // Рекурсивная сортировка правой части
            QuickSortRecursive(array, pivotIndex + 1, high);
        }
    }

    /// <summary>
    /// Разделение подмассива на две части относительно опорного элемента.
    /// </summary>
    /// <param name="array">Массив для разделения.</param>
    /// <param name="low">Начальный индекс подмассива.</param>
    /// <param name="high">Конечный индекс подмассива.</param>
    /// <returns>Индекс опорного элемента после разделения.</returns>
    private int Partition(T[] array, int low, int high)
    {
        // Выбираем последний элемент в качестве опорного
        T pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            // Если текущий элемент меньше или равен опорному, меняем его местами
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        // Перемещаем опорный элемент на его правильную позицию
        Swap(array, i + 1, high);
        return i + 1;
    }

    /// <summary>
    /// Вспомогательный метод для обмена элементов.
    /// </summary>
    /// <param name="array">Массив.</param>
    /// <param name="i">Индекс первого элемента.</param>
    /// <param name="j">Индекс второго элемента.</param>
    private void Swap(T[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
}