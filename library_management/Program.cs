using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        FileManagement file = new FileManagement();

        // 처음 bookInformation.dat 파일 만들때 사용
        // file.initializeBookFile();

        FileManagement.bookList = file.LoadBookFile(FileManagement.bookList);

        foreach (Book books in FileManagement.bookList)
        {
            Console.WriteLine($"After {books.Id}");
        }

        //User user = new User();
        //Book book = new Book();
        //bool a = user.SearchForID(FileManagement.bookList);
        //bool b = book.SearchForID(FileManagement.userList);
        //Console.WriteLine($"{a},{b}");

        UI ui = new UI();

        ui.View_1_1_1();
    }
    
}
