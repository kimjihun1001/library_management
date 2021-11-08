using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

[Serializable]
public class BookVO
{
    private string bookIDNumber;
    private string bookName;
    private string bookPublisherName;
    private string bookAuthorName;
    private string bookPrice;
    private int bookQuantity;
    public BookVO()
    {

    }

    public BookVO(string bookIDNumber, string bookName, string bookPublisherName, string bookAuthorName, string bookPrice, int bookQuantity)
    {
        this.bookIDNumber = bookIDNumber;
        this.bookName = bookName;
        this.bookPublisherName = bookPublisherName;
        this.bookAuthorName = bookAuthorName;
        this.bookPrice = bookPrice;
        this.bookQuantity = bookQuantity;

    }

    public string BookIDNumber
    {
        get { return bookIDNumber; }
        set { bookIDNumber = value; }
    }

    public string BookName
    {
        get { return bookName; }
        set { bookName = value; }
    }

    public string BookPublisherName
    {
        get { return bookPublisherName; }
        set { bookPublisherName = value; }
    }
    public string BookAuthorName
    {
        get { return bookAuthorName; }
        set { bookAuthorName = value; }
    }

    public string BookPrice
    {
        get { return bookPrice; }
        set { bookPrice = value; }
    }


    public int BookQuantity
    {
        get { return bookQuantity; }
        set { bookQuantity = value; }
    }

}
