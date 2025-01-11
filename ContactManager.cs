namespace ContactList;

public class ContactManager : IContactManager
{
    private readonly List<Contact> Contacts;

    public ContactManager()
    {
        Contacts = [];
    }

    public void AddContact(string name, string phoneNumber, string? email)
    {
        int id = Contacts.Count > 0 ? Contacts.Count + 1 : 1;
        bool contactAlreadyExist = IsContactExist(phoneNumber);

        if (contactAlreadyExist)
        {
            Console.WriteLine($"Contact with {phoneNumber} already exist!");
            return;
        }

        var contact = new Contact
        {
            Id = id,
            Name = name,
            MobileNumber = phoneNumber,
            Email = email,
            CreatedAt = DateTime.Now
        };

        Contacts.Add(contact);
        Console.WriteLine($"Contact with name {contact.Name} and id {contact.Id} successfully created!");
        Console.WriteLine();
    }

    public void DeleteContact(int id)
    {
        throw new NotImplementedException();
    }

    public void GetContact()
    {
        throw new NotImplementedException();
    }

    public void GetContacts()
    {
        if (Contacts.Count == 0)
        {
            Console.WriteLine("There is no contact in the record yet!. Add a new contact");
            return;
        }

        foreach(var contact in Contacts)
        {
            var contactData = $"Id: {contact.Id}\tName {contact.Name}\tPhone: {contact.MobileNumber}\tEmail: {contact.Email}\tCreated: {contact.CreatedAt}";

            Console.WriteLine(contactData);   
        } 

        Console.WriteLine();
    }

    public Contact SearchContactById(int id)
    {
        throw new NotImplementedException();
    }

    public Contact SearchContactByName(string name)
    {
        throw new NotImplementedException();
    }

    public Contact SearchContactByPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public void UpdateContact(int id, string name, string phoneNumber, string? alternatePhone, string? workPhone, string? email, ContactType? contactType)
    {
        throw new NotImplementedException();
    }

    private bool IsContactExist(string phoneNumber)
    {
        return Contacts.Any(c => c.MobileNumber == phoneNumber);
    }
}
