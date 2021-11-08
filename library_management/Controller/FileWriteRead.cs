using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class FileWriteRead
{
    public static List<Book> book = new List<Book>();
    public static List<BookVO> bookList = new List<BookVO>();
    public string text;

    public FileWriteRead()
    {
        //Book firstBook = new Book("1234");
        //book.Add(firstBook);
        //UpdataBookData(book);

        // file 읽기
        Stream ws;
        FileInfo fileBookInfo = new FileInfo("bookInfomation.dat");

        if (!fileBookInfo.Exists)       //파일이 없을경우
        {
            ws = new FileStream("bookInfomation.dat", FileMode.Create);
            ws.Close();
        }
        else
        {
            if (fileBookInfo.Length != 0)   //기존의 데이타를 가지고 있다면.
            {
                Stream rs = new FileStream("bookInfomation.dat", FileMode.Open); //일단 불러온다.
                BinaryFormatter deserializer = new BinaryFormatter();
                //bookList = (List<BookVO>)deserializer.Deserialize(rs);       //역직렬화,리스트에 저장함.
                var text = deserializer.Deserialize(rs);
                rs.Close();
            }
        }

        Console.WriteLine(text.ToString());

        foreach (BookVO books in bookList)
        {
            Console.WriteLine($"{books.BookIDNumber}");
        }
    }



    //file 쓰기

    public void UpdataBookData(List<Book> bookList)
    {
        Stream ws = new FileStream("bookInfomation.dat", FileMode.Create);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(ws, bookList);     //직렬화(저장)
        ws.Close();
    }

}
