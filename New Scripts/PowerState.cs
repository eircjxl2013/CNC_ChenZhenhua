using UnityEngine;
using System.Collections;

public class PowerState : MonoBehaviour {

	// Use this for initialization
	Rect power_notifi_window2 = new Rect(0, 0, 200f, 100f); 
	public GUIStyle ScreenCull;
	void Start () {
	
	}
	
	void OnGUI () 
	{
		//GUI.depth = 0;
		power_notifi_window2 = GUI.Window(2, power_notifi_window2, MyWindow3, "hello");
		GUI.Box(new Rect(0,0,Screen.width, Screen.height), "");
		if(GUI.Button(new Rect(500,500,100, 50),""))
		{
			Debug.Log("small");
		}
		
		if(GUI.Button(new Rect(0,0,Screen.width, Screen.height),""))
		{
			Event.current.Use();
			Debug.Log("big");
		}
		
		//GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 400f, 200f), "Hello");
	}
	
	void MyWindow3 (int WindowID)
	{
		
		GUI.Label(new Rect(20,20,100,100), "Hello!!!!!!!!");
		GUI.DragWindow();
		if(GUI.Button(new Rect(40,40,100,20), "sdf"))
			Debug.Log("dgyj");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
