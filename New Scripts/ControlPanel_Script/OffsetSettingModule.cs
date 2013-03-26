using UnityEngine;
using System.Collections;

public class OffsetSettingModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	
	
	void Awake () 
	{
		
	}
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		
	}
	
	public void Offset ()
	{
		//刀偏设置
		if(Main.OffSetTool)
		{
			ToolOffSet();
		}
		//系统相关参数设置
		if(Main.OffSetSetting)
		{
			ArguSettings();
		}
		//坐标系设置
		if(Main.OffSetCoo)
		{
			CooOffSetting();
		}
	}
	
	//刀偏设定界面
	void ToolOffSet () {
		GUI.Label(new Rect(40f/1000f*Main.width, 28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"刀偏", Main.sty_Title);
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(77f/1000f*Main.width,421f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(168f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(258f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(420f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}		
		else if(Main.OffSetTwo)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(73f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"No检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"C输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(350f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(441f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"-输入", Main.sty_BottomChooseMenu);
		}
	}
	//参数设置界面
	void ArguSettings () {
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设定（手持盒）", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width, 55f/1000f*Main.height , 500f/1000f*Main.width,300f/1000f*Main.height), "", Main.sty_SettingsBG);
		
		
		
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect(77f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(168f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(258f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(420f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
	}
	//工件坐标系设定界面
	void CooOffSetting () {
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"工件坐标系设定", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width,60f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"(G54)", Main.sty_MostWords);
		GUI.Label(new Rect(40f/1000f*Main.width,92f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"番号", Main.sty_MostWords);
		GUI.Label(new Rect(180f/1000f*Main.width,92f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"数据", Main.sty_MostWords);
		GUI.Label(new Rect(290f/1000f*Main.width,92f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"番号", Main.sty_MostWords);
		GUI.Label(new Rect(435f/1000f*Main.width,92f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"数据", Main.sty_MostWords);
		
		if(Main.OffCooFirstPage)
		{
			GUI.Label(new Rect(45f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00", Main.sty_MostWords);
			GUI.Label(new Rect(45f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"EXT", Main.sty_MostWords);
			GUI.Label(new Rect(100f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(130f/1000f*Main.width,119f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,149f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,179f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect(45f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"01", Main.sty_MostWords);
			GUI.Label(new Rect(45f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G54", Main.sty_MostWords);
			GUI.Label(new Rect(100f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(130f/1000f*Main.width,239f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,269f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,299f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect(290f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"02", Main.sty_MostWords);
			GUI.Label(new Rect(290f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G55", Main.sty_MostWords);
			GUI.Label(new Rect(345f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(375f/1000f*Main.width,119f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,149f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,179f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect(290f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"03", Main.sty_MostWords);
			GUI.Label(new Rect(290f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G56", Main.sty_MostWords);
			GUI.Label(new Rect(345f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(375f/1000f*Main.width,239f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,269f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,299f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);	
		}
		else
		{
			GUI.Label(new Rect(45f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"04", Main.sty_MostWords);
			GUI.Label(new Rect(45f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G57", Main.sty_MostWords);
			GUI.Label(new Rect(100f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(130f/1000f*Main.width,119f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,149f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,179f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect(45f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"05", Main.sty_MostWords);
			GUI.Label(new Rect(45f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G58", Main.sty_MostWords);
			GUI.Label(new Rect(100f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(100f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(130f/1000f*Main.width,239f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,269f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(130f/1000f*Main.width,299f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect(290f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"06", Main.sty_MostWords);
			GUI.Label(new Rect(290f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G59", Main.sty_MostWords);
			GUI.Label(new Rect(345f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect(345f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect(375f/1000f*Main.width,119f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,149f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(375f/1000f*Main.width,179f/1000f*Main.height,140f/1000f*Main.width,29f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		}
		
		GUI.Label(new Rect(Main.coo_setting_cursor_x/1000f*Main.width, Main.coo_setting_cursor_y/1000f*Main.height,138f/1000f*Main.width,26f/1000f*Main.height),"", Main.sty_EDITCursor);
		//GUI.Label(new Rect(131f/1000f*width,150f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		//GUI.Label(new Rect(131f/1000f*width,180f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		
		//GUI.Label(new Rect(131f/1000f*width,120f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		
		if(Main.OffCooFirstPage)
		{
			GUI.Label(new Rect(130f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G00_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G00_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G00_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect(130f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G54_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G54_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G54_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect(375f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G55_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G55_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G55_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect(375f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G56_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G56_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G56_pos.z), Main.sty_SmallNum);
		}
		else
		{
			GUI.Label(new Rect(130f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G57_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G57_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G57_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect(130f/1000f*Main.width,240f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G58_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,270f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G58_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(130f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G58_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect(375f/1000f*Main.width,120f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G59_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G59_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect(375f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.G59_pos.z), Main.sty_SmallNum);
		}
		
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(77f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(168f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(258f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(420f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}		
		else if(Main.OffSetTwo)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(73f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"No检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(168f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"测 量", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(350f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(452f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"输入", Main.sty_BottomChooseMenu);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
