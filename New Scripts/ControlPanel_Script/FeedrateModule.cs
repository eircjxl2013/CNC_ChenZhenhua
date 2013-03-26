using UnityEngine;
using System.Collections;

public class FeedrateModule : MonoBehaviour {
	ControlPanel Main;
	MoveControl MoveControl_script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
	}
	
	
	public void FeedrateSelect()
	{
		GUI.DrawTexture(new Rect(480f/1000f*Main.width,633f/1000f*Main.height,168.66f/1000f*Main.width,126.15f/1000f*Main.height), Main.t2d_feedrate, ScaleMode.ScaleAndCrop, true, 1.378f);
		if (GUI.Button(new Rect(455f/1000f*Main.width, 730f/1000f*Main.height, 60f/1000f*Main.width, 22f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_0;
			PlayerPrefs.SetInt("FeedrateSelect", 1);
			Main.move_rate = 0f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(455f/1000f*Main.width, 712f/1000f*Main.height, 60f/1000f*Main.width, 19f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_10;
			PlayerPrefs.SetInt("FeedrateSelect", 2);
			Main.move_rate = 0.1f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(460f/1000f*Main.width, 697/1000f*Main.height, 60f/1000f*Main.width, 15f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_20;
			PlayerPrefs.SetInt("FeedrateSelect", 3);
			Main.move_rate = 0.2f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(460f/1000f*Main.width, 682/1000f*Main.height, 60f/1000f*Main.width, 15f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_30;
			PlayerPrefs.SetInt("FeedrateSelect", 4);
			Main.move_rate = 0.3f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(463f/1000f*Main.width, 667/1000f*Main.height, 60f/1000f*Main.width, 15f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_40;
			PlayerPrefs.SetInt("FeedrateSelect", 5);
			Main.move_rate = 0.4f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(463f/1000f*Main.width, 647/1000f*Main.height, 40f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_40;
			PlayerPrefs.SetInt("FeedrateSelect", 5);
			Main.move_rate = 0.4f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(503f/1000f*Main.width, 647/1000f*Main.height, 25f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_50;
			PlayerPrefs.SetInt("FeedrateSelect", 6);
			Main.move_rate = 0.5f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(490f/1000f*Main.width, 627/1000f*Main.height, 30f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_50;
			PlayerPrefs.SetInt("FeedrateSelect", 6);
			Main.move_rate = 0.5f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(520f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_60;
			PlayerPrefs.SetInt("FeedrateSelect", 7);
			Main.move_rate = 0.6f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(528f/1000f*Main.width, 647/1000f*Main.height, 17f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_60;
			PlayerPrefs.SetInt("FeedrateSelect", 7);
			Main.move_rate = 0.6f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(545f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_70;
			PlayerPrefs.SetInt("FeedrateSelect", 8);
			Main.move_rate = 0.7f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(540f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_70;
			PlayerPrefs.SetInt("FeedrateSelect", 8);
			Main.move_rate = 0.7f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(560f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_80;
			PlayerPrefs.SetInt("FeedrateSelect", 9);
			Main.move_rate = 0.8f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(560f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_80;
			PlayerPrefs.SetInt("FeedrateSelect", 9);
			Main.move_rate = 0.8f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(580f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_90;
			PlayerPrefs.SetInt("FeedrateSelect", 10);
			Main.move_rate = 0.9f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(575f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_90;
			PlayerPrefs.SetInt("FeedrateSelect", 10);
			Main.move_rate = 0.9f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(590f/1000f*Main.width, 647/1000f*Main.height, 12f/1000f*Main.width, 25f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_100;
			PlayerPrefs.SetInt("FeedrateSelect", 11);
			Main.move_rate = 1.0f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(600f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 30f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_100;
			PlayerPrefs.SetInt("FeedrateSelect", 11);
			Main.move_rate = 1.0f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(602f/1000f*Main.width, 657/1000f*Main.height, 12f/1000f*Main.width, 25f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_110;
			PlayerPrefs.SetInt("FeedrateSelect", 12);
			Main.move_rate = 1.1f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(614f/1000f*Main.width, 657/1000f*Main.height, 25f/1000f*Main.width, 18f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_110;
			PlayerPrefs.SetInt("FeedrateSelect", 12);
			Main.move_rate = 1.1f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(602f/1000f*Main.width, 677/1000f*Main.height, 40f/1000f*Main.width, 19f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_120;
			PlayerPrefs.SetInt("FeedrateSelect", 13);
			Main.move_rate = 1.2f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(602f/1000f*Main.width, 696/1000f*Main.height, 45f/1000f*Main.width, 17f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_130;
			PlayerPrefs.SetInt("FeedrateSelect", 14);
			Main.move_rate = 1.3f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(602f/1000f*Main.width, 713/1000f*Main.height, 45f/1000f*Main.width, 17f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_140;
			PlayerPrefs.SetInt("FeedrateSelect", 15);
			Main.move_rate = 1.4f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		if (GUI.Button(new Rect(602f/1000f*Main.width, 730/1000f*Main.height, 45f/1000f*Main.width, 27f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			Main.t2d_feedrate = Main.t2d_FeedRate_150;
			PlayerPrefs.SetInt("FeedrateSelect", 16);
			Main.move_rate = 1.5f;
			MoveControl_script.move_rate = Main.move_rate;
		}
		//GUIUtility
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
