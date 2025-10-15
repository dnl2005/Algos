using System;
public class MergeSort<T> where T : IComparable<T>
{
    /// <summary>
    /// Основной метод для сортировки массива по возрастанию
    /// </summary>
    /// <param name="array">Массив для сортировки</param>
    /// <remarks>
    /// Временная сложность: O(n log n) в худшем, среднем и лучшем случае
    /// Пространственная сложность: O(n)
    /// Алгоритм устойчив и использует стратегию "разделяй и властвуй"
    /// </remarks>
    public void Sort(T[] array)
    {
        // проверка на пригодность входного массива
        if (array == null || array.Length <= 1) return;

        // вызов рекурсивного метода сортировки слиянием
        MergeSortRecursive(array, 0, array.Length - 1);
    }

    /// <summary>
    /// Рекурсивно сортирует подмассив методом слияния
    /// </summary>
    /// <param name="arr">Исходный массив</param>
    /// <param name="left">Левый индекс подмассива (включительно)</param>
    /// <param name="right">Правый индекс подмассива (включительно)</param>
    private void MergeSortRecursive(T[] arr, int left, int right)
    {
        if (left >= right) return; // базовый случай: подмассив длиной 1

        int mid = left + (right - left) / 2;

        // сортируем левую половину
        MergeSortRecursive(arr, left, mid);

        // сортируем правую половину
        MergeSortRecursive(arr, mid + 1, right);

        // сливаем левую и правую половину
        Merge(arr, left, mid, right);
    }

    /// <summary>
    /// Сливает два отсортированных подмассива в один отсортированный массив
    /// </summary>
    /// <param name="arr">Исходный массив, в который производится слияние</param>
    /// <param name="left">Начальный индекс левого подмассива</param>
    /// <param name="mid">Конечный индекс левого подмассива и разделительная точка</param>
    /// <param name="right">Конечный индекс правого подмассива</param>
    private void Merge(T[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1;  // длина левого подмассива
        int len2 = right - mid;     // длина правого подмассива

        T[] leftArr = new T[len1];  // временный массив для левой части
        T[] rightArr = new T[len2]; // временный массив для правой части

        // копируем значения во временные массивы
        Array.Copy(arr, left, leftArr, 0, len1);
        Array.Copy(arr, mid + 1, rightArr, 0, len2);

        int i = 0, j = 0, k = left;

        // сливаем элементы обратно в arr по возрастанию
        while (i < len1 && j < len2)
        {
            if (leftArr[i].CompareTo(rightArr[j]) <= 0)
                arr[k++] = leftArr[i++];
            else
                arr[k++] = rightArr[j++];
        }

        // копируем оставшиеся элементы, если они есть
        while (i < len1) arr[k++] = leftArr[i++];
        while (j < len2) arr[k++] = rightArr[j++];
    }
}