// See https://aka.ms/new-console-template for more information
using лаба_3;

Vektor a = new Vektor();

a.vvod();
Console.WriteLine("Вектор модуля:" + a.Module());
Console.WriteLine("Наибольший элемент:" + a.max());
Console.WriteLine("Индекс минимального элемента:" + a.InMin());
Console.WriteLine("Вектор только из положителльных элементов" + a.poloj());
Vektor b = new Vektor();
b.vvod();
Console.WriteLine("Сумма векторов" + Vektor.Sum(a, b));
Console.WriteLine("Скалярное произведение" + Vektor.Scalar(a, b));
Console.WriteLine("Равенство векторов:" + Vektor.Ravn(a, b));
Console.WriteLine("Элемент по индексу:" + a.value(3));
a.change(3, 6);
Console.WriteLine("Измененый элемент вектора по индексу" + a);
a.rnd(-10, 10);
Console.WriteLine("Случайный вектор:" + a);
Console.WriteLine("Линейный поиск " + a.line(6));
Console.WriteLine("проверка на отсортированность " + a.sorted());
Console.WriteLine("Бинарный поиск:" + a.binar(7));
Console.WriteLine("Вектор сдвинутый направо" + a.sdvig());
Console.WriteLine("Есть ли два стоящих рядом отриц числа:" + a.otric());
Console.WriteLine("Сортировка Хаора:" + a.Haora());