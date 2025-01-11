namespace ContactList;

public interface IContactManager
{
    void AddContact(string name, string phoneNumber, string? email);

    Contact SearchContactById(int id);

    Contact SearchContactByName(string name);

    Contact SearchContactByPhoneNumber(string phoneNumber);

    void GetContact();

    void GetContacts();

    void UpdateContact(int id, string name, string phoneNumber, string? alternatePhone, string? workPhone, string? email, ContactType? contactType);

    void DeleteContact(int id);
}
