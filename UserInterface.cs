using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCSA.OOP.LibraryManagementSystem
{
    internal class UserInterface
    {
        private BooksController booksController = new BooksController();

        internal void MainMenu()
        {
            
            while (true)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                  new SelectionPrompt<Enums.MenuOption>()
                  .Title("What do you want to do next?")
                  .AddChoices(Enum.GetValues<Enums.MenuOption>()));

                switch (choice)
                {
                    case Enums.MenuOption.ViewBooks:
                        booksController.ViewBooks();
                        break;

                    case Enums.MenuOption.AddBook:
                        booksController.AddBook();
                        break;

                    case Enums.MenuOption.DeleteBook:

                        booksController.DeleteBook();
                        break;
                }

            }
        }
    }
}