using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		
		GUI.Label(new Rect(40f/1000f*Main.width,60f/1000f*Main.height,40f/1000f*Main.width,20f/1000f*Main.height),"编号", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect(110f/1000f*Main.width,60f/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"形状(H)", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect(220f/1000f*Main.width,60f/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"磨损(H)", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect(330f/1000f*Main.width,60f/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"形状(D)", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect(440f/1000f*Main.width,60f/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"磨损(D)", Main.sty_MostWords_ToolOffSet);
		
		int j = Main.ToolOffSetPage.Count;
		for(j= 0;j<50;j++)
		{
			Main.ToolOffSetPage.Add(false);
		}
		
		
		Main.ToolOffSetPage[Main.ToolOffSetPage_num]= true;
	   // Debug.Log(Main.ToolOffSetPage_num);
		Main.number = 8 * Main.ToolOffSetPage_num;
		
		
		
		if(Main.ToolOffSetPage[Main.ToolOffSetPage_num])
		{
			GUI.Label(new Rect(45f/1000f*Main.width,80f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+1), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,105f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+2), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,130f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+3), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,155f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+4), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,180f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+5), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,205f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+6), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,230f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+7), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(45f/1000f*Main.width,255f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+8), Main.sty_MostWords_ToolOffSet);
			GUI.Label(new Rect(90f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(200f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(310f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect(420f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
				GUI.Label(new Rect(Main.tool_setting_cursor_w/1000f*Main.width, Main.tool_setting_cursor_y/1000f*Main.height,107f/1000f*Main.width,22f/1000f*Main.height),"", Main.sty_EDITCursor);
			
			//显示数字
			GUI.Label(new Rect(90f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,80f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number]), Main.sty_MostWords);
			GUI.Label(new Rect(90f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+1]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+1]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+1]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,105f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+1]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+2]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+2]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+2]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,130f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+2]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+3]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+3]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+3]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,155f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+3]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+4]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+4]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+4]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,180f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+4]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+5]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+5]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+5]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,205f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+5]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+6]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+6]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+6]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,230f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+6]), Main.sty_MostWords);
		    GUI.Label(new Rect(90f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+7]), Main.sty_MostWords);
			GUI.Label(new Rect(200f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+7]), Main.sty_MostWords);
			GUI.Label(new Rect(310f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+7]), Main.sty_MostWords);
			GUI.Label(new Rect(420f/1000f*Main.width,255f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+7]), Main.sty_MostWords);
		}
		    GUI.Label(new Rect(45f/1000f*Main.width,282f/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"相 对 坐 标 X", Main.sty_MostWords_ToolOffSet);
		    GUI.Label(new Rect(230f/1000f*Main.width,282f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.relative_pos.x),Main.sty_MostWords);
		    GUI.Label(new Rect(360f/1000f*Main.width,282f/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"Y", Main.sty_MostWords_ToolOffSet);
		    GUI.Label(new Rect(390f/1000f*Main.width,282f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.relative_pos.y),Main.sty_MostWords);
		    GUI.Label(new Rect(45f/1000f*Main.width,306f/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"            Z", Main.sty_MostWords_ToolOffSet);
		    GUI.Label(new Rect(230f/1000f*Main.width,306f/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.relative_pos.z),Main.sty_MostWords);
		
	
		
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
			GUI.Label(new Rect(441f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height)," 输入", Main.sty_BottomChooseMenu);
		}
	}
	   
	
	//参数设置界面
	void ArguSettings () {
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设定（手持盒）", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width, 55f/1000f*Main.height , 500f/1000f*Main.width,300f/1000f*Main.height), "", Main.sty_SettingsBG);
		
		GUI.Label(new Rect(45f/1000f*Main.width,60f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"写参数", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,60f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,60f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,60f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：不可以   1：可以）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,85f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"TV  检查", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,85f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,85f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,85f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：关断   1：接通）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,110f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"穿孔代码", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,110f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,110f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,110f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：EIA  1：ISO）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,135f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"输入单位", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,135f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,135f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,135f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：毫米   1：英寸）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,160f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"I/O  通道", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,160f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,160f/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mid);
		GUI.Label(new Rect(285f/1000f*Main.width,160f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0-35： 通道号   ）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,185f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,185f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,185f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,185f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：关断   1：接通）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,210f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"纸带格式", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,210f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,210f/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect(265f/1000f*Main.width,210f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：无变换 1：F10/11）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,235f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号停止", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,235f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,235f/1000f*Main.height,120f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		GUI.Label(new Rect(365f/1000f*Main.width,235f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（ 程 序 号 ）", Main.sty_MostWords);
		GUI.Label(new Rect(45f/1000f*Main.width,260f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号停止", Main.sty_MostWords);
		GUI.Label(new Rect(220f/1000f*Main.width,260f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect(240f/1000f*Main.width,260f/1000f*Main.height,120f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		GUI.Label(new Rect(365f/1000f*Main.width,260f/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（ 顺 序 号 ）", Main.sty_MostWords);
		
		GUI.Label(new Rect(242f/1000f*Main.width, Main.argu_setting_cursor_y/1000f*Main.height,Main.argu_setting_cursor_w/1000f*Main.width,22f/1000f*Main.height),"", Main.sty_EDITCursor);
		
		GUI.Label(new Rect(243f/1000f*Main.width,60f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.parameter, Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,85f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.TV, Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,110f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.CKJC, Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,135f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.input_unit, Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,160f/1000f*Main.height,40f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet_IO(CooSystem_script.IO), Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,185f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.order, Main.sty_SmallNum);
		GUI.Label(new Rect(243f/1000f*Main.width,210f/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.zhidai, Main.sty_SmallNum);
		GUI.Label(new Rect(248f/1000f*Main.width,235f/1000f*Main.height,120f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet(CooSystem_script.order_stop1), Main.sty_SmallNum);
		GUI.Label(new Rect(248f/1000f*Main.width,260f/1000f*Main.height,120f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet(CooSystem_script.order_stop2), Main.sty_SmallNum);
		
		
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(77f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(168f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
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
			GUI.Label(new Rect(73f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"宏变量", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(168f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"模 式", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"操 作", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(420f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
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
