using UnityEngine;
using System.Collections;

public class ShowOuterSkin : MonoBehaviour {
	
	Transform outer_skin;
	string display = "Hide Outer Skin";
	// Use this for initialization
	void Start () {
		outer_skin = GameObject.Find("OuterSkin").transform;
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(0,0,120,30), display ))
		{
			if(display == "Hide Outer Skin")
			{
				display = "Show Outer Skin";
				foreach(Transform child in outer_skin)
				{
					child.renderer.enabled = false;
				}
			}
			else
			{
				display = "Hide Outer Skin";
				foreach(Transform child in outer_skin)
				{
					child.renderer.enabled = true;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
