using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomState : MonoBehaviour {

    [SerializeField]
    private Text _buttonText;
    private Text ButtonText { get { return _buttonText; } }

    public void roomState()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }

        PhotonNetwork.room.IsOpen = !PhotonNetwork.room.IsOpen;
        PhotonNetwork.room.IsVisible = PhotonNetwork.room.IsOpen;

        
        if (PhotonNetwork.room.IsOpen == true)
        {
            ButtonText.text = "Lock/Unlock Room \n" + "Current State: Open";
        }
        else
        {
            ButtonText.text = "Lock/Unlock Room \n" + "Current State: Closed";
        }
    }
}
