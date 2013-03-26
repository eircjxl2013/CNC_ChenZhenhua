using UnityEngine;
using System.Collections;
using System.IO;

public class CooSystem : MonoBehaviour {
	
	ControlPanel ControlPanel_script;
	MoveControl MoveControl_script;
	public Vector3 absolute_pos = new Vector3(0,0,0);
	public Vector3 relative_pos = new Vector3(0,0,0);
	public int workpiece_flag = 1;
	
	public Vector3 G00_pos = new Vector3(0,0,0);
	public Vector3 G54_pos = new Vector3(0,0,0);
	public Vector3 G55_pos = new Vector3(0,0,0);
	public Vector3 G56_pos = new Vector3(0,0,0);
	public Vector3 G57_pos = new Vector3(0,0,0);
	public Vector3 G58_pos = new Vector3(0,0,0);
	public Vector3 G59_pos = new Vector3(0,0,0);
	public Vector3 workpiece_coo = new Vector3(0,0,0);
		//设置界面里面的参数
	public string parameter = "0";
	public string TV = "0";
	public string CKJC = "0";
	public string input_unit = "0";
	public string IO = "0";
	public string order = "0";
	public string zhidai = "0";
	public string order_stop1 = "0";
	public string order_stop2 = "0";
	//设置界面里面的参数

	void Awake () {
		
	}
	
	// Use this for initialization
	void Start () {
		ControlPanel_script = gameObject.GetComponent<ControlPanel>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		ReadCooFile();
		workpiece_coo = G54_pos;
		workpiece_flag = 1;
		
		
		//获得设置界面显示值
		if(PlayerPrefs.HasKey("parameter"))
			parameter = PlayerPrefs.GetString("parameter");
		else
			PlayerPrefs.SetString("parameter", "0");
		
		if(PlayerPrefs.HasKey("TV"))
			TV = PlayerPrefs.GetString("TV");
		else
			PlayerPrefs.SetString("TV", "0");
		
		if(PlayerPrefs.HasKey("CKJC"))
			CKJC = PlayerPrefs.GetString("CKJC");
		else
			PlayerPrefs.SetString("CKJC", "0");
		
		if(PlayerPrefs.HasKey("input_unit"))
			input_unit = PlayerPrefs.GetString("input_unit");
		else
			PlayerPrefs.SetString("input_unit", "0");
		
		if(PlayerPrefs.HasKey("IO"))
			IO = PlayerPrefs.GetString("IO");
		else
			PlayerPrefs.SetString("IO", "0");
		
		if(PlayerPrefs.HasKey("order"))
			order = PlayerPrefs.GetString("order");
		else
			PlayerPrefs.SetString("order", "0");
		
		if(PlayerPrefs.HasKey("zhidai"))
			zhidai = PlayerPrefs.GetString("zhidai");
		else
			PlayerPrefs.SetString("zhidai", "0");
		
		if(PlayerPrefs.HasKey("order_stop1"))
			order_stop1 = PlayerPrefs.GetString("order_stop1");
		else
			PlayerPrefs.SetString("order_stop1", "0");
		
		if(PlayerPrefs.HasKey("order_stop2"))
			order_stop2 = PlayerPrefs.GetString("order_stop2");
		else
			PlayerPrefs.SetString("order_stop2", "0");
		//获得设置界面显示值
	}
	
	//设定界面下移
	public void argu_down()
	{
		switch(ControlPanel_script.argu_setting)
		{
		case 1:
		ControlPanel_script.argu_setting = 2;
			//Debug.Log("can run");
		ArguCursorPos();
		break;
		case 2:
		ControlPanel_script.argu_setting = 3;
		ArguCursorPos();
		break;
		case 3:
		ControlPanel_script.argu_setting = 4;
		ArguCursorPos();
		break;
		case 4:
		ControlPanel_script.argu_setting = 5;
		ArguCursorPos();
		break;
		case 5:
		ControlPanel_script.argu_setting = 6;
		ArguCursorPos();
		break;
		case 6:
		ControlPanel_script.argu_setting = 7;
		ArguCursorPos();
		break;
		case 7:
		ControlPanel_script.argu_setting = 8;
		ArguCursorPos();
		break;
		case 8:
		ControlPanel_script.argu_setting = 9;
		ArguCursorPos();
		break;
		}
	}
	//设定界面下移
	
		//设定界面上移
	public void argu_up()
	{
		switch(ControlPanel_script.argu_setting)
		{
		case 9:
		ControlPanel_script.argu_setting = 8;
		ArguCursorPos();
		break;
		case 8:
		ControlPanel_script.argu_setting = 7;
		ArguCursorPos();
		break;
		case 7:
		ControlPanel_script.argu_setting = 6;
		ArguCursorPos();
		break;
		case 6:
		ControlPanel_script.argu_setting = 5;
		ArguCursorPos();
		break;
		case 5:
		ControlPanel_script.argu_setting = 4;
		ArguCursorPos();
		break;
		case 4:
		ControlPanel_script.argu_setting = 3;
		ArguCursorPos();
		break;
		case 3:
		ControlPanel_script.argu_setting = 2;
		ArguCursorPos();
		break;
		case 2:
		ControlPanel_script.argu_setting = 1;
		ArguCursorPos();
		break;
		}
	}
	//设定界面上移
	
	//黄色背景位置
	public void ArguCursorPos()
	{
		switch(ControlPanel_script.argu_setting)
		{
		case 1:
	    ControlPanel_script.argu_setting_cursor_y = 61.5f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 2:
		ControlPanel_script.argu_setting_cursor_y = 86.5f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 3:
		ControlPanel_script.argu_setting_cursor_y = 112f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 4:
		ControlPanel_script.argu_setting_cursor_y = 136.5f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 5:
		ControlPanel_script.argu_setting_cursor_y = 161.5f;
		ControlPanel_script.argu_setting_cursor_w = 36f;
			break;
		case 6:
		ControlPanel_script.argu_setting_cursor_y = 186.5f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 7:
		ControlPanel_script.argu_setting_cursor_y = 212f;
		ControlPanel_script.argu_setting_cursor_w = 16f;
			break;
		case 8:
		ControlPanel_script.argu_setting_cursor_y = 236.5f;
		ControlPanel_script.argu_setting_cursor_w = 116f;
			break;
		case 9:
		ControlPanel_script.argu_setting_cursor_y = 261.5f;
		ControlPanel_script.argu_setting_cursor_w = 116f;
			break;
		}
	}
	//黄色背景位置
	
	//输入值传入
	public void set_parameter(string input)
	{
		//Debug.Log(input);
		switch (ControlPanel_script.argu_setting)
		{
		case 1:
			if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("parameter", input);
		    parameter = PlayerPrefs.GetString("parameter");
			//Debug.Log(parameter);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 2:
		    if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("TV", input);
			TV = PlayerPrefs.GetString("TV");
			//Debug.Log(TV);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 3:
			if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("CKJC", input);
			CKJC = PlayerPrefs.GetString("CKJC");
			//Debug.Log(CKJC);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 4:
			if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("input_unit", input);
			input_unit = PlayerPrefs.GetString("input_unit");
			//Debug.Log(input_unit);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 5:
			if( input == "0" || input=="1" || input=="2" || input=="3"|| input=="4"|| input=="5"|| input=="6"|| input=="7"|| input=="8"|| input=="9"
				|| input=="10"|| input=="11"|| input=="12"|| input=="13"|| input=="14"|| input=="15"|| input=="16"|| input=="17"|| input=="18"|| input=="19"
				|| input=="20"|| input=="21"|| input=="22"|| input=="23"|| input=="24"|| input=="25"|| input=="26"|| input=="27"|| input=="28"|| input=="29"
				|| input=="30"|| input=="31"|| input=="32"|| input=="33"|| input=="34"|| input=="35")
			{
			PlayerPrefs.SetString("IO", input);
			IO = PlayerPrefs.GetString("IO");
			//Debug.Log(IO);
			}
			else
			{
				Debug.Log("请输入0~35");
				return;
			}
			break;
		case 6:
			if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("order", input);
			order= PlayerPrefs.GetString("order");
			//Debug.Log(order);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 7:
			if( input == "0" || input=="1")
			{
			PlayerPrefs.SetString("zhidai", input);
			zhidai = PlayerPrefs.GetString("zhidai");
			//Debug.Log(zhidai);
			}
			else
			{
				Debug.Log("请输入0或1");
				return;
			}
			break;
		case 8:
			PlayerPrefs.SetString("order_stop1", input);
			order_stop1 = PlayerPrefs.GetString("order_stop1");
			//Debug.Log(order_stop1);
			break;
		case 9:
			PlayerPrefs.SetString("order_stop2", input);
			order_stop2 = PlayerPrefs.GetString("order_stop2");
			//Debug.Log(order_stop2);
			break;
		default:
			Debug.Log("out of range");
			break;
		}
		
	}
	//输入值传入

	//参数界面内容
	public void ReadCooFile () 
	{
		string line_str = "";
		string[] coo_str;
		StreamReader line_str_reader;
		FileStream coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G00.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G00_pos.x = 0f;
			G00_pos.y = 0f;
			G00_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G00_pos.x = float.Parse(coo_str[0]);
			G00_pos.y = float.Parse(coo_str[1]);
			G00_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G54.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G54_pos.x = 0f;
			G54_pos.y = 0f;
			G54_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G54_pos.x = float.Parse(coo_str[0]);
			G54_pos.y = float.Parse(coo_str[1]);
			G54_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G55.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G55_pos.x = 0f;
			G55_pos.y = 0f;
			G55_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G55_pos.x = float.Parse(coo_str[0]);
			G55_pos.y = float.Parse(coo_str[1]);
			G55_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G56.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G56_pos.x = 0f;
			G56_pos.y = 0f;
			G56_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G56_pos.x = float.Parse(coo_str[0]);
			G56_pos.y = float.Parse(coo_str[1]);
			G56_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G57.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G57_pos.x = 0f;
			G57_pos.y = 0f;
			G57_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G57_pos.x = float.Parse(coo_str[0]);
			G57_pos.y = float.Parse(coo_str[1]);
			G57_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G58.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G58_pos.x = 0f;
			G58_pos.y = 0f;
			G58_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G58_pos.x = float.Parse(coo_str[0]);
			G58_pos.y = float.Parse(coo_str[1]);
			G58_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
		coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/G59.txt", FileMode.OpenOrCreate, FileAccess.Read);
		line_str_reader = new StreamReader(coo_stream);
		line_str = line_str_reader.ReadLine();
		if(line_str == null)
		{
			G59_pos.x = 0f;
			G59_pos.y = 0f;
			G59_pos.z = 0f;
		}
		else
		{
			coo_str = line_str.Split(',');
			G59_pos.x = float.Parse(coo_str[0]);
			G59_pos.y = float.Parse(coo_str[1]);
			G59_pos.z = float.Parse(coo_str[2]);
		}
		line_str_reader.Close();
	}
	
	public void WriteCooChoose (int coo_select , string write_str) 
	{
		switch (coo_select)
		{
		case 1:
			WriteCooFile("G00", write_str);
			break;
		case 2:
			WriteCooFile("G54", write_str);
			break;
		case 3:
			WriteCooFile("G55", write_str);
			break;
		case 4:
			WriteCooFile("G56", write_str);
			break;
		case 5:
			WriteCooFile("G57", write_str);
			break;
		case 6:
			WriteCooFile("G58", write_str);
			break;
		case 7:
			WriteCooFile("G59", write_str);
			break;
		default:
			Debug.Log("out of range");
			break;
		}
	}
	
	void WriteCooFile (string filename, string write_str)
	{
		StreamWriter line_str_writer;
		FileStream coo_stream;
		FileInfo check_exist = new FileInfo(Application.dataPath+"/Resources/Coordinate/"+filename+".txt");
		if(check_exist.Exists)
			coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/"+filename+".txt", FileMode.Truncate, FileAccess.Write);
		else
			coo_stream = new FileStream(Application.dataPath+"/Resources/Coordinate/"+filename+".txt", FileMode.Create, FileAccess.Write);
		line_str_writer = new StreamWriter(coo_stream);
		line_str_writer.WriteLine(write_str);
		line_str_writer.Close();
	}
	

	public void Down () 
	{
		switch (ControlPanel_script.coo_setting_1)
		{
		case 1:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 2;
			}
			CooCursorPos();
			break;
		case 2:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 3;
			}
			CooCursorPos();
			break;
		case 3:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 4;
			}
			CooCursorPos();
			break;
		case 4:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 5;
				ControlPanel_script.OffCooFirstPage = false;
			}
			CooCursorPos();
			break;
		case 5:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 6;
			}
			CooCursorPos();
			break;
		case 6:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			else
			{
				ControlPanel_script.coo_setting_2 = 1;
				ControlPanel_script.coo_setting_1 = 7;
			}
			CooCursorPos();
			break;
		case 7:
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_2 = 2;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 3;
			CooCursorPos();
			break;
		}
	}
	
	public void Up () 
	{
		switch (ControlPanel_script.coo_setting_1)
		{
		case 1:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			CooCursorPos();
			break;
		case 2:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 1;
			}
			CooCursorPos();
			break;
		case 3:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 2;
			}
			CooCursorPos();
			break;
		case 4:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 3;
			}
			CooCursorPos();
			break;
		case 5:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 4;
				ControlPanel_script.OffCooFirstPage = true;
			}
			CooCursorPos();
			break;
		case 6:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 5;
			}
			CooCursorPos();
			break;
		case 7:
			if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_2 = 1;
			else if(ControlPanel_script.coo_setting_2 == 3)
				ControlPanel_script.coo_setting_2 = 2;
			else
			{
				ControlPanel_script.coo_setting_2 = 3;
				ControlPanel_script.coo_setting_1 = 6;
			}
			CooCursorPos();
			break;
		}
	}
	
	public void Left () 
	{
		switch(ControlPanel_script.coo_setting_1)
		{
		case 3:
			ControlPanel_script.coo_setting_1 = 1;
			CooCursorPos();
			break;
		case 4:
			ControlPanel_script.coo_setting_1 = 2;
			CooCursorPos();
			break;
		case 7:
			ControlPanel_script.coo_setting_1 = 5;
			CooCursorPos();
			break;
		}
	}
	
	public void Right () 
	{
		switch(ControlPanel_script.coo_setting_1)
		{
		case 1:
			ControlPanel_script.coo_setting_1 = 3;
			CooCursorPos();
			break;
		case 2:
			ControlPanel_script.coo_setting_1 = 4;
			CooCursorPos();
			break;
		case 5:
			ControlPanel_script.coo_setting_1 = 7;
			CooCursorPos();
			break;
		}
	}
	
	public void PageUp ()
	{
		switch (ControlPanel_script.coo_setting_1)
		{
		case 5:
			ControlPanel_script.coo_setting_1 = 1;
			break;
		case 6:
			ControlPanel_script.coo_setting_1 = 2;
			break;
		case 7:
			ControlPanel_script.coo_setting_1 = 3;
			break;
		}
	}
	
	public void PageDown ()
	{
		switch (ControlPanel_script.coo_setting_1)
		{
		case 1:
			ControlPanel_script.coo_setting_1 = 5;
			break;
		case 2:
			ControlPanel_script.coo_setting_1 = 6;
			break;
		case 3:
			ControlPanel_script.coo_setting_1 = 7;
			break;
		case 4:
			ControlPanel_script.coo_setting_1 = 7;
			ControlPanel_script.coo_setting_2 = 3;
			CooCursorPos();
			break;
		}
	}
	
	public void CooCursorPos () 
	{
		switch(ControlPanel_script.coo_setting_1)
		{
		case 1:
		case 5:
			ControlPanel_script.coo_setting_cursor_x = 131f;
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_cursor_y = 120f;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_cursor_y = 150f;
			else
				ControlPanel_script.coo_setting_cursor_y = 180f;
			break;
		case 2:
		case 6:
			ControlPanel_script.coo_setting_cursor_x = 131f;
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_cursor_y = 240f;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_cursor_y = 270f;
			else
				ControlPanel_script.coo_setting_cursor_y = 300f;
			break;
		case 3:
		case 7:
			ControlPanel_script.coo_setting_cursor_x = 376f;
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_cursor_y = 120f;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_cursor_y = 150f;
			else
				ControlPanel_script.coo_setting_cursor_y = 180f;
			break;
		case 4:
			ControlPanel_script.coo_setting_cursor_x = 376f;
			if(ControlPanel_script.coo_setting_2 == 1)
				ControlPanel_script.coo_setting_cursor_y = 240f;
			else if(ControlPanel_script.coo_setting_2 == 2)
				ControlPanel_script.coo_setting_cursor_y = 270f;
			else
				ControlPanel_script.coo_setting_cursor_y = 300f;
			break;
		}
	}
	
	public void SearchNo (string num_str) 
	{
		string str_temp = num_str.TrimStart('0', ' ');
		switch (str_temp)
		{
		case "":
			ControlPanel_script.coo_setting_1 = 1;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = true;
			break;
		case "1":
			ControlPanel_script.coo_setting_1 = 2;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = true;
			break;
		case "2":
			ControlPanel_script.coo_setting_1 = 3;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = true;
			break;
		case "3":
			ControlPanel_script.coo_setting_1 = 4;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = true;
			break;
		case "4":
			ControlPanel_script.coo_setting_1 = 5;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = false;
			break;
		case "5":
			ControlPanel_script.coo_setting_1 = 6;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = false;
			break;
		case "6":
			ControlPanel_script.coo_setting_1 = 7;
			ControlPanel_script.coo_setting_2 = 1;
			CooCursorPos();
			ControlPanel_script.OffCooFirstPage = false;
			break;
		default:
			break;
		}
	}
	
	public void Measure (string coo_value)
	{
		char[] coo_choose = coo_value.ToCharArray();
		string value_str = "";
		float value_f = 0;
		if(coo_choose.Length < 2 || (coo_choose[0] != 'X' && coo_choose[0] != 'Y'  && coo_choose[0] != 'Z' && coo_choose[0] != 'x' && coo_choose[0] != 'y' && coo_choose[0] != 'z' ))
		{
			Debug.Log("Format Error!!!");
			return;
		}
		else
		{
			for(int i = 1; i < coo_choose.Length; i++)
			{
				if(coo_choose[i] != '.'  && coo_choose[i] != '+' && coo_choose[i] != '-')
				{
					if(coo_choose[i] < '0' || coo_choose[i] > '9')
					{
						Debug.Log("Format Error!!!");
						return;
					}
				}
				else if(coo_choose[i] == '+' || coo_choose[i] == '-')
				{
					if(i != 1)
					{
						Debug.Log("Format Error!!!");
						return;
					}
				}
				value_str += coo_choose[i];
			}
			if(value_str == "+" || value_str == "-")
			{
				Debug.Log("Format Error!!!");
				return;
			}
			value_f = float.Parse(value_str);
			//Debug.Log(value_f);
			switch(coo_choose[0])
			{
			case 'X':
			case 'x':
				Measure_choose(1, value_f, 1);
				ControlPanel_script.coo_setting_2 = 1;
				break;
			case 'Y':
			case 'y':
				Measure_choose(2, value_f, 1);
				ControlPanel_script.coo_setting_2 = 2;
				break;
			case 'Z':
			case 'z':
				Measure_choose(3, value_f, 1);
				ControlPanel_script.coo_setting_2 = 3;
				break;
			default:
				Debug.Log("Format Error!!!");
				break;
			}
			CooCursorPos();
		}		
	}
	
	public void PlusInput (string input_value, bool plus_flag) 
	{
		char[] coo_choose = input_value.ToCharArray();
		string value_str = "";
		float value_f = 0;
		for(int i = 0; i < coo_choose.Length; i++)
		{
			if(coo_choose[i] != '.'  && coo_choose[i] != '+' && coo_choose[i] != '-')
			{
				if(coo_choose[i] < '0' || coo_choose[i] > '9')
				{
					Debug.Log("Format Error!!!");
					return;
				}
			}
			else if(coo_choose[i] == '+' || coo_choose[i] == '-')
			{
				if(i != 0)
				{
					Debug.Log("Format Error!!!");
					return;
				}
			}
			value_str += coo_choose[i];
		}
		if(value_str == "+" || value_str == "-")
		{
			Debug.Log("Format Error!!!");
			return;
		}
		value_f = float.Parse(value_str);
		if(plus_flag)
			Measure_choose(ControlPanel_script.coo_setting_2, value_f, 2);
		else
			Measure_choose(ControlPanel_script.coo_setting_2, value_f, 3);
	}
	
	void Measure_choose (int xyz_select, float value_f, int mode_flag) 
	{
		string write_str = "";
		switch (ControlPanel_script.coo_setting_1)
		{
		case 1:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G00_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G00_pos.x += value_f; 
				else
					G00_pos.x = value_f; 
				write_str = G00_pos.x+","+G00_pos.y+","+G00_pos.z;
				WriteCooChoose(1,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G00_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G00_pos.y += value_f; 
				else
					G00_pos.y = value_f; 
				write_str = G00_pos.x+","+G00_pos.y+","+G00_pos.z;
				WriteCooChoose(1,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G00_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G00_pos.z += value_f; 
				else
					G00_pos.z = value_f; 
				write_str = G00_pos.x+","+G00_pos.y+","+G00_pos.z;
				WriteCooChoose(1,write_str);
			}
			ControlPanel_script.OffCooFirstPage = true;
			Workpiece_Change();
			break;
		case 2:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G54_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G54_pos.x += value_f; 
				else
					G54_pos.x = value_f; 
				write_str = G54_pos.x+","+G54_pos.y+","+G54_pos.z;
				WriteCooChoose(2,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G54_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G54_pos.y += value_f; 
				else
					G54_pos.y = value_f; 
				write_str = G54_pos.x+","+G54_pos.y+","+G54_pos.z;
				WriteCooChoose(2,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G54_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G54_pos.z += value_f; 
				else
					G54_pos.z = value_f; 
				write_str = G54_pos.x+","+G54_pos.y+","+G54_pos.z;
				WriteCooChoose(2,write_str);
			}
			ControlPanel_script.OffCooFirstPage = true;
			Workpiece_Change();
			break;
		case 3:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G55_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G55_pos.x += value_f; 
				else
					G55_pos.x = value_f; 
				write_str = G55_pos.x+","+G55_pos.y+","+G55_pos.z;
				WriteCooChoose(3,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G55_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G55_pos.y += value_f; 
				else
					G55_pos.y = value_f; 
				write_str = G55_pos.x+","+G55_pos.y+","+G55_pos.z;
				WriteCooChoose(3,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G55_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G55_pos.z += value_f; 
				else
					G55_pos.z = value_f; 
				write_str = G55_pos.x+","+G55_pos.y+","+G55_pos.z;
				WriteCooChoose(3,write_str);
			}
			ControlPanel_script.OffCooFirstPage = true;
			Workpiece_Change();
			break;
		case 4:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G56_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G56_pos.x += value_f; 
				else
					G56_pos.x = value_f; 
				write_str = G56_pos.x+","+G56_pos.y+","+G56_pos.z;
				WriteCooChoose(4,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G56_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G56_pos.y += value_f; 
				else
					G56_pos.y = value_f;
				write_str = G56_pos.x+","+G56_pos.y+","+G56_pos.z;
				WriteCooChoose(4,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G56_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G56_pos.z += value_f; 
				else
					G56_pos.z = value_f;
				write_str = G56_pos.x+","+G56_pos.y+","+G56_pos.z;
				WriteCooChoose(4,write_str);
			}
			ControlPanel_script.OffCooFirstPage = true;
			Workpiece_Change();
			break;
		case 5:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G57_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G57_pos.x += value_f; 
				else
					G57_pos.x = value_f;
				write_str = G57_pos.x+","+G57_pos.y+","+G57_pos.z;
				WriteCooChoose(5,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G57_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G57_pos.y += value_f; 
				else
					G57_pos.y = value_f;
				write_str = G57_pos.x+","+G57_pos.y+","+G57_pos.z;
				WriteCooChoose(5,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G57_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G57_pos.z += value_f; 
				else
					G57_pos.z = value_f;
				write_str = G57_pos.x+","+G57_pos.y+","+G57_pos.z;
				WriteCooChoose(5,write_str);
			}
			ControlPanel_script.OffCooFirstPage = false;
			Workpiece_Change();
			break;
		case 6:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G58_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G58_pos.x += value_f; 
				else
					G58_pos.x = value_f;
				write_str = G58_pos.x+","+G58_pos.y+","+G58_pos.z;
				WriteCooChoose(6,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G58_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G58_pos.y += value_f; 
				else
					G58_pos.y = value_f;
				write_str = G58_pos.x+","+G58_pos.y+","+G58_pos.z;
				WriteCooChoose(6,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G58_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G58_pos.z += value_f; 
				else
					G58_pos.z = value_f;
				write_str = G58_pos.x+","+G58_pos.y+","+G58_pos.z;
				WriteCooChoose(6,write_str);
			}
			ControlPanel_script.OffCooFirstPage = false;
			Workpiece_Change();
			break;
		case 7:
			if(xyz_select == 1)
			{
				if(mode_flag == 1)
					G59_pos.x = MoveControl_script.MachineCoo.x - value_f;
				else if(mode_flag == 2)
					G59_pos.x += value_f; 
				else
					G59_pos.x = value_f;
				write_str = G59_pos.x+","+G59_pos.y+","+G59_pos.z;
				WriteCooChoose(7,write_str);
			}
			else if(xyz_select == 2)
			{
				if(mode_flag == 1)
					G59_pos.y = MoveControl_script.MachineCoo.y - value_f;
				else if(mode_flag == 2)
					G59_pos.y += value_f; 
				else
					G59_pos.y = value_f;
				write_str = G59_pos.x+","+G59_pos.y+","+G59_pos.z;
				WriteCooChoose(7,write_str);
			}
			else
			{
				if(mode_flag == 1)
					G59_pos.z = MoveControl_script.MachineCoo.z - value_f;
				else if(mode_flag == 2)
					G59_pos.z += value_f; 
				else
					G59_pos.z = value_f;
				write_str = G59_pos.x+","+G59_pos.y+","+G59_pos.z;
				WriteCooChoose(7,write_str);
			}
			ControlPanel_script.OffCooFirstPage = false;
			Workpiece_Change();
			break;
		default:
			break;
		}
	}
	
	
	
	// Update is called once per frame
	void Update () {
		absolute_pos = MoveControl_script.MachineCoo - G00_pos - workpiece_coo;
		//Debug.Log(workpiece_coo.x +","+workpiece_coo.y+","+workpiece_coo.z);
		relative_pos = MoveControl_script.MachineCoo - G00_pos - workpiece_coo;
	}
	
	
	public void Workpiece_Change () {
		switch (workpiece_flag)
		{
		case 1:
			workpiece_coo = G54_pos;
			break;
		case 2:
			workpiece_coo = G55_pos;
			Debug.Log("2222222222");
			break;
		case 3:
			workpiece_coo = G56_pos;
			break;
		case 4:
			workpiece_coo = G57_pos;
			break;
		case 5:
			workpiece_coo = G58_pos;
			break;
		case 6:
			workpiece_coo = G59_pos;
			break;
		default:
			Debug.Log("workpiece flag is wrong!!!");
			break;
		}
	}
}
