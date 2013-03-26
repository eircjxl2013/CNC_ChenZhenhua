using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class RegexTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Regex r = new Regex(@"([A-Z]+[^A-Z^\s]+)+");
		Match m = r.Match("WHILE90G02G0G11G43X0.22 G25Y0.1+");
		MatchCollection mc = r.Matches("WHILE90G02G0G11G43X0.22 G25Y0.1+");
		Debug.Log("Groups:  "+m.Groups.Count);
		Debug.Log("Matches:  "+ mc.Count);
		for(int i = 0; i < m.Groups.Count; i++)
		{
			Debug.Log(m.Groups[i].Value);
			for(int j = 0; j < m.Groups[i].Captures.Count; j++)
				Debug.Log(m.Groups[i].Captures[j].Value);
		}
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
