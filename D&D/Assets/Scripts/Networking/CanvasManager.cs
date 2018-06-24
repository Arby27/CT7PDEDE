using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {


    public static CanvasManager canvansManagerInstance;

    [SerializeField]
    private LobbyMenuManager _lobbyMM;
    public LobbyMenuManager LobbyMM { get { return _lobbyMM; } }

    [SerializeField]
    private RoomMenuManager _roomMM;
    public RoomMenuManager RoomMM { get { return _roomMM; } }


    void Awake()
    {
        canvansManagerInstance = this;
    }

}
