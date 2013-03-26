using UnityEngine;
using System.Collections;

public class MDIInputModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
	}
	
	public void MDIInput ()
	{
		//MDI面板输入区		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "p O"))            
		{
			if(Main.ScreenPower)
				LetterInput("O");
		}
		
		if (GUI.Button(new Rect(660f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "q N"))            
		{
			if(Main.ScreenPower)
				LetterInput("N");
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "r G"))            
		{
			if(Main.ScreenPower)
				LetterInput("G");
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "a 7"))            
		{
			if(Main.ScreenPower)
				LetterInput("7");
		}
		
		if (GUI.Button(new Rect(840f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "b 8"))            
		{
			if(Main.ScreenPower)
				LetterInput("8");
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 30f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "c 9"))            
		{
			if(Main.ScreenPower)
				LetterInput("9");
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "u X"))            
		{
			if(Main.ScreenPower)
				LetterInput("X");
		}
		
		if (GUI.Button(new Rect(660f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "v Y"))            
		{
			if(Main.ScreenPower)
				LetterInput("Y");
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "w Z"))            
		{
			if(Main.ScreenPower)
				LetterInput("Z");
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "[  4"))            
		{
			if(Main.ScreenPower)
				LetterInput("4");
		}
		
		if (GUI.Button(new Rect(840f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "]  5"))            
		{
			if(Main.ScreenPower)
				LetterInput("5");
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 90f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "sp 6"))            
		{
			if(Main.ScreenPower)
				LetterInput("6");
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "i M"))            
		{
			if(Main.ScreenPower)
				LetterInput("M");
		}
		
		if (GUI.Button(new Rect(660f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "j S"))            
		{
			if(Main.ScreenPower)
				LetterInput("S");
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "k T"))            
		{
			if(Main.ScreenPower)
				LetterInput("T");
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), ", 1"))            
		{
			if(Main.ScreenPower)
				LetterInput("1");
		}
		
		if (GUI.Button(new Rect(840f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "# 2"))            
		{
			if(Main.ScreenPower)
				LetterInput("2");
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 150f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "= 3"))            
		{
			if(Main.ScreenPower)
				LetterInput("3");
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "l F"))            
		{
			if(Main.ScreenPower)
				LetterInput("F");
		}
		
		if (GUI.Button(new Rect(660f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "d H"))            
		{
			if(Main.ScreenPower)
				LetterInput("H");
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "eEOB"))            
		{
			if(Main.ScreenPower)
				LetterInput(";");
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "+  -"))            
		{
			if(Main.ScreenPower)
				LetterInput("-");
		}
		
		if (GUI.Button(new Rect(840f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "*  0"))            
		{
			if(Main.ScreenPower)
				LetterInput("0");
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 210f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "/  ."))            
		{
			if(Main.ScreenPower)
				LetterInput(".");
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "SHIFT"))            
		{
			if(Main.ScreenPower)
				Main.ShiftFlag = true;
		}
	}

	void LetterInput (string letter) 
	{
		string with_shift = "";
		string without_shift = "";
		switch(letter)
		{
		case "O":
			with_shift = "P";
			without_shift = "O";
			break;	
		case "N":
			with_shift = "Q";
			without_shift = "N";
			break;
		case "G":
			with_shift = "R";
			without_shift = "G";
			break;
		case "X":
			with_shift = "U";
			without_shift = "X";
			break;
		case "Y":
			with_shift = "V";
			without_shift = "Y";
			break;
		case "Z":
			with_shift = "W";
			without_shift = "Z";
			break;
		case "M":
			with_shift = "I";
			without_shift = "M";
			break;
		case "S":
			with_shift = "J";
			without_shift = "S";
			break;
		case "T":
			with_shift = "K";
			without_shift = "T";
			break;
		case "F":
			with_shift = "I";
			without_shift = "F";
			break;
		case "H":
			with_shift = "D";
			without_shift = "H";
			break;
		case ";":
			with_shift = "E";
			without_shift = ";";
			break;
		case "7":
			with_shift = "A";
			without_shift = "7";
			break;
		case "8":
			with_shift = "B";
			without_shift = "8";
			break;
		case "9":
			with_shift = "C";
			without_shift = "9";
			break;
		case "4":
			with_shift = "[";
			without_shift = "4";
			break;	
		case "5":
			with_shift = "]";
			without_shift = "5";
			break;		
		case "6":
			with_shift = " ";
			without_shift = "6";
			break;
		case "1":
			with_shift = ",";
			without_shift = "1";
			break;
		case "2":
			with_shift = "#";
			without_shift = "2";
			break;
		case "3":
			with_shift = "=";
			without_shift = "3";
			break;
		case "-":
			with_shift = "+";
			without_shift = "-";
			break;
		case "0":
			with_shift = "*";
			without_shift = "0";
			break;
		case ".":
			with_shift = "/";
			without_shift = ".";
			break;
		}
		
		if(Main.ProgMenu || Main.SettingMenu)
		{
			if(Main.SettingMenu && Main.OffSetOne)
			{
				Main.OffSetOne = false;
				Main.OffSetTwo = true;
			}
			if(Main.ProgEDITCusorPos < 335f)
			{
				if(Main.ShiftFlag)
				{
					Main.InputText += with_shift;
					Main.ShiftFlag = false;
				}
				else
				{
					Main.InputText += without_shift;
					Main.ShiftFlag = false;
				}
				Main.CursorText.text = Main.InputText;
				Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
				Main.ProgEDITCusorPos =57f + Main.InputTextSize.x;
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
