using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModeSelectModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	MoveControl MoveControl_script;
	CompileNC CompileNC_script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		CompileNC_script = gameObject.GetComponent<CompileNC>();
	}
	
	public void ModeSelectButton () 
	{
		GUI.DrawTexture(new Rect(215f/1000f*Main.width,655f/1000f*Main.height,182f/1000f*Main.width,83.9F/1000f*Main.height), Main.t2d_ModeSelect, ScaleMode.ScaleAndCrop, true, 2.17f);
		if (GUI.Button(new Rect(215f/1000f*Main.width, 716f/1000f*Main.height, 60f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "编辑";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectEDIT;
			PlayerPrefs.SetInt("ModeSelect", 1);
			Main.ProgEDIT = true;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		
		if (GUI.Button(new Rect(215f/1000f*Main.width, 693f/1000f*Main.height, 55f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "DNC";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectDNC;
			PlayerPrefs.SetInt("ModeSelect", 2);
			Main.ProgEDIT = false;
			Main.ProgDNC = true;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		if (GUI.Button(new Rect(222f/1000f*Main.width, 672f/1000f*Main.height, 58f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "AUTO";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectAUTO;
			PlayerPrefs.SetInt("ModeSelect", 3);
			//automode
			if(Main.ProgAUTO == false && Main.AutoProgName != Main.ProgramNum && Main.Code01 != "")
			{
				Main.AutoProgName = Main.ProgramNum;
				Debug.Log(Main.CodeForAll[0]);
				Debug.Log(Main.CodeForAll[1]);
				CompileNC_script.motionCode = new List<CodeClass>();
				CompileNC_script.CodeCompile(Main.CodeForAll);
				for(int i = 0; i < CompileNC_script.motionCode.Count; i++)
				{
					Debug.Log(CompileNC_script.motionCode[i]);
				}
				
			}
			Main.ProgEDIT =false;
			Main.ProgDNC = false;
			Main.ProgAUTO = true;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		if (GUI.Button(new Rect(280f/1000f*Main.width, 650f/1000f*Main.height, 20f/1000f*Main.width, 40f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "MDI";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectMDI;
			PlayerPrefs.SetInt("ModeSelect", 4);
			Main.ProgEDIT = false;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = true;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		if (GUI.Button(new Rect(302f/1000f*Main.width, 650f/1000f*Main.height, 15f/1000f*Main.width, 43f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "HAN";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectHANDLE;
			PlayerPrefs.SetInt("ModeSelect", 5);
			Main.ProgEDIT = false;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = true;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		if (GUI.Button(new Rect(317f/1000f*Main.width, 650f/1000f*Main.height, 50f/1000f*Main.width, 25f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "HAN";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectHANDLE;
			PlayerPrefs.SetInt("ModeSelect", 5);
			Main.ProgEDIT = false;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN =true;
			Main.ProgJOG = false;
			Main.ProgREF = false;
		}
		
		if (GUI.Button(new Rect(319f/1000f*Main.width, 674f/1000f*Main.height, 58f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "JOG";	
			Main.t2d_ModeSelect = Main.t2d_ModeSelectJOG;
			PlayerPrefs.SetInt("ModeSelect", 6);
			MoveControl_script.speed_to_move = 0.10201F;
			MoveControl_script.move_rate = Main.move_rate;
			Main.ProgEDIT = false;	
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = true;
			Main.ProgREF = false;
		}
		if (GUI.Button(new Rect(319f/1000f*Main.width, 698f/1000f*Main.height, 58f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.MenuDisplay = "REF";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectREF;
			PlayerPrefs.SetInt("ModeSelect", 7);
			MoveControl_script.speed_to_move = 0.60201F;
			MoveControl_script.move_rate = 1.0f;
			Main.ProgEDIT = false;
			Main.ProgDNC = false;	
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
