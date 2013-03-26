using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {
	
	public AudioClip move_sound;
	ControlPanel ControlPanel_Script;
	public Transform X_part;
	public Transform Y_part;
	public Transform Z_part;

	public float move_rate = 1f;
	public float speed_to_move = 0.10201F;
	
	public Vector3 MachineZero = new Vector3(0.0288153f,1.301697f,-0.918393f);
	public Vector3 MachineZeroShift = new Vector3(-0.918393f,0.0288153f,1.301697f);
	public Vector3 MachinePoint = new Vector3(800f,500f,510f);
	public Vector3 MachineCoo = new Vector3(800f,500f,510f);
	
	public bool x_p = false;
	public bool x_n = false; 
	public bool y_p = false;
	public bool y_n = false;
	public bool z_p = false;
	public bool z_n = false;
	
	bool move_sound_on = false;
	int sound_stop = 3;
	int sound_be4 = 3;
	
	void Awake () {
		
	}

	// Use this for initialization
	void Start () {
		X_part = GameObject.Find("X_axis").transform;
		Y_part = GameObject.Find("Y_axis").transform;
		Z_part = GameObject.Find("Z_axis").transform;
		move_sound = (AudioClip)Resources.Load("Audio/move");
		ControlPanel_Script = GameObject.Find("MainScript").GetComponent<ControlPanel>();
	}
	
	void OnGUI () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sound_stop = 0;
		
		if(x_p)
			X_part.Translate(0,0,speed_to_move*Time.deltaTime*move_rate);
		
		if(x_n)
			X_part.Translate(0,0,-speed_to_move*Time.deltaTime*move_rate);
		
		if(y_p)
			Y_part.Translate(-speed_to_move*Time.deltaTime*move_rate,0,0);
		
		if(y_n)
			Y_part.Translate(speed_to_move*Time.deltaTime*move_rate,0,0);
		
		if(z_p)
			Z_part.Translate(0,speed_to_move*Time.deltaTime*move_rate,0);
		
		if(z_n)
			Z_part.Translate(0,-speed_to_move*Time.deltaTime*move_rate,0);
		
		if(MachineZero.z - X_part.position.z <= 0)
		{
			X_part.position = new Vector3(X_part.position.x, X_part.position.y, MachineZero.z);
			MachineCoo.x = 800f;
			x_p = false;
		}
		else
			MachineCoo.x = 800f-(MachineZero.z - X_part.position.z)*1000;
		
		if(MachineZero.z - X_part.position.z >= 0.8f)
		{
			X_part.position = new Vector3(X_part.position.x, X_part.position.y, MachineZero.z-0.8f);
			MachineCoo.x = 0;
		}
		else
			MachineCoo.x = 800f-(MachineZero.z - X_part.position.z)*1000;
		
		if(Y_part.position.x - MachineZero.x <= 0)
		{
			Y_part.position = new Vector3(MachineZero.x, Y_part.position.y, Y_part.position.z);
			MachineCoo.y = 500f;
			y_p = false;
		}
		else
			MachineCoo.y = 500f-(Y_part.position.x - MachineZero.x)*1000;
		
		if(Y_part.position.x - MachineZero.x >= 0.5f)
		{
			Y_part.position = new Vector3(MachineZero.x + 0.5f, Y_part.position.y, Y_part.position.z);
			MachineCoo.y = 0f;
		}
		else
			MachineCoo.y = 500f-(Y_part.position.x - MachineZero.x)*1000;
		
		if(MachineZero.y - Z_part.position.y <= 0)
		{
			Z_part.position = new Vector3(Z_part.position.x, MachineZero.y, Z_part.position.z);
			MachineCoo.z = 510f;
			z_p = false;
		}
		else
			MachineCoo.z = 510f-(MachineZero.y - Z_part.position.y)*1000;
		
		if(MachineZero.y - Z_part.position.y >= 0.51f)
		{
			Z_part.position = new Vector3(Z_part.position.x, MachineZero.y - 0.51f, Z_part.position.z);
			MachineCoo.z = 0f;
		}
		else
			MachineCoo.z = 510f-(MachineZero.y - Z_part.position.y)*1000;
		
		if((x_n||x_p||y_n||y_p||z_n||z_p) && move_sound_on == false)
		{
			move_sound_on = true;
			audio.Play();
		}
		
		if(Mathf.Approximately(MachineCoo.x,800f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.x,0f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.y,500f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.y,0f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.z,510f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.z,0f))
		{
			sound_stop++;
		}
		
		if((Input.GetMouseButtonUp(0) && ControlPanel_Script.ProgREF == false)||(sound_stop > sound_be4))
		{
			audio.Stop();
			move_sound_on = false;
		}
		
		sound_be4 = sound_stop;
		
		if(x_n||x_p||y_n||y_p||z_n||z_p)
			move_sound_on = true;
		else
			move_sound_on = false;
	}
}
