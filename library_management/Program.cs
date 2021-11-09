using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        FileManagement file = new FileManagement();
        //file.initializeBookFile();

        //file.UpdateBookFile(FileManagement.bookList);
        //foreach (Book book in FileManagement.bookList)
        //{
        //    Console.WriteLine($"Before {book.Id}");
        //}

        FileManagement.bookList = FileManagement.LoadBookFile(FileManagement.bookList);

        foreach (Book book in FileManagement.bookList)
        {
            Console.WriteLine($"After {book.Id}");
        }
    }


}
