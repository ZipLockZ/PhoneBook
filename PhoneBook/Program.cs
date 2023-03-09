namespace Module14_PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortedContact = from contact in phoneBook
                                orderby contact.Name, contact.LastName
                                select contact;

            foreach (var contact in sortedContact)
            {
                Console.WriteLine(contact.Name + " " + contact.LastName);
            }

            while (true)
            {
                
                var input = Console.ReadKey().KeyChar;

                
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                
                else
                {
                    
                    var pageContent = sortedContact.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
        }

        public class Contact 
        {
            public Contact(string name, string lastName, long phoneNumber, String email) 
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}