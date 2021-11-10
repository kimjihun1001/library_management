using System;
using System.Collections.Generic;

[Serializable]
public class DataProcessing : FileManagement
{
    public static User currentUser;

    public static List<Book> searchedBookList = new List<Book>();
    public static List<User> searchedUserList = new List<User>();

    public DataProcessing()
    {
    }

    // 검색
    // 책 이름 
    public void SearchForName(List<Book> list, string input)
    {
        int i = 0;
        foreach (Book book in list)
        {
            if (book.Name.Contains(input))
            {
                i++;
                book.Number = i;
                searchedBookList.Add(book);
            }
        }
    }

    // 회원 이름  
    public void SearchForName(List<User> list, string input)
    {
        int i = 0;
        foreach (User user in list)
        {
            if (user.Name.Contains(input))
            {
                i++;
                user.Number = i;
                searchedUserList.Add(user);
            }
        }
    }

    // 책 출판사 
    public void SearchForPublisher(List<Book> list, string input)
    {
        int i = 0;
        foreach (Book book in list)
        {
            if (book.Publisher.Contains(input))
            {
                i++;
                book.Number = i;
                searchedBookList.Add(book);
            }
        }
    }

    // 책 저자명 
    public void SearchForAuthor(List<Book> list, string input)
    {
        int i = 0;
        foreach (Book book in list)
        {
            if (book.Author.Contains(input))
            {
                i++;
                book.Number = i;
                searchedBookList.Add(book);
            }
        }
    }

    // 책 대출 
    public void BorrowBook(string input)
    {
        foreach (Book book in searchedBookList)
        {
            if (book.Id == input)
            {
                if (book.Quantity == 0)
                {
                    Console.WriteLine("대출 가능한 책이 없습니다.");
                }
                else
                {
                    currentUser.BorrowedBook.Add(book);
                    book.Quantity--;
                    Console.WriteLine($"<{book.Name}> 대출 완료했습니다.");
                }
            }
        }
    }

    // 책 반납
    public void ReturnBook(string input)
    {
        foreach (Book book in currentUser.BorrowedBook)
        {
            if (book.Id == input)
            {
                currentUser.BorrowedBook.Remove(book);
                book.Quantity++;
                Console.WriteLine($"<{book.Name}> 반납 완료했습니다.");
            }
            else
            {
                Console.WriteLine("잘못 입력했습니다.");
            }
        }
    }


    // 로그인 확인 과정
    // 아이디 
    public bool CheckUserID(string id)
    {
        bool IsIDChecked = false;
        foreach (User user in userList)
        {
            if (user.Id == id)
            {
                IsIDChecked = true;
            }
        }

        if (IsIDChecked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // 로그인 확인 과정
    // 비밀번호 
    public bool CheckUserPassword(string password)
    {
        bool IsPasswordChecked = false;
        foreach (User user in userList)
        {
            if (user.Password == password)
            {
                IsPasswordChecked = true;
                currentUser = user;
            }
        }

        if (IsPasswordChecked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 책의 총 권수 계산
    public int SumQuantityOfBooks(List<Book> list)
    {
        int totalQuantity = 0;
        foreach (Book book in list)
        {
            totalQuantity += book.Quantity;
        }
        return totalQuantity;
    }
}
