using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MDIEditModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
	}
	
	public void Edit ()
	{
		GUI.color = Color.cyan;
		if (GUI.Button(new Rect(840f/1000f*Main.width, 270f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "CAN"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.InputText != "")
				{
					char[] TempCharArray = Main.InputText.ToCharArray();
					string TempStr = "";
					for(int i = 0; i < TempCharArray.Length - 1; i++)
					{
						TempStr += TempCharArray[i];
					}
					Main.InputText = TempStr;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = 57f + Main.InputTextSize.x;
				}
			}
		}

		if (GUI.Button(new Rect(780f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "ALTER"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
					}
					else
					{
						Main.ProgProtectWarn = false;
						if(Main.ProgEDIT)
						{
							if(Main.InputText != "")
							{
								AlterCode();	
							}	
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect(840f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "INSERT"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
					}
					else
					{
						Main.ProgProtectWarn = false;
						if(Main.ProgEDIT)
						{
							if(Main.InputText != "")
							{
								InsertCode();	
							}	
						}
					}
				}
			}
		}
		
		if (GUI.Button(new Rect(900f/1000f*Main.width, 330f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "DELETE"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
					}
					else
					{
						Main.ProgProtectWarn = false;
						if(Main.ProgEDIT)
							DeleteCode();	
					}
				}
			}
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 390f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "PAGEu"))            
		{
			if(Main.ScreenPower)
				PageUp();
		}
		
		if (GUI.Button(new Rect(600f/1000f*Main.width, 450f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "PAGEd"))            
		{
			if(Main.ScreenPower)
				PageDown();
		}
		GUI.color = Color.white;
		if (GUI.Button(new Rect(660f/1000f*Main.width, 420f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "LEFT"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgEDIT)
					{
						//编辑程序时
						if(Main.ProgEDITProg)
						{
							EditProgLeft();
						}
					}
				}
				
				if(Main.SettingMenu)
				{
					if(Main.OffSetTool)
					{
						
					}
					if(Main.OffSetCoo)
					{
						CooSystem_script.Left();
					}
				}
			}
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 390f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "UP"))            
		{
			if(Main.ScreenPower)
				UpButton();
		}
		
		if (GUI.Button(new Rect(720f/1000f*Main.width, 450f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "DOWN"))            
		{
			if(Main.ScreenPower)
				DownButton();
		}
		
		if (GUI.Button(new Rect(780f/1000f*Main.width, 420f/1000f*Main.height, 50f/1000f*Main.width, 50f/1000f*Main.height), "RIGHT"))            
		{
			if(Main.ScreenPower)
			{
				if(Main.ProgMenu)
				{
					if(Main.ProgEDIT)
					{
						//编辑程序时
						if(Main.ProgEDITProg)
						{
							EditProgRight();
						}
					}
				}
				
				if(Main.SettingMenu)
				{
					if(Main.OffSetTool)
					{
					
					}
					if(Main.OffSetCoo)
					{
						CooSystem_script.Right();
					}
				}
			}
		}
	}
	
	float VerticalValue (int Row)
	{
		float Value = 0;
		if(Row == 1)
			Value = 100f;
		else if(Row == 2)
			Value = 125f;
		else if(Row == 3)
			Value = 150f;
		else if(Row == 4)
			Value = 175f;
		else if(Row == 5)
			Value = 200f;
		else if(Row == 6)
			Value = 225f;
		else if(Row == 7)
			Value = 250f;
		else if(Row == 8)
			Value = 275f;
		else 
			Value = 300f;
		return Value;
	}
	
	
	void AlterCode()
	{
		if(Main.MoreThanOneArray[Main.VerticalNum - 1])
		{
			List<string> TempCodeSubList = new List<string>();
			List<string> CalStr = new List<string>();
			List<List<string>> SingleRowCodeList = new List<List<string>>();
			char[] TempCharArray;
			bool SpaceFlag = false;
			string TestStr = "";
			string FormerWords = "";
			string LatterWords = "";
			int TargetRow = -1;
			int FirstVerticalRow = -1;
			TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
			for(int k = 0; k < TempCharArray.Length; k++)
			{
				if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
				{
					if(SpaceFlag)
					{
						CalStr.Add(TestStr);
						TestStr = ""+TempCharArray[k];
						SpaceFlag = false;
					}
					else
					{
						TestStr += TempCharArray[k];
						SpaceFlag = false;
					}
				}
				else
				{
					TestStr += TempCharArray[k];
					SpaceFlag = true;
				}
				if(k == TempCharArray.Length - 1)
				{
					CalStr.Add(TestStr);
					TestStr = "";
					SpaceFlag = false;
				}
			}
			TestStr = "";
			for(int a = 0; a < CalStr.Count; a++)
			{
				Main.EDITText.text = TestStr + CalStr[a];
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				if(Main.TextSize.x > 320f)
				{
					SingleRowCodeList.Add(TempCodeSubList);
					TempCodeSubList = new List<string>();
					TempCodeSubList.Add(CalStr[a]);
					TestStr = CalStr[a] + "  ";
				}
				else
				{
					TempCodeSubList.Add(CalStr[a]);
					TestStr = TestStr + CalStr[a] + "  ";	
				}
				if(a == CalStr.Count - 1)
					SingleRowCodeList.Add(TempCodeSubList);
			}
			string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted2 = new List<string>();
			for(int i = 0; i < MiddleStr.Length; i++)
			{
				if(MiddleStr[i].Trim() != "" && MiddleStr[i].Trim() != ";")
					RowStrWanted2.Add(MiddleStr[i].Trim());
			}	
			for(int k = 0; k < SingleRowCodeList.Count; k++)
			{
				TestStr = "";
				for(int t = 0; t < SingleRowCodeList[k].Count; t++)
				{
					TestStr += SingleRowCodeList[k][t];
				}
				string TestStr2 = "";
				for(int t = 0; t < RowStrWanted2.Count; t++)
				{
					TestStr2 += RowStrWanted2[t];
				}
				if(TestStr == TestStr2)
				{
					TargetRow = k;
					break;
				}	
			}
			FirstVerticalRow = Main.VerticalNum - TargetRow;
			int RangeInt = 0;
			if(TargetRow == SingleRowCodeList.Count - 1)
			{
				if(RowStrWanted2.Count + 1 == Main.HorizontalNum)
					RangeInt = Main.HorizontalNum - 1;
				else
					RangeInt = Main.HorizontalNum;
			}
			else
				RangeInt = Main.HorizontalNum;
			for(int a = 0; a < TargetRow+1; a++)
			{
				for(int k = 0; k < SingleRowCodeList[a].Count; k++)
				{
					if(a == TargetRow)
					{
						if(k == RangeInt - 1)
							break;		
					}
					FormerWords += SingleRowCodeList[a][k];
				}
			}
			for(int a = TargetRow; a < SingleRowCodeList.Count; a++)
			{
				for(int k = 0; k < SingleRowCodeList[a].Count; k++)
				{
					if(a == TargetRow)
					{
						if(k < Main.HorizontalNum)
							k = Main.HorizontalNum;
					}
					if(k >= SingleRowCodeList[a].Count)
						break;
					LatterWords += SingleRowCodeList[a][k];
				}
			}
			char[] TempCharArray1;
			TestStr = "";
			TempCharArray1 = Main.InputText.ToCharArray();
			CalStr = new List<string>();
			for(int k = 0; k < TempCharArray1.Length; k++)
			{
				if(TempCharArray1[k] == ';')
				{
					if(TestStr == "")
					{
						CalStr.Add("");
					}
					else
					{
						CalStr.Add(TestStr);
						TestStr = "";
					}
				}
				else
				{
					TestStr += TempCharArray1[k];
				}	
			}
			if(CalStr.Count > 0 || ((TargetRow == SingleRowCodeList.Count - 1)&&(Main.HorizontalNum == SingleRowCodeList[TargetRow].Count + 1)))
			{
				if(Main.HorizontalNum != SingleRowCodeList[TargetRow].Count + 1)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll.Insert(Main.RealCodeNum,"");
					Main.CodeForAll[Main.RealCodeNum] = TestStr + LatterWords;
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				else if((Main.HorizontalNum == SingleRowCodeList[TargetRow].Count + 1) && CalStr.Count > 0)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll[Main.RealCodeNum] = TestStr + Main.CodeForAll[Main.RealCodeNum];
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				else
				{
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll[Main.RealCodeNum - 1] = Main.CodeForAll[Main.RealCodeNum - 1] + TestStr + Main.CodeForAll[Main.RealCodeNum];
					Main.CodeForAll.RemoveAt(Main.RealCodeNum);
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);
			}
			else
			{
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + TestStr + LatterWords;	
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);	
			}
			
			Main.Code01 = Main.TempCodeArray[0];
			Main.Code02 = Main.TempCodeArray[1];
			Main.Code03 = Main.TempCodeArray[2];
			Main.Code04 = Main.TempCodeArray[3];
			Main.Code05 = Main.TempCodeArray[4];
			Main.Code06 = Main.TempCodeArray[5];
			Main.Code07 = Main.TempCodeArray[6];
			Main.Code08 = Main.TempCodeArray[7];
			Main.Code09 = Main.TempCodeArray[8];
			string[] MiddleStr1 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted3 = new List<string>();
			for(int i = 0; i < MiddleStr1.Length; i++)
			{
				if(MiddleStr1[i].Trim() != "")
					RowStrWanted3.Add(MiddleStr1[i].Trim());
			}
			if(RowStrWanted3.Count < Main.HorizontalNum)
			{
				Main.HorizontalNum = RowStrWanted3.Count;		
			}
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted3[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted3[Main.HorizontalNum - 1].Trim();
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
			Main.InputText = "";
			Main.ProgEDITCusorPos = 57f;
		}
		else
		{
			List<string> CalStr = new List<string>();
			char[] TempCharArray;
			string TestStr = "";
			string FormerWords = "";
			string LatterWords = "";
			string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted = new List<string>();
			for(int i = 0; i < MiddleStr.Length; i++)
			{
				if(MiddleStr[i].Trim() != "")
					RowStrWanted.Add(MiddleStr[i].Trim());
			}
			for(int a = 0; a < Main.HorizontalNum - 1; a++)
			{
				if(RowStrWanted[a] != ";")
					FormerWords += RowStrWanted[a];	
			}
			for(int a = Main.HorizontalNum; a < RowStrWanted.Count; a++)
			{
				if(RowStrWanted[a] != ";")
					LatterWords += RowStrWanted[a];	
			}
			TempCharArray = Main.InputText.ToCharArray();
			CalStr = new List<string>();
			for(int k = 0; k < TempCharArray.Length; k++)
			{
				if(TempCharArray[k] == ';')
				{
					if(TestStr == "")
					{
						CalStr.Add("");
					}
					else
					{
						CalStr.Add(TestStr);
						TestStr = "";
					}
				}
				else
				{
					TestStr += TempCharArray[k];
				}		
			}
			if(CalStr.Count > 0 || Main.HorizontalNum == RowStrWanted.Count)
			{
				if(Main.HorizontalNum != RowStrWanted.Count)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll.Insert(Main.RealCodeNum,"");
					Main.CodeForAll[Main.RealCodeNum] = TestStr + LatterWords;
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;
				}
				else if((Main.HorizontalNum == RowStrWanted.Count) && CalStr.Count > 0)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll[Main.RealCodeNum] = TestStr + Main.CodeForAll[Main.RealCodeNum];
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				else
				{
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}		
					Main.CodeForAll[Main.RealCodeNum - 1] = Main.CodeForAll[Main.RealCodeNum - 1] + TestStr + Main.CodeForAll[Main.RealCodeNum];	
					Main.CodeForAll.RemoveAt(Main.RealCodeNum);
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
			}
			else
			{
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + TestStr + LatterWords;
			}
			MiddleCodeEdit(Main.RealCodeNum, Main.VerticalNum);
			
			Main.Code01 = Main.TempCodeArray[0];
			Main.Code02 = Main.TempCodeArray[1];
			Main.Code03 = Main.TempCodeArray[2];
			Main.Code04 = Main.TempCodeArray[3];
			Main.Code05 = Main.TempCodeArray[4];
			Main.Code06 = Main.TempCodeArray[5];
			Main.Code07 = Main.TempCodeArray[6];
			Main.Code08 = Main.TempCodeArray[7];
			Main.Code09 = Main.TempCodeArray[8];
			
			string[] MiddleStr1 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted3 = new List<string>();
			for(int i = 0; i < MiddleStr1.Length; i++)
			{
				if(MiddleStr1[i].Trim() != "")
					RowStrWanted3.Add(MiddleStr1[i].Trim());
			}
			if(RowStrWanted3.Count < Main.HorizontalNum)
			{
				Main.HorizontalNum = RowStrWanted3.Count;		
			}
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted3[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted3[Main.HorizontalNum - 1].Trim();
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
			Main.InputText = "";
			Main.ProgEDITCusorPos = 57f;
		}
	}
	
	
	void MiddleCodeEdit (int StartRealNum, int StartVerticalNum) 
	{
		List<string> CalStr = new List<string>();
		List<string> StrStorage = new List<string>();
		int VerticalRow = StartVerticalNum - 1;
		for(int i = StartRealNum - 1; i < Main.TotalCodeNum; i++)
		{
			if(VerticalRow > 8)
				break;
			if(Main.CodeForAll[i] == "%")
			{
				StrStorage.Add("%");
				Main.TempCodeArray[VerticalRow] = "%";
				Main.RealNumArray[VerticalRow] = i;
				Main.MoreThanOneArray[VerticalRow] = false;
				VerticalRow++;
			}
			else if(Main.CodeForAll[i] == "")
			{
				StrStorage.Add(";");
				Main.TempCodeArray[VerticalRow] = ";";
				Main.RealNumArray[VerticalRow] = i;
				Main.MoreThanOneArray[VerticalRow] = false;
				VerticalRow++;
			}
			else
			{
				char[] TempCharArray;
				bool SpaceFlag = false;
				string AimCode = "";
				CalStr.Clear();
				CalStr = new List<string>();
				TempCharArray = Main.CodeForAll[i].ToCharArray();
				for(int k = 0; k < TempCharArray.Length; k++)
				{
					if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
					{
						if(SpaceFlag)
						{
							CalStr.Add(AimCode);
							AimCode = ""+TempCharArray[k];
							SpaceFlag = false;
						}
						else
						{
							AimCode += TempCharArray[k];
							SpaceFlag = false;
						}
					}
					else
					{
						AimCode += TempCharArray[k];
						SpaceFlag = true;
					}
					if(k == TempCharArray.Length - 1)
					{
						CalStr.Add(AimCode);
						AimCode = "";
						SpaceFlag = false;
						CalStr.Add(";");
					}
				}
				AimCode = "";
				SpaceFlag = false;
				for(int a = 0; a < CalStr.Count; a++)
				{
					if(VerticalRow > 8)
						break;
					Main.EDITText.text = AimCode + CalStr[a];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				
					if(Main.TextSize.x > 320f)
					{
						Main.TempCodeArray[VerticalRow] = AimCode.TrimEnd();						
						Main.RealNumArray[VerticalRow] = i;				
						Main.MoreThanOneArray[VerticalRow] = true;					
						VerticalRow++;					
						AimCode = CalStr[a] + "  ";
						SpaceFlag = true;
					}
					else
					{
						AimCode	= AimCode + CalStr[a] + "  ";
					}
				}
				
				if(VerticalRow <= 8)
				{
					Main.TempCodeArray[VerticalRow] = AimCode.TrimEnd();					
					Main.RealNumArray[VerticalRow] = i;				
					if(SpaceFlag)				
						Main.MoreThanOneArray[VerticalRow] = true;					
					else				
						Main.MoreThanOneArray[VerticalRow] = false;					
					VerticalRow++;
				}	
			}
		}	
		if(VerticalRow < 9)
		{
			for(int a = VerticalRow; a < 9; a++)
			{
				Main.TempCodeArray[a] = "";
				Main.RealNumArray[a] = -1;
				Main.MoreThanOneArray[a] = false;
			}
		}	
	}
	
	
	void MiddleCodeSpecialEdit(int StartRealNum, int StartVerticalNum)  
	{
		List<string> CalStr = new List<string>();
		List<string> StrStorage = new List<string>();
		int RejectedRow = 1 - StartVerticalNum;
		int VerticalRow = 0;
		int RejectedNum = 0;
		for(int i = StartRealNum - 1; i < Main.TotalCodeNum; i++)
		{
			if(VerticalRow > 8)
				break;
			if(Main.CodeForAll[i] == "%")
			{
				StrStorage.Add("%");
				Main.TempCodeArray[VerticalRow] = "%";
				Main.RealNumArray[VerticalRow] = i;
				Main.MoreThanOneArray[VerticalRow] = false;
				VerticalRow++;
			}
			else if(Main.CodeForAll[i] == "")
			{
				StrStorage.Add(";");
				Main.TempCodeArray[VerticalRow] = ";";
				Main.RealNumArray[VerticalRow] = i;
				Main.MoreThanOneArray[VerticalRow] = false;
				VerticalRow++;
			}
			else
			{
				char[] TempCharArray;
				bool SpaceFlag = false;
				string AimCode = "";
				CalStr.Clear();
				CalStr = new List<string>();
				TempCharArray = Main.CodeForAll[i].ToCharArray();
				for(int k = 0; k < TempCharArray.Length; k++)
				{
					if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
					{
						if(SpaceFlag)
						{
							CalStr.Add(AimCode);
							AimCode = ""+TempCharArray[k];
							SpaceFlag = false;
						}
						else
						{
							AimCode += TempCharArray[k];
							SpaceFlag = false;
						}	
					}
					else
					{
						AimCode += TempCharArray[k];
						SpaceFlag = true;
					}	
					if(k == TempCharArray.Length - 1)
					{
						CalStr.Add(AimCode);
						AimCode = "";
						SpaceFlag = false;
						CalStr.Add(";");
					}
				}
				AimCode = "";	
				SpaceFlag = false;
				for(int a = 0; a < CalStr.Count; a++)
				{
					if(VerticalRow > 8)
						break;
					Main.EDITText.text = AimCode + CalStr[a];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					if(Main.TextSize.x > 320f)
					{
						RejectedNum++;
						if(RejectedNum > RejectedRow)
						{
							Main.TempCodeArray[VerticalRow] = AimCode.TrimEnd();
							Main.RealNumArray[VerticalRow] = i;
							Main.MoreThanOneArray[VerticalRow] = true;
							VerticalRow++;
						}
						AimCode = CalStr[a] + "  ";
						SpaceFlag = true;
					}
					else
					{
						AimCode	= AimCode + CalStr[a] + "  ";
					}
				}	
				if(VerticalRow <= 8)
				{
					Main.TempCodeArray[VerticalRow] = AimCode.TrimEnd();
					Main.RealNumArray[VerticalRow] = i;		
					if(SpaceFlag)		
						Main.MoreThanOneArray[VerticalRow] = true;				
					else				
						Main.MoreThanOneArray[VerticalRow] = false;				
					VerticalRow++;
				}
			}
		}	
		if(VerticalRow < 8)
		{
			for(int a = VerticalRow; a < 9; a++)
			{
				Main.TempCodeArray[a] = "";
				Main.RealNumArray[a] = -1;
				Main.MoreThanOneArray[a] = false;
			}
		}
	}
	
	
	void InsertCode ()
	{
		if(Main.MoreThanOneArray[Main.VerticalNum - 1])
		{
			List<string> TempCodeSubList = new List<string>();
			List<string> CalStr = new List<string>();
			List<List<string>> SingleRowCodeList = new List<List<string>>();
			char[] TempCharArray;
			bool SpaceFlag = false;
			string TestStr = "";
			string FormerWords = "";
			string LatterWords = "";
			int TargetRow = -1;
			int FirstVerticalRow = -1;
			TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
			for(int k = 0; k < TempCharArray.Length; k++)
			{
				if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
				{
					if(SpaceFlag)
					{
						CalStr.Add(TestStr);				
						TestStr = ""+TempCharArray[k];
						SpaceFlag = false;
					}
					else
					{
						TestStr += TempCharArray[k];
						SpaceFlag = false;
					}
				}
				else
				{
					TestStr += TempCharArray[k];
					SpaceFlag = true;
				}
				if(k == TempCharArray.Length - 1)
				{
					CalStr.Add(TestStr);
					TestStr = "";
					SpaceFlag = false;
				}
			}	
			TestStr = "";
			for(int a = 0; a < CalStr.Count; a++)
			{
				Main.EDITText.text = TestStr + CalStr[a];			
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				if(Main.TextSize.x > 320f)
				{
					SingleRowCodeList.Add(TempCodeSubList);
					TempCodeSubList = new List<string>();
					TempCodeSubList.Add(CalStr[a]);
					TestStr = CalStr[a] + "  ";
				}
				else
				{
					TempCodeSubList.Add(CalStr[a]);
					TestStr = TestStr + CalStr[a] + "  ";	
				}
				if(a == CalStr.Count - 1)
					SingleRowCodeList.Add(TempCodeSubList);	
			}
			string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted2 = new List<string>();
			for(int i = 0; i < MiddleStr.Length; i++)
			{
				if(MiddleStr[i].Trim() != "" && MiddleStr[i].Trim() != ";")
					RowStrWanted2.Add(MiddleStr[i].Trim());
			}
			for(int k = 0; k < SingleRowCodeList.Count; k++)
			{
				TestStr = "";
				for(int t = 0; t < SingleRowCodeList[k].Count; t++)
				{
					TestStr += SingleRowCodeList[k][t];
				}
				string TestStr2 = "";
				for(int t = 0; t < RowStrWanted2.Count; t++)
				{
					TestStr2 += RowStrWanted2[t];
				}
				if(TestStr == TestStr2)
				{
					TargetRow = k;	
					break;
				}	
			}	
			FirstVerticalRow = Main.VerticalNum - TargetRow;
			int RangeInt = 0;
			if(TargetRow == SingleRowCodeList.Count - 1)
			{
				if(RowStrWanted2.Count + 1 == Main.HorizontalNum)
					RangeInt = Main.HorizontalNum - 1;
				else
					RangeInt = Main.HorizontalNum;
			}
			else
				RangeInt = Main.HorizontalNum;
			for(int a = 0; a < TargetRow+1; a++)
			{
				for(int k = 0; k < SingleRowCodeList[a].Count; k++)
				{
					if(a == TargetRow)
					{
						if(k == RangeInt)	
							break;		
					}
					FormerWords += SingleRowCodeList[a][k];
				}
			}
			for(int a = TargetRow; a < SingleRowCodeList.Count; a++)
			{
				for(int k = 0; k < SingleRowCodeList[a].Count; k++)
				{
					if(a == TargetRow)
					{
						if(k < Main.HorizontalNum)
							k = Main.HorizontalNum;
					}
					if(k >= SingleRowCodeList[a].Count)
						break;
					LatterWords += SingleRowCodeList[a][k];
				}
			}
			char[] TempCharArray1;	
			TestStr = "";
			TempCharArray1 = Main.InputText.ToCharArray();	
			CalStr = new List<string>();		
			for(int k = 0; k < TempCharArray1.Length; k++)
			{
				if(TempCharArray1[k] == ';')
				{
					if(TestStr == "")
					{
						CalStr.Add("");
					}
					else
					{
						CalStr.Add(TestStr);	
						TestStr = "";
					}
				}
				else
				{
					TestStr += TempCharArray1[k];
				}		
			}		
			if(CalStr.Count > 0 || ((TargetRow == SingleRowCodeList.Count - 1)&&(Main.HorizontalNum == SingleRowCodeList[TargetRow].Count + 1)))
			{
				if(Main.HorizontalNum != SingleRowCodeList[TargetRow].Count + 1)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll.Insert(Main.RealCodeNum,"");
					Main.CodeForAll[Main.RealCodeNum] = TestStr + LatterWords;
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				else
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords;
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll[Main.RealCodeNum] = TestStr + Main.CodeForAll[Main.RealCodeNum];
					for(int a = CalStr.Count - 1; a >= 0; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}					
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);
			}
			else
			{
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + TestStr + LatterWords;	
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);	
			}
			
			Main.Code01 = Main.TempCodeArray[0];
			Main.Code02 = Main.TempCodeArray[1];
			Main.Code03 = Main.TempCodeArray[2];
			Main.Code04 = Main.TempCodeArray[3];
			Main.Code05 = Main.TempCodeArray[4];
			Main.Code06 = Main.TempCodeArray[5];
			Main.Code07 = Main.TempCodeArray[6];
			Main.Code08 = Main.TempCodeArray[7];
			Main.Code09 = Main.TempCodeArray[8];
			
			string[] MiddleStr1 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted3 = new List<string>();
			for(int i = 0; i < MiddleStr1.Length; i++)
			{
				if(MiddleStr1[i].Trim() != "")
					RowStrWanted3.Add(MiddleStr1[i].Trim());
			}
			if(RowStrWanted3.Count <= Main.HorizontalNum)
			{
				Main.HorizontalNum = RowStrWanted3.Count;			
			}
			else
				Main.HorizontalNum++;
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted3[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted3[Main.HorizontalNum - 1].Trim();
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);	
			Main.InputText = "";		
			Main.ProgEDITCusorPos = 57f;
		}
		else
		{
			List<string> CalStr = new List<string>();
			char[] TempCharArray;
			string TestStr = "";
			string FormerWords = "";	
			string LatterWords = "";	
			string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');		
			List<string> RowStrWanted = new List<string>();		
			for(int i = 0; i < MiddleStr.Length; i++)
			{
				if(MiddleStr[i].Trim() != "")			
					RowStrWanted.Add(MiddleStr[i].Trim());
			}		
			for(int a = 0; a < Main.HorizontalNum; a++)
			{
				if(RowStrWanted[a] != ";")
					FormerWords += RowStrWanted[a];	
			}
			for(int a = Main.HorizontalNum; a < RowStrWanted.Count; a++)
			{
				if(RowStrWanted[a] != ";")
					LatterWords += RowStrWanted[a];	
			}
			TempCharArray = Main.InputText.ToCharArray();
			CalStr = new List<string>();
			for(int k = 0; k < TempCharArray.Length; k++)
			{
				if(TempCharArray[k] == ';')
				{
					if(TestStr == "")
					{
						CalStr.Add("");
					}
					else
					{
						CalStr.Add(TestStr);
						TestStr = "";
					}
				}
				else
				{
					TestStr += TempCharArray[k];
				}	
			}
			if(CalStr.Count > 0 || Main.HorizontalNum == RowStrWanted.Count)
			{
				if(Main.HorizontalNum != RowStrWanted.Count)
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + CalStr[0];
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll.Insert(Main.RealCodeNum,"");
					Main.CodeForAll[Main.RealCodeNum] = TestStr + LatterWords;
					for(int a = CalStr.Count - 1; a >= 1; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;
				}
				else
				{
					Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords;
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						Main.CodeForAll.Add("");
					}
					Main.CodeForAll[Main.RealCodeNum] = TestStr + Main.CodeForAll[Main.RealCodeNum];
					for(int a = CalStr.Count - 1; a >= 0; a--)
					{
						Main.CodeForAll.Insert(Main.RealCodeNum,CalStr[a]);
					}
					if(Main.RealCodeNum == Main.TotalCodeNum)
					{
						if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
							Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
					}
					Main.TotalCodeNum = Main.CodeForAll.Count;	
				}
			}
			else
			{
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + TestStr + LatterWords;
			}
			MiddleCodeEdit(Main.RealCodeNum, Main.VerticalNum);
			
			Main.Code01 = Main.TempCodeArray[0];
			Main.Code02 = Main.TempCodeArray[1];
			Main.Code03 = Main.TempCodeArray[2];
			Main.Code04 = Main.TempCodeArray[3];
			Main.Code05 = Main.TempCodeArray[4];
			Main.Code06 = Main.TempCodeArray[5];
			Main.Code07 = Main.TempCodeArray[6];
			Main.Code08 = Main.TempCodeArray[7];
			Main.Code09 = Main.TempCodeArray[8];
			
			string[] MiddleStr1 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
			List<string> RowStrWanted3 = new List<string>();	
			for(int i = 0; i < MiddleStr1.Length; i++)
			{
				if(MiddleStr1[i].Trim() != "")
					RowStrWanted3.Add(MiddleStr1[i].Trim());
			}
			if(RowStrWanted3.Count <= Main.HorizontalNum)
			{
				Main.HorizontalNum = RowStrWanted3.Count;			
			}
			else
				Main.HorizontalNum++;
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted3[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted3[Main.HorizontalNum - 1].Trim();
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
			Main.InputText = "";
			Main.ProgEDITCusorPos = 57f;
		}	
	}
	
	
	public void CodeEdit ()
	{
		List<int> RealNumList = new List<int>();
		Main.TempCodeList.Clear();
		Main.TempCodeList = new List<List<string>>();
		List<string> TempCodeSubList = new List<string>();
		string TestStr = "";
		int Nine = 9;
		if(Main.TotalCodeNum <= Main.RealCodeNum + 8)
			Nine = Main.TotalCodeNum;
		else
			Nine = Main.RealCodeNum + 8;
		for(int i = 0; i < 9; i++)
		{
			Main.TempCodeArray[i] = "";
			Main.MoreThanOneArray[i] = false;
			Main.RealNumArray[i] = -1;
		}
		for(int i = Main.RealCodeNum - 1; i < Nine; i++)
		{
			TempCodeSubList = new List<string>();
			if(Main.CodeForAll[i] == "%")
			{
				TempCodeSubList.Add(Main.CodeForAll[i]);
				Main.TempCodeList.Add(TempCodeSubList);
				RealNumList.Add(i);
			}
			else if(Main.CodeForAll[i] == "")
			{
				TempCodeSubList.Add(";");
				Main.TempCodeList.Add(TempCodeSubList);
				RealNumList.Add(i);
			}
			else
			{
				TestStr = Main.CodeForAll[i];
				char[] TempCharArray;
				bool SpaceFlag = false;
				TempCharArray = TestStr.ToCharArray();
				TestStr = "";
				for(int k = 0; k < TempCharArray.Length; k++)
				{
					if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
					{
						if(SpaceFlag)
						{
							TempCodeSubList.Add(TestStr);
							TestStr = ""+TempCharArray[k];	
							SpaceFlag = false;
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = false;
						}
					}
					else
					{
						TestStr += TempCharArray[k];
						SpaceFlag = true;
					}
					
					if(k == TempCharArray.Length - 1)
					{
						TempCodeSubList.Add(TestStr);
						TestStr = "";
						SpaceFlag = false;
						TempCodeSubList.Add(";");
					}
				}
				Main.TempCodeList.Add(TempCodeSubList);
				RealNumList.Add(i);			
			}
		}
		int Row = 0;
		int RowA = 0;
		int Number = Main.TempCodeList.Count;
		for(int i = 0; i < Number; i++)
		{
			Row = i + RowA;
			for(int k =0; k < Main.TempCodeList[i].Count; k++)
			{
				if(k != Main.TempCodeList[i].Count - 1)
				{
					Main.EDITText.text = Main.TempCodeArray[Row] + Main.TempCodeList[i][k];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					if(Main.TextSize.x > 320f)
					{
						RowA++;
						Number--;
						Row = i + RowA;
						if(Row > 8)
							break;
						Main.TempCodeArray[Row - 1] = Main.TempCodeArray[Row - 1].TrimEnd();
						Main.TempCodeArray[Row] += (Main.TempCodeList[i][k] + "  ");
						Main.RealNumArray[Row] = i + Main.RealCodeNum - 1;
						Main.MoreThanOneArray[Row - 1] = true;
						Main.MoreThanOneArray[Row] = true;
					}
					else
					{
						Main.TempCodeArray[Row] += (Main.TempCodeList[i][k] + "  ");
						Main.RealNumArray[Row] = i + Main.RealCodeNum - 1;	
					}
				}
				else
				{
					Main.EDITText.text = Main.TempCodeArray[Row] + Main.TempCodeList[i][k];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					if(Main.TextSize.x >= 320f)
					{
						RowA++;		
						Number--;	
						Row = i + RowA;
						if(Row > 8)
							break;
						Main.TempCodeArray[Row - 1] = Main.TempCodeArray[Row - 1].TrimEnd();
						Main.TempCodeArray[Row] += (Main.TempCodeList[i][k]);
						Main.RealNumArray[Row] = i + Main.RealCodeNum - 1;
						Main.MoreThanOneArray[Row - 1] = true;
						Main.MoreThanOneArray[Row] = true;
					}
					else
					{
						Main.TempCodeArray[Row] += (Main.TempCodeList[i][k]);
						Main.RealNumArray[Row] = i + Main.RealCodeNum - 1;
					}
				}
			}
			if(Row > 8)
				break;
		}
		Main.StartRow = Main.RealCodeNum - 1;
		if(Number == 1)
			Main.EndRow = Main.StartRow + 1;
		else if(Number == 0)
			Main.EndRow = Main.StartRow;
		else
			Main.EndRow = Main.StartRow + Number - 1;
		Main.Code01 = Main.TempCodeArray[0];
		Main.Code02 = Main.TempCodeArray[1];
		Main.Code03 = Main.TempCodeArray[2];
		Main.Code04 = Main.TempCodeArray[3];
		Main.Code05 = Main.TempCodeArray[4];
		Main.Code06 = Main.TempCodeArray[5];
		Main.Code07 = Main.TempCodeArray[6];
		Main.Code08 = Main.TempCodeArray[7];
		Main.Code09 = Main.TempCodeArray[8];
	}
	
	
	void DeleteCode () 
	{
		List<string> TempCodeSubList = new List<string>();
		List<string> CalStr = new List<string>();
		List<List<string>> SingleRowCodeList = new List<List<string>>();
		char[] TempCharArray;
		bool SpaceFlag = false;
		string TestStr = "";
		string FormerWords = "";
		string LatterWords = "";
		int TargetRow = -1;
		int FirstVerticalRow = -1;	
		string KeyWord = "";		
		TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();	
		for(int k = 0; k < TempCharArray.Length; k++)
		{
			if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
			{
				if(SpaceFlag)
				{
					CalStr.Add(TestStr);
					TestStr = ""+TempCharArray[k];
					SpaceFlag = false;
				}
				else
				{
					TestStr += TempCharArray[k];
					SpaceFlag = false;
				}
			}
			else
			{
				TestStr += TempCharArray[k];
				SpaceFlag = true;
			}
			if(k == TempCharArray.Length - 1)
			{
				CalStr.Add(TestStr);
				TestStr = "";
				SpaceFlag = false;
			}
		}
		TestStr = "";
		for(int a = 0; a < CalStr.Count; a++)
		{
			Main.EDITText.text = TestStr + CalStr[a];
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			if(Main.TextSize.x > 320f)
			{
				SingleRowCodeList.Add(TempCodeSubList);
				TempCodeSubList = new List<string>();
				TempCodeSubList.Add(CalStr[a]);
				TestStr = CalStr[a] + "  ";
			}
			else
			{
				TempCodeSubList.Add(CalStr[a]);
				TestStr = TestStr + CalStr[a] + "  ";	
			}
			if(a == CalStr.Count - 1)
				SingleRowCodeList.Add(TempCodeSubList);	
		}
		string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
		List<string> RowStrWanted = new List<string>();	
		for(int i = 0; i < MiddleStr.Length; i++)
		{
			if(MiddleStr[i].Trim() != "")
				RowStrWanted.Add(MiddleStr[i].Trim());
		}
		KeyWord = RowStrWanted[Main.HorizontalNum - 1];
		if(Main.MoreThanOneArray[Main.VerticalNum - 1])
		{
			for(int k = 0; k < SingleRowCodeList.Count; k++)
			{
				TestStr = "";
				for(int t = 0; t < SingleRowCodeList[k].Count; t++)
				{
					TestStr += SingleRowCodeList[k][t];
				}
				string TestStr2 = "";
				for(int t = 0; t < RowStrWanted.Count; t++)
				{
					if(RowStrWanted[t] != ";")
						TestStr2 += RowStrWanted[t];
				}
				if(TestStr == TestStr2)
				{
					TargetRow = k;
					break;
				}
			}
			FirstVerticalRow = Main.VerticalNum - TargetRow;
			if(KeyWord == ";")
			{
				if(Main.RealCodeNum == Main.TotalCodeNum)
				{
					Main.EDITText.text = KeyWord;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));		
					return;
				}
				FormerWords = Main.CodeForAll[Main.RealCodeNum - 1];
				LatterWords = Main.CodeForAll[Main.RealCodeNum];
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + LatterWords;
				Main.CodeForAll.RemoveAt(Main.RealCodeNum);
				Main.TotalCodeNum = Main.CodeForAll.Count;
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);
				
				Main.Code01 = Main.TempCodeArray[0];
				Main.Code02 = Main.TempCodeArray[1];
				Main.Code03 = Main.TempCodeArray[2];
				Main.Code04 = Main.TempCodeArray[3];
				Main.Code05 = Main.TempCodeArray[4];
				Main.Code06 = Main.TempCodeArray[5];
				Main.Code07 = Main.TempCodeArray[6];
				Main.Code08 = Main.TempCodeArray[7];
				Main.Code09 = Main.TempCodeArray[8];
				
				string[] MiddleStr2 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				List<string> RowStrWanted2 = new List<string>();
				for(int i = 0; i < MiddleStr2.Length; i++)
				{
					if(MiddleStr2[i].Trim() != "")
						RowStrWanted2.Add(MiddleStr2[i].Trim());
				}
				if(RowStrWanted2.Count < Main.HorizontalNum)
				{
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;
				}
				Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
			}
			else
			{
				for(int a = 0; a < TargetRow+1; a++)
				{
					for(int k = 0; k < SingleRowCodeList[a].Count; k++)
					{
						if(a == TargetRow)
						{
							if(k == Main.HorizontalNum - 1)
								break;		
						}
						FormerWords += SingleRowCodeList[a][k];
					}
				}
				for(int a = TargetRow; a < SingleRowCodeList.Count; a++)
				{
					for(int k = 0; k < SingleRowCodeList[a].Count; k++)
					{
						if(a == TargetRow)
						{
							if(k < Main.HorizontalNum)
								k = Main.HorizontalNum;
						}
						if(k >= SingleRowCodeList[a].Count)
							break;
						LatterWords += SingleRowCodeList[a][k];
					}
				}
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + LatterWords;
				if(FirstVerticalRow > 0)
					MiddleCodeEdit(Main.RealCodeNum, FirstVerticalRow);
				else
					MiddleCodeSpecialEdit(Main.RealCodeNum, FirstVerticalRow);
				
				Main.Code01 = Main.TempCodeArray[0];
				Main.Code02 = Main.TempCodeArray[1];
				Main.Code03 = Main.TempCodeArray[2];
				Main.Code04 = Main.TempCodeArray[3];
				Main.Code05 = Main.TempCodeArray[4];
				Main.Code06 = Main.TempCodeArray[5];
				Main.Code07 = Main.TempCodeArray[6];
				Main.Code08 = Main.TempCodeArray[7];
				Main.Code09 = Main.TempCodeArray[8];
				
				string[] MiddleStr2 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				List<string> RowStrWanted2 = new List<string>();
				for(int i = 0; i < MiddleStr2.Length; i++)
				{
					if(MiddleStr2[i].Trim() != "")
						RowStrWanted2.Add(MiddleStr2[i].Trim());
				}
				if(RowStrWanted2.Count < Main.HorizontalNum)
				{
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;
				}
				Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
			}	
		}
		else
		{
			if(KeyWord == ";")
			{
				if(Main.RealCodeNum == Main.TotalCodeNum)
				{
					Main.EDITText.text = KeyWord;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					return;
				}
				for(int a = 0; a < RowStrWanted.Count - 1; a++)
				{
					FormerWords += RowStrWanted[a];
				}
				LatterWords = Main.CodeForAll[Main.RealCodeNum];
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + LatterWords;
				Main.CodeForAll.RemoveAt(Main.RealCodeNum);
				Main.TotalCodeNum = Main.CodeForAll.Count;
				MiddleCodeEdit(Main.RealCodeNum, Main.VerticalNum);
				
				Main.Code01 = Main.TempCodeArray[0];
				Main.Code02 = Main.TempCodeArray[1];
				Main.Code03 = Main.TempCodeArray[2];
				Main.Code04 = Main.TempCodeArray[3];
				Main.Code05 = Main.TempCodeArray[4];
				Main.Code06 = Main.TempCodeArray[5];
				Main.Code07 = Main.TempCodeArray[6];
				Main.Code08 = Main.TempCodeArray[7];
				Main.Code09 = Main.TempCodeArray[8];
				
				string[] MiddleStr2 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				List<string> RowStrWanted2 = new List<string>();
				for(int i = 0; i < MiddleStr2.Length; i++)
				{
					if(MiddleStr2[i].Trim() != "")
						RowStrWanted2.Add(MiddleStr2[i].Trim());
				}
				if(RowStrWanted2.Count < Main.HorizontalNum)
				{
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;
				}
				Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	 
			}
			else
			{
				for(int a = 0; a < Main.HorizontalNum - 1; a++)
				{
					FormerWords += RowStrWanted[a];
				}
				for(int a = Main.HorizontalNum; a < RowStrWanted.Count - 1; a++)
				{
					LatterWords += RowStrWanted[a];
				}
				Main.CodeForAll[Main.RealCodeNum - 1] = FormerWords + LatterWords;
				MiddleCodeEdit(Main.RealCodeNum, Main.VerticalNum);
				
				Main.Code01 = Main.TempCodeArray[0];
				Main.Code02 = Main.TempCodeArray[1];
				Main.Code03 = Main.TempCodeArray[2];
				Main.Code04 = Main.TempCodeArray[3];
				Main.Code05 = Main.TempCodeArray[4];
				Main.Code06 = Main.TempCodeArray[5];
				Main.Code07 = Main.TempCodeArray[6];
				Main.Code08 = Main.TempCodeArray[7];
				Main.Code09 = Main.TempCodeArray[8];
				
				string[] MiddleStr2 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				List<string> RowStrWanted2 = new List<string>();
				for(int i = 0; i < MiddleStr2.Length; i++)
				{
					if(MiddleStr2[i].Trim() != "")
						RowStrWanted2.Add(MiddleStr2[i].Trim());
				}
				if(RowStrWanted2.Count < Main.HorizontalNum)
				{
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;
				}
				Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			}
		}	
	}
	
	
	void PageUp () 
	{	
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.RealNumArray[0] == 0)
					{
						return;
					}
					else
					{
						Main.RealCodeNum = Main.RealNumArray[0];
						Main.HorizontalNum = 1;				
						Main.VerticalNum = 1;			
						Main.ProgEDITCusorV = 100f;			
						Main.ProgEDITCusorH = 32f;						
						if(Main.RealCodeNum <= 9)							
							Main.RealCodeNum = 1;
						else							
							Main.RealCodeNum = Main.RealCodeNum - 8;						
						CodeEdit();						
						Main.EDITText.text = Main.TempCodeList[0][0];						
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					}
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
					int CurrentPage = (Main.RealListNum - 1) / 8;
					if(CurrentPage > 0)	
						CurrentPage--;
					Main.ProgEDITCusor = 175f;	
					Main.RealListNum = CurrentPage * 8 + 1; 
					string[] TempNameArray = new string[8];	
					int[] TempSizeArray = new int[8];		
					string[] TempDateArray = new string[8];			
					for(int i = 0; i < 8; i++)
					{
						TempNameArray[i] = "";	
						TempSizeArray[i] = 0;
						TempDateArray[i] = "";
					}
					int MiddleNum = -1;
					int FinalNum = Main.RealListNum + 7;
					if(FinalNum > Main.TotalListNum)	
						FinalNum = Main.TotalListNum;
					for(int i = Main.RealListNum - 1; i < FinalNum; i++)
					{
						MiddleNum++;
						TempNameArray[MiddleNum] = Main.FileNameList[i];
						TempSizeArray[MiddleNum] = Main.FileSizeList[i];
						TempDateArray[MiddleNum] = Main.FileDateList[i];
					}
					
					Main.CodeName01 = TempNameArray[0];
					Main.CodeName02 = TempNameArray[1];
					Main.CodeName03 = TempNameArray[2];
					Main.CodeName04 = TempNameArray[3];
					Main.CodeName05 = TempNameArray[4];
					Main.CodeName06 = TempNameArray[5];
					Main.CodeName07 = TempNameArray[6];
					Main.CodeName08 = TempNameArray[7];
					
					Main.CodeSize01 = TempSizeArray[0];
					Main.CodeSize02 = TempSizeArray[1];
					Main.CodeSize03 = TempSizeArray[2];
					Main.CodeSize04 = TempSizeArray[3];
					Main.CodeSize05 = TempSizeArray[4];
					Main.CodeSize06 = TempSizeArray[5];
					Main.CodeSize07 = TempSizeArray[6];
					Main.CodeSize08 = TempSizeArray[7];
					
					Main.UpdateDate01 = TempDateArray[0];
					Main.UpdateDate02 = TempDateArray[1];
					Main.UpdateDate03 = TempDateArray[2];
					Main.UpdateDate04 = TempDateArray[3];
					Main.UpdateDate05 = TempDateArray[4];
					Main.UpdateDate06 = TempDateArray[5];
					Main.UpdateDate07 = TempDateArray[6];
					Main.UpdateDate08 = TempDateArray[7];	
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffCooFirstPage == false)
				{
					Main.OffCooFirstPage = true;
					CooSystem_script.PageUp();
				}
			}
		}
	}
	
	void PageDown () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.RealNumArray[8] == -1 || Main.RealNumArray[8] == Main.TotalCodeNum - 1)
					{
						return;
					}
					else
					{
						Main.RealCodeNum = Main.RealNumArray[8] + 2;
						Main.HorizontalNum = 1;	
						Main.VerticalNum = 1;			
						Main.ProgEDITCusorV = 100f;
						Main.ProgEDITCusorH = 32f;
						CodeEdit();	
						Main.EDITText.text = Main.TempCodeList[0][0];	
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					}
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
					int TotalPage = (Main.TotalListNum - 1) / 8;
					int CurrentPage = (Main.RealListNum - 1) / 8;
					if(TotalPage > CurrentPage)
						CurrentPage++;
					Main.ProgEDITCusor = 175f;
					Main.RealListNum = CurrentPage * 8 + 1; 
					string[] TempNameArray = new string[8];
					int[] TempSizeArray = new int[8]; 
					string[] TempDateArray = new string[8];
					for(int i = 0; i < 8; i++)
					{
						TempNameArray[i] = "";
						TempSizeArray[i] = 0;
						TempDateArray[i] = "";
					}
					int MiddleNum = -1;
					int FinalNum = Main.RealListNum + 7;
					if(FinalNum > Main.TotalListNum)
						FinalNum = Main.TotalListNum;
					for(int i = Main.RealListNum - 1; i < FinalNum; i++)
					{
						MiddleNum++;
						TempNameArray[MiddleNum] = Main.FileNameList[i];
						TempSizeArray[MiddleNum] = Main.FileSizeList[i];
						TempDateArray[MiddleNum] = Main.FileDateList[i];
					}
					
					Main.CodeName01 = TempNameArray[0];
					Main.CodeName02 = TempNameArray[1];
					Main.CodeName03 = TempNameArray[2];
					Main.CodeName04 = TempNameArray[3];
					Main.CodeName05 = TempNameArray[4];
					Main.CodeName06 = TempNameArray[5];
					Main.CodeName07 = TempNameArray[6];
					Main.CodeName08 = TempNameArray[7];
						
					Main.CodeSize01 = TempSizeArray[0];
					Main.CodeSize02 = TempSizeArray[1];
					Main.CodeSize03 = TempSizeArray[2];
					Main.CodeSize04 = TempSizeArray[3];
					Main.CodeSize05 = TempSizeArray[4];
					Main.CodeSize06 = TempSizeArray[5];
					Main.CodeSize07 = TempSizeArray[6];
					Main.CodeSize08 = TempSizeArray[7];
					
					Main.UpdateDate01 = TempDateArray[0];
					Main.UpdateDate02 = TempDateArray[1];
					Main.UpdateDate03 = TempDateArray[2];
					Main.UpdateDate04 = TempDateArray[3];
					Main.UpdateDate05 = TempDateArray[4];
					Main.UpdateDate06 = TempDateArray[5];
					Main.UpdateDate07 = TempDateArray[6];
					Main.UpdateDate08 = TempDateArray[7];
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffCooFirstPage)
				{
					Main.OffCooFirstPage = false;
					CooSystem_script.PageDown();
				}
			}
		}
	}
	
	void EditProgLeft()
	{
		string[] CurrentRowStr = Main.TempCodeArray[Main.VerticalNum - 1].TrimEnd().Split(' ');
		List<string> RowStrWanted = new List<string>();
		for(int i = 0; i < CurrentRowStr.Length; i++)
		{
			if(CurrentRowStr[i].Trim() != "")
				RowStrWanted.Add(CurrentRowStr[i]);
		}
		if(Main.HorizontalNum > 1)
		{
			Main.HorizontalNum--;
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted[Main.HorizontalNum - 1];
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
		}
		else
		{
			if(Main.VerticalNum != 1)
			{
				Main.VerticalNum--;
				if(Main.RealNumArray[Main.VerticalNum] != Main.RealNumArray[Main.VerticalNum - 1])
					Main.RealCodeNum--;
				string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				List<string> RowStrWanted2 = new List<string>();
				for(int i = 0; i < MiddleStr.Length; i++)
				{
					if(MiddleStr[i].Trim() != "")
						RowStrWanted2.Add(MiddleStr[i]);
				}
				Main.HorizontalNum = RowStrWanted2.Count;
				string TempStr = "";
				for(int i = 0; i < Main.HorizontalNum - 1; i++)
				{
					TempStr = TempStr + RowStrWanted2[i] + "0";
				}
				Main.EDITText.text = TempStr;
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorH = 32f + Main.TextSize.x;
				Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
			}
			else
			{
				if(Main.MoreThanOneArray[0])
				{
					List<string> CalStr = new List<string>();
					List<string> StrStorage = new List<string>();
					string[] StrArray = new string[9];
					int[] intStorage = new int[9];
					bool[] boolStorage = new bool[9];
					for(int a= 0; a < 9; a++)
					{
						StrArray[a] = Main.TempCodeArray[a];
						intStorage[a] = Main.RealNumArray[a];
						boolStorage[a] = Main.MoreThanOneArray[a];
					}
					int Num1 = 0;
					int Num2 = 0;
					string TestStr = "";
					bool SpaceFlag = false;
					char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
					for(int a = 0; a < 9; a++)
					{
						if(Main.RealNumArray[a] == Main.RealCodeNum - 1)
						Num1++;
					}
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[0] == '%')
						{
							CalStr.Add("%");
							break;
						}
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);
								TestStr = ""+TempCharArray[k];
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = false;
							}	
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = true;
						}
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);
							TestStr = "";
							SpaceFlag = false;
							CalStr.Add(";");
						}
					}
					TestStr = "";
					for(int a = 0; a < CalStr.Count; a++)
					{
						Main.EDITText.text = TestStr + CalStr[a];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
						if(Main.TextSize.x > 320f)
						{
							StrStorage.Add(TestStr.TrimEnd());
							TestStr = CalStr[a] + "  ";
						}
						else
						{
							TestStr = TestStr + CalStr[a] + "  ";
						}
						if(a == CalStr.Count - 1)
							StrStorage.Add(TestStr.TrimEnd());	
					}
					Num2 = StrStorage.Count;
					for(int a = 1; a < 9; a++)
					{
						Main.TempCodeArray[a] = StrArray[a - 1];
						Main.MoreThanOneArray[a] = boolStorage[a - 1];
						Main.RealNumArray[a] = intStorage[a - 1];
					}
					if(Num1 == Num2)
					{
						Main.RealCodeNum--;
						char[] TempCharArray1 = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
						TestStr = "";
						CalStr.Clear();		
						CalStr= new List<string>();		
						StrStorage.Clear();
						StrStorage = new List<string>();
						if(TempCharArray1.Length == 0)
						{
							CalStr.Add(";");
						}
						for(int k = 0; k < TempCharArray1.Length; k++)
						{
							if(TempCharArray1[0] == '%')
							{
								CalStr.Add("%");
								break;
							}
							if(TempCharArray1[k] >= 'A' && TempCharArray1[k] <= 'Z')
							{
								if(SpaceFlag)
								{
									CalStr.Add(TestStr);
									TestStr = ""+TempCharArray1[k];
									SpaceFlag = false;
								}
								else
								{
									TestStr += TempCharArray1[k];
									SpaceFlag = false;
								}
							}
							else
							{
								TestStr += TempCharArray1[k];
								SpaceFlag = true;
							}
							if(k == TempCharArray1.Length - 1)
							{
								CalStr.Add(TestStr);
								TestStr = "";
								SpaceFlag = false;
								CalStr.Add(";");
							}
						}
						TestStr = "";
						for(int a = 0; a < CalStr.Count; a++)
						{
							Main.EDITText.text = TestStr + CalStr[a];
							Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							if(Main.TextSize.x > 320f)
							{
								StrStorage.Add(TestStr.TrimEnd());
								TestStr = CalStr[a] + "  ";
							}
							else
							{
								TestStr = TestStr + CalStr[a] + "  ";
							}
							if(a == CalStr.Count - 1)
								StrStorage.Add(TestStr.TrimEnd());
						}
						Main.TempCodeArray[0] = StrStorage[StrStorage.Count - 1];
						Main.RealNumArray[0] = Main.RealCodeNum - 1;
						if(StrStorage.Count > 1)
						{
							Main.MoreThanOneArray[0] = true;
						}
						else
						{
							Main.MoreThanOneArray[0] = false;
						}
					}
					else
					{
						Main.MoreThanOneArray[0] = true;
						Main.RealNumArray[0] = Main.RealCodeNum - 1;
						Main.TempCodeArray[0] = StrStorage[Num1 - 1];
					}
					
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					string[] MiddleStr = Main.TempCodeArray[0].Split(' ');
					List<string> RowStrWanted2 = new List<string>();	
					for(int i = 0; i < MiddleStr.Length; i++)
					{
						if(MiddleStr[i].Trim() != "")
							RowStrWanted2.Add(MiddleStr[i]);
					}
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;
					Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				}
				else
				{
					if(Main.RealCodeNum == 1)
					{
						Main.HorizontalNum = 1;
						return;
					}
					List<string> CalStr = new List<string>();
					List<string> StrStorage = new List<string>();
					string[] StrArray = new string[9];
					int[] intStorage = new int[9];
					bool[] boolStorage = new bool[9];
					for(int a= 0; a < 9; a++)
					{
						StrArray[a] = Main.TempCodeArray[a];
						intStorage[a] = Main.RealNumArray[a];
						boolStorage[a] = Main.MoreThanOneArray[a];
					}
					string TestStr = "";
					bool SpaceFlag = false;
					char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 2].ToCharArray();
					if(TempCharArray.Length == 0)
					{
						CalStr.Add(";");
					}
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[0] == '%')
						{
							CalStr.Add("%");
							break;
						}
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);
								TestStr = ""+TempCharArray[k];
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = false;
							}
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = true;
						}
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);
							TestStr = "";
							SpaceFlag = false;
							CalStr.Add(";");
						}
					}
					TestStr = "";
					for(int a = 0; a < CalStr.Count; a++)
					{
						Main.EDITText.text = TestStr + CalStr[a];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
						if(Main.TextSize.x > 320f)
						{
							StrStorage.Add(TestStr.TrimEnd());
							TestStr = CalStr[a] + "  ";
						}
						else
						{
							TestStr = TestStr + CalStr[a] + "  ";
						}
						if(a == CalStr.Count - 1)
							StrStorage.Add(TestStr.TrimEnd());
					}
					for(int a = 1; a < 9; a++)
					{
						Main.TempCodeArray[a] = StrArray[a - 1];
						Main.MoreThanOneArray[a] = boolStorage[a - 1];
						Main.RealNumArray[a] = intStorage[a - 1];
					}
					if(StrStorage.Count > 1)	
						Main.MoreThanOneArray[0] = true;	
					else
						Main.MoreThanOneArray[0] = false;
					Main.TempCodeArray[0] = StrStorage[StrStorage.Count - 1];
					Main.RealCodeNum--;	
					Main.RealNumArray[0] = Main.RealCodeNum - 1;		
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					string[] MiddleStr = Main.TempCodeArray[0].Split(' ');	
					List<string> RowStrWanted2 = new List<string>();		
					for(int i = 0; i < MiddleStr.Length; i++)
					{
						if(MiddleStr[i].Trim() != "")
							RowStrWanted2.Add(MiddleStr[i]);
					}
					Main.HorizontalNum = RowStrWanted2.Count;
					string TempStr = "";
					for(int i = 0; i < Main.HorizontalNum - 1; i++)
					{
						TempStr = TempStr + RowStrWanted2[i] + "0";
					}
					Main.EDITText.text = TempStr;
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f + Main.TextSize.x;	
					Main.EDITText.text = RowStrWanted2[Main.HorizontalNum - 1].Trim();
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
				}
			}
		}
	}
	
	
	
	void UpButton () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//编辑程序时
				if(Main.ProgEDITProg)
				{
					bool NumInNine = false;
					EditProgUp(NumInNine);
				}
				
				//O检索时
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0 && Main.RealListNum != 1)
						Main.ProgEDITFlip = 1;
					switch((int)Main.ProgEDITCusor)
					{
					case 175:
						if(Main.RealListNum > 1)
						{
							Main.RealListNum--;
							string[] TempNameArray = new string[8];
							int[] TempSizeArray = new int[8];
							string[] TempDateArray = new string[8];
							for(int i = 0; i < 8; i++)
							{
								TempNameArray[i] = "";
								TempSizeArray[i] = 0;
								TempDateArray[i] = "";
							}
							int MiddleNum = -1;
							int FinalNum = Main.RealListNum + 7;
							if(FinalNum > Main.TotalListNum)
								FinalNum = Main.TotalListNum;
							for(int i = Main.RealListNum - 1; i < FinalNum; i++)
							{
								MiddleNum++;
								TempNameArray[MiddleNum] = Main.FileNameList[i];
								TempSizeArray[MiddleNum] = Main.FileSizeList[i];
								TempDateArray[MiddleNum] = Main.FileDateList[i];
							}
							
							Main.CodeName01 = TempNameArray[0];
							Main.CodeName02 = TempNameArray[1];
							Main.CodeName03 = TempNameArray[2];
							Main.CodeName04 = TempNameArray[3];
							Main.CodeName05 = TempNameArray[4];
							Main.CodeName06 = TempNameArray[5];
							Main.CodeName07 = TempNameArray[6];
							Main.CodeName08 = TempNameArray[7];
							
							Main.CodeSize01 = TempSizeArray[0];
							Main.CodeSize02 = TempSizeArray[1];
							Main.CodeSize03 = TempSizeArray[2];
							Main.CodeSize04 = TempSizeArray[3];
							Main.CodeSize05 = TempSizeArray[4];
							Main.CodeSize06 = TempSizeArray[5];
							Main.CodeSize07 = TempSizeArray[6];
							Main.CodeSize08 = TempSizeArray[7];
							
							Main.UpdateDate01 = TempDateArray[0];
							Main.UpdateDate02 = TempDateArray[1];
							Main.UpdateDate03 = TempDateArray[2];
							Main.UpdateDate04 = TempDateArray[3];
							Main.UpdateDate05 = TempDateArray[4];
							Main.UpdateDate06 = TempDateArray[5];
							Main.UpdateDate07 = TempDateArray[6];
							Main.UpdateDate08 = TempDateArray[7];
						}
						break;
					case 195:
						Main.RealListNum--;
						Main.ProgEDITCusor = 175f;
						break;
					case 215:
						Main.RealListNum--;
						Main.ProgEDITCusor = 195f;
						break;
					case 235:
						Main.RealListNum--;
						Main.ProgEDITCusor = 215f;
						break;
					case 255:
						Main.RealListNum--;
						Main.ProgEDITCusor = 235f;
						break;	
					case 275:
						Main.RealListNum--;
						Main.ProgEDITCusor = 255f;
						break;
					case 295:
						Main.RealListNum--;
						Main.ProgEDITCusor = 275f;
						break;
					case 315:
						Main.RealListNum--;
						Main.ProgEDITCusor = 295f;
						break;
					}
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				
			}
			if(Main.OffSetCoo)
			{
				CooSystem_script.Up();
			}
		}
	}
	
	void DownButton () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//编辑程序时
				if(Main.ProgEDITProg)
				{
					bool NumInNine = false;
					EditProgDown(NumInNine);
				}
				
				//O检索时
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;	
					switch((int)Main.ProgEDITCusor)
					{
					case 175:
						if(Main.CodeName01 != "")
						{
							if(Main.TotalListNum > Main.RealListNum)
							{
								Main.RealListNum++;
								Main.ProgEDITCusor = 195f;
							}
						}
						break;		
					case 195:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 215f;
						}
						break;
					case 215:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 235f;
						}
						break;
					case 235:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 255f;
						}
						break;
					case 255:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 275f;
						}
						break;
					case 275:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 295f;
						}
						break;
					case 295:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							Main.ProgEDITCusor = 315f;
						}
						break;
					case 315:
						if(Main.TotalListNum > Main.RealListNum)
						{
							Main.RealListNum++;
							string[] TempNameArray = new string[8];
							int[] TempSizeArray = new int[8];
							string[] TempDateArray = new string[8];
							for(int i = 0; i < 8; i++)
							{
								TempNameArray[i] = "";
								TempSizeArray[i] = 0;
								TempDateArray[i] = "";
							}
							int MiddleNum = -1;
							for(int i = Main.RealListNum - 8; i < Main.RealListNum; i++)
							{
								MiddleNum++;
								TempNameArray[MiddleNum] = Main.FileNameList[i];	
								TempSizeArray[MiddleNum] = Main.FileSizeList[i];
								TempDateArray[MiddleNum] = Main.FileDateList[i];
							}
							
							Main.CodeName01 = TempNameArray[0];
							Main.CodeName02 = TempNameArray[1];
							Main.CodeName03 = TempNameArray[2];
							Main.CodeName04 = TempNameArray[3];
							Main.CodeName05 = TempNameArray[4];
							Main.CodeName06 = TempNameArray[5];
							Main.CodeName07 = TempNameArray[6];
							Main.CodeName08 = TempNameArray[7];
							
							Main.CodeSize01 = TempSizeArray[0];
							Main.CodeSize02 = TempSizeArray[1];
							Main.CodeSize03 = TempSizeArray[2];
							Main.CodeSize04 = TempSizeArray[3];
							Main.CodeSize05 = TempSizeArray[4];
							Main.CodeSize06 = TempSizeArray[5];
							Main.CodeSize07 = TempSizeArray[6];
							Main.CodeSize08 = TempSizeArray[7];
							
							Main.UpdateDate01 = TempDateArray[0];
							Main.UpdateDate02 = TempDateArray[1];
							Main.UpdateDate03 = TempDateArray[2];
							Main.UpdateDate04 = TempDateArray[3];
							Main.UpdateDate05 = TempDateArray[4];
							Main.UpdateDate06 = TempDateArray[5];
							Main.UpdateDate07 = TempDateArray[6];
							Main.UpdateDate08 = TempDateArray[7];
						}
						break;
					}
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				
			}
			if(Main.OffSetCoo)
			{
				CooSystem_script.Down();
			}
		}
	}
	
	
	void EditProgUp (bool NumInNine) {
		
		if(Main.RealCodeNum > 1)
		{
			Main.RealCodeNum--;
			for(int i = 0; i < 9; i++)
			{
				if(Main.RealNumArray[i] == Main.RealCodeNum - 1)
				{
					NumInNine = true;
					Main.VerticalNum = i + 1;		
					if(Main.VerticalNum == 1 && Main.MoreThanOneArray[0])
					{
						List<string> CalStr = new List<string>();	
						List<string> StrStorage = new List<string>();		
						string[] StrArray = new string[9];
						int[] intStorage = new int[9];
						bool[] boolStorage = new bool[9];						
						for(int a = 0; a < 9; a++)
						{
							StrArray[a] = Main.TempCodeArray[a];							
							intStorage[a] = Main.RealNumArray[a];							
							boolStorage[a] = Main.MoreThanOneArray[a];
						}
						int Num1 = 0;
						int Num2 = 0;
						string TestStr = "";
						bool SpaceFlag = false;
						char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
						for(int a = 0; a < 9; a++)
						{
							if(Main.RealNumArray[a] == Main.RealCodeNum - 1)
								Num1++;
						}
						for(int k = 0; k < TempCharArray.Length; k++)
						{
							if(TempCharArray[0] == '%')
							{
								CalStr.Add("%");
								break;
							}
							if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
							{
								if(SpaceFlag)
								{
									CalStr.Add(TestStr);
									TestStr = ""+TempCharArray[k];
									SpaceFlag = false;
								}
								else
								{
									TestStr += TempCharArray[k];
									SpaceFlag = false;
								}	
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = true;
							}
							
							if(k == TempCharArray.Length - 1)
							{
								CalStr.Add(TestStr);
								TestStr = "";
								SpaceFlag = false;
								CalStr.Add(";");
							}
						}
						TestStr = "";
						for(int a = 0; a < CalStr.Count; a++)
						{
							Main.EDITText.text = TestStr + CalStr[a];
							Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							if(Main.TextSize.x > 320f)
							{
								StrStorage.Add(TestStr.TrimEnd());
								TestStr = CalStr[a] + "  ";
							}
							else
							{
								TestStr = TestStr + CalStr[a] + "  ";
							}
							if(a == CalStr.Count - 1)
								StrStorage.Add(TestStr.TrimEnd());
						}
						Num2 = StrStorage.Count;				
						if(Num2 > Num1)
						{	
							if(Num1 >= 9)
							{
								for(int a = 0; a < 9; a++)
								{
									Main.TempCodeArray[a] = StrStorage[a];
									Main.RealNumArray[a] = Main.RealCodeNum - 1;		
									Main.MoreThanOneArray[a] = true;
								}
							}
							else
							{
								for(int a = 0; a < Num2; a++)
								{
									Main.TempCodeArray[a] = StrStorage[a];			
									Main.RealNumArray[a] = Main.RealCodeNum - 1;
									Main.MoreThanOneArray[a] = true;
								}
								
								for(int a = 0; a < 9 - Num2; a++)
								{
									Main.TempCodeArray[a + Num2] = StrArray[a + Num1];
									
									Main.RealNumArray[a + Num2] = intStorage[a + Num1];
									
									Main.MoreThanOneArray[a + Num2] = boolStorage[a + Num1];
								}
							}
							
							Main.Code01 = Main.TempCodeArray[0];
							Main.Code02 = Main.TempCodeArray[1];
							Main.Code03 = Main.TempCodeArray[2];
							Main.Code04 = Main.TempCodeArray[3];
							Main.Code05 = Main.TempCodeArray[4];
							Main.Code06 = Main.TempCodeArray[5];
							Main.Code07 = Main.TempCodeArray[6];
							Main.Code08 = Main.TempCodeArray[7];
							Main.Code09 = Main.TempCodeArray[8];
							
							Main.ProgEDITCusorV = 100f;		
							Main.HorizontalNum = 1;	
							string[] MiddleStr = Main.TempCodeArray[0].Split(' ');
							Main.EDITText.text = MiddleStr[0];
							Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							Main.ProgEDITCusorH = 32f;			
							return;
						}		
					}		
					break;
				}
			}
			
			if(NumInNine)
			{
				NumInNine = false;
				Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
				Main.HorizontalNum = 1;
				string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				Main.EDITText.text = MiddleStr[0];
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorH = 32f;	
			}
			else
			{
				List<string> CalStr = new List<string>();	
				List<string> StrStorage = new List<string>();
				string[] StrArray = new string[9];	
				int[] intStorage = new int[9];
				bool[] boolStorage = new bool[9];
				for(int a= 0; a < 9; a++)
				{
					StrArray[a] = Main.TempCodeArray[a];
					intStorage[a] = Main.RealNumArray[a];
					boolStorage[a] = Main.MoreThanOneArray[a];
				}
				int Num2 = 0;
				string TestStr = "";
				bool SpaceFlag = false;	
				char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();	
				if(TempCharArray.Length == 0)
				{
					CalStr.Add(";");
				}
				
				for(int k = 0; k < TempCharArray.Length; k++)
				{
					if(TempCharArray[0] == '%')
					{
						CalStr.Add("%");
						break;
					}
					
					if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
					{
						if(SpaceFlag)
						{
							CalStr.Add(TestStr);
							TestStr = ""+TempCharArray[k];					
							SpaceFlag = false;
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = false;
						}
					}
					else
					{
						TestStr += TempCharArray[k];
						SpaceFlag = true;
					}
					
					if(k == TempCharArray.Length - 1)
					{
						CalStr.Add(TestStr);
						TestStr = "";
						SpaceFlag = false;
						CalStr.Add(";");
					}
				}
				TestStr = "";
				for(int a = 0; a < CalStr.Count; a++)
				{
					Main.EDITText.text = TestStr + CalStr[a];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					if(Main.TextSize.x > 320f)
					{
						StrStorage.Add(TestStr.TrimEnd());
						TestStr = CalStr[a] + "  ";
					}
					else
					{
						TestStr = TestStr + CalStr[a] + "  ";
					}
					if(a == CalStr.Count - 1)
						StrStorage.Add(TestStr.TrimEnd());	
				}
				Num2 = StrStorage.Count;
				if(Num2 >= 9)
				{
					for(int a = 0; a < 9; a++)
					{
						Main.TempCodeArray[a] = StrStorage[a];
						Main.MoreThanOneArray[a] = true;
						Main.RealNumArray[a] = Main.RealCodeNum - 1;
					}
				}
				else
				{
					if(Num2 == 1)
					{
						Main.TempCodeArray[0] = StrStorage[0];
						Main.MoreThanOneArray[0] = false;		
						Main.RealNumArray[0] = Main.RealCodeNum - 1;
						for(int a = 1; a < 9; a++)
						{
							Main.TempCodeArray[a] = StrArray[a - 1];
							Main.RealNumArray[a] = intStorage[a - 1];
							Main.MoreThanOneArray[a] = boolStorage[a - 1];
						}
					}
					else
					{
						for(int a = 0; a < Num2; a++)
						{
							Main.TempCodeArray[a] = StrStorage[a];
							Main.RealNumArray[a] = Main.RealCodeNum - 1;
							Main.MoreThanOneArray[a] = true;
						}					
						for(int a = Num2; a < 9; a++)
						{
							Main.TempCodeArray[a] = StrArray[a - Num2];
							Main.RealNumArray[a] = intStorage[a - Num2];
							Main.MoreThanOneArray[a] = boolStorage[a - Num2];
						}
					}
				}
				
				Main.Code01 = Main.TempCodeArray[0];
				Main.Code02 = Main.TempCodeArray[1];
				Main.Code03 = Main.TempCodeArray[2];
				Main.Code04 = Main.TempCodeArray[3];
				Main.Code05 = Main.TempCodeArray[4];
				Main.Code06 = Main.TempCodeArray[5];
				Main.Code07 = Main.TempCodeArray[6];
				Main.Code08 = Main.TempCodeArray[7];
				Main.Code09 = Main.TempCodeArray[8];
				
				Main.ProgEDITCusorV = 100f;
				Main.HorizontalNum = 1;
				string[] MiddleStr = Main.TempCodeArray[0].Split(' ');
				Main.EDITText.text = MiddleStr[0];
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorH = 32f;	
			}	
		}	
	}
	
	
	void EditProgRight () 
	{
		string[] CurrentRowStr = Main.TempCodeArray[Main.VerticalNum - 1].TrimEnd().Split(' ');
		List<string> RowStrWanted = new List<string>();
		for(int i = 0; i < CurrentRowStr.Length; i++)
		{
			if(CurrentRowStr[i].Trim() != "")
				RowStrWanted.Add(CurrentRowStr[i]);
		}
		int CurrentRowNum = RowStrWanted.Count;
		if(CurrentRowNum > Main.HorizontalNum)
		{
			Main.HorizontalNum++;
			string TempStr = "";
			for(int i = 0; i < Main.HorizontalNum - 1; i++)
			{
				TempStr = TempStr + RowStrWanted[i] + "0";
			}
			Main.EDITText.text = TempStr;
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITCusorH = 32f + Main.TextSize.x;
			Main.EDITText.text = RowStrWanted[Main.HorizontalNum - 1];
			Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
		}
		else
		{
			if(Main.RealCodeNum == Main.TotalCodeNum)
			{
				if(Main.MoreThanOneArray[Main.VerticalNum - 1])
				{
					string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
					List<string> RowStrWanted2 = new List<string>();
					for(int i = 0; i < MiddleStr.Length; i++)
					{
						if(MiddleStr[i].Trim() != "")
							RowStrWanted2.Add(MiddleStr[i].Trim());
					}
					if(RowStrWanted2[RowStrWanted2.Count - 1] == ";")
						return;
				}
				if(Main.MoreThanOneArray[Main.VerticalNum - 1])
				{
					List<string> TempCodeSubList = new List<string>();
					List<string> CalStr = new List<string>();
					List<List<string>> SingleRowCodeList = new List<List<string>>();
					char[] TempCharArray;
					bool SpaceFlag = false;
					string TestStr = "";		
					int TargetRow = -1;	
					int FirstVerticalRow = -1;			
					TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();		
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);		
								TestStr = ""+TempCharArray[k];	
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = false;
							}
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = true;
						}
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);
							CalStr.Add(";");
							TestStr = "";
							SpaceFlag = false;
						}
					}	
					TestStr = "";		
					for(int a = 0; a < CalStr.Count; a++)
					{
						Main.EDITText.text = TestStr + CalStr[a];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
						if(Main.TextSize.x > 320f)
						{
							SingleRowCodeList.Add(TempCodeSubList);
							TempCodeSubList = new List<string>();
							TempCodeSubList.Add(CalStr[a]);
							TestStr = CalStr[a] + "  ";
						}
						else
						{
							TempCodeSubList.Add(CalStr[a]);
							TestStr = TestStr + CalStr[a] + "  ";	
						}
						if(a == CalStr.Count - 1)
							SingleRowCodeList.Add(TempCodeSubList);
					}
					string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
					List<string> RowStrWanted2 = new List<string>();
					for(int i = 0; i < MiddleStr.Length; i++)
					{
						if(MiddleStr[i].Trim() != "")
							RowStrWanted2.Add(MiddleStr[i].Trim());
					}	
					for(int k = 0; k < SingleRowCodeList.Count; k++)
					{
						TestStr = "";	
						for(int t = 0; t < SingleRowCodeList[k].Count; t++)
						{
							TestStr += SingleRowCodeList[k][t];
						}
						string TestStr2 = "";
						for(int t = 0; t < RowStrWanted2.Count; t++)
						{
							TestStr2 += RowStrWanted2[t];
						}
						if(TestStr == TestStr2)
						{
							TargetRow = k;
							break;
						}	
					}
					FirstVerticalRow = Main.VerticalNum - TargetRow;	
					if(Main.VerticalNum == 9)
					{
						Main.HorizontalNum = 1;
						string[] StrArray = new string[9];
						int[] intStorage = new int[9];
						bool[] boolStorage = new bool[9];
						for(int a= 0; a < 9; a++)
						{
							StrArray[a] = Main.TempCodeArray[a];
							intStorage[a] = Main.RealNumArray[a];
							boolStorage[a] = Main.MoreThanOneArray[a];
						}
						for(int a = 0; a < 8; a++)
						{
							Main.TempCodeArray[a] = StrArray[a + 1];
							Main.RealNumArray[a] = intStorage[a + 1];
							Main.MoreThanOneArray[a] = boolStorage[a + 1];
						}
						TestStr = "";
						for(int a = 0; a < SingleRowCodeList[TargetRow + 1].Count; a++)
						{
							TestStr = TestStr + SingleRowCodeList[TargetRow + 1][a] + "  ";
						}
						Main.TempCodeArray[8] = TestStr.TrimEnd();
						Main.RealNumArray[8] = Main.RealCodeNum - 1;
						Main.MoreThanOneArray[8] = true;	
					}
					else
					{
						Main.VerticalNum++;
						Main.HorizontalNum = 1;	
					}
					
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					string[] MiddleStr2 = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
					Main.EDITText.text = MiddleStr2[0].Trim();
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f;
					Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);	
				}
				return;
			}
			Main.HorizontalNum = 1;
			if(Main.VerticalNum != 9)
			{
				Main.VerticalNum++;
				if(Main.RealNumArray[Main.VerticalNum - 2] != Main.RealNumArray[Main.VerticalNum - 1])
					Main.RealCodeNum++;
				string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				Main.EDITText.text = MiddleStr[0].Trim();
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorH = 32f;
				Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
			}
			else
			{
				if(Main.MoreThanOneArray[8])
				{
					List<string> CalStr = new List<string>();
					List<string> StrStorage = new List<string>();
					string[] StrArray = new string[9];
					int[] intStorage = new int[9];
					bool[] boolStorage = new bool[9];
					for(int a= 0; a < 9; a++)
					{
						StrArray[a] = Main.TempCodeArray[a];
						intStorage[a] = Main.RealNumArray[a];
						boolStorage[a] = Main.MoreThanOneArray[a];
					}
					int Num1 = 0;
					int Num2 = 0;
					string TestStr = "";
					bool SpaceFlag = false;
					char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
					for(int a = 0; a < 9; a++)
					{
						if(Main.RealNumArray[a] == Main.RealCodeNum - 1)
						Num1++;
					}
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[0] == '%')
						{
							CalStr.Add("%");
							break;
						}
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);
								TestStr = ""+TempCharArray[k];
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = false;
							}
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = true;
						}
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);
							TestStr = "";
							SpaceFlag = false;
							CalStr.Add(";");
						}
					}
					TestStr = "";
					for(int a = 0; a < CalStr.Count; a++)
					{
						Main.EDITText.text = TestStr + CalStr[a];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
						if(Main.TextSize.x > 320f)
						{
							StrStorage.Add(TestStr.TrimEnd());
							TestStr = CalStr[a] + "  ";
						}
						else
						{
							TestStr = TestStr + CalStr[a] + "  ";
						}
						if(a == CalStr.Count - 1)
							StrStorage.Add(TestStr.TrimEnd());
					}
					Num2 = StrStorage.Count;				
					for(int a = 0; a < 8; a++)
					{
						Main.TempCodeArray[a] = StrArray[a + 1];
						Main.MoreThanOneArray[a] = boolStorage[a + 1];	
						Main.RealNumArray[a] = intStorage[a + 1];
					}	
					if(Num1 == Num2)
					{
						Main.RealCodeNum++;					
						char[] TempCharArray1 = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();						
						TestStr = "";						
						CalStr.Clear();						
						CalStr= new List<string>();						
						StrStorage.Clear();						
						StrStorage = new List<string>();						
						for(int a = 0; a < 9; a++)
						{
							if(Main.RealNumArray[a] == Main.RealCodeNum - 1)							
							Num1++;
						}						
						if(TempCharArray1.Length == 0)
						{
							CalStr.Add(";");
						}						
						for(int k = 0; k < TempCharArray1.Length; k++)
						{
							if(TempCharArray1[0] == '%')
							{
								CalStr.Add("%");								
								break;
							}						
							if(TempCharArray1[k] >= 'A' && TempCharArray1[k] <= 'Z')
							{
								if(SpaceFlag)
								{
									CalStr.Add(TestStr);									
									TestStr = ""+TempCharArray1[k];								
									SpaceFlag = false;
								}
								else
								{
									TestStr += TempCharArray1[k];									
									SpaceFlag = false;
								}								
							}
							else
							{
								TestStr += TempCharArray1[k];								
								SpaceFlag = true;
							}						
							if(k == TempCharArray1.Length - 1)
							{
								CalStr.Add(TestStr);								
								TestStr = "";							
								SpaceFlag = false;							
								CalStr.Add(";");
							}
						}						
						TestStr = "";						
						for(int a = 0; a < CalStr.Count; a++)
						{
							Main.EDITText.text = TestStr + CalStr[a];							
							Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));							
							if(Main.TextSize.x > 320f)
							{
								StrStorage.Add(TestStr.TrimEnd());								
								TestStr = CalStr[a] + "  ";
							}
							else
							{
								TestStr = TestStr + CalStr[a] + "  ";
							}						
							if(a == CalStr.Count - 1)								
								StrStorage.Add(TestStr.TrimEnd());
						}						
						Main.TempCodeArray[8] = StrStorage[0];						
						Main.RealNumArray[8] = Main.RealCodeNum - 1;						
						if(StrStorage.Count > 1)
						{
							Main.MoreThanOneArray[8] = true;
						}
						else
						{
							Main.MoreThanOneArray[8] = false;
						}	
					}
					else
					{
						Main.MoreThanOneArray[8] = true;						
						Main.RealNumArray[8] = Main.RealCodeNum - 1;						
						Main.TempCodeArray[8] = StrStorage[Num1];
					}					
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					string[] MiddleStr = Main.TempCodeArray[8].Split(' ');					
					Main.EDITText.text = MiddleStr[0];			
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));				
					Main.ProgEDITCusorH = 32f;
				}
				else
				{
					if(Main.TotalCodeNum == Main.RealCodeNum)
					{
						Main.HorizontalNum = CurrentRowNum;						
						return;
					}					
					List<string> CalStr = new List<string>();					
					List<string> StrStorage = new List<string>();					
					string[] StrArray = new string[9];					
					int[] intStorage = new int[9];					
					bool[] boolStorage = new bool[9];					
					for(int a= 0; a < 9; a++)
					{
						StrArray[a] = Main.TempCodeArray[a];					
						intStorage[a] = Main.RealNumArray[a];					
						boolStorage[a] = Main.MoreThanOneArray[a];
					}				
					string TestStr = "";					
					bool SpaceFlag = false;				
					char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum].ToCharArray();				
					if(TempCharArray.Length == 0)
					{
						CalStr.Add(";");
					}				
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[0] == '%')
						{
							CalStr.Add("%");						
							break;
						}						
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);						
								TestStr = ""+TempCharArray[k];						
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];						
								SpaceFlag = false;
							}					
						}
						else
						{
							TestStr += TempCharArray[k];		
							SpaceFlag = true;
						}				
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);			
							TestStr = "";						
							SpaceFlag = false;						
							CalStr.Add(";");
						}
					}					
					TestStr = "";				
					for(int a = 0; a < CalStr.Count; a++)
					{
						Main.EDITText.text = TestStr + CalStr[a];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
						if(Main.TextSize.x > 320f)
						{
							StrStorage.Add(TestStr.TrimEnd());
							TestStr = CalStr[a] + "  ";
						}
						else
						{
							TestStr = TestStr + CalStr[a] + "  ";
						}
						if(a == CalStr.Count - 1)						
							StrStorage.Add(TestStr.TrimEnd());	
					}				
					for(int a = 0; a < 8; a++)
					{
						Main.TempCodeArray[a] = StrArray[a + 1];		
						Main.MoreThanOneArray[a] = boolStorage[a + 1];	
						Main.RealNumArray[a] = intStorage[a + 1];
					}
					if(StrStorage.Count > 1)	
						Main.MoreThanOneArray[8] = true;
					else
						Main.MoreThanOneArray[8] = false;
					Main.TempCodeArray[8] = StrStorage[0];
					Main.RealCodeNum++;
					Main.RealNumArray[8] = Main.RealCodeNum - 1;
					
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					string[] MiddleStr = Main.TempCodeArray[8].Split(' ');				
					Main.EDITText.text = MiddleStr[0];
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f;	
				}	
			}
		}	
	}
	
	void EditProgDown (bool NumInNine) {
		
		if(Main.TotalCodeNum > Main.RealCodeNum)
		{
			Main.RealCodeNum++;
			for(int i = 0; i < 9; i++)
			{
				if(Main.RealNumArray[i] == Main.RealCodeNum - 1)
				{
					NumInNine = true;
					Main.VerticalNum = i + 1;
					break;
				}
			}
			if(NumInNine)
			{
				NumInNine = false;
				Main.ProgEDITCusorV = VerticalValue(Main.VerticalNum);
				Main.HorizontalNum = 1;
				string[] MiddleStr = Main.TempCodeArray[Main.VerticalNum - 1].Split(' ');
				Main.EDITText.text = MiddleStr[0];
				Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
				Main.ProgEDITCusorH = 32f;
			}
			else
			{
				if(Main.RealCodeNum - 1 != Main.EndRow)
				{
					Main.VerticalNum = 9;
					List<string> CalStr = new List<string>();
					List<string> StrStorage = new List<string>();
					string[] StrArray = new string[9];
					int[] intStorage = new int[9];
					bool[] boolStorage = new bool[9];
					for(int a= 0; a < 9; a++)
					{
						StrArray[a] = Main.TempCodeArray[a];
						intStorage[a] = Main.RealNumArray[a];			
						boolStorage[a] = Main.MoreThanOneArray[a];
					}
					int Num1 = 0;
					int Num2 = 0;
					string TestStr = "";
					bool SpaceFlag = false;
					char[] TempCharArray = Main.CodeForAll[Main.RealCodeNum - 2].ToCharArray();
					if((int)Main.ProgEDITCusorV == 300)
					{
						if(Main.MoreThanOneArray[8])
						{
							for(int k = 0; k < TempCharArray.Length; k++)
							{
								if(TempCharArray[0] == '%')
								{
									CalStr.Add("%");
									break;
								}
								if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
								{
									if(SpaceFlag)
									{
										CalStr.Add(TestStr);
										TestStr = ""+TempCharArray[k];
										SpaceFlag = false;
									}
									else
									{
										TestStr += TempCharArray[k];
										SpaceFlag = false;
									}
								}
								else
								{
									TestStr += TempCharArray[k];
									SpaceFlag = true;
								}
								if(k == TempCharArray.Length - 1)
								{
									CalStr.Add(TestStr);
									TestStr = "";
									SpaceFlag = false;
									CalStr.Add(";");
								}
							}
							TestStr = "";
							for(int i = 0; i < CalStr.Count; i++)
							{
								Main.EDITText.text = TestStr + CalStr[i];
								Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
								if(Main.TextSize.x > 320f)
								{
									StrStorage.Add(TestStr.TrimEnd());
									TestStr = CalStr[i] + "  ";
								}
								else
								{
									TestStr = TestStr + CalStr[i] + "  ";
								}
								if(i == CalStr.Count - 1)
									StrStorage.Add(TestStr.TrimEnd());
							}
							Num2 = StrStorage.Count;
							if(Num2 >= 8)
							{
								for(int i = 0; i < 8; i++)
								{
									Main.TempCodeArray[i] = StrStorage[i + Num2 - 8];
									Main.RealNumArray[i] = Main.RealCodeNum - 2;
									Main.MoreThanOneArray[i] = true;
								}
							}
							else
							{
								for(int i = 0; i < 8 - Num2; i++)
								{
									Main.TempCodeArray[i] = StrArray[i + Num2];
									Main.RealNumArray[i] = intStorage[i + Num2];
									Main.MoreThanOneArray[i] = boolStorage[i + Num2];
								}
								
								for(int i = 8 - Num2; i < 8; i++)
								{
									Main.TempCodeArray[i] = StrStorage[i - 8 + Num2];
									Main.RealNumArray[i] = Main.RealCodeNum - 2;
									Main.MoreThanOneArray[i] = true;
								}
							}
						}
						else
						{
							for(int i = 0; i < 8; i++)
							{
								Main.TempCodeArray[i] = StrArray[i + 1];
								Main.RealNumArray[i] = intStorage[i + 1];
								Main.MoreThanOneArray[i] = boolStorage[i + 1];
							}
						}
					}
					else
					{
						for(int i = 0; i < 9; i++)
						{
							if(Main.RealNumArray[i] == Main.RealCodeNum - 2)	
								Num1++;
						}
					
						for(int k = 0; k < TempCharArray.Length; k++)
						{
							if(TempCharArray[0] == '%')
							{
								CalStr.Add("%");
								break;
							}
							
							if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
							{
								if(SpaceFlag)
								{
									CalStr.Add(TestStr);
									TestStr = ""+TempCharArray[k];
									SpaceFlag = false;
								}
								else
								{
									TestStr += TempCharArray[k];
									SpaceFlag = false;
								}
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = true;
							}
							
							if(k == TempCharArray.Length - 1)
							{
								CalStr.Add(TestStr);
								TestStr = "";
								SpaceFlag = false;
								CalStr.Add(";");
							}
						}
						TestStr = "";
						for(int i = 0; i < CalStr.Count; i++)
						{
							Main.EDITText.text = TestStr + CalStr[i];
							Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							if(Main.TextSize.x > 320f)
							{
								Num2++;
								StrStorage.Add(TestStr.TrimEnd());
								TestStr = CalStr[i] + "  ";
							}
							else
							{
								TestStr = TestStr + CalStr[i] + "  ";
							}
							if(i == CalStr.Count - 1)
								StrStorage.Add(TestStr.TrimEnd());
						}
						Num2 = StrStorage.Count;
						if(Num2 >= 8)
						{
							for(int i = 0; i < 8; i++)
							{
								Main.TempCodeArray[i] = StrStorage[i + Num2 - 8];
								Main.RealNumArray[i] = Main.RealCodeNum - 2;
								Main.MoreThanOneArray[i] = true;
							}
						}
						else
						{
							for(int i = 0; i < 8 - Num2; i++)
							{
								Main.TempCodeArray[i] = StrArray[i + (Num2 - Num1) + 1];
								Main.RealNumArray[i] = intStorage[i + (Num2 - Num1) + 1];
								Main.MoreThanOneArray[i] = boolStorage[i + (Num2 - Num1) + 1];
							}
							
							for(int i = 8 - Num2; i < 8; i++)
							{
								Main.TempCodeArray[i] = StrStorage[i - 8 + Num2];
								Main.RealNumArray[i] = Main.RealCodeNum - 2;
								Main.MoreThanOneArray[i] = true;
							}
						}	
					}
					TempCharArray = Main.CodeForAll[Main.RealCodeNum - 1].ToCharArray();
					CalStr.Clear();	
					CalStr = new List<string>();
					TestStr = "";
					Main.RealNumArray[8] = Main.RealCodeNum - 1;
					Main.MoreThanOneArray[8] = false;
					SpaceFlag = false;
					if(TempCharArray.Length == 0)
					{
						CalStr.Add(";");
					}
					for(int k = 0; k < TempCharArray.Length; k++)
					{
						if(TempCharArray[0] == '%')
						{
							CalStr.Add("%");
							break;
						}
						if(TempCharArray[k] >= 'A' && TempCharArray[k] <= 'Z')
						{
							if(SpaceFlag)
							{
								CalStr.Add(TestStr);
								TestStr = ""+TempCharArray[k];
								SpaceFlag = false;
							}
							else
							{
								TestStr += TempCharArray[k];
								SpaceFlag = false;
							}
						}
						else
						{
							TestStr += TempCharArray[k];
							SpaceFlag = true;
						}
						
						if(k == TempCharArray.Length - 1)
						{
							CalStr.Add(TestStr);
							TestStr = "";
							SpaceFlag = false;
							CalStr.Add(";");
						}
					}
					TestStr = "";
					for(int i = 0; i < CalStr.Count; i++)
					{
						Main.EDITText.text = TestStr + CalStr[i];
						Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));	
						if(Main.TextSize.x > 320f)
						{
							Main.MoreThanOneArray[8] = true;
							break;
						}
						else
						{
							TestStr += CalStr[i] + "  ";
						}	
					}
					
					Main.TempCodeArray[8] = TestStr.TrimEnd();
					
					Main.Code01 = Main.TempCodeArray[0];
					Main.Code02 = Main.TempCodeArray[1];
					Main.Code03 = Main.TempCodeArray[2];
					Main.Code04 = Main.TempCodeArray[3];
					Main.Code05 = Main.TempCodeArray[4];
					Main.Code06 = Main.TempCodeArray[5];
					Main.Code07 = Main.TempCodeArray[6];
					Main.Code08 = Main.TempCodeArray[7];
					Main.Code09 = Main.TempCodeArray[8];
					
					Main.ProgEDITCusorV = 300f;
					Main.HorizontalNum = 1;
					string[] MiddleStr = Main.TempCodeArray[8].Split(' ');
					Main.EDITText.text = MiddleStr[0];	
					Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
					Main.ProgEDITCusorH = 32f;	
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
