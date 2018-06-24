using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreate : MonoBehaviour {

    [SerializeField]
    private Text _roomName;
    private Text RoomName { get { return _roomName; } }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 8 };

        if (PhotonNetwork.CreateRoom(RoomName.text,roomOptions,TypedLobby.Default))
        {
            Debug.Log("created room sent");
        }
        else
        {
            Debug.Log("Room creation Failed");
        }
    }

    void OnPhotonCreateRoomFailed(object[] messageAndCode)
    {
        Debug.Log(messageAndCode[1]);
    }

    void OnCreatedRoom()
    {
        Debug.Log("Room created successfully");
    }
}
