using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("������� ����� ����� ������:");

        // ������ � �������������� ����� � ������ �����
        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        // �������� �� ������ ������
        if (numbers.Length == 0) return;

        // ������� ����������� � ������������ �������� � �������
        int min = numbers.Min();
        int max = numbers.Max();

        // ������� ������ ��� �������� ���������� ������� ��������
        int[] count = new int[max - min + 1];

        // ������������ ���������� ��������� ������� ����� - O(n)
        foreach (int num in numbers)
            count[num - min]++; // �������� ������� ��� ����� ������������� �����

        // ��������������� ��������������� ������ - O(n)
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            // ��������� ������ ����� ������� ���, ������� ��� �����������
            while (count[i] > 0)
            {
                numbers[index++] = i + min; // ���������� �������� �������� �����
                count[i]--;
            }
        }

        // ������� ���������
        Console.WriteLine("��������������� ������: " + string.Join(" ", numbers));
    }
}