using UnityEngine;
using System.Collections;

public class TopDialog : MonoBehaviour {

	// Use this for initialization
	Rect power_notifi_window3 = new Rect(Screen.width / 2, Screen.height / 2, 300, 100);
	void Start () {
	
	}
	
	void OnGUI () 
	{
		GUI.depth = -1;
		power_notifi_window3 = GUI.Window(3, power_notifi_window3, MyWindow3, "hello");
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
