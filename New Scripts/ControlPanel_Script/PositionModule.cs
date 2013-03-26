using UnityEngine;
using System.Collections;

public class PositionModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	MoveControl MoveControl_script;
	
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
	}
	
	public void Position () {
		//绝对坐标界面
		if(Main.AbsoluteCoo)	
		{
			PosAbsoluteCoo();
		 }
		//相对坐标界面
		if(Main.RelativeCoo)
		{
			PosRelativeCoo();
		}
		//综合界面
		if(Main.GeneralCoo)
		{
			PosGeneralCoo();
		}
		//位置界面下方公共区域显示控制
		PosBottomScreen();
	}
	
	//绝对坐标界面显示控制
	void PosAbsoluteCoo() 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"绝对坐标", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width,422f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_BottomButtonSmallest);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect(78f/1000f*Main.width,421f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(352f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		GUI.Label(new Rect(60f/1000f*Main.width,65f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,65f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.x), Main.sty_BigXYZ);
		GUI.Label(new Rect(60f/1000f*Main.width,115f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,115f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.y), Main.sty_BigXYZ);
		GUI.Label(new Rect(60f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.CooStringGet(CooSystem_script.absolute_pos.z), Main.sty_BigXYZ);
	}
	
	//相对坐标界面显示控制
	void PosRelativeCoo () 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相对坐标", Main.sty_Title);
		GUI.Label(new Rect(40f/1000f*Main.width,422f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_BottomButtonSmallest);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect(78f/1000f*Main.width,420f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(171f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(261f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(352f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		GUI.Label(new Rect(60f/1000f*Main.width,65f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,65f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),  Main.CooStringGet(CooSystem_script.relative_pos.x), Main.sty_BigXYZ);
		GUI.Label(new Rect(60f/1000f*Main.width,115f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,115f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.relative_pos.y), Main.sty_BigXYZ);
		GUI.Label(new Rect(60f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
		GUI.Label(new Rect(140f/1000f*Main.width,165f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.relative_pos.z), Main.sty_BigXYZ);
	}
	
	//综合界面显示控制
	void PosGeneralCoo() 
	{
		GUI.Label(new Rect(40f/1000f*Main.width,28f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"综合显示", Main.sty_Title);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		
		GUI.Label(new Rect(78f/1000f*Main.width,420f/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(171f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(261f/1000f*Main.width,421f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(352f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(423f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect(523f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_MostWords);
		
		GUI.Label(new Rect(113f/1000f*Main.width,57f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相对坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect(60f/1000f*Main.width,80f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,80f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.relative_pos.x), Main.sty_SmallNum);
		GUI.Label(new Rect(60f/1000f*Main.width,105f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,105f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.relative_pos.y), Main.sty_SmallNum);
		GUI.Label(new Rect(60f/1000f*Main.width,130f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,130f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.relative_pos.z), Main.sty_SmallNum);

		GUI.Label(new Rect(375f/1000f*Main.width,57f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"绝对坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect(300f/1000f*Main.width,80f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,80f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.x), Main.sty_SmallNum);
		GUI.Label(new Rect(300f/1000f*Main.width,105f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,105f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.y), Main.sty_SmallNum);
		GUI.Label(new Rect(300f/1000f*Main.width,130f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,130f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(CooSystem_script.absolute_pos.z), Main.sty_SmallNum);
			
		GUI.Label(new Rect(113f/1000f*Main.width,157f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"机械坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect(60f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(MoveControl_script.MachineCoo.x), Main.sty_SmallNum);
		GUI.Label(new Rect(60f/1000f*Main.width,205f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,205f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(MoveControl_script.MachineCoo.y), Main.sty_SmallNum);
		GUI.Label(new Rect(60f/1000f*Main.width,230f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect(100f/1000f*Main.width,230f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringGet(MoveControl_script.MachineCoo.z), Main.sty_SmallNum);
				
				
		GUI.Label(new Rect(370f/1000f*Main.width,157f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"剩余移动量", Main.sty_PosSmallWord);
		GUI.Label(new Rect(300f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,180f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
		GUI.Label(new Rect(300f/1000f*Main.width,205f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,205f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
		GUI.Label(new Rect(300f/1000f*Main.width,230f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect(360f/1000f*Main.width,230f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"     0.000", Main.sty_SmallNum);
	}
	
	//位置界面下方公共区域显示控制
	void PosBottomScreen()
	{
		GUI.Label(new Rect(290f/1000f*Main.width,280f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"加工零件数", Main.sty_MostWords);
		GUI.Label(new Rect(452f/1000f*Main.width,278f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.PartsNum), Main.sty_SmallNum);
		
		GUI.Label(new Rect(40f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"运行时间", Main.sty_MostWords);
		GUI.Label(new Rect(187f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_MostWords);
		GUI.Label(new Rect(250f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"M", Main.sty_MostWords);
		
		GUI.Label(new Rect(105f/1000f*Main.width,299f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningTimeH), Main.sty_SmallNum);
		GUI.Label(new Rect(166f/1000f*Main.width,299f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningTimeM), Main.sty_SmallNum);
		
		GUI.Label(new Rect(290f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"循环时间", Main.sty_MostWords);
		GUI.Label(new Rect(437f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_MostWords);
		GUI.Label(new Rect(480f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"M", Main.sty_MostWords);
		GUI.Label(new Rect(522f/1000f*Main.width,301f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"S", Main.sty_MostWords);
		
		GUI.Label(new Rect(357f/1000f*Main.width,299f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeH), Main.sty_SmallNum);
		GUI.Label(new Rect(398f/1000f*Main.width,299f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeM), Main.sty_SmallNum);
		GUI.Label(new Rect(440f/1000f*Main.width,299f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeS), Main.sty_SmallNum);
		
		GUI.Label(new Rect(40f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"实速度         MM/MIN", Main.sty_MostWords);
		GUI.Label(new Rect(133f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		GUI.Label(new Rect(310f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SACT         /分", Main.sty_MostWords);
		GUI.Label(new Rect(380f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SACT), Main.sty_SmallNum);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
