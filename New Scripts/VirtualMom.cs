using UnityEngine;
using System.Collections;

public class VirtualMom : MonoBehaviour {
	AutoMove AutoMoveScript;

	// Use this for initialization
	void Start () {
		AutoMoveScript = gameObject.GetComponent<AutoMove>();
		
		Debug.Log(AutoMoveScript.line_direction);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
