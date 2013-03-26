using UnityEngine;
using System.Collections;

public class MachineFunctionModule : MonoBehaviour {
	ControlPanel Main;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
	}
	
	public void MachineFunction ()
	{
		if (GUI.Button(new Rect(680f/1000f*Main.width, 640f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "MLK"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(750f/1000f*Main.width, 640f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "DRN"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(820f/1000f*Main.width, 640f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "BDT"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(890f/1000f*Main.width, 640f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "SBK"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		
		
		if (GUI.Button(new Rect(680f/1000f*Main.width, 700f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "OSP"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(750f/1000f*Main.width, 700f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "ZLOCK"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if(GUI.Button(new Rect(820f/1000f*Main.width, 700f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), ""))
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if(GUI.Button(new Rect(890f/1000f*Main.width, 700f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), ""))
		{
			if(Main.ScreenPower)
			{
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
