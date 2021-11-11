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
    public void SearchBookForName(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Name.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }
    // 검색
    // 회원 이름  
    public void SearchUserForName(string input)
    {
        foreach (User user in userList)
        {
            if (user.Name.Contains(input))
            {
                searchedUserList.Add(user);
            }
        }
    }
    // 검색
    // 책 출판사 
    public void SearchForPublisher(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Publisher.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }
    // 검색
    // 책 저자명 
    public void SearchForAuthor(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Author.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }

    // 삭제
    // 도서
    public void RemoveBook(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Id == input)
            {
                bookList.Remove(book);
                UpdateBookFile(bookList);
                Console.WriteLine($"<{book.Name}>이 도서 리스트에서 삭제되었습니다.");
            }
        }
    }
    // 삭제
    // 회원
    public void RemoveUser(string input)
    {
        foreach (User user in userList)
        {
            if (user.Id == input)
            {
                userList.Remove(user);
                UpdateUserFile(userList);
                Console.WriteLine($"<{user.Name}>이 회원 리스트에서 삭제되었습니다.");
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
                    HistoryOfBorrow(book);
                    UpdateBookFile(bookList);
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
                HistoryOfReturn(book);
                UpdateBookFile(bookList);
                Console.WriteLine($"<{book.Name}> 반납 완료했습니다.");
            }
            else
            {
                Console.WriteLine("잘못 입력했습니다.");
            }
        }
    }

    // 도서 대출 기록
    public void HistoryOfBorrow(Book book)
    {
        BookHistory bookHistory = new BookHistory(currentUser.Name, book.Name);
        bookHistory.BorrowTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        bookHistoryList.Add(bookHistory);
    }

    // 도서 반납 기록
    public void HistoryOfReturn(Book book)
    {
        BookHistory bookHistory = new BookHistory(currentUser.Name, book.Name);
        bookHistory.ReturnTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        bookHistoryList.Add(bookHistory);
    }

    // 신규 책 등록
    public void AddNewBook(string id, string name, string publisher, string author, string price, int quantity)
    {
        Book book= new Book(id, name, publisher, author, price, quantity);
        bookList.Add(book);
        UpdateBookFile(bookList);
    }

    // 신규 회원 등록
    public void AddNewUser(string id, string password, string name, int age, string phoneNumber, string address)
    {
        User user = new User(id, password, name, age, phoneNumber, address);
        userList.Add(user);
        UpdateUserFile(userList);
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
