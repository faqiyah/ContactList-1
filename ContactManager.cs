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
        var contact = Contacts.Find(x => x.Id == id);

        if (contact is null)
        {
            Console.WriteLine("Contact you are trying to delete does not exist!");
            return;
        }

        bool isRemoved = Contacts.Remove(contact);

        string result = isRemoved 
            ? "Contact removed successfully!" 
            : "Unable to remove contact!";

        Console.WriteLine(result);
        Console.WriteLine();
    }

    public void ListAllContacts()
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

    public void SearchContactById(int id) 
    {
        var contact = Contacts.Find(x => x.Id == id);

        if (contact is null)
        {
            Console.WriteLine("Contact does not exist!");
            return;
        }

        var result = $"""
        =====CONTACT DETAILS=====
        Name: {contact.Name}
        Mobile Number: {contact.MobileNumber}
        Email: {contact.Email ?? "N/A"}
        Alternate Mobile: {contact.AlternateMobileNumber ?? "N/A"}
        Work Number: {contact.WorkNumber ?? "N/A"}
        Contact Type: {contact.ContactType}
        """;

        Console.WriteLine(result);
        Console.WriteLine();
    }

    public void SearchContactByPhoneNumber(string mobileNumber)
    {
        var contact = Contacts.Find(x => x.MobileNumber == mobileNumber);

        if (contact is null)
        {
            Console.WriteLine("Contact does not exist!");
            return;
        }

        var result = $"""
        =====CONTACT DETAILS=====
        Name: {contact.Name}
        Mobile Number: {contact.MobileNumber}
        Email: {contact.Email ?? "N/A"}
        Alternate Mobile: {contact.AlternateMobileNumber ?? "N/A"}
        Work Number: {contact.WorkNumber ?? "N/A"}
        Contact Type: {contact.ContactType}
        """;

        Console.WriteLine(result);
    }

    public void UpdateContact(int id, string name, string mobileNumber, string? email, string? alternatePhone, string? workPhone, ContactType? contactType)
    {
        var contact = Contacts.Find(x => x.Id == id);

        if (contact is null)
        {
            Console.WriteLine("Contact you are trying to edit does not exist!");
            return;
        }

        contact.Name = name;
        contact.MobileNumber = mobileNumber;
        contact.Email = email ?? null;
        contact.AlternateMobileNumber = alternatePhone ?? null;
        contact.WorkNumber = workPhone ?? null;
        contact.ContactType = contactType ?? null;

        Console.WriteLine("Contact was updated successfully!");
        Console.WriteLine();
    }

    private bool IsContactExist(string phoneNumber)
    {
        return Contacts.Any(c => c.MobileNumber == phoneNumber);
    }

    private bool IsContactExist(int id)
    {
        return Contacts.Any(c => c.Id == id);
    }
}
