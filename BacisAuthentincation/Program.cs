namespace BasicAuthentincation;

class Program
{
    static void Main()
    {
        string input;

        tampilan_awal();
        Console.Write("Input : ");
        input = Console.ReadLine();

        Console.WriteLine(input);
    }

    static void tampilan_awal()
    {
        Console.WriteLine("==BASIC AUTHENTICATION==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Exit");
    }
}