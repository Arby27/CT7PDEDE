using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings("1.0.0");
        
	}

    private void OnConnectedToMaster()
    {
        Debug.Log("connected");
        PhotonNetwork.automaticallySyncScene = false;
        PhotonNetwork.playerName = PlayerNetwork.playerName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }
}
