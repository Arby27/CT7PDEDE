using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour {


    [SerializeField]
    private Text _roomName;
    public Text RoomName { get { return _roomName; } }

    public bool upToDate;

	// Use this for initialization
	void Start () {
        GameObject lobbyObj = CanvasManager.canvansManagerInstance.LobbyMM.gameObject;
        if (lobbyObj == null)
        {
            return;
        }

        LobbyMenuManager lobbyMenu = lobbyObj.GetComponent<LobbyMenuManager>();

        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => lobbyMenu.JoinRoomClicked(RoomName.text));
        button.onClick.AddListener(() => MenuSettings.menuSettingsInstance.JoinRoom());
	}

    private void OnDestroy()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }

    public void SetRoomName(string text)
    {
        RoomName.text = text;
        Debug.Log("made it here" + text);
    }

}
