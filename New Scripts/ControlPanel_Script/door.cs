using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	
	bool enter;
	bool move;
	GameObject target;
	float speed;
	
	
	void Start () {
		target = this.gameObject;
		speed=0.08F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(enter==true)
			{
				move=true;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			move=false;
		}
		
		
		if(move)
		{
			float h =  Input.GetAxis("Mouse X"); 
		
			target.transform.Translate(new Vector3(0,0,1f)*h*speed,Space.Self);
		}
		
		if(this.name == "door_left")
		{
			if(target.transform.position.z >= 0.01470597f)
				target.transform.position = new Vector3(target.transform.position.x , target.transform.position.y, 0.01470597f);
			
			if(target.transform.position.z <= -0.5059499f)
				target.transform.position = new Vector3(target.transform.position.x , target.transform.position.y, -0.5059499f);
		}
		
		if(this.name == "door_right")
		{
			if(target.transform.position.z >= -1.091452f)
				target.transform.position = new Vector3(target.transform.position.x , target.transform.position.y, -1.091452f);
			
			if(target.transform.position.z <= -1.58747f)
				target.transform.position = new Vector3(target.transform.position.x , target.transform.position.y, -1.58747f);
		}
		
		
	
	}
	void OnGUI()
	{
		//GUI.Label(new Rect(100,100,100,100),hideFlags.ToString());
	}
	
	void OnMouseEnter() 
	{
        enter=true;
    }
	
	void OnMouseExit() 
	{
        enter=false;
    }
}
