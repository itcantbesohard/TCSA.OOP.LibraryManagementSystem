using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using static TCSA.OOP.LibraryManagementSystem.Enums;

namespace TCSA.OOP.LibraryManagementSystem
{
    internal class UserInterface
    {
        private readonly BooksController _booksController = new BooksController();
        private readonly MagazineController _magazineController = new MagazineController();
        private readonly NewspaperController _newspaperController = new NewspaperController();

        internal void MainMenu()
        {

            while (true)
            {
                Console.Clear();

                var actionChoice = AnsiConsole.Prompt(
                  new SelectionPrompt<Enums.MenuAction>()
                  .Title("What do you want to do next?")
                  .AddChoices(Enum.GetValues<Enums.MenuAction>()));

                var itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>()
                .Title("Select the type of item:")
                .AddChoices(Enum.GetValues<ItemType>()));

                switch (actionChoice)
                {
                    case MenuAction.ViewItem:
                        ViewItems(itemTypeChoice);
                        break;

                    case MenuAction.AddItem:
                        AddItem(itemTypeChoice);
                        break;

                    case MenuAction.DeleteItem:
                        DeleteItem(itemTypeChoice);
                        break;
                }

            }
        }

        private void ViewItems(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.ViewItems();
                    break;
                case ItemType.Magazine:
                    _magazineController.ViewItems();
                    break;
                case ItemType.Newspaper:
                    _newspaperController.ViewItems();
                    break;
            }
        }
        private void AddItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.AddItem();
                    break;
                case ItemType.Magazine:
                    _magazineController.AddItem();
                    break;
                case ItemType.Newspaper:
                    _newspaperController.AddItem();
                    break;
            }
        }
        private void DeleteItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.DeleteItem();
                    break;
                case ItemType.Magazine:
                    _magazineController.DeleteItem();
                    break;
                case ItemType.Newspaper:
                    _newspaperController.DeleteItem();
                    break;
            }
        }

    }
}