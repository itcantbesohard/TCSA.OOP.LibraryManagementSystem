namespace TCSA.OOP.LibraryManagementSystem;
using Spectre.Console;
using System;

internal class BooksController
{

    internal  void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in MockDatabase.books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal  void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

        // checking if the book already exists to avoid duplication.
        if (MockDatabase.books.Contains(title))
        {
            AnsiConsole.MarkupLine($"[red]This book already exists.[/]");
        }
        else
        {
            MockDatabase.books.Add(title);
            AnsiConsole.MarkupLine($"[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal  void DeleteBook()
    {
        // checking if there are any books to delete and letting the user know
        if (MockDatabase.books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        //showing a list of books and letting the user choose with arrows using SelectionPrompt
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(MockDatabase.books));

        //Using the Remove method to delete a book. 
        if (MockDatabase.books.Remove(bookToDelete))
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
}
