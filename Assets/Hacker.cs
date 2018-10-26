using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Configuration for the game
    string[] level1Passwords = {"dwarf", "argon", "ring", "force", "wizard" };
    string[] level2Passwords = { "generator", "alien", "speciman", "predator", "padawan" };
    string[] level3Passwords = { "dreadnought", "blitzkrieg", "desertatio n", "annexation" };
    

    // Game state
    int level;
    string password;
    //Screens the player can be
    enum Screen { MainMenu, Password, Win };

    Screen currentScreen;



    // Use this for initialization
    void Start ()
    {
        print(level1Passwords[0]);
         ShowMainMenu();
     }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Aleks");

        Terminal.WriteLine("Greetings international student.\n");
        Terminal.WriteLine("Welcome to our hacking anagram game.\n" +
            "Please select a scenario:\n");
        Terminal.WriteLine("Press 1 for fantasy scenario.");
        Terminal.WriteLine("Press 2 for Sci-Fi scene.");
        Terminal.WriteLine("Press 3 for War.");
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckingPassword(input);

        }

    }

     void RunMainMenu(string input)
    {
        bool isValidLvlNumber = (input == "1" || input == "2" || input ==" 3");
        if (isValidLvlNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        /*
        if (input == "1")
        {
           // level = 1;
            password = level1Passwords[0];
            StartGame();
        }
        else if (input == "2")
        {
            //level = 2;
            password = level2Passwords[2];
            StartGame();
        }
        else if (input == "3")
        {
            password = "amazing";
            //level = 3;
            StartGame();
        }
        */
        else
        {
            print("Wrong inout. Please try again.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[2];
                break;
            case 2:
                password = level2Passwords[3];
                break;
            case 3:
                password = level3Passwords[0];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        //Terminal.WriteLine("You have chosen level" + level);
        Terminal.WriteLine("Please enter your password");
    }

    void CheckingPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("AWESOME WORK");
        }else
        {
            Terminal.WriteLine("Sry, password is not right");
        }
    }
}
