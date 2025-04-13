using System; // Подключаем базовые возможности C#

// Определяем пространство имен (должно совпадать с тем, что в VedicSquareGenerator.cs)
namespace VedicSquareConsole
{
    // Основной класс программы
    class Program
    {
        // Точка входа в программу - метод Main
        static void Main(string[] args)
        {
            Console.WriteLine("Генератор Ведического Квадрата");

            // --- Настройки ---
            int tableSize = 9; // Размер таблиц (обычно 9x9 для Ведического квадрата)
            int numberForPattern = 7; // Число, по которому будем строить узор (от 1 до 9)

            // --- Создание объекта нашего генератора ---
            // Мы создали класс VedicSquareGenerator, теперь нам нужен его экземпляр (объект),
            // чтобы вызывать его методы.
            VedicSquareGenerator generator = new VedicSquareGenerator();

            // --- Генерация данных ---
            // 1. Получаем таблицу Пифагора
            int[,] pythagoreanTable = generator.GetPythagoreanTable(tableSize);

            // 2. Получаем Ведический квадрат
            int[,] vedicSquare = generator.GetVedicSquare(tableSize);

            // 3. Получаем узор по числу
            Console.WriteLine($"\nГенерируем узор для числа: {numberForPattern}");
            int[,] pattern = generator.GetPatternByNumber(vedicSquare, numberForPattern);

            // --- Вывод данных в консоль ---
            // Используем метод PrintTable из нашего генератора
            generator.PrintTable(pythagoreanTable, $"Таблица Пифагора ({tableSize}x{tableSize})");
            generator.PrintTable(vedicSquare, $"Ведический Квадрат ({tableSize}x{tableSize})");
            generator.PrintTable(pattern, $"Узор для числа {numberForPattern}");


            // Чтобы консольное окно не закрылось сразу (если запускаешь не из Rider/VS)
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}