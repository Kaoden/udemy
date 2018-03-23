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

	void StartGame(){
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		switch(level){
			case 1:
				password = levelOnePasswords[0];
				break;
			case 2:
				password = levelTwoPasswords[0];
				break;
			case 3:
				password = levelThreePasswords[0];
				break;
			default:
				Debug.LogError("Invalid level number.");
				break;
		}
		Terminal.WriteLine("Please enter the password:");
	}

	void RunMainMenu(string input) {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber) {
			level = int.Parse(input);
			StartGame();
		} else {
			Terminal.WriteLine("Invalid input. Please try again.");
		}
	}

	void CheckPassword(string input) {
		string result = "Incorrect password, try again."; // result will be updated if the answer is correct
		if (level == 1 && input == password){
			result = "Correct!";
			currentScreen = Screen.Win;
		}
		if (level == 2 && input == password){
			result = "Correct!";
			currentScreen = Screen.Win;
		}
		if (level == 3 && input == password){
			result = "Correct!";
			currentScreen = Screen.Win;
		}

		Terminal.WriteLine(result);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
