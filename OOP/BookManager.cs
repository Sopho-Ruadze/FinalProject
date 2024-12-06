using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    internal class BookManager
    {

        public class Book
        {


            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime PublishDate { get; set; }
            public int ID { get; set; }



            public Book(string title, string author, DateTime publishDate, int id)
            {
                Title = title;
                Author = author;
                PublishDate = publishDate;
                ID = id;
            }



            public override string ToString()
            {
                return $"ID: {ID}, Title: {Title}, Author: {Author}, Publish Date: {PublishDate.ToShortDateString()}";
            }
        }



        public class BookManager
        {


            private List<Book> books = new List<Book>();



            public void AddBook()
            {
                Console.WriteLine("\n--- Add New Book ---");



                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty!");
                    return;
                }



                Console.Write("Enter Author: ");
                string author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Author cannot be empty!");
                    return;
                }



                Console.Write("Enter Publish Date (yyyy-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime publishDate))
                {
                    Console.WriteLine("Invalid date format!");
                    return;
                }



                Console.Write("Enter ID (unique): ");
                if (!int.TryParse(Console.ReadLine(), out int id) || books.Any(b => b.ID == id))
                {
                    Console.WriteLine("ID must be a unique integer!");
                    return;
                }



                books.Add(new Book(title, author, publishDate, id));
                Console.WriteLine("Book added successfully!");
            }



            public void ViewAllBooks()
            {
                Console.WriteLine("\n--- All Books ---");
                if (books.Count == 0)
                {
                    Console.WriteLine("No books available.");
                    return;
                }

                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }



            public void SearchBookById()
            {
                Console.Write("\nEnter Book ID to Search: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID format!");
                    return;
                }

                var book = books.FirstOrDefault(b => b.ID == id);
                if (book != null)
                {
                    Console.WriteLine("Book Found:");
                    Console.WriteLine(book);
                }
                else
                {
                    Console.WriteLine("No book found with the given ID.");
                }
            }
        }
        static void Main(string[] args)
        {
            BookManager manager = new BookManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Book Management System ---");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        manager.AddBook();
                        break;
                    case "2":
                        manager.ViewAllBooks();
                        break;
                    case "3":
                        manager.SearchBookById();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }

    }


}




