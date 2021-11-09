using System;

public class UI : DataProcessing
{
    public UI()
    {
    }

    public void View_Title()
    {
        Console.WriteLine("LIBRARY");
    }

    public void View_1_1_1()    // 책 이름으로 검색
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 이름을 입력하세요: ");

            // 입력받는 메소드 만들기
            string input = "가";

            // 예외처리하는 메소드 만들기

            // 검색 리스트 생성
            SearchForName(FileManagement.bookList, input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_SearchedBookList();
            }
        }
    }

    public void View_SearchedBookList()
    {
        foreach (Book book in searchedBookList)
        {
            Console.WriteLine(book.Name);
        }
    }

}
