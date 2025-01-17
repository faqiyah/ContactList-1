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

            Console.Write("Enter option: ");
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
                        
                        char[] check = name.ToCharArray();
                          char[] specialChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '{', '}', '[', ']', '|', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/', '`', '~' };
                        for (int i = 0; i < name.Length; i++)
                        {
                            if (specialChar.Contains(name[i]))
                            {
                                Console.WriteLine("Invalid name. Name must not contain special characters: ");
                                name = Console.ReadLine()!;
                            }
                        }

                        while (!(name.Length <= 3))
                        {
                            Console.Write("Invalid name. Name must be more than 3 characters: ");
                            name = Console.ReadLine()!;
                        }
                        
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine()!;
                        char[] checkphone = phoneNumber.ToCharArray();
                        specialChar = new char[]{ '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '{', '}', '[', ']', '|', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/', '`', '~' };
                        for (int i = 0; i < phoneNumber.Length; i++)
                        {
                            if (specialChar.Contains(phoneNumber[i]))
                            {
                                Console.WriteLine("Invalid phone number. Phone number must not contain special characters: ");
                                phoneNumber = Console.ReadLine()!;
                            }
                        }

                        while (!(phoneNumber.Length == 11))
                        {
                            Console.Write("Invalid Phone number. Phone number should be 11 digits: ");
                            phoneNumber = Console.ReadLine()!;
                        }
                        Console.Write("Enter email: ");
                        string? email = Console.ReadLine();
                        _contactManager.AddContact(name, phoneNumber, email);
                        break;


                    case 2:
                        Console.Write("Enter the ID of contact: ");
                        int id = int.Parse(Console.ReadLine()!);
                        _contactManager.SearchContactById(id);
                        break;

                    case 3:
                        Console.Write("Enter the phone number of contact: ");
                        string number = Console.ReadLine()!;
                        _contactManager.SearchContactByPhoneNumber(number);
                        break;

                    case 4:
                        Console.Write("Enter the ID of contact: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter contact name: ");
                        string updatedName = Console.ReadLine()!;
                        while(updatedName.Length <= 3)
                        {
                            Console.Write("Invalid name. name must be more than 3 characters: ");
                            updatedName = Console.ReadLine()!;
                        }
                        specialChar = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '{', '}', '[', ']', '|', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/', '`', '~' };
                        for (int i = 0; i < updatedName.Length; i++)
                        {
                            if (specialChar.Contains(updatedName[i]))
                            {
                                Console.Write("Invalid phone number. name must not contain special characters: ");
                                updatedName = Console.ReadLine()!;
                            }
                        }
            
                        Console.Write("Enter phone number: ");
                        string updatedPhoneNumber = Console.ReadLine()!;
                        checkphone = updatedPhoneNumber.ToCharArray();
                        specialChar = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '{', '}', '[', ']', '|', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/', '`', '~' };
                        for (int i = 0; i < updatedPhoneNumber.Length; i++)
                        {
                            if (specialChar.Contains(updatedPhoneNumber[i]))
                            {
                                Console.Write("Invalid phone number. Phone number must not contain special characters: ");
                                updatedPhoneNumber = Console.ReadLine()!;
                            }
                        }

                        while (!(updatedPhoneNumber.Length == 11))
                        {
                            Console.Write("Invalid Phone number. Phone number should be 11 digits: ");
                            updatedPhoneNumber = Console.ReadLine()!;
                        }

                        Console.Write("Enter email: ");
                        string? updatedEmail = Console.ReadLine();
                        Console.Write("Enter the ContactType you want: ");
                        string EnterType = Console.ReadLine()!;
                         ContactType UserContactType = (ContactType)Enum.Parse(typeof(ContactType), EnterType);
                        _contactManager.UpdateContact(updateId, updatedName, updatedPhoneNumber, updatedEmail, null, null, UserContactType);
                        break;

                    case 5:
                        _contactManager.ListAllContacts();
                        break;

                    case 6:
                        Console.Write("Enter the ID of contact: ");
                        int deleteId = int.Parse(Console.ReadLine()!);
                        _contactManager.DeleteContact(deleteId);
                        break;

                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }
        }
    }

    private void ToCharArray()
    {
        throw new NotImplementedException();
    }

    private static void PrintContactMenu()
    {
        Console.WriteLine("Enter 1 to Add new contact");
        Console.WriteLine("Enter 2 to Search contact by ID");
        Console.WriteLine("Enter 3 to Search contact by phone number");
        Console.WriteLine("Enter 4 to Update contact");
        Console.WriteLine("Enter 5 to Display all contacts");
        Console.WriteLine("Enter 6 to Delete contact");
        Console.WriteLine("Enter 0 to Exit");
    }
}
