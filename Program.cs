using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace таск_5
{
 
    class Program
    {
        static void Main(string[] args)
        {
            List<IZdanie> books = new List<IZdanie>();

            Book book1 = new Spravochnik("Справочник по С#", "Иван Иванов", 2020, "Издательство 1", 300, "Язык программирования");
            Spravochnik book2 = new Spravochnik("Справочник по C++", "Петр Петров", 2018, "Издательство 2", 250, "Язык программирования");
            Enciklopedia book3 = new Enciklopedia("История мировой культуры", "Виктория Смирнова", 2015, "Издательство 3", 3, "Культурология");

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            book1.NowoeIzdan();
            book2.Pereizdanie();
            book3.Pereizdanie();

            book1.Info();
            book2.AddPages();
            book2.Info();
            book3.AddPart();
            book3.Info();

            Console.WriteLine("\nСписок книг:");
            foreach (IZdanie book in books)
            {
                book.NowoeIzdan();
                book.Pereizdanie();
                book.Izdatelstvo = "Издательство Обновленное";
            }
            Console.ReadLine();
        }
    }
}

interface IZdanie
{
    string Izdatelstvo { get; set; }
    void NowoeIzdan();
    void Pereizdanie();
}

abstract class Book : IZdanie
{
    string _name;
    string _author;
    int _year;
    string _edition;

    public string Name { get { return _name; } set { _name = value; } }
    public string Author { get { return _author; } set { _author = value; } }
    public int Year { get { return _year; } set { _year = value; } }
    public string Izdatelstvo { get { return _edition; } set { _edition = value; } }

    public Book(string name, string author, int year, string izdatelstvo)
    {
        _name = name;
        _author = author;
        _year = year;
        _edition = izdatelstvo;
    }

    public void NowoeIzdan()
    {
        Console.WriteLine("Вышло новое издание книги " + _name);
    }

    public void Pereizdanie()
    {
        Console.WriteLine("Вышло переиздание книги " + _name);
    }

    public virtual void Info()
    {
        Console.WriteLine("Информация о книге:\nНазвание: " + _name + "\nАвтор: " + _author + "\nГод издания: " + _year + "\nИздательство: " + _edition);
    }
}

class Spravochnik : Book
{
    int _pages;
    string _theme;

    public int Pages { get { return _pages; } set { _pages = value; } }
    public string Tema { get { return _theme; } set { _theme = value; } }

    public Spravochnik(string name, string author, int year, string izdatelstvo, int stranits, string tema) : base(name, author, year, izdatelstvo)
    {
        _pages = stranits;
        _theme = tema;
    }

    public override void Info()
    {
        Console.WriteLine("Информация о справочнике:\nНазвание: " + Name + "\nАвтор: " + Author + "\nГод издания: " + Year + "\nИздательство: " + Izdatelstvo + "\nКоличество страниц: " + _pages + "\nТематика: " + _theme);
    }

    public void AddPages()
    {
        Console.WriteLine("Добавлена новая страница в справочник " + Name);
        _pages++;
    }
}

class Enciklopedia : Book
{
    int _parts;
    string _oblast;

    public int Parts { get { return _parts; } set { _parts = value; } }
    public string Oblast { get { return _oblast; } set { _oblast = value; } }

    public Enciklopedia(string name, string author, int year, string izdatelstvo, int parts, string oblast) : base(name, author, year, izdatelstvo)
    {
        _parts= parts;
        _oblast = oblast;
    }

  
    public override void Info()
    {
        Console.WriteLine("Информация об энциклопедии:\nНазвание: " + Name + "\nАвтор: " + Author + "\nГод издания: " + Year + "\nИздательство: " + Izdatelstvo + "\nКоличество томов: " + _parts + "\nОбласть: " + _oblast);
    }

    public void AddPart()
    {
        Console.WriteLine("Добавлен новый том в энциклопедию " + Name);
        _parts++;
    }
}