using UnityEngine;
using System.Collections;

public class AuxiliaryFunctionModule : MonoBehaviour {
	ControlPanel Main;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
	}
	
	public void AuxiliaryFunction ()
	{
		if (GUI.Button(new Rect(280f/1000f*Main.width, 790f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "COOL"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(340f/1000f*Main.width, 790f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
			{
				
			}
		};
		
		if (GUI.Button(new Rect(400f/1000f*Main.width, 790f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "MHS"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}

		if (GUI.Button(new Rect(280f/1000f*Main.width, 850f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "ATCW"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(340f/1000f*Main.width, 850f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "ATCCW"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(400f/1000f*Main.width, 850f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "MHRN"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}

		if (GUI.Button(new Rect(280f/1000f*Main.width, 910f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "FOR"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if (GUI.Button(new Rect(340f/1000f*Main.width, 910f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "BACK"))            
		{
			if(Main.ScreenPower)
			{
				
			}
		}
		
		if(GUI.Button(new Rect(400f/1000f*Main.width, 910f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), ""))
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
