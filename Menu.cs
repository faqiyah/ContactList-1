using System;

namespace ContactList;

public class Menu
{
    private readonly IContactManager _contactManager;

    public Menu()
    {
        _contactManager = new ContactManager();
    }

    public void ContactMenu()
    {
        bool exit = false;

        while (!exit)
        {
            PrintContactMenu();

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 0:
                        exit = true;
                        break;

                    case 1:
                        Console.Write("Enter contact name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine()!;
                        Console.Write("Enter email: ");
                        string? email = Console.ReadLine();
                        _contactManager.AddContact(name, phoneNumber, email);
                        break;

                    case 5:
                        _contactManager.GetContacts();
                        break;

                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }
        }
    }

    private static void PrintContactMenu()
    {
        Console.WriteLine("Enter 1 to Add new contact");
        Console.WriteLine("Enter 2 to Search contact");
        Console.WriteLine("Enter 3 to Delete contact");
        Console.WriteLine("Enter 4 to Update contact");
        Console.WriteLine("Enter 5 to Display all contacts");
        Console.WriteLine("Enter 0 to Exit");
    }
}
