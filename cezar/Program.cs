using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

        string cesar;
        int step;

        Console.WriteLine("Введите сообщение, которое будет закодировано: ");
    inputstr:
        cesar = Console.ReadLine();
        for (int i = 0; i < cesar.Length; i++)
        {
            if (cesar[i] < 32 || cesar[i] > 126 || cesar[i] < 0)
            {
                Console.WriteLine("Ошибка в вводе сообщения, попробуйте снова.");
                goto inputstr;
            }
        }

        Console.WriteLine("Введите шаг кодировки: ");
    inputstep:
        if (!int.TryParse(Console.ReadLine(), out step))
        {
            Console.WriteLine("Ошибка в вводе шага кодировки, попробуйте снова.");
            goto inputstep;
        }

        char[] cesarArray = cesar.ToCharArray();
        for (int i = 0; i < cesarArray.Length; i++)
        {
            if ((cesarArray[i] >= 'A' && cesarArray[i] <= 'Z') || (cesarArray[i] >= 'a' && cesarArray[i] <= 'z'))
            {
                cesarArray[i] = (char)(cesarArray[i] + step);
                if (cesarArray[i] > 'Z' && cesarArray[i] < 'a')
                {
                    cesarArray[i] = (char)((cesarArray[i] - 'Z') + 'A' - 1);
                }
                if (cesarArray[i] > 'z')
                {
                    cesarArray[i] = (char)((cesarArray[i] - 'z') + 'a' - 1);
                }
            }
        }

        cesar = new string(cesarArray);
        Console.WriteLine(cesar);
    }
}