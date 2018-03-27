using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	int level;
	enum Screen { MainMenu, Password, Win }
	Screen currentScreen;
	string[] levelOnePasswords = {"books", "aisle", "shelf", "password", "font", "borrow"};
	string[] levelTwoPasswords = {"prisoner", "handcuffs", "holster", "uniform", "arrest"};
	string[] levelThreePasswords = {"starfield", "telescope", "environment", "exploration", "astronauts"};
	string password;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu () {
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("What would you like to hack into?");
		Terminal.WriteLine("");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for NASA");
		Terminal.WriteLine("");
		Terminal.WriteLine("Enter your selection:");
	}

	void OnUserInput (string input) {
		if (input == "menu") {
			level = 0;
			ShowMainMenu();
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);	
		} else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
    }

    private void SetRandomPassword() {
        switch (level) {
            case 1:
                password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
                break;
            case 2:
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
                break;
            case 3:
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
    }

    void RunMainMenu(string input) {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber) {
			level = int.Parse(input);
			AskForPassword();
		} else {
			Terminal.WriteLine("Invalid input. Please try again.");
		}
	}

	void CheckPassword(string input) {
		if (input == password){
			DisplayWinScreen();
		} else {
			AskForPassword();
		}
	}

	void DisplayWinScreen(){
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void ShowLevelReward(){
		switch(level){
			case 1:
				Terminal.WriteLine("You beat level 1");
				break;
			case 2:
				Terminal.WriteLine("You beat level 2");
				break;
			case 3:
				Terminal.WriteLine("You beat level 3");
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
