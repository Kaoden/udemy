﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu () {
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
		if (input == "1") {
			print("You chose level one");
		} else if (input == "menu") {
			ShowMainMenu();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
