using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManagement
{
    public static List<Book> bookList = new List<Book>();

    public FileManagement()
    {
        //Book firstBook = new Book("1234");
        //bookList.Add(firstBook);
        //UpdateBookFile(bookList);

        //foreach (Book books in bookList)
        //{
        //    Console.WriteLine($"{books.Id}");
        //}
    }

    // file 읽기 : .dat file에서 데이터를 불러와 list에 저장
    public static List<Book> LoadBookFile(List<Book> bookList)
    {
        Stream ws;
        FileInfo fileBookInfo = new FileInfo("bookInfomation.dat");

        if (fileBookInfo.Exists)   // dat file이 존재한다면
        {
            Stream rs = new FileStream("bookInfomation.dat", FileMode.Open); //일단 불러온다.
            BinaryFormatter deserializer = new BinaryFormatter();
            bookList = (List<Book>)deserializer.Deserialize(rs);       //역직렬화,리스트에 저장함.
            rs.Close();
        }

        return bookList;
    }

    // file 쓰기 : list에 저장된 데이터를 .dat file에 저장
    public void UpdateBookFile(List<Book> bookList)
    {
        Stream ws;
        FileInfo fileBookInfo = new FileInfo("bookInfomation.dat");

        if (!fileBookInfo.Exists)       //파일이 없을경우, 생성
        {
            ws = new FileStream("bookInfomation.dat", FileMode.Create);
            ws.Close();
        }

        // 리스트를 새로 업데이트 
        ws = new FileStream("bookInfomation.dat", FileMode.Open);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(ws, bookList);     //직렬화(저장)
        ws.Close();

    }

    // file 초기화: .dat file을 직접 만들어야 해서, 한 번 사용하고 주석 처리할 예정.
    // 메소드: 객체 생성 -> 리스트 생성 -> dat file 생성
    //public void initializeBookFile()
    //{
    //    // 객체 생성
    //    Book firstBook = new Book("1234");
    //    Book secondBook = new Book("5678");

    //    // 리스트 생성
    //    bookList.Add(firstBook);
    //    bookList.Add(secondBook);

    //    // dat file 생성
    //    UpdateBookFile(bookList);
    //}
}
