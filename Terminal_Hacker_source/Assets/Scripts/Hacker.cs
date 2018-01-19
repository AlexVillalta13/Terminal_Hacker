using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string playerName;
    int currentLevel;
    string password;

    string[] lv01Passwords = { "nazi", "franco", "gerard", "puigdemony" };
    string[] lv02Passwords = { "musolini", "darth vader", "palpatine", "junqueras" };

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

    void ShowMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to hack?");
        Terminal.WriteLine("Level 1: Library");
        Terminal.WriteLine("Level 2: Police Station");
        Terminal.WriteLine("Level 3: NASA");
        Terminal.WriteLine("Select level:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            currentLevel = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please, type a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You choose level " + currentLevel);
        Terminal.WriteLine("Please enter your password");

        switch (currentLevel)
        {
            case 1:
                password = lv01Passwords[UnityEngine.Random.Range(0, lv01Passwords.Length)];
                    break;
            case 2:
                password = lv02Passwords[UnityEngine.Random.Range(0, lv02Passwords.Length)];
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("WELL DONE!");
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }
}
