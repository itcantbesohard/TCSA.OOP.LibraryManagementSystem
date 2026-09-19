namespace TCSA.OOP.LibraryManagementSystem;

using Spectre.Console;
using System;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using TCSA.OOP.LibraryManagementSystem.Models;

internal class BooksController : IBaseController
{

    public void ViewBooks()
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDatabase.LibraryItems.OfType<Book>();


        foreach (var book in books)
        {
            table.AddRow(
            book.Id.ToString(),
            $"[cyan]{book.Name}[/]",
            $"[cyan]{book.Author}[/]",
            $"[green]{book.Category}[/]",
            $"[blue]{book.Location}[/]",
            book.Pages.ToString());
        };

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
    }

    public void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        // checking if the book already exists to avoid duplication.
        if(MockDatabase.LibraryItems.OfType<Book>().Any(b=>b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine($"[red]A book with the title '{title}' already exists.[/]");
        }
        else
        {
            var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
            MockDatabase.LibraryItems.Add(newBook);
            AnsiConsole.MarkupLine($"[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void DeleteBook()
    {
        // checking if there are any books to delete and letting the user know
        if (MockDatabase.LibraryItems.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        //showing a list of books and letting the user choose with arrows using SelectionPrompt
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<LibraryItem>()
            .Title("Select a [red]book[/] to delete:")
            .UseConverter(b => $"{b.Name}")
            .AddChoices(MockDatabase.LibraryItems.OfType<Book>()));

        //Using the Remove method to delete a book. 
        if (MockDatabase.LibraryItems.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void ViewItems()
    {
        throw new NotImplementedException();
    }

    public void AddItem()
    {
        throw new NotImplementedException();
    }

    public void DeleteItem()
    {
        throw new NotImplementedException();
    }
}
