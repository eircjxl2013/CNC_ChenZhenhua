using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CompileNC : MonoBehaviour 
{
	CooSystem CooSystem_script;
	MoveControl MoveControl_script;
	public List<CodeClass> motionCode = new List<CodeClass>();
	CodeClass temp_code_info = new CodeClass();
	InitialParameter system_initial_para = new InitialParameter();

	Vector3 coo_machine_current = new Vector3(0,0,0);
	Vector3 coo_machine_togo = new Vector3(0,0,0);
	Vector3 coo_ext = new Vector3(0,0,0);
	Vector3 coo_workpiece = new Vector3(0,0,0);
	float G00_Move_speed = 0.10201f;
	
	void Awake () 
	{
	}
	
	void Start ()
	{
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
	}
	
	public void CodeCompile (List<string> CodeOfAll)
	{
		try
		{
			coo_machine_current = MoveControl_script.MachineCoo;
			if(motionCode.Count == 0)
				coo_machine_togo = new Vector3(0,0,0);
			else
				coo_machine_togo = new Vector3(motionCode[motionCode.Count - 1].x_value, motionCode[motionCode.Count - 1].y_value, motionCode[motionCode.Count - 1].z_value);
			for(int i = 0; i < CodeOfAll.Count; i++)
			{
				temp_code_info = new CodeClass();
				temp_code_info.index = i;
				if(CodeOfAll[i] == "")
				{
					temp_code_info.move_flag = false;
					motionCode.Add(temp_code_info);
					continue;
				}
				if(CodeOfAll[i].StartsWith("%") || CodeOfAll[i].StartsWith("O"))
				{
					temp_code_info.move_flag = false;
					motionCode.Add(temp_code_info);
					continue;
				}
				bool SpaceFlag = false;
				List<string> CalStr = new List<string>();
				Regex rule = new Regex(@"([A-Z]+[^A-Z^\s]+)+");
				Match match = rule.Match(CodeOfAll[i]);
				if(match.Groups.Count > 1)
				{
					for(int j = 0; j < match.Groups[1].Captures.Count; j++)
					{
						CalStr.Add(match.Groups[1].Captures[j].Value);
					}
				}
				for(int j = 0; j < CalStr.Count; j++)
				{
					SpaceFlag = false;
					switch(CalStr[j])
					{
					case "G17":
						system_initial_para.plane_choose = 0;
						SpaceFlag = true;
						break;
					case "G18":
						system_initial_para.plane_choose = 1;
						SpaceFlag = true;
						break;
					case "G19":
						system_initial_para.plane_choose = 2;
						SpaceFlag = true;
						break;
					case "G20":
						system_initial_para.unitmode = false;
						SpaceFlag = true;
						break;
					case "G21":
						system_initial_para.unitmode = true;
						SpaceFlag = true;
						break;
					case "G40":
						system_initial_para.makeup_right_left = 0;
						SpaceFlag = true;
						break;
					case "G41":
						system_initial_para.makeup_right_left = 1;
						SpaceFlag = true;
						break;
					case "G42":
						system_initial_para.makeup_right_left = 2;
						SpaceFlag = true;
						break;
					case "G43":
						system_initial_para.makeup_positive_negative = 1;
						SpaceFlag = true;
						break;
					case "G44":
						system_initial_para.makeup_positive_negative = 2;
						SpaceFlag = true;
						break;
					case "G49":
						system_initial_para.makeup_positive_negative = 0;
						SpaceFlag = true;
						break;
					case "G54":
						CooSystem_script.workpiece_flag = 1;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G55":
						CooSystem_script.workpiece_flag = 2;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G56":
						CooSystem_script.workpiece_flag = 3;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G57":
						CooSystem_script.workpiece_flag = 4;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G58":
						CooSystem_script.workpiece_flag = 5;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G59":
						CooSystem_script.workpiece_flag = 6;
						CooSystem_script.Workpiece_Change();
						SpaceFlag = true;
						break;
					case "G90":
						system_initial_para.absolute_relative = true;
						SpaceFlag = true;
						break;
					case "G91":
						system_initial_para.absolute_relative = false;
						SpaceFlag = true;
						break;
					default:
						break;
					}
					if(SpaceFlag)
					{
						CalStr.RemoveAt(j);
						j--;
						continue;
					}
					
					char[] codefield = CalStr[j].ToCharArray();
					
					switch(codefield[0])
					{
					case 'G':
						Gcode_Compile(CalStr[j], ref temp_code_info);
						break;
					case 'M':
						Mcode_Compile(CalStr, CalStr[j], ref temp_code_info);
						break;	
					case 'F':
						string f_num = "";
						for(int k = 1; k < codefield.Length; k++)
						{
							f_num += codefield[k];
						}
						if(NumFormatCheck(f_num) == false || float.Parse(f_num) < 0)
						{
							Debug.Log("Number format is not correct. Please check your code on Line: " +"\""+(i+(int)1)+"\"");
							return;
						}
						temp_code_info.f_value = float.Parse(f_num);
						system_initial_para.feed_rate = float.Parse(f_num);
						break;
						
					case 'S':
						string s_num = "";
						for(int k = 1; k < codefield.Length; k++)
						{
							s_num += codefield[k];
						}
						if(NumFormatCheck(s_num) == false || float.Parse(s_num) < 0)
						{
							Debug.Log("Number format is not correct. Please check your code on Line: " +"\""+(i+(int)1)+"\"");
							return;
						}
						temp_code_info.s_value = float.Parse(s_num);
						system_initial_para.rotate_speed = float.Parse(s_num);
						break;
						
					case 'T':
						temp_code_info.im_execution.Add(CalStr[j]);
						system_initial_para.tool_num = CalStr[j];
						temp_code_info.t_value = CalStr[j];
						break;
						
					case 'X':
						string x_num = "";
						for(int k = 1; k < codefield.Length; k++)
						{
							x_num += codefield[k];
						}
						if(NumFormatCheck(x_num) == false)
						{
							Debug.Log("Number format is not correct. Please check your code on Line: " +"\""+(i+(int)1)+"\"");
							return;
						}
						XYZ_Compile(CalStr, j, i +1, x_num, 'X', ref temp_code_info);
						break;
						
					case 'Y':
						string y_num = "";
						for(int k = 1; k < codefield.Length; k++)
						{
							y_num += codefield[k];
						}
						if(NumFormatCheck(y_num) == false)
						{
							Debug.Log("Number format is not correct. Please check your code on Line: " +"\""+(i+(int)1)+"\"");
							return;
						}
						XYZ_Compile(CalStr, j, i +1, y_num, 'Y', ref temp_code_info);
						break;
						
					case 'Z':
						string z_num = "";
						for(int k = 1; k < codefield.Length; k++)
						{
							z_num += codefield[k];
						}
						if(NumFormatCheck(z_num) == false)
						{
							Debug.Log("Number format is not correct. Please check your code on Line: " +"\""+(i+(int)1)+"\"");
							return;
						}
						XYZ_Compile(CalStr, j, i +1, z_num, 'Z', ref temp_code_info);
						break;
						
					case 'I':
						//yo
						break;
						
					case 'J':
						//yo
						break;
						
					case 'K':
						//yo
						break;
						
					case 'H':
						//yo
						break;
						
					case 'D':
						//yo
						break;
						
					case 'P':
						//yo
						break;
						
					case 'R':
						//yo
						break;
						
					case 'L':
						//yo
						break;
						
					case 'N':
						break;
						
					default:
						Debug.Log(CalStr[j]);
						Debug.Log(CodeOfAll[i]);
						break;
					}
				}
				temp_code_info.s_value = system_initial_para.rotate_speed;
				temp_code_info.t_value = system_initial_para.tool_num;
				if(temp_code_info.move_flag)
				{
					if(temp_code_info.motion_str == "G00")
						temp_code_info.f_value = G00_Move_speed;
					else
						temp_code_info.f_value = system_initial_para.feed_rate;
					
					if(temp_code_info.s_value == 0 && temp_code_info.motion_str != "G00")
						Debug.Log("Wrong! Tool rotate speed is not specified on code line:  "+"\""+(i+(int)1)+"\"");
					if(temp_code_info.f_value == 0)
						Debug.Log("Wrong! Feed Rate is not specified on code line:  "+"\""+(i+(int)1)+"\"");
				}
				//代码解析
				/*
				if(move_mode == -1)
					temp_code_info.movemode = motionCode[motionCode.Count - 1].movemode;
				else
					temp_code_info.movemode = move_mode;
			*/
				Debug.Log("end: " + i);
				motionCode.Add(temp_code_info);
			}
		}
		catch
		{
			Debug.Log("Exception");
		}
		finally
		{
			Debug.Log("ok");
		}
		
		
	}
	
	
	
	
	void Mcode_Compile (List<string> targetRow, string m_code, ref CodeClass temp_code_class) {
		
		try{
			switch(m_code){
			case "M03":
			case "M3":
				temp_code_class.im_execution.Add("M03");
				break;
			case "M06":
			case "M6":
				temp_code_class.im_execution.Add("M06");
				break;
			default:
				Debug.Log("M code to go!");
				break;
			}
		}
		catch{
			Debug.Log("M code Exception!");
		}
		finally{
			
		}
		
	}
	
	void Gcode_Compile (string g_code, ref CodeClass temp_code_class) {
		
		try{
			switch(g_code){
			case "G00":
			case "G0":
				system_initial_para.start_gcode = "G00";
				temp_code_class.move_flag = true;
				temp_code_info.motion_str = "G00";
				break;
				
			case "G01":
			case "G1":
				system_initial_para.start_gcode = "G01";
				temp_code_class.move_flag = true;
				temp_code_info.motion_str = "G01";
				break;
				
			case "G02":
			case "G2":
				system_initial_para.start_gcode = "G02";
				temp_code_class.move_flag = true;
				temp_code_info.motion_str = "G02";
				break;
				
			case "G03":
			case "G3":
				system_initial_para.start_gcode = "G03";
				temp_code_class.move_flag = true;
				temp_code_info.motion_str = "G03";
				break;
				
			default:
				Debug.Log("Unkonw G code   "+"\""+g_code+"\"");
				break;
			}
		}
		catch{
			
		}
		finally{
			
		}
		
	}
	
	void XYZ_Compile (List<string> code_segment, int index,  int code_line, string value_str, char xyz, ref CodeClass temp_code_class)
	{
		for(int i = index  + 1; i < code_segment.Count; i++)
		{
			switch(code_segment[index])
			{
			case "G00":
			case "G0":
			case "G01":
			case "G1":
			case "G02":
			case "G2":
			case "G03":
			case "G3":
				Debug.Log("Warning! X,Y,Z code appears before G code. It may cause mistakes in coordinate. Please check your program on Line: "+code_line+" !");
				break;
			default:
				break;
			}
		}
		float xyz_value = float.Parse(value_str);
		switch (system_initial_para.start_gcode)
		{
		case "G0":
		case "G1":
		case "G00":
		case "G01":
			if(xyz == 'X')
			{
				coo_machine_togo.x = xyz_value+CooSystem_script.G00_pos.x+CooSystem_script.workpiece_coo.x;
			}
			else if(xyz == 'Y')
			{
				coo_machine_togo.y = xyz_value+CooSystem_script.G00_pos.y+CooSystem_script.workpiece_coo.y;
			}
			else
			{
				coo_machine_togo.z = xyz_value+CooSystem_script.G00_pos.z+CooSystem_script.workpiece_coo.z;
			}
			temp_code_class.x_value = coo_machine_togo.x;
			temp_code_class.y_value = coo_machine_togo.y;
			temp_code_class.z_value = coo_machine_togo.z;
			temp_code_class.move_flag = true;
			temp_code_class.motion_str = system_initial_para.start_gcode;
			break;
			
		case "G2":
		case "G02":
			
			break;
			
		default:
			break;
		}
		
	}
	
	bool NumFormatCheck (string value_str) 
	{
		char[] num_array = value_str.ToCharArray();
		if(num_array.Length == 1 && (num_array[0] == '.' || num_array[0] == '-' || num_array[0] == '+'))
			return false;
		else
		{
			for(int i = 0; i < num_array.Length; i++)
			{
				if(num_array[i] != '.'  && num_array[i] != '+' && num_array[i] != '-')
				{
					if(num_array[i] < '0' || num_array[i] > '9')
						return false;
				}
				else if(num_array[i] == '+' || num_array[i] == '-')
				{
					if(i != 0)
						return false;
				}
			}
			return true;
		}	
	
	}
	

	
}

class InitialParameter {
	public string start_gcode = "G00";
	public float feed_rate = 0;
	public float rotate_speed = 0;
	public string tool_num = "";
	
	public int plane_choose = 0;//0:XY平面； 1:ZX平面； 2:YZ平面
	public bool unitmode = true;         //true:公制； false:英制
	public bool absolute_relative = true;//true:绝对坐标系； false:相对坐标系
	public float makeup_radius = 0;     //刀具半径补偿；
	public int makeup_right_left = 0;   //0:没有补偿； 1:左补偿； 2:右补偿
	public float makeup_length = 0;     //刀具长度补偿；
	public int makeup_positive_negative = 0;  //0:没有补偿； 1:正补偿； 2:负补偿
	
}


