using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour {

    public static MenuSettings menuSettingsInstance;

    [SerializeField]
    private GameObject _lobbyMenu;
    private GameObject LobbyMenu { get { return _lobbyMenu; } }

    [SerializeField]
    private GameObject _roomMenu;
    private GameObject RoomMenu { get { return _roomMenu; } }

    [SerializeField]
    private GameObject _firstMenu;
    private GameObject FirstMenu { get { return _firstMenu; } }

    [SerializeField]
    private GameObject _creatorMenu;
    private GameObject CreatorMenu { get { return _creatorMenu; } }

    public GameObject DDOL;
    public GameObject parentDDOL;
    GameObject createdDDOL;

    private void Awake()
    {
        menuSettingsInstance = this;
    }

    public void JoinLobby()
    {
        FirstMenu.SetActive(false);
        LobbyMenu.SetActive(true);
        CreatorMenu.SetActive(false);
        RoomMenu.SetActive(false);

        if (LobbyMenu.transform.localScale == new Vector3(0, 0, 0))
        {
            LobbyMenu.transform.localScale = new Vector3(100, 100, 100);
        }

        createdDDOL = Instantiate(DDOL, transform);
        createdDDOL.transform.parent = null;
    }

    public void CharacterCreator()
    {
        FirstMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        CreatorMenu.SetActive(true);
        RoomMenu.SetActive(false);
    }

    public void JoinRoom()
    {
        FirstMenu.SetActive(false);
        LobbyMenu.transform.localScale = new Vector3(0, 0, 0);
        CreatorMenu.SetActive(false);
        RoomMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void BackToMain()
    {
        FirstMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        CreatorMenu.SetActive(false);
        RoomMenu.SetActive(false);
        if (createdDDOL != null)
        {
            Destroy(createdDDOL);
        }

    }

}
