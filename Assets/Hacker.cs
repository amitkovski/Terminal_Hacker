//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Configuration for the game
    string[] level1Passwords = {"dwarf", "argon", "ring", "force", "wizard" };
    string[] level2Passwords = { "generator", "alien", "speciman", "predator", "padawan" };
    string[] level3Passwords = { "dreadnought", "blitzkrieg", "desertation", "annexation" };
    

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

    void Update()
    {

        //int index = Random.Range(0, level1Passwords.Length); // Checking random valid?
        //print(index);
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
                //print(level1Passwords.Length);
                int index_1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index_1];
                break;
            case 2:
                int index_2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index_2];
                break;
            case 3:
                int index_3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index_3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        //Terminal.WriteLine("You have chosen level" + level);
        Terminal.WriteLine("Enter your password, HINT" + password.Anagram());
    }

    void CheckingPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }else
        {
            Terminal.WriteLine("Sry, password is not right");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowRewardForLevel();
    }

    void ShowRewardForLevel()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("R2-D2 and Lea congratulates you ");
                Terminal.WriteLine(@"
                    .==.
                   ()''()-.
        .---.       ;--; /
      .'_:___'._..'.  __'.
      | __-- ==| '-''' \'...;
      [  ]  :[|       | ---\
      | __ | I =[|     .'    '.
      / / ____ |     :       '._
     | -/.____.'      | :       :
     / ___\ / ___\      '-'._----'
"
                    
                    );
                break;
            case 2:
                Terminal.WriteLine("You are going to an adventure...");
                Terminal.WriteLine(@"

            _.===._      ,' ^^^^ ',
           / _\^^^/ _\    /  ^ ,^  \     ,
           (0\ ^ / 0)\  / ^  /  ^  \    /\
            \     /  ^^   ^ \ ^ \  ',.' /
             )   (  ^  ^   ^ \   \    ,'
             (o_o) ^    \ ^   ,)  /`^^`
              ^ V ^\ ^ \  \_,-'((((
         '/  /`'' /  /
         '(((`   '(((

"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");

        }

    }
}
