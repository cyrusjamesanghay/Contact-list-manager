using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_list_manager
{
    internal class Contact_list_manager
    {
        class Contact
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        }

        class Program
        {
            static List<Contact> contactList = new List<Contact>();

            static void Main(string[] args)
            {
                bool running = true;

                while (running)
                {
                    Console.WriteLine("=== Contact Manager ===");
                    Console.WriteLine("1. Add Contact");
                    Console.WriteLine("2. View Contacts");
                    Console.WriteLine("3. Update Contact");
                    Console.WriteLine("4. Delete Contact");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            AddContact();
                            break;
                        case "2":
                            ViewContacts();
                            break;
                        case "3":
                            UpdateContact();
                            break;
                        case "4":
                            DeleteContact();
                            break;
                        case "5":
                            running = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    Console.WriteLine(); // Space between actions
                }
            }

            static void AddContact()
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine();

                // Check if the phone number already exists in the contact list
                bool duplicateExists = contactList.Exists(c => c.PhoneNumber.Equals(phone));

                if (duplicateExists)
                {
                    Console.WriteLine("Error: A contact with this Phone Number already exists.");
                    return; // Exit the method to prevent adding the duplicate contact
                }

                Console.Write("Enter Address: ");
                string address = Console.ReadLine();

                // If no duplicate phone number, add the new contact
                Contact newContact = new Contact
                {
                    Name = name,
                    PhoneNumber = phone,
                    Address = address
                };

                contactList.Add(newContact);
                Console.WriteLine("Contact added successfully!");
            }


            static void ViewContacts()
            {
                Console.WriteLine("=== Contact List ===");

                if (contactList.Count == 0)
                {
                    Console.WriteLine("No contacts found.");
                    return;
                }

                for (int i = 0; i < contactList.Count; i++)
                {
                    Contact c = contactList[i];
                    Console.WriteLine($"[{i + 1}] Name: {c.Name}, Phone: {c.PhoneNumber}, Address: {c.Address}");
                }
            }

            static void UpdateContact()
            {
                ViewContacts();

                if (contactList.Count == 0)
                    return;

                Console.Write("Enter the number of the contact to update: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= contactList.Count)
                {
                    Contact contactToUpdate = contactList[index - 1];

                    Console.WriteLine("Leave blank to keep the current value.");

                    Console.Write($"New Name (current: {contactToUpdate.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        contactToUpdate.Name = newName;

                    Console.Write($"New Phone Number (current: {contactToUpdate.PhoneNumber}): ");
                    string newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone))
                        contactToUpdate.PhoneNumber = newPhone;

                    Console.Write($"New Address (current: {contactToUpdate.Address}): ");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress))
                        contactToUpdate.Address = newAddress;

                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid contact number.");
                }
            }

            static void DeleteContact()
            {
                ViewContacts();

                if (contactList.Count == 0)
                    return;

                Console.Write("Enter the number of the contact to delete: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= contactList.Count)
                {
                    Contact contactToDelete = contactList[index - 1];
                    contactList.Remove(contactToDelete);
                    Console.WriteLine($"Contact '{contactToDelete.Name}' deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid contact number.");
                }
            }
        }
    }
}
