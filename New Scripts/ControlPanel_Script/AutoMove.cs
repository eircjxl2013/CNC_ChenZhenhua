using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {
	MoveControl MoveControlScript;
	public AudioClip move_sound;
	public Transform rotate_ref;
	public Transform round_dot_transform;
	
	public Vector3 line_direction = new Vector3(30f,20f,510f);
	Vector3 final_pos = new Vector3(0,0,0);
	Vector3 X_move_vector = new Vector3(0,0,0);
	Vector3 Y_move_vector = new Vector3(0,0,0);
	Vector3 Z_move_vector = new Vector3(0,0,0);
	Vector3 X_original_pos = new Vector3(0,0,0);
	Vector3 Y_original_pos = new Vector3(0,0,0);
	Vector3 Z_original_pos = new Vector3(0,0,0);
	
	Vector3 round_dot = new Vector3(180f,0,510f);
	Vector3 rotate_start = new Vector3(0,0,0);
	Vector3 rotate_end = new Vector3(300f,0,510f);
	float rotate_degree = 0f;
	
	bool X_move_flag = false;
	bool Y_move_flag = false;
	bool Z_move_flag = false;
	bool sound_flag = false;
	bool rotate_flag = false;
	bool rotate_cw = true;

	public float move_rate = 1f;
	float auto_speed_to_move = 0.201F;
	float time_value = 0f;
	float delta_time = 0f;
	
	/*
	private float rotAngle = 0;    
	private Vector2 pivotPoint;
	*/
	void Awake () 
	{
		//Debug.Log(Vector3.Angle(new Vector3(1,0,0), new Vector3(-1,-1,0)));
	}
	// Use this for initialization
	void Start () 
	{
		MoveControlScript = GameObject.Find("move_control").GetComponent<MoveControl>();
		rotate_ref = GameObject.Find("rotate_ref").transform;
		round_dot_transform = GameObject.Find("zero").transform;
		move_sound = (AudioClip)Resources.Load("Audio/move");
	}
	
	void OnGUI () 
	{
		if(GUI.Button(new Rect(10,10,100,50), "Punch"))
		{
			StartCoroutine(MainRun_Virtual(line_direction));
		}
		if(GUI.Button(new Rect(10,70,100,40), "R"))
		{
			StartCoroutine(Rotate_Entrance_Virtual(new Vector3(180,0,510), 180, true));
		}
		
		if(GUI.Button(new Rect(10,120,100,40), "Set 0"))
		{
			Set_Pos_Ref(new Vector3(0,0,0));
		}
		
		/*
		pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);        
		GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);        
		if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), "Rotate"))            
			rotAngle += 10;
		*/
	}
	
	IEnumerator MainRun_Real (Vector3 target_pos)
	{
		time_value = Get_Time_Value(target_pos - Get_Current_RealPos());
		Get_move_vector_from_real(target_pos);
		delta_time = 0f;
		if(Mathf.Approximately(X_move_vector.magnitude, 0) == false)
			X_move_flag = true;
	    if(Mathf.Approximately(Y_move_vector.magnitude, 0) == false)
			Y_move_flag = true;
		if(Mathf.Approximately(Z_move_vector.magnitude, 0) == false)
			Z_move_flag = true;
		yield return StartCoroutine(Timer(time_value));
		Set_Real_Pos(target_pos);
	}
	
	IEnumerator MainRun_Virtual (Vector3 target_pos)
	{
		time_value = Get_Time_Value(Virtual_To_RealPos(target_pos) - Get_Current_RealPos());
		Get_move_vector_from_virtual(target_pos);
		delta_time = 0f;
		if(Mathf.Approximately(X_move_vector.magnitude, 0) == false)
			X_move_flag = true;
	    if(Mathf.Approximately(Y_move_vector.magnitude, 0) == false)
			Y_move_flag = true;
		if(Mathf.Approximately(Z_move_vector.magnitude, 0) == false)
			Z_move_flag = true;
		yield return StartCoroutine(Timer(time_value));
		Set_Virtual_Pos(target_pos);
	}
	
	IEnumerator Rotate_Entrance_Virtual (Vector3 rounddot, float roatatedegree, bool cw)
	{
		Set_Round_Dot(rounddot);
		rotate_cw = cw;
		rotate_flag = true;
		yield return StartCoroutine(Timer(6f));
		Set_Virtual_Pos(rotate_end);
	}
	
	IEnumerator Timer (float timevalue) 
	{
		yield return new WaitForSeconds(timevalue);
		X_move_flag = false;
		Y_move_flag = false;
		Z_move_flag = false;
		rotate_flag = false;
	}
	
	float Get_Time_Value (Vector3 move_vector) {
		return move_vector.magnitude/auto_speed_to_move;
	}
	
	void Get_move_vector_from_real (Vector3 target_vector) 
	{
		Vector3 move_vector = target_vector - Get_Current_RealPos();
		X_move_vector = new Vector3(0,0,move_vector.x)/time_value;
		Y_move_vector = new Vector3(move_vector.y,0,0)/time_value;
		Z_move_vector = new Vector3(0,move_vector.z,0)/time_value;
		X_original_pos = MoveControlScript.X_part.position;
		Y_original_pos = MoveControlScript.Y_part.position;
		Z_original_pos = MoveControlScript.Z_part.position;
	}
	
	void Get_move_vector_from_virtual (Vector3 target_vector) 
	{
		target_vector = Virtual_To_RealPos(target_vector);
		Get_move_vector_from_real(target_vector);
	}
	
	Vector3 Virtual_To_RealPos (Vector3 show_pos) 
	{
		Vector3 real_pos = new Vector3(0,0,0);
		Vector3 TempVector = (show_pos - MoveControlScript.MachinePoint)/1000;
		real_pos.x = MoveControlScript.MachineZero.z + TempVector.x;
		real_pos.y = MoveControlScript.MachineZero.x - TempVector.y;
		real_pos.z = MoveControlScript.MachineZero.y + TempVector.z;
		return real_pos;
	}
	
	Vector3 Real_To_VirtualPos (Vector3 real_pos) 
	{
		Vector3 TempVector = (real_pos - MoveControlScript.MachineZeroShift)*1000;
		Vector3 virtual_pos = new Vector3(TempVector.x, -TempVector.y, TempVector.z);
		virtual_pos += MoveControlScript.MachinePoint;
		return virtual_pos;
	}
	
	Vector3 Get_Current_RealPos () 
	{
		Vector3 real_pos = new Vector3(0,0,0);
		real_pos.x = MoveControlScript.X_part.position.z;
		real_pos.y = MoveControlScript.Y_part.position.x;
		real_pos.z = MoveControlScript.Z_part.position.y;
		return real_pos;
	}
	
	Vector3 Get_Current_VirtualPos () 
	{
		Vector3 vitual_pos = new Vector3(0,0,0);
		vitual_pos.x = MoveControlScript.X_part.position.z;
		vitual_pos.y = MoveControlScript.Y_part.position.x;
		vitual_pos.z = MoveControlScript.Z_part.position.y;
		vitual_pos = Real_To_VirtualPos(vitual_pos);
		return vitual_pos;
	}
	
	void Set_Virtual_Pos (Vector3 virtual_pos) 
	{
		Vector3 real_pos = Virtual_To_RealPos(virtual_pos);
		Set_Real_Pos (real_pos);
	}
	
	void Set_Real_Pos (Vector3 real_pos) 
	{
		MoveControlScript.X_part.position = new Vector3(MoveControlScript.X_part.position.x, MoveControlScript.X_part.position.y, real_pos.x);
		MoveControlScript.Y_part.position = new Vector3(real_pos.y, MoveControlScript.Y_part.position.y, MoveControlScript.Y_part.position.z);
		MoveControlScript.Z_part.position = new Vector3(MoveControlScript.Z_part.position.x, real_pos.z, MoveControlScript.Z_part.position.z);
	}
	
	void Set_Ref_Virtual (Vector3 virtual_point)
	{
		rotate_ref.position = new Vector3(MoveControlScript.MachineCoo.y/1000, MoveControlScript.MachineCoo.z/1000, -MoveControlScript.MachineCoo.x/1000);
	}
	
	void Set_Pos_Ref (Vector3 ref_vector) 
	{
		Vector3 virtual_pos = new Vector3(-ref_vector.z*1000, ref_vector.x*1000, ref_vector.y*1000);
		Set_Virtual_Pos(virtual_pos);
	}
	
	void Set_Round_Dot (Vector3 rounddot)
	{
		round_dot_transform.position = new Vector3(rounddot.y/1000, rounddot.z/1000, -rounddot.x/1000);
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if((X_move_flag||Y_move_flag||Z_move_flag||rotate_flag) && sound_flag == false)
		{
			audio.Play();
			sound_flag = true;
		}
		if(rotate_flag == false)
			Set_Ref_Virtual(MoveControlScript.MachineCoo);
		
		delta_time += Time.deltaTime;
		
		if(X_move_flag)
		{
			MoveControlScript.X_part.position = new Vector3(MoveControlScript.X_part.position.x , MoveControlScript.X_part.position.y, X_original_pos.z + X_move_vector.z*delta_time);
		}
		
		if(Y_move_flag)
		{
			MoveControlScript.Y_part.position = new Vector3(Y_original_pos.x + Y_move_vector.x*delta_time, Y_original_pos.y, Y_original_pos.z);
		}
		
		if(Z_move_flag)
		{
			MoveControlScript.Z_part.position = new Vector3(Z_original_pos.x, Z_original_pos.y + Z_move_vector.y*delta_time, Z_original_pos.z);
		}
		
		if(rotate_flag)
		{
			if(rotate_cw)
				rotate_ref.transform.RotateAround(round_dot_transform.position, Vector3.up, 30f*Time.deltaTime);
			else
				rotate_ref.transform.RotateAround(round_dot_transform.position, Vector3.down, 30f*Time.deltaTime);
			
			Set_Pos_Ref(rotate_ref.position);
		}
		
		if(!(X_move_flag||Y_move_flag||Z_move_flag||rotate_flag))
		{
			audio.Stop();
			sound_flag = false;
		}
	}
}
