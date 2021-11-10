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
        //file.initializeBookFile();

        FileManagement.bookList = file.LoadBookFile(FileManagement.bookList);

        foreach (Book books in FileManagement.bookList)
        {
            Console.WriteLine($"After {books.Id}");
        }

        UI ui = new UI();

        User user = new User();

        FileManagement.userList = user.LoadUserFile(FileManagement.userList);
        foreach (User users in FileManagement.userList)
        {
            Console.WriteLine($"After {users.Id}");
        }

        ui.View_1_4();
        //ui.View_Main();

        //user.BorrowBook("");


    }
    
}
