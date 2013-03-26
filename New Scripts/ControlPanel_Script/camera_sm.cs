using UnityEngine;
using System.Collections;

public class camera_sm : MonoBehaviour {

	// Use this for initialization
	Vector3 p,p1,axe;
	Vector3 old_p;
	public Vector3 center;
	Quaternion old_r;
	float old_field;
	Vector3 new1,old1;
//	public GameObject cen,empty;
	public bool locked;
	
	// Use this for initialization
	void Start () {
		
		old_p=this.transform.position;
		old_r=this.transform.rotation;
		old_field=camera.fieldOfView;
	//int x=Application.OpenURL("http://www.51cax.com/vt/authen.jsp?username=sunnytech&password=sunnytech&id=mold");
		//Debug.Log (x+"URL");
	//	empty=GameObject.FindGameObjectWithTag("empty");
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		
				if(Input.GetKey("z"))
			{
	
			transform.Rotate(Vector3.left*0.4f);
		//	Debug.Log ("forward");
			
			}
		
		
		if(Input.GetKey("x"))
			{

			transform.Rotate(Vector3.left*-0.4f);
		//	Debug.Log ("forward");
			
			}
			
		*/	
		
			
		
		
	
		
	}
	void OnGUI() {
		
		Event e=Event.current;
		//Debug.Log("Current event detected: " + Event.current.type+Input.GetMouseButton(0)+Input.GetMouseButton(1)+Input.GetMouseButton(2));
		float s1=15;
		float s2=5;
			
					//if(e.isMouse)
						if(Input.GetMouseButton(2)&&Input.GetMouseButton(1)==false)
							{		
						//		Debug.Log ("in");
								new1=Input.mousePosition;
								
								axe.x=e.delta.y;
								axe.y=e.delta.x;
								axe.z=0;
				//				axe.z=e.delta.x;
				//				axe.y=0;
								p=camera.transform.TransformDirection(axe);
			

		
							//if(axe.x==0&&axe.y==0)
							if(new1==old1)
									{
			
				
									}
							else{
								//	camera.transform.RotateAround(center, -p, 30* Time.deltaTime);
									//center=cen.transform.position;
				    float dist1 = Vector3.Distance(camera.transform.position, new Vector3(0,0,0));
		//	float zz= camera.transform.position.y/Mathf.Cos(camera.transform.rotation.z*3.14F/180);
	//			Debug.Log (zz+" "+(Mathf.Acos(0.5F)));
			//	  Vector3 pp = camera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, dist));
					Vector3 pp = camera.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2, dist1));
				
				float x=-camera.transform.position.y/(pp.y-camera.transform.position.y)*(pp.x-camera.transform.position.x)+camera.transform.position.x;
				
				float z=-camera.transform.position.y/(pp.y-camera.transform.position.y)*(pp.z-camera.transform.position.z)+camera.transform.position.z;
				Vector3 ss=new Vector3(x,0,z);
				float dist = Vector3.Distance(camera.transform.position, ss);
				pp = camera.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2, dist));
								//	camera.transform.RotateAround(center, p, 200* Time.deltaTime);
									camera.transform.RotateAround(pp, p, 10* 0.02F*s1);
								//	camera.transform.RotateAround(cen.transform.position, -p, 30* Time.deltaTime);
								}
			
			
								old1=new1;
		
		
		
							}
						if(Input.GetMouseButton(2)&&Input.GetMouseButton(1))
							{
			
								new1=Input.mousePosition;
								axe.x=e.delta.x;
								axe.y=-e.delta.y;
								axe.z=0;
		
								p=-axe.normalized;
							
								if(new1!=old1)
									transform.Translate(p*0.006F*1.0F*s2,Space.Self);
		
								old1=new1;
		
							}
		//camera.fieldOfView
		
							if (Input.GetAxis("Mouse ScrollWheel") != 0) 
								{
								//	Debug.Log ("wow"+Input.GetAxis("Mouse ScrollWheel"));
										if(camera.fieldOfView>1&&Input.GetAxis("Mouse ScrollWheel")<0)
											camera.fieldOfView+=Input.GetAxis("Mouse ScrollWheel")*1;
			
										if(Input.GetAxis("Mouse ScrollWheel")>0&&camera.fieldOfView<70)
											camera.fieldOfView+=Input.GetAxis("Mouse ScrollWheel")*1;
			
			
								}
		
				}
	
	
	void recover(){
		
		this.transform.position=old_p;
		this.transform.rotation=old_r;
		camera.fieldOfView=old_field;
		
		
	}
}
