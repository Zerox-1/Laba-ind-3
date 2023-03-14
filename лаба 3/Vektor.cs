using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace лаба_3
{
    public class Vektor
    {
        public double[] mas;
        public Vektor()
        {
            mas = new double[1];
        }
        public Vektor(double[] s)
        {
            mas = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                mas[i] = s[i];
            }
        }
        public Vektor(Vektor b)
        {
            mas = new double[b.mas.Length];

            for (int i = 0; i < b.mas.Length; i++)
            {
                mas[i] = b.mas[i];
            }
        }
        public void vvod()
        {
            Console.WriteLine("Введите размер массива:");
            int N = Convert.ToInt16(Console.ReadLine());
            mas = new double[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Введите элемент массива:");
                double a = Convert.ToDouble(Console.ReadLine());
                mas[i] = a;
            }
        }
        public void vivod()
        {
            Console.Write("(");
            for (int i = 0; i < mas.Length - 1; i++)
            {
                Console.Write($"{mas[i]},");
            }
            Console.Write($"{mas[mas.Length - 1]})");
            Console.WriteLine();
        }
        public override string ToString()
        {
            string y = "(";
            for (int i = 0; i < mas.Length; i++)
            {
                if (i < mas.Length - 1)
                {
                    y += mas[i] + ",";
                }
                else
                {
                    y += mas[i];
                }
            }
            y += ")";
            return y;
        }
        public double Module()
        {
            double sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                sum += mas[i] * mas[i];
            }
            return Math.Sqrt(sum);
        }
        public double max()
        {
            double t = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (t < mas[i])
                {
                    t = mas[i];
                }
            }
            return t;
        }
        public int InMin()
        {
            int t = 0;
            double min = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (min > mas[i])
                {
                    min = mas[i];
                    t = i;
                }
            }
            return t;
        }
        public Vektor poloj()
        {
            Vektor a = new Vektor();
            int t = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    t++;
                }
            }
            a.mas = new double[t];
            for (int i = 0, y = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    a.mas[y] = mas[i];
                    y++;
                }
            }
            return a;
        }
        public double value(int index)
        {
            if (index > 0 && index < mas.Length)
            {
                return mas[index];
            }
            else
            {
                return double.PositiveInfinity;
            }
        }
        public void change(int index, double a)
        {
            if (index > 0 && index < mas.Length)
            {
                mas[index] = a;
            }
            else
            {
                Console.WriteLine("Нет такого индекса!");
            }
        }
        public void rnd(int a, int b)
        {
            var rand = new Random();
            if (a > b)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rand.Next(b,a);
                }
            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rand.Next(a, b);
                }
            }
        }
        public int line(double a)
        {
            int i = 0;
            while (i <= mas.Length - 1 && mas[i] != a)
            {
                if (i != mas.Length - 1) { i++; }
                else
                {
                    i = -1;
                    break;
                }
            }
            return i;
        }
        public bool sorted()
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] > mas[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        public Vektor Haora()
        {
            if (mas.Length > 1)
            {
                var rand = new Random();
                double x = mas[rand.Next(0, mas.Length - 1)];
                int lowi = 0, hii = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] < x)
                    {
                        lowi++;
                    }
                    else if (mas[i] > x)
                    {
                        hii++;
                    }
                }
                double[] low = new double[lowi]; double[] hi = new double[hii]; double[] eq = { x };
                for (int i = 0, l = 0, h = 0; i < mas.Length; i++)
                {
                    if (mas[i] < x)
                    {
                        low[l] = mas[i];
                        l++;
                    }
                    else if (mas[i] > x)
                    {
                        hi[h] = mas[i];
                        h++;
                    }
                }
                Vektor a = new Vektor(low);
                Vektor b = new Vektor(hi);
                mas = (a.Haora().mas).Concat(eq).Concat(b.Haora().mas).ToArray();
            }
            return new Vektor(mas);
        }
        public int binar(double a)
        {
            Haora();
            int left = 0;
            int right = mas.Length - 1;
            int index = 0;
            int res = -1;
            while (left <= right)
            {
                index = (right + left) / 2;
                if (mas[index] == a)
                {
                    return index;
                }
                if (mas[index] < a)
                {
                    left = index + 1;
                }
                else
                {
                    right = index - 1;
                }
            }
            return res;
        }
        public Vektor sdvig()
        {
            double a = mas[mas.Length - 1];
            for (int i = mas.Length - 1; i > 0; i--)
            {
                mas[i] = mas[i - 1];
            }
            mas[0] = a;
            Vektor c = new Vektor(mas);
            return c;
        }
        public bool otric()
        {
            int count = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] < 0 && mas[i + 1] < 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static public Vektor Sum(Vektor a, Vektor b)
        {
            Vektor c = new Vektor(); int f;
            if (a.mas.Length >= b.mas.Length)
            {
                f = a.mas.Length;
            }
            else
            {
                f = b.mas.Length;
            }
            c.mas = new double[f];

            if (a.mas.Length == b.mas.Length)
            {
                for (int i = 0; i < a.mas.Length; i++)
                {
                    c.mas[i] = a.mas[i] + b.mas[i];
                }
            }
            else if (a.mas.Length < b.mas.Length)
            {
                for (int i = 0; i < a.mas.Length; i++)
                {
                    c.mas[i] = a.mas[i] + b.mas[i];
                }
                for (int i = a.mas.Length; i < b.mas.Length; i++)
                {
                    c.mas[i] = b.mas[i];
                }
            }
            else
            {
                for (int i = 0; i < b.mas.Length; i++)
                {
                    c.mas[i] = a.mas[i] + b.mas[i];
                }
                for (int i = b.mas.Length; i < a.mas.Length; i++)
                {
                    c.mas[i] = a.mas[i];
                }
            }
            return c;
        }
        static public double Scalar(Vektor a, Vektor b)
        {
            double sum = 0; int f = 0;
            if (a.mas.Length <= b.mas.Length)
            {
                f = a.mas.Length;
            }
            else
            {
                f = b.mas.Length;
            }
            for (int i = 0; i < f; i++)
            {
                sum += a.mas[i] * b.mas[i];
            }
            return sum;
        }
        static public bool Ravn(Vektor a, Vektor b)
        {
            if (a.mas.Length == b.mas.Length)
            {
                for (int i = 0; i < a.mas.Length; i++)
                {
                    if (a.mas[i] != b.mas[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
