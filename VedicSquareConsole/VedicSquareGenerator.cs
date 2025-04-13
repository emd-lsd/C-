using System;

// Определяем пространство имен (обычно совпадает с именем проекта)
namespace VedicSquareConsole
{
    // Наш класс для генерации таблиц
    public class VedicSquareGenerator
    {
        // --- 1. Метод для генерации таблицы Пифагора ---
        // Возвращает двумерный массив int[,]
        // size - размер таблицы (обычно 9 или 10)
        public int[,] GetPythagoreanTable(int size)
        {
            // Создаем двумерный массив размером size x size
            int[,] table = new int[size, size];

            // Используем вложенные циклы для заполнения таблицы
            // i и j будут представлять числа от 1 до size
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    // Массивы в C# индексируются с 0, поэтому используем i-1 и j-1
                    table[i - 1, j - 1] = i * j;
                }
            }
            // Возвращаем готовую таблицу
            return table;
        }

        // --- Вспомогательный метод для вычисления цифрового корня ---
        // Цифровой корень - это сумма цифр числа, повторяющаяся, пока не останется одна цифра.
        // Например: digitalRoot(48) -> 4+8=12 -> 1+2=3. digitalRoot(19) -> 1+9=10 -> 1+0=1.
        // Особый случай: цифровой корень числа, кратного 9, равен 9 (кроме 0).
        private int GetDigitalRoot(int n)
        {
            // Базовый случай
            if (n == 0) return 0;

            // Математический трюк:
            // Цифровой корень числа n равен n % 9.
            // Если n % 9 == 0, то корень равен 9 (для n > 0).
            int root = n % 9;
            if (root == 0)
            {
                return 9;
            }
            else
            {
                return root;
            }

            // Альтернативная реализация (более понятная, но чуть длиннее):
            /*
            while (n > 9)
            {
                int sum = 0;
                while (n > 0)
                {
                    sum += n % 10; // Берем последнюю цифру
                    n /= 10;      // Убираем последнюю цифру
                }
                n = sum; // Повторяем с суммой цифр
            }
            return n;
            */
        }

        // --- 2. Метод для генерации Ведического квадрата ---
        // Возвращает двумерный массив int[,]
        public int[,] GetVedicSquare(int size)
        {
            int[,] vedicSquare = new int[size, size];

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    int product = i * j; // Результат умножения
                    // Вычисляем цифровой корень и записываем в массив
                    vedicSquare[i - 1, j - 1] = GetDigitalRoot(product);
                }
            }
            return vedicSquare;
        }

        // --- 3. Метод для генерации узора по числу ---
        // Принимает Ведический квадрат и число для поиска (patternNumber)
        // Возвращает двумерный массив int[,]:
        //   - содержит patternNumber в ячейках, где он был в Ведическом квадрате
        //   - содержит 0 в остальных ячейках
        public int[,] GetPatternByNumber(int[,] vedicSquare, int patternNumber)
        {
            // Получаем размеры из входного массива
            int rows = vedicSquare.GetLength(0); // Количество строк
            int cols = vedicSquare.GetLength(1); // Количество столбцов

            int[,] pattern = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Если число в ячейке Ведического квадрата совпадает с искомым...
                    if (vedicSquare[i, j] == patternNumber)
                    {
                        // ...ставим это число в массив узора
                        pattern[i, j] = patternNumber;
                    }
                    else
                    {
                        // ...иначе ставим 0 (или можно -1, или другое значение для "пусто")
                        pattern[i, j] = 0;
                    }
                }
            }
            return pattern;
        }

        // --- 4. Метод для красивого вывода таблицы в консоль ---
        // Принимает любой двумерный массив и заголовок
        public void PrintTable(int[,] table, string title)
        {
            Console.WriteLine($"--- {title} ---"); // Выводим заголовок

            int rows = table.GetLength(0);
            int cols = table.GetLength(1);

            // Определим максимальную ширину числа для форматирования
            int maxWidth = 0;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                   int width = table[i, j].ToString().Length;
                   if (width > maxWidth) maxWidth = width;
                }
            }
            // Добавим 1 для пробела между числами
            int cellWidth = maxWidth + 1;


            for (int i = 0; i < rows; i++) // Цикл по строкам
            {
                for (int j = 0; j < cols; j++) // Цикл по столбцам
                {
                    // Получаем значение ячейки
                    int value = table[i, j];
                    string cellValue;

                    // Для узора: если 0, выводим пробел или точку для наглядности
                    if (title.Contains("Pattern") && value == 0)
                    {
                        cellValue = "."; // Используем точку для пустых мест в узоре
                    }
                    else
                    {
                       cellValue = value.ToString();
                    }

                    // Выводим значение, выравнивая по правому краю (PadLeft)
                    // cellWidth - общая ширина ячейки
                    Console.Write(cellValue.PadLeft(cellWidth));
                }
                Console.WriteLine(); // Переход на новую строку после каждой строки таблицы
            }
            Console.WriteLine(); // Пустая строка для разделения таблиц
        }
    }
}