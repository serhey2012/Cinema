﻿using SimpleTicketBookingSystem.Data;
using SimpleTicketBookingSystem.Data.Screen;
using SimpleTicketBookingSystem.Enums;
using SimpleTicketBookingSystem.Interfaces;
using SimpleTicketBookingSystem.Interfaces.Data;

namespace SimpleTicketBookingSystem.UI
{
    /// <summary>
    /// main screen
    /// </summary>
    public class MainScreen : Screen
    {

        public SelectSeatsScreen _selectSeatsScreen;

        public MoviesScreen _moviesScreen;

        public IDataService _dataService;

        public MainScreen(SelectSeatsScreen selectSeatsScreen, MoviesScreen moviesScreen, IDataService dataService)
        {
            _selectSeatsScreen = selectSeatsScreen;
            _moviesScreen = moviesScreen;
            _dataService = dataService; 
        }

        public override void Show()
        {
            while (true)
            {

                var list = new List<ScreenLineEntry>
                {
                    new ScreenLineEntry { Text = "0. Exit" },
                    new ScreenLineEntry { Text = "1. Choose a movie" },
                    new ScreenLineEntry{Text = "2. Save as JSON"}
                };


                ScreenRender(list);
                SwitchHandler();
            }
        }



        public override void EnterScreen()
        {
            try
            {
                MainScreenChoices choice = (MainScreenChoices)currentField;
                switch (choice)
                {
                    case MainScreenChoices.СhooseAMovie:
                        _moviesScreen.Show();
                        break;
                    case MainScreenChoices.SaveJSON:
                        _dataService.Write("C:\\Users\\User\\Downloads\\ООП\\SimpleTicketBookingSystem-main\\SimpleTicketBookingSystem.App\\SimpleTicketBookingSystem.App\\JSON_File\\json1.json");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}