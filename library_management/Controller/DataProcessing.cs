using System;
using System.Collections.Generic;

[Serializable]
public class DataProcessing
{
    public static List<Book> searchedBookList = new List<Book>();
    public static List<User> searchedUserList = new List<User>();

    public DataProcessing()
    {
    }

    public void SearchForName(List<Book> list, string input)
    {
        foreach (Book book in list)
        {
            if (book.Name.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }

}
