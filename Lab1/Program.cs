using System;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторная работа № 1 ===");
    Console.WriteLine("Вариант 8");
    Console.WriteLine("1. Вычислить факториал");
    Console.WriteLine("2. Последовательность Фибоначчи");
    Console.WriteLine("3. Вычислить функцию варианта 8");
    Console.WriteLine("4. Сумма ряда Тейлора для e^x");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите задание: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Ошибка: введите целое число от 0 до 4.");
        continue;
    }

    switch (choice)
    {
        case 1:
            Task1();
            break;
        case 2:
            Task2();
            break;
        case 3:
            Task3();
            break;
        case 4:
            Task4();
            break;
        case 0:
            Console.WriteLine("Программа завершена.");
            return;
        default:
            Console.WriteLine("Ошибка: выберите задание от 0 до 4.");
            break;
    }
}

static void Task1()
{
    Console.Write("Введите n (от 0 до 20): ");

    if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 20)
    {
        Console.WriteLine("Ошибка: n должно быть целым числом от 0 до 20.");
        return;
    }

    Console.WriteLine($"{n}! = {Factorial(n)}");
}

static long Factorial(int n)
{
    long result = 1;

    for (int i = 2; i <= n; i++)
    {
        result *= i;
    }

    return result;
}

static void Task2()
{
    Console.Write("Введите n (от 0 до 92): ");

    if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 92)
    {
        Console.WriteLine("Ошибка: n должно быть целым числом от 0 до 92.");
        return;
    }

    Console.WriteLine($"Числа Фибоначчи от 0 до {n}:");
    Console.WriteLine(string.Join(", ", Fibonacci(n)));
}

static long[] Fibonacci(int n)
{
    long[] numbers = new long[n + 1];

    numbers[0] = 0;

    if (n >= 1)
    {
        numbers[1] = 1;
    }

    for (int i = 2; i <= n; i++)
    {
        numbers[i] = numbers[i - 1] + numbers[i - 2];
    }

    return numbers;
}

static void Task3()
{
    Console.Write("Введите x: ");

    if (!TryReadDouble(out double x))
    {
        Console.WriteLine("Ошибка: введите корректное вещественное число.");
        return;
    }

    if (!TryCalculateFunction(x, out double result, out string error))
    {
        Console.WriteLine($"Ошибка: {error}");
        return;
    }

    Console.WriteLine($"A = {result:F10}");
}

static bool TryCalculateFunction(
    double x, out double result, out string error)
{
    result = 0;
    error = "";

    double cosine = Math.Cos(x * x);

    if (Math.Abs(cosine) < 1e-12)
    {
        error = "тангенс x² не определён или близок к точке разрыва.";
        return false;
    }

    double exponent = Math.Tan(x * x) + Math.Atan(x);

    if (!double.IsFinite(exponent) ||
        exponent > 700 ||
        Math.Abs(15 - x) > 700)
    {
        error = "результат выходит за допустимый числовой диапазон.";
        return false;
    }

    double fifthRoot =
        Math.Sign(x - 5) * Math.Pow(Math.Abs(x - 5), 1.0 / 5.0);

    result = Math.Exp(exponent) * Math.Cosh(15 - x) - fifthRoot;

    if (!double.IsFinite(result))
    {
        error = "не удалось получить конечный результат.";
        return false;
    }

    return true;
}

static void Task4()
{
    Console.Write("Введите x: ");

    if (!TryReadDouble(out double x))
    {
        Console.WriteLine("Ошибка: введите корректное вещественное число.");
        return;
    }

    const double epsilon = 1e-6;

    double sum = 1.0;
    double term = 1.0;
    int count = 1;
    int n = 1;

    while (true)
    {
        double nextTerm = term * x / n;

        if (Math.Abs(nextTerm) <= epsilon)
        {
            break;
        }

        term = nextTerm;
        sum += term;
        count++;
        n++;

        if (count >= 100000)
        {
            Console.WriteLine("Ошибка: превышено максимальное число итераций.");
            return;
        }
    }

    double libraryResult = Math.Exp(x);

    Console.WriteLine($"Сумма ряда Тейлора: {sum:F10}");
    Console.WriteLine($"Math.Exp(x):        {libraryResult:F10}");
    Console.WriteLine($"Абсолютная разница: {Math.Abs(sum - libraryResult):E6}");
    Console.WriteLine($"Количество членов:  {count}");
}

static bool TryReadDouble(out double value)
{
    string input = Console.ReadLine() ?? "";
    input = input.Trim().Replace(',', '.');

    return double.TryParse(
               input,
               NumberStyles.Float,
               CultureInfo.InvariantCulture,
               out value)
           && double.IsFinite(value);
}
