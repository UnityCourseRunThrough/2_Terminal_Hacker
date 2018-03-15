using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    string password;
    enum Screen { MainMenu, Password, Win, Off };
    Screen currentScreen;
    enum Level { Library, Police, NASA };
    Level currentLevel;

    // Game Configuation Data
    string[] level1Passwords = { "books", "ailse", "quiet", "font", "password" };
    string[] level2Passwords = { "jail", "squad", "force", "protect", "serve" };
    string[] level3Passwords = { "jupiter", "cassini", "rocket", "shuttle", "JPL" };

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        currentLevel = 0;
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type " + currentLevel + " for " + currentLevel);
        Terminal.WriteLine("Type " + (currentLevel + 1) + " for " + (currentLevel + 1));
        Terminal.WriteLine("Type " + (currentLevel + 2) + " for " + (currentLevel + 2));
        Terminal.WriteLine("");
        Terminal.WriteLine("Type menu at any time to return here");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") //We can always go to the main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            AskToPlayAgain(input);
        }
    }

    void SetCurrentLevel(string input)
    {
        if (input == Level.Library.ToString())
        {
            currentLevel = Level.Library;
        }
        else if (input == Level.Police.ToString())
        {
            currentLevel = Level.Police;
        }
        else if (input == Level.NASA.ToString())
        {
            currentLevel = Level.NASA;
        }
    }

    void RunMainMenu(string input)
    {

        if (input == Level.Library.ToString() || input == Level.Police.ToString() || input == Level.NASA.ToString())
        {
            SetCurrentLevel(input);
            StartHackingOnLevel(input);
        }
        else if (input == Level.Police.ToString())
        {
            SetCurrentLevel(input);
            StartHackingOnLevel(input);
        }
        else if (input == Level.NASA.ToString())
        {
            SetCurrentLevel(input);
            StartHackingOnLevel(input);
        }
        else
        {
            Terminal.WriteLine("Invalid entry, please try again...");
        }
    }

    void StartHackingOnLevel(string input)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SelectRandomPassword();
        DisplayLevelOptions();
     }

    void DisplayLevelOptions()
    {
        Terminal.WriteLine("========================");
        Terminal.WriteLine("");
        Terminal.WriteLine("Welcome To " + currentLevel);
        Terminal.WriteLine("Security Level " + ((int)currentLevel + 1));
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Password: hint: " + password.Anagram());
    }

    void SelectRandomPassword()
    {
        switch (currentLevel)
        {
            case Level.Library:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case Level.Police:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case Level.NASA:
                password = level3Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Error");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            Terminal.WriteLine("Invalid password, pelase try again...");
            DisplayLevelOptions();
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        DisplayPrize();
        Terminal.WriteLine("Would you like to play again?");
        Terminal.WriteLine("Press y / n and press enter...");
    }

    void DisplayPrize()
    {
        switch(currentLevel)
        {
            case Level.Library:
                Terminal.WriteLine("You have Won!");
                Terminal.WriteLine("Here, have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      // 
 /______//
(______)/
");
                break;
            case Level.Police:
                Terminal.WriteLine("You have Won!");
                Terminal.WriteLine("Here, have a Key...");
                Terminal.WriteLine(@"
 ____
/    \________
|     _/\/\__=/
\____/
");
                break;
            case Level.NASA:
                Terminal.WriteLine("You have Won!");
                Terminal.WriteLine("Here, have a rocket...");
                Terminal.WriteLine(@"
    ^
   / \
   | |
   | |
  /___\
");
                break;
        }
            

    }

    void AskToPlayAgain(string input)
    {
        if (input == "y")
        {
            ShowMainMenu();
        }
        else if (input == "n")
        {
            Goodbye();
        }
        else
        {
            Terminal.WriteLine("Invalid input, please try again");
        }
    }

    void Goodbye()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Off;
    }
}