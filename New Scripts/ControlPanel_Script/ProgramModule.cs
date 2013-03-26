using UnityEngine;
using System.Collections;

public class ProgramModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
	}
	
	public void Program () 
	{
		//编辑窗口
		if(Main.ProgEDIT)
		{
			//程序
			if(Main.ProgEDITProg)
			{
				ProgEDITWindow();
			}
			//列表
			if(Main.ProgEDITList)
			{
				ProgEDITListWindow();
			}	
		}
		//自动运行
		if(Main.ProgAUTO)
		{
			ProgAUTOWindow();
		}
		//JOG或者REF
		if(Main.ProgJOG || Main.ProgREF)
		{
			ProgShared();
		}
	}
	
	//编辑窗口
	void ProgEDITWindow () 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect(45f/1000f*Main.width,70f/1000f*Main.height,465f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_EDITLabel);
		GUI.Label(new Rect(45f/1000f*Main.width,68f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O", Main.sty_ProgEDITWindowO);
		GUI.Label(new Rect(70f/1000f*Main.width,70f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.ToolNumFormat(Main.ProgramNum), Main.sty_ProgEditProgNum);
		GUI.Label(new Rect(70f/1000f*Main.width,70f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.ToolNumFormat(Main.ProgramNum), Main.sty_ProgEditProgNum);
		GUI.Label(new Rect(375f/1000f*Main.width,70f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（FG:编辑）", Main.sty_ProgEDITWindowFG);	
		GUI.Label(new Rect(45f/1000f*Main.width,97f/1000f*Main.height,465f/1000f*Main.width,243f/1000f*Main.height),"", Main.sty_EDITLabelWindow);
		GUI.Label(new Rect(513f/1000f*Main.width,97f/1000f*Main.height,23f/1000f*Main.width,23f/1000f*Main.height),"", Main.sty_EDITLabelBar_1);
		GUI.Label(new Rect(513f/1000f*Main.width,121f/1000f*Main.height,23f/1000f*Main.width,191f/1000f*Main.height),"", Main.sty_EDITLabelBar_2);
		GUI.Label(new Rect(513f/1000f*Main.width,313f/1000f*Main.height,23f/1000f*Main.width,23f/1000f*Main.height),"", Main.sty_EDITLabelBar_3);
		if(Main.Code01 != "")
			GUI.Label(new Rect(Main.ProgEDITCusorH, Main.ProgEDITCusorV/1000f*Main.height, Main.TextSize.x + 3f, 25f/1000f*Main.height),"", Main.sty_EDITCursor);
		GUI.Label(new Rect(46f/1000f*Main.width,100f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code01, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,125f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code02, Main.sty_Code);			
		GUI.Label(new Rect(46f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code03, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,175f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code04, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,200f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code05, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,225f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code06, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,250f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code07, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,275f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code08, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code09, Main.sty_Code);
		if(Main.ProgEDITFlip == 0)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(78f/1000f*Main.width,421f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程 序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"列 表", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 1)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(62f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"后台编辑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↓", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(352f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(430f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"REWIND", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
		else if(Main.ProgEDITFlip == 2)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(80f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"F检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"READ", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(257f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"PUNCH", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(340f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"DELETE", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(432f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"EX-EDT", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
		else if(Main.ProgEDITFlip == 3)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(165f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"C-EXT", Main.sty_BottomChooseMenu);
		}
	}
	
	//编辑界面程序列表
	void ProgEDITListWindow () 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序列表", Main.sty_Title);
		GUI.Label(new Rect(45f/1000f*Main.width,58f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect(170f/1000f*Main.width,60f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"程序数", Main.sty_MostWords);
		GUI.Label(new Rect(370f/1000f*Main.width,60f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"内存(BYTE)", Main.sty_MostWords);
		GUI.Label(new Rect(60f/1000f*Main.width,79f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"已用：", Main.sty_MostWords);	
		GUI.Label(new Rect(150f/1000f*Main.width,79f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUsedNum), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect(370f/1000f*Main.width,79f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUsedSpace), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect(60f/1000f*Main.width,99f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"空区：", Main.sty_MostWords);
		GUI.Label(new Rect(150f/1000f*Main.width,99f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUnusedNum), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect(370f/1000f*Main.width,99f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUnusedSpace), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect(45f/1000f*Main.width,127f/1000f*Main.height,490f/1000f*Main.width,213f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect(48f/1000f*Main.width,127f/1000f*Main.height,484f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_EDITLabel);
		GUI.Label(new Rect(48f/1000f*Main.width,127f/1000f*Main.height,484f/1000f*Main.width,25f/1000f*Main.height),"设备：CNC_MEM", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(60f/1000f*Main.width,153f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"O号码", Main.sty_MostWords);
		GUI.Label(new Rect(200f/1000f*Main.width,153f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"容量(BYTE)", Main.sty_MostWords);
		GUI.Label(new Rect(400f/1000f*Main.width,153f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"更新时间", Main.sty_MostWords);
		if(Main.CodeName01 != "")
			GUI.Label(new Rect(48f/1000f*Main.width, Main.ProgEDITCusor/1000f*Main.height,484f/1000f*Main.width,21f/1000f*Main.height),"", Main.sty_EDITCursor);			
		GUI.Label(new Rect(58f/1000f*Main.width,174f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName01, Main.sty_ClockStyle);
		if(Main.CodeName01 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,174f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize01), Main.sty_ClockStyle);			
		GUI.Label(new Rect(330f/1000f*Main.width,174f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate01, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,194f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName02, Main.sty_ClockStyle);
		if(Main.CodeName02 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,194f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize02), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,194f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate02, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,214f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName03, Main.sty_ClockStyle);
		if(Main.CodeName03 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,214f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize03), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,214f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate03, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,234f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName04, Main.sty_ClockStyle);
		if(Main.CodeName04 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,234f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize04), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,234f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate04, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,254f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName05, Main.sty_ClockStyle);
		if(Main.CodeName05 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,254f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize05), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,254f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate05, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,274f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName06, Main.sty_ClockStyle);
		if(Main.CodeName06 != "")	
			GUI.Label(new Rect(200f/1000f*Main.width,274f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize06), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,274f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate06, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,294f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName07, Main.sty_ClockStyle);
		if(Main.CodeName07 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,294f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize07), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,294f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate07, Main.sty_ClockStyle);
		
		GUI.Label(new Rect(58f/1000f*Main.width,314f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName08, Main.sty_ClockStyle);
		if(Main.CodeName08 != "")
			GUI.Label(new Rect(200f/1000f*Main.width,314f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize08), Main.sty_ClockStyle);
		GUI.Label(new Rect(330f/1000f*Main.width,314f/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate08, Main.sty_ClockStyle);
		
		if(Main.ProgEDITFlip == 0)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(78f/1000f*Main.width,420f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程 序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"列 表", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 1)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(62f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"后台编辑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↓", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(352f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(430f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"REWIND", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
		else if(Main.ProgEDITFlip == 2)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(80f/1000f*Main.width,420f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"F检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"READ", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(257f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"PUNCH", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(340f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"DELETE", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(432f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"EX-EDT", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
		else if(Main.ProgEDITFlip == 3)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
			GUI.Label(new Rect(165f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"C-EXT", Main.sty_BottomChooseMenu);
		}
	} 

	//AUTO模式下的程序界面
	void ProgAUTOWindow () 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序（检查）", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width,55f/1000f*Main.height,500f/1000f*Main.width,110f/1000f*Main.height),"", Main.sty_EDITList);
		
		if(Main.Code01 != "")
			GUI.Label(new Rect(46f/1000f*Main.width,60f/1000f*Main.height,484f/1000f*Main.width,26f/1000f*Main.height),"", Main.sty_EDITCursor);
		GUI.Label(new Rect(46f/1000f*Main.width,60f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code01, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,85f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code02, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,110f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code03, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,135f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code04, Main.sty_Code);
	
		GUI.Label(new Rect(40f/1000f*Main.width,165f/1000f*Main.height,150f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect(191f/1000f*Main.width,165f/1000f*Main.height,145f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect(70f/1000f*Main.width,165f/1000f*Main.height,100f/1000f*Main.width,300f/1000f*Main.height),"绝对坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect(42f/1000f*Main.width,185f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect(50f/1000f*Main.width,185f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.x), Main.sty_SmallNum);
		GUI.Label(new Rect(42f/1000f*Main.width,210f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect(50f/1000f*Main.width,210f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.y), Main.sty_SmallNum);
		GUI.Label(new Rect(42f/1000f*Main.width,235f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect(50f/1000f*Main.width,235f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.z), Main.sty_SmallNum);
		GUI.Label(new Rect(210f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"剩余移动量", Main.sty_PosSmallWord);
		GUI.Label(new Rect(195f/1000f*Main.width,185f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
		GUI.Label(new Rect(195f/1000f*Main.width,210f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
		GUI.Label(new Rect(195f/1000f*Main.width,235f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
		GUI.Label(new Rect(340f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "G00   G94   G80", Main.sty_Code);
		GUI.Label(new Rect(340f/1000f*Main.width,189f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "G17   G21   G98", Main.sty_Code);
		GUI.Label(new Rect(340f/1000f*Main.width,213f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "G90   G40   G50", Main.sty_Code);
		GUI.Label(new Rect(340f/1000f*Main.width,237f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "G22   G49   G67", Main.sty_Code);			
		GUI.Label(new Rect(340f/1000f*Main.width,262f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_MostWords);
		GUI.Label(new Rect(420f/1000f*Main.width,262f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"M", Main.sty_MostWords);
		GUI.Label(new Rect(40f/1000f*Main.width,280f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"T", Main.sty_MostWords);
		GUI.Label(new Rect(340f/1000f*Main.width,280f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"D", Main.sty_MostWords);
		GUI.Label(new Rect(40f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"F", Main.sty_MostWords);
		GUI.Label(new Rect(210f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"S", Main.sty_MostWords);
		GUI.Label(new Rect(40f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"实速度         MM/MIN", Main.sty_MostWords);
		GUI.Label(new Rect(113f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		GUI.Label(new Rect(310f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SACT         /分", Main.sty_MostWords);
		GUI.Label(new Rect(365f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SACT), Main.sty_SmallNum);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect(78f/1000f*Main.width,421f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程 序", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"列 表", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
	}
	
	//显示Handle、Jog、Ref模式下的程序界面
	void ProgShared () 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect(45f/1000f*Main.width,90f/1000f*Main.height,490f/1000f*Main.width,245f/1000f*Main.height),"", Main.sty_ProgSharedWindow);
		if(Main.Code01 != "")
			GUI.Label(new Rect(32f, Main.ProgEDITCusorV/1000f*Main.height, 480f/1000f*Main.width, 25f/1000f*Main.height),"", Main.sty_EDITCursor);
		GUI.Label(new Rect(46f/1000f*Main.width,100f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code01, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,125f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code02, Main.sty_Code);			
		GUI.Label(new Rect(46f/1000f*Main.width,150f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code03, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,175f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code04, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,200f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code05, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,225f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code06, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,250f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code07, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,275f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code08, Main.sty_Code);
		GUI.Label(new Rect(46f/1000f*Main.width,300f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.Code09, Main.sty_Code);

		if(Main.ProgSharedFlip == 0)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(88f/1000f*Main.width,421f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(255f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(345f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(429f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
		else
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect(88f/1000f*Main.width,421f/1000f*Main.height,100f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(255f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(345f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(429f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
