using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	int level;
	enum Screen { MainMenu, Password, Win }
	Screen currentScreen;
	string levelOnePassword = "Hurf";
	string levelTwoPassword = "Durf";
	string levelThreePassword = "HurfDurf";

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
		} else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);	
		}
	}

	void StartGame(){
		currentScreen = Screen.Password;
		Terminal.WriteLine("You have chosen level " + level);
		Terminal.WriteLine("Please enter the password:");
	}

	void RunMainMenu(string input) {
		if (input == "1") {
			level = 1;
			StartGame();
		} else if (input == "2") {
			level = 2;
			StartGame();
		} else if (input == "3") {
			level = 3;
			StartGame();
		} else {
			Terminal.WriteLine("Invalid input. Please try again.");
		}
	}

	void CheckPassword(string password) {
		string result = "Incorrect password"; // result will be updated if the answer is correct
		if (level == 1 && password == "Hurf"){
			result = "Correct!";
			currentScreen = Screen.Win;
		}
		if (level == 2 && password == "Durf"){
			result = "Correct!";
			currentScreen = Screen.Win;
		}
		if (level == 3 && password == "HurfDurf"){
			result = "Correct!";
			currentScreen = Screen.Win;
		}

		Terminal.WriteLine(result);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
