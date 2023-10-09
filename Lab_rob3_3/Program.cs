class Parent
{
    protected double Pole1; // всього місць
    protected double Pole2; // з них зайнято
    protected double Pole3; // з них вільно

    // Конструктор з одним параметром
    public Parent(double totalrooms)
    {
        this.Pole1 = totalrooms;
        this.Pole2 = 0;
        this.Pole3 = totalrooms;
    }

    // Метод для виведення значень полів
    public void Print()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Всього місць = {0}, Зайнято = {1}, Вільно = {2}", Pole1, Pole2, Pole3);
    }

    // Поселити одну людину в готель
    public bool Metod1()
    {
        if (Pole3 > 0)
        {
            Pole2++;
            Pole3--;
            return true; // Якщо місця є
        }
        return false; // Якщо місць немає
    }

    // Виселити одну людину з готелю. 
    public bool Metod2()
    {
        if (Pole2 > 0)
        {
            Pole2--;
            Pole3++;
            return true; // Готель не порожній (людина успішно виселилася)
        }
        return false; // Якщо готель порожній
    }
}


class Child : Parent
{
    double Pole4; // Кількість лікарів

    // Конструктор з одним параметром
    public Child (double totalrooms) : base(totalrooms)
    {
        Pole4 = 0;
    }

    // Метод для виведення значень полів
    new public void Print()
    {
        base.Print();
        Console.WriteLine("Кількість лікарів: {0}", Pole4);
    }

    // Метод для обчислення кількості лікарів
    public void Metod3()
    {
        Pole4 = Math.Ceiling(Pole2 / 3) + 1;
    }
}

class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("         Готель");
        Console.WriteLine("-------------------------");

        Parent hotel = new Parent(5);
        hotel.Print();

        Random o = new Random();
        int arrived = o.Next(1, 7);
        Console.WriteLine("Приїхало в готель {0} людей", arrived);
        for (int i = 0; i < arrived; i++)
        {
            if (hotel.Metod1())
            {
                Console.WriteLine("Гість заселився в № {0}", i + 1);
            }
            else
            {
                Console.WriteLine("Вільних місць більше немає");
            }
        }
        hotel.Print();

        int left = o.Next(1, arrived + 1);
        Console.WriteLine("Виїжджає з готелю {0} людей", left);
        for (int i = 0; i < left; i++)
        {
            if (hotel.Metod2())
            {
                Console.WriteLine("Виїхав гість з № {0}", i + 1);
            }
            else
            {
                Console.WriteLine("Готель порожній");
            }
        }
        hotel.Print();
        

        Console.WriteLine("-------------------------");
        Console.WriteLine("        Санаторій");
        Console.WriteLine("-------------------------");

        Child sanatorium = new Child(5);
        sanatorium.Print();


        Random s = new Random();
        int arrived1 = s.Next(1, 7);
        Console.WriteLine("Приїхало в санаторій {0} людей", arrived1);
        for (int i = 0; i < arrived1; i++)
        {
            if (sanatorium.Metod1())
            {
                Console.WriteLine("Гість заселився в № {0}", i + 1);
            }
            else
            {
                Console.WriteLine("Вільних місць більше немає");
            }
        }
        sanatorium.Metod3();
        sanatorium.Print();

        int left1 = s.Next(1, arrived1 + 1);
        Console.WriteLine("Виїжджає з готелю {0} людей", left1);
        for (int i = 0; i < left1; i++)
        {
            if (sanatorium.Metod2())
            {
                Console.WriteLine("Виїхав гість з № {0}", i + 1);
            }
            else
            {
                Console.WriteLine("Санаторій порожній");
            }
        }
        sanatorium.Metod3();
        sanatorium.Print();
    }
}