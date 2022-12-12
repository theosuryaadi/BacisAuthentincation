using System.Collections.Generic;

namespace BasicAuthentincation;

class Program
{
    static void Main()
    {
        string[] first_name = { };
        string[] last_name = { };
        string[] full_name = { };
        string[] username = { };
        string[] password = { };
        string[] data_user = { };



    awal:
        tampilan_awal();
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Clear();
                string first, last, pass;
                char[] uname1 = { };
                char[] uname2 = { };
                bool cek_password = true;
                bool cek_name = true;

                do
                {
                    Console.Write("First Name: ");
                    first = Console.ReadLine();

                    if (first.Length < 2)
                    {
                        Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
                        cek_name = true;
                    }
                    else
                    {
                        cek_name = false;
                    }

                } while (cek_name);


                do
                {
                    Console.Write("Last Name: ");
                    last = Console.ReadLine();

                    if (last.Length < 2)
                    {
                        Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
                        cek_name = true;
                    }
                    else
                    {
                        cek_name = false;
                    }

                } while (cek_name);

                do
                {
                    Console.Write("Password: ");
                    pass = Console.ReadLine();

                    if (pass.Length > 8 && pass.Any(Char.IsUpper) && pass.Any(Char.IsLower))
                    {
                        Console.WriteLine("\nUser Success to Created!!!");
                        cek_password = false;
                    }
                    else
                    {
                        Console.WriteLine("\nPassword must have at least 8 characters\nwith at least one Capital letter, at least one lower case letter and at least one number.");
                    }

                } while (cek_password);

                uname1 = first.ToCharArray();
                uname2 = last.ToCharArray();
                username = username.Append("" + uname1[0] + uname1[1] + uname2[0] + uname2[1]).ToArray();

                first_name = first_name.Append(first).ToArray();
                last_name = last_name.Append(last).ToArray();
                full_name = full_name.Append(first + " " + last).ToArray();
                password = password.Append(pass).ToArray();

                Console.ReadKey();
                goto awal;
                break;
            case "2":
                show_user(full_name, username, password);
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        goto awal;
                        break;
                    default:
                        wrong_input();
                        break;
                }

                //Console.ReadKey();
                break;
            case "3":
                search_user(full_name, username, password);

                Console.ReadKey();
                goto awal;
                break;
            case "4":
                login(username, password);

                Console.ReadKey();
                goto awal;
                break;
            case "5":
                Environment.Exit(1);// exit
                break;
            default:
                wrong_input();
                break;
        }

    }

    static void tampilan_awal()
    {
        Console.Clear();
        Console.WriteLine("==BASIC AUTHENTICATION==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Exit");
        Console.Write("Input : ");

    }

    static void show_user(string[] fullname, string[] uname, string[] pass)
    {
        Console.Clear();
        Console.WriteLine("==SHOW USER==");

        if (!uname.Any())
        {
            Console.WriteLine("Empty Data\n");
        }
        else
        {
            for (int i = 0; i < uname.Length; i++)
            {
                Console.WriteLine("========================");
                Console.WriteLine("ID        : {0}", i + 1);
                Console.WriteLine("Name      : {0}", fullname[i]);
                Console.WriteLine("Username  : {0}", uname[i]);
                Console.WriteLine("Password  : {0}", pass[i]);
                Console.WriteLine("========================");

            }

        }

        Console.WriteLine("\nMenu");
        Console.WriteLine("1. Edit User");
        Console.WriteLine("2. Delete User");
        Console.WriteLine("3. Back");

    }

    static void search_user(string[] fullname, string[] uname, string[] pass)
    {
        Console.Clear();
        string nama = "";
        int[] indexs = { };
        int index;


        Console.WriteLine("== Cari Akun ==");
        Console.Write("Masukan Nama : ");
        string input_nama = Console.ReadLine();
        
        for(int i=0; i < fullname.Length; i++)
        {
            nama = Array.Find(fullname, n => n.Contains(input_nama));
            index = Array.IndexOf(fullname, nama);
            if(index != -1)
            {
                indexs = indexs.Append(index).ToArray();
            }

        }

        if(indexs.Length > 0)
        {
            for(int i=0; i<indexs.Length; i++)
            {
                Console.WriteLine("========================");
                Console.WriteLine("ID        : {0}", i + 1);
                Console.WriteLine("Name      : {0}", fullname[i]);
                Console.WriteLine("Username  : {0}", uname[i]);
                Console.WriteLine("Password  : {0}", pass[i]);
                Console.WriteLine("========================");
            }

        }

    }


    static void login(string[] username, string[] password)
    {
        string uname, pass;

        Console.Clear();
        Console.WriteLine("==LOGIN==");

        if(!username.Any() && !password.Any())
        {
            Console.WriteLine("MESSAGE: Empty Data");
        }
        else
        {
            Console.Write("USERNAME: ");
            uname = Console.ReadLine();
            Console.Write("PASSWORD: ");
            pass = Console.ReadLine();

            for(int i=0; i<username.Length; i++)
            {
                if(uname == username[i] && pass == password[i])
                {
                    Console.WriteLine("MESSAGE: Login Berhasil!!!");
                }
                else
                {
                    Console.WriteLine("MESSAGE: Username atau Password Tidak Ditemukan");
                }
            }

        }

    }

    //Method Untuk Tampilan Salah Input
    static void wrong_input()
    {
        Console.Clear();
        Console.WriteLine("Maaf, Input Tidak Sesuai\nSilahkan Run Ulang...");
    }

}