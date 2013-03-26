using UnityEngine;
using System.Collections;
using System.Net;

public class ServerConnect : MonoBehaviour {
	
	Rect connecting_window = new Rect(200,100,250,150);
	string server_IP = "";
	int Port = 2012;
	
	// Use this for initialization
	void Start () {
		IPHostEntry   ipHost   =   Dns.GetHostEntry(Dns.GetHostName()); 
		IPAddress   ipAddr   =   ipHost.AddressList[0];
		if(ipHost.AddressList.Length>1)
		{
			server_IP=ipHost.AddressList[1].ToString();
		}
		else
			server_IP=ipHost.AddressList[0].ToString();
		Network.InitializeServer(50, Port, false);
	}
	
	void OnGUI () {
		if(Network.peerType == NetworkPeerType.Disconnected)
		{
			connecting_window = GUI.Window(0, connecting_window, ConnectWindow, "");
		}
	}
	
	void ConnectWindow (int WindowID) {
		GUI.Label(new Rect(10,30,50,20), "Host IP");
		server_IP = GUI.TextField(new Rect(60,30,150,20), server_IP);
		GUI.Label(new Rect(50,80,200,20), "Waiting For Connecting......");
		
		GUI.DragWindow();  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
