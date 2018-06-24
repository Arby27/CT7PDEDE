using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLayout : MonoBehaviour {

    [SerializeField]
    private GameObject _playButtonPrefab;
    private GameObject PlayerButtonPrefab { get { return _playButtonPrefab; } }

    private List<PlayerList> _playerLists = new List<PlayerList>();
    private List<PlayerList> PlayerLists { get { return _playerLists; } }

    private void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        leaveRoom(newMasterClient);
    }


    void OnJoinedRoom()
    {

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        CanvasManager.canvansManagerInstance.RoomMM.transform.SetAsLastSibling();
        MenuSettings.menuSettingsInstance.JoinRoom();
        PhotonPlayer[] players = PhotonNetwork.playerList;
        for (int i = 0; i < players.Length; i++)
        {
            PlayerJoinRoom(players[i]);
        }
    }

    void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinRoom(photonPlayer);
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeaveRoom(photonPlayer);
    }

    void PlayerJoinRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
        {
            return;
        }

        PlayerLeaveRoom(photonPlayer);

        GameObject playerButtonObj = Instantiate(PlayerButtonPrefab);
        playerButtonObj.transform.SetParent(transform, false);

        PlayerList playerList = playerButtonObj.GetComponent<PlayerList>();
        playerList.ApplyPhotonPlayer(photonPlayer);

        PlayerLists.Add(playerList);
        
    }

    void PlayerLeaveRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerLists.FindIndex(x => x.PhotonPlayers == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerLists[index].gameObject);
            PlayerLists.RemoveAt(index);
        }
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        if (!PhotonNetwork.inRoom)
        {
            MenuSettings.menuSettingsInstance.JoinLobby();
        }
    }

    void leaveRoom(PhotonPlayer photonPlayer)
    {
        PhotonNetwork.LeaveRoom();
        if (!PhotonNetwork.inRoom)
        {
            MenuSettings.menuSettingsInstance.JoinLobby();
        }
    }
}
