using System;
using System.Collections.Generic;

public class UI : DataProcessing
{
    public UI()
    {
    }

    // 책 리스트 출력 메소드
    // 파라미터로 원하는 리스트 넣기 
    public void View_BookList(List<Book> list)
    {
        foreach (Book book in list)
        {
            Console.WriteLine($"책 ID: {book.Id}");
            Console.WriteLine($"책 이름: {book.Name}");
            Console.WriteLine($"책 출판사: {book.Publisher}");
            Console.WriteLine($"책 저자: {book.Author}");
            Console.WriteLine($"책 가격: {book.Price}");
            Console.WriteLine($"책 수량: {book.Quantity}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    // 회원 리스트 출력 메소드
    public void View_UserList(List<User> list)
    {
        foreach (User user in list)
        {
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"이름: {user.Name}");
            Console.WriteLine($"나이: {user.Age}");
            Console.WriteLine($"전화 번호: {user.PhoneNumber}");
            Console.WriteLine($"주소: {user.Address}");
            Console.WriteLine($"대출한 책: {user.BorrowedBook.Count}권");
            Console.WriteLine($"대출한 책 리스트");
            View_BookList(user.BorrowedBook);
        }
    }

    // 타이틀
    public void View_Title()
    {
        Console.Clear();
        Console.WriteLine("" +
            "█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗\n" +
            "╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝\n" +
            "███████╗███╗   ██╗ ██╗ ██╗     ██╗     ██╗██████╗ ██████╗  █████╗ ██████╗ ██╗   ██╗ \n" +
            "██╔════╝████╗  ██║████████╗    ██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝ \n" +
            "█████╗  ██╔██╗ ██║╚██╔═██╔╝    ██║     ██║██████╔╝██████╔╝███████║██████╔╝ ╚████╔╝  \n" +
            "██╔══╝  ██║╚██╗██║████████╗    ██║     ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗  ╚██╔╝   \n" +
            "███████╗██║ ╚████║╚██╔═██╔╝    ███████╗██║██████╔╝██║  ██║██║  ██║██║  ██║   ██║    \n" +
            "╚══════╝╚═╝  ╚═══╝ ╚═╝ ╚═╝     ╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    \n" +
            "█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗\n" +
            "╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝");
    }

    // 메인 화면 
    public void View_Main()
    {
        while (true)
        {
            // 회원 로그아웃시켜야 함.
            currentUser = null;

            View_Title();
            Console.WriteLine("1. 로그인");
            Console.WriteLine("2. 회원가입");
            Console.WriteLine("3. 관리자모드");
            Console.WriteLine("4. 종료");

            string input = ReadNumber();

            switch (input)
            {
                case "1":
                    View_Login();
                    break;
                case "2":
                    View_JoinToUser();
                    break;
                case "3":
                    View_AdminMode();
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    }

    // 전체 책 리스트
    public void View_1_4()
    {
        View_Title();
        Console.WriteLine("도서관에 등록된 모든 책의 리스트입니다.");
        Console.WriteLine();

        View_BookList(bookList);
        Console.WriteLine($"책이 총 {bookList.Count}종류, {SumQuantityOfBooks(bookList)}권 등록되어 있습니다.");
    }

    // 책 검색
    public void View_1_1()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("1. 책 이름으로 검색");
            Console.WriteLine("2. 책 저자명으로 검색");
            Console.WriteLine("3. 책 출판사로 검색");
            Console.WriteLine("4. 종료");

            string input = ReadNumber();
            if (input == null)
                break;

            switch (input)
            {
                case "1":
                    View_1_1_1();
                    break;
                case "2":
                    View_1_1_2();
                    break;
                case "3":
                    View_1_1_3();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    }

    // 책 이름으로 검색
    public void View_1_1_1()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 이름을 입력하세요: ");

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == null)
                break;

            // 검색 리스트 생성
            SearchBookForName(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            input = ReadESC();
            if (input == null)
                break;
        }
    }
    // 책 저자명으로 검색
    public void View_1_1_2()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 저자명을 입력하세요: ");

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == null)
                break;

            // 검색 리스트 생성
            SearchForAuthor(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            input = ReadESC();
            if (input == null)
                break;
        }
    }
    // 책 출판사로 검색
    public void View_1_1_3()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 출판사를 입력하세요: ");

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == null)
                break;

            // 검색 리스트 생성
            SearchForPublisher(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            input = ReadESC();
            if (input == null)
                break;
        }
    }

    // 회원 정보
    public void View_1_5()
    {
        Console.WriteLine($"ID: {currentUser.Id}");
        Console.WriteLine($"이름: {currentUser.Name}");
        Console.WriteLine($"나이: {currentUser.Age}");
        Console.WriteLine($"전화 번호: {currentUser.PhoneNumber}");
        Console.WriteLine($"주소: {currentUser.Address}");
        Console.WriteLine($"대출한 책: {currentUser.BorrowedBook.Count}권");
        Console.WriteLine($"대출한 책 리스트");
        View_BookList(currentUser.BorrowedBook);
    }

    // 전체 회원 리스트
    public void View_3_1()
    {
        View_UserList(userList);
    }

    // 회원 검색
    public void View_3_2()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 이름을 입력하세요: ");

            // 입력받는 메소드 만들기
            string input = "가";

            // 예외처리하는 메소드 만들기

            // 검색 리스트 생성
            SearchUserForName(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
            }
        }

    }

    // 책 대출, 반납 기록
    public void View_3_8()
    {
        foreach (BookHistory bookHistory in bookHistoryList)
        {
            if (bookHistory.BorrowTime != null)
            {
                Console.WriteLine($"{bookHistory.BorrowTime}: \"{bookHistory.UserName}\"님이 <{bookHistory.BookName}> 도서를 대출하셨습니다.");
            }
            else
            {
                Console.WriteLine($"{bookHistory.ReturnTime}: \"{bookHistory.UserName}\"님이 <{bookHistory.BookName}> 도서를 반납하셨습니다.");
            }
        }
    }

    // 신규 책 등록
    public void View_3_5()
    {
        string id = Console.ReadLine();
        string name = Console.ReadLine();
        string publisher = Console.ReadLine();
        string author = Console.ReadLine();
        string price = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        AddNewBook(id, name, publisher, author, price, quantity);
        Console.WriteLine("신규 도서 등록이 완료되었습니다.");
    }

    // 회원가입
    public void View_JoinToUser()
    {
        View_Title();

        string id;
        string password;
        string name;
        int age;
        string phoneNumber;
        string address;
        Console.Write("ID를 입력하세요. (숫자/영어)");
        while (true)
        {
            id = ReadEnglishOrNumber();
            if (id == null)
                goto Jump;

            if (CheckUserID(id))
                Console.Write("이미 존재하는 ID입니다. 다시 입력하세요: ");
            else
                break;
        }
        
        Console.Write("비밀번호를 입력하세요. (숫자/영어)");
        while (true)
        {
            password = ReadEnglishOrNumber();
            if (password == null)
                goto Jump;

            if (password.Length > 11)
                Console.Write("비밀번호가 너무 깁니다. 10자리 이하로 다시 입력하세요: ");
            else
                break;
        }
        
        Console.Write("이름을 입력하세요. (한글)");
        while (true)
        {
            name = ReadKorean();
            if (name == null)
                goto Jump;
            if (name.Length > 5)
                Console.Write("이름이 너무 깁니다. 4자리 이하로 다시 입력하세요: ");
            else
                break;
        }
        
        Console.Write("나이를 입력하세요. (숫자)");
        while (true)
        {
            string ageString = ReadNumber();
            if (ageString == null)
                goto Jump;
            age = int.Parse(ageString);
            if (age > 100 || age < 1)
                Console.Write("1세부터 100세까지 회원가입 가능합니다. 다시 입력하세요: ");
            else
                break;
        }
        
        Console.Write("전화번호를 입력하세요. (숫자)");
        while (true)
        {
            phoneNumber = ReadNumber();
            if (phoneNumber == null)
                goto Jump;
            if (phoneNumber.Length > 11)
                Console.Write("전화번호가 너무 깁니다. 11자리 이하로 다시 입력하세요: ");
            else
                break;
        }
        
        Console.Write("주소를 입력하세요. (숫자/한글/영어)");
        address = ReadString();
        if (phoneNumber == null)
            goto Jump;

        AddNewUser(id, password, name, age, phoneNumber, address);
        Console.WriteLine("회원 가입이 완료되었습니다.");
        Console.WriteLine("메인 화면으로 돌아가려면 ESC를 눌러주세요.");
        string input = ReadESC();
        if (input == null)
        {
            View_Main();
        }

        Jump:
        Console.WriteLine();
    }

    // 로그인
    public void View_Login()
    {
        View_Title();

        Console.Write("ID를 입력하세요. (숫자/영어)");
        while (true)
        {
            string id = ReadEnglishOrNumber();
            if (id == null)
                goto Jump;

            if (CheckUserID(id))
                break;
            else
                Console.Write("존재하지 않는 ID입니다. 다시 입력하세요.");
        }

        Console.Write("비밀번호를 입력하세요. (숫자/영어)");
        while (true)
        {
            string password = ReadEnglishOrNumber();
            if (password == null)
                goto Jump;

            if (CheckUserPassword(password))
                break;
            else
                Console.Write("잘못 입력하셨습니다. 다시 입력하세요.");
        }

        while (true)
        {
            View_Title();
            Console.WriteLine($"로그인 성공. 반갑습니다. {currentUser.Name}님");
            Console.WriteLine("1. 책 검색");
            Console.WriteLine("2. 책 대출");
            Console.WriteLine("3. 책 반납");
            Console.WriteLine("4. 책 리스트");
            Console.WriteLine("5. 나의 회원 정보");
            Console.WriteLine("6. 처음 메뉴로 가기");
            Console.WriteLine("7. 종료");

            string input = ReadNumber();
            if (input == null)
                break;

            switch (input)
            {
                case "1":
                    View_1_1();
                    break;
                case "2":
                    View_1_2();
                    break;
                case "3":
                    View_1_3();
                    break;
                case "4":
                    View_1_4();
                    break;
                case "5":
                    View_1_5();
                    break;
                case "6":
                    View_Main();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
        Jump:
        Console.WriteLine();
    }

    // 관리자 모드
    public void View_AdminMode()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("1. 회원 리스트");
            Console.WriteLine("2. 회원 검색");
            Console.WriteLine("3. 회원 삭제");
            Console.WriteLine("4. 책 리스트");
            Console.WriteLine("5. 신규 책 등록");
            Console.WriteLine("6. 책 정보 수정");
            Console.WriteLine("7. 책 삭제");
            Console.WriteLine("8. 책 대출/반납 기록");
            Console.WriteLine("9. 돌아가기");

            string input = ReadNumber();
            if (input == null)
                break;

            switch (input)
            {
                case "1":
                    View_3_1();
                    break;
                case "2":
                    View_3_2();
                    break;
                case "3":
                    View_3_3();
                    break;
                case "4":
                    View_3_4();
                    break;
                case "5":
                    View_3_5();
                    break;
                case "6":
                    View_3_6();
                    break;
                case "7":
                    View_3_7();
                    break;
                case "8":
                    View_3_8();
                    break;
                case "9":
                    View_Main();
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    }
}
