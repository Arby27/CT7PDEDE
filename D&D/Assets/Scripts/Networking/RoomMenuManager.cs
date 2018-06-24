using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMenuManager : MonoBehaviour {

    public void StartSynch()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }
        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;
        PhotonNetwork.LoadLevel(1);
    }

}
