using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CodeClass 
{
	public int index = 0;	
	public List<string> im_execution = new List<string>();
	public bool move_flag = false;
	public string motion_str = "";
	public float x_value = 0;
	public float y_value = 0;
	public float z_value = 0;
	public float s_value = 0;
	public float f_value = 0;
	public string t_value = "";
	public CodeClass () 
	{
		index = 0;
		im_execution = new List<string>();
		move_flag = false;
		motion_str = ""; 
		x_value = 0;
		y_value = 0;
		z_value = 0;
		s_value = 0;
		f_value = 0;
		t_value = "";
	}
	
	public override string ToString ()
	{
		return "Index: "+index+"; "+"Motion: "+motion_str+"; "+"X:"+x_value+"; "+"Y:"+y_value+"; "+"Z:"+z_value+"; "+"S:"+s_value+"; "+"F:"+f_value+"; "+"T:"+t_value+"; ";
	}
}
