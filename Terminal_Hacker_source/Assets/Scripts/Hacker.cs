
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string playerName;
    int currentLevel;
    string password;

    string[] lv01Passwords = { "nazi", "franco", "gerard", "puigdemony" };
    string[] lv02Passwords = { "musolini", "darth vader", "palpatine", "junqueras" };
    string[] lv03Passwords = { "paco", "manolo", "barcenas", "rajoy" };

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
        input = input.ToLower();
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
        SetPassword();
    }

    private void SetPassword()
    {
        switch (currentLevel)
        {
            case 1:
                password = lv01Passwords[Random.Range(0, lv01Passwords.Length)];
                break;
            case 2:
                password = lv02Passwords[Random.Range(0, lv02Passwords.Length)];
                break;
            case 3:
                password = lv03Passwords[Random.Range(0, lv03Passwords.Length)];
                break;
        }
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Sorry, wrong password!");
            Terminal.WriteLine("Password changed");
            SetPassword();
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("WELL DONE!");
        Terminal.WriteLine("You complete the level " + currentLevel);
        ShowReward();
        Terminal.WriteLine("");
        Terminal.WriteLine("Menu - to return to level selection");
    }

    void ShowReward()
    {
        switch (currentLevel)
        {
            case 1:
                Terminal.WriteLine(@"
              ∩
　　　　　　　＼＼
　　　　　　　／　 ）
⊂＼＿／￣￣￣　 ／
　＼＿／   ° ͜ʖ ° （
　　　）　　 　／⌒＼
　　／　 ＿＿＿／⌒＼⊃
　（　 ／
　　＼＼
       U
                ");
                break;
            case 2:
                Terminal.WriteLine(@"
(\_/)
( •,•)
(')_(')
                ");
                break;
            case 3:
                Terminal.WriteLine(@"
(\__/) || 
(•ㅅ•) || 
/ 　   づ  
                ");
                break;
        }
    }
}
