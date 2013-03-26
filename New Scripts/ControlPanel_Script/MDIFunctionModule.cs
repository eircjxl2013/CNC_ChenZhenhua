using UnityEngine;
using System.Collections;

public class MDIFunctionModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
	}
	
	public void Function () 
	{
		GUI.color = Color.cyan;
		//POS---------------------------------------------------------------------------------------------------
		if (GUI.Button(new Rect(600f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "POS"))            
		{
			if(Main.ScreenPower)
				PosButton();
		}
		
		//PROG---------------------------------------------------------------------------------------------------
		if (GUI.Button(new Rect(660f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "PROG"))            
		{
			if(Main.ScreenPower)
				ProgButton();
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "SET"))            
		{
			if(Main.ScreenPower)
				OffSettingsButton();
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "INPUT"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.SettingMenu)
				{
					if(Main.OffSetCoo && Main.OffSetTwo)
					{
						if(Main.InputText != "")
						{
							CooSystem_script.PlusInput(Main.InputText, false);
							Main.InputText = "";
							Main.CursorText.text = Main.InputText;
							Main.ProgEDITCusorPos = 57f;
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "SYSTEM"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(660f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "MESSAGE"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "ORPH"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 390f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "HELP"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		GUI.color = Color.white;
		if (GUI.Button(new Rect(900f/1000f*Main.width, 450f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "RESET"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
	}
	
	void PosButton () 
	{
		if(Main.ProgMenu)
		{
			Main.TempInputText = Main.InputText;
			Main.InputText = "";
			Main.CursorText.text = Main.InputText;
			Main.ProgEDITCusorPos = 57f;
		}
		
		if(Main.SettingMenu)
		{
			Main.OffSetTemp = Main.InputText;
			Main.InputText = "";
			Main.CursorText.text = Main.InputText;
			Main.ProgEDITCusorPos = 57f;
		}
		
		if(Main.PosMenu)
		{
			if(Main.AbsoluteCoo)
			{
				Main.AbsoluteCoo = false;
				Main.RelativeCoo = true;
				Main.GeneralCoo = false;
			}
			else if(Main.RelativeCoo)
			{
				Main.AbsoluteCoo = false;
				Main.RelativeCoo = false;
				Main.GeneralCoo = true;
			}
			else
			{
				Main.AbsoluteCoo = true;
				Main.RelativeCoo = false;
				Main.GeneralCoo = false;
			}
		}
		else
		{
			Main.PosMenu = true;
			Main.ProgMenu = false;
			Main.SettingMenu = false;
		}
	}
	
	void ProgButton ()
	{
		if(Main.PosMenu)
		{
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
			Main.ProgEDITCusorPos = 57f + Main.InputTextSize.x;
		}
		if(Main.SettingMenu)
		{
			Main.OffSetTemp = Main.InputText;
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
			Main.ProgEDITCusorPos = 57f + Main.InputTextSize.x;
		}
		Main.PosMenu = false;
		Main.SettingMenu = false;
		Main.ProgMenu = true;
	}
	
	void OffSettingsButton () {
		if(Main.PosMenu)
		{
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
			Main.ProgEDITCusorPos = 57f + Main.InputTextSize.x;
		}
		if(Main.ProgMenu)
		{
			Main.TempInputText = Main.InputText;
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
			Main.ProgEDITCusorPos = 57f + Main.InputTextSize.x;
		}
		Main.PosMenu = false;
		Main.SettingMenu = true;
		Main.ProgMenu = false;
		//CooSystem_script.ReadCooFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
