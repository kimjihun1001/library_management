using System;

[Serializable]
public class Book
{
    private string id;  // 도서번호
    private string name;    // 도서명
    private string publisher;   // 출판사명
    private string author;  // 저자명
    private string price;   // 가격
    private string quantity;    // 수량

    public Book()
    {
        // 생성자
    }

    public Book(string id)
    {
        this.id = id;
    }

    public string Id    // get/set method
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get; set;
    }

    public string Publisher
    {
        get; set;
    }

    public string Author
    {
        get; set;
    }

    public string Price
    {
        get; set;
    }

    public string Quantity
    {
        get; set;
    }
}
