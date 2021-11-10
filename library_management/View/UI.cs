﻿using System;
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
            Console.WriteLine(user.Name);
        }
    }

    public void View_Title()
    {
        Console.WriteLine("LIBRARY");
    }

    public void View_Main()
    {
        while (true)
        {
            // 로그아웃시켜야 함.
            currentUser = null;

            View_Title();
            Console.WriteLine("1. 로그인");
            Console.WriteLine("2. 회원가입");
            Console.WriteLine("3. 관리자모드");
            Console.WriteLine("4. 종료");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    View_Login();
                    break;
                case "2":
                    View_JoinToUser();
                    break;
                case "3":

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
        Console.WriteLine("도서관에 등록된 모든 책의 리스트입니다.");
        Console.WriteLine();

        View_BookList(bookList);
        Console.WriteLine($"책이 총 {bookList.Count}종류, {SumQuantityOfBooks(bookList)}권 등록되어 있습니다.");
    }

    // 책 이름으로 검색
    public void View_1_1_1() 
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
                View_BookList(searchedBookList);
            }
        }
    }

    // 회원가입
    public void View_JoinToUser()
    {
        string id = Console.ReadLine();
        string password = Console.ReadLine();
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string phoneNumber = Console.ReadLine();
        string address = Console.ReadLine();

        User user = new User(id, password, name, age, phoneNumber, address);
        userList.Add(user);
        UpdateUserFile(userList);
        Console.WriteLine("회원 가입이 완료되었습니다.");
    }

    // 로그인
    public void View_Login()
    {
        while (true)
        {
            string id = Console.ReadLine();
            if (CheckUserID(id))
                break;
        }

        while (true)
        {
            string password = Console.ReadLine();
            if (CheckUserPassword(password))
                break;
        }

        Console.WriteLine("로그인 성공");
    }

}
