using UnityEngine;
using System.Collections;

public class SpindleControl : MonoBehaviour {
	
	public AudioClip spindle_sound;
	public Transform spindle;
	public float rotate_rate = 1f;
	public float speed_to_rotate = 3000f;	
	public bool rotate_flag = false;
	public bool cw_rotate_flag = true;
	public bool audio_flag = false;
	
	void Awake () {
		
	}

	// Use this for initialization
	void Start () {
		spindle = GameObject.Find("rotate_axis").transform;
		spindle_sound = (AudioClip)Resources.Load("Audio/spn");
	}
	
	public void SpindleSoundOff () {
		audio.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if(rotate_flag)
		{
			if(cw_rotate_flag)
			{
				spindle.Rotate(0, speed_to_rotate*Time.deltaTime, 0);	
			}
			else
			{
				spindle.Rotate(0, -speed_to_rotate*Time.deltaTime, 0);
			}
			if(audio_flag == false)
			{
				audio_flag = true;
				audio.Play();
			}
		}
	}
}
