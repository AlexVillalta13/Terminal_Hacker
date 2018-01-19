using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string playerName;
    int currentLevel;

    enum Screen
    {
        MainMenu,
        Password,
        Win
    }

    Screen currentScreen = Screen.MainMenu;

	void Start ()
    {
        playerName = "Alex";
        ShowMenu();
    }

    void OnUserInput(string input)
    {
        if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "menu")
        {
            ShowMenu();
        }
        else if (input == "1")
        {
            currentScreen = Screen.Password;
            currentLevel = 1;
            StartGame();
}
        else if (input == "2")
        {
            currentScreen = Screen.Password;
            currentLevel = 2;
            StartGame();
        }
        else if (input == "3")
        {
            currentScreen = Screen.Password;
            currentLevel = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please, type a valid text");
        }
    }

    void ShowMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to hack?");
        Terminal.WriteLine("Level 1: Library");
        Terminal.WriteLine("Level 2: Police Station");
        Terminal.WriteLine("Select level:");
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You choose level " + currentLevel);
        Terminal.WriteLine("Please enter your password");
    }
}
