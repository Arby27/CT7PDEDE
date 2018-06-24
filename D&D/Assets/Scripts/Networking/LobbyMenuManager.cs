using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuManager : MonoBehaviour {

    [SerializeField]
    private RoomLayout _roomLayout;
    private RoomLayout RoomLayout { get { return _roomLayout; } }


    public void JoinRoomClicked(string roomName)
    {

        if (PhotonNetwork.JoinRoom(roomName))
        {

        }
        else
        {
            Debug.Log("Failed to join");
        }

    }

}
