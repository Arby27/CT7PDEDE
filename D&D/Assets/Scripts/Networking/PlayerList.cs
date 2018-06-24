using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour {

	public PhotonPlayer PhotonPlayers { get; private set; }

    [SerializeField]
    Text _playerName;
    Text PlayerName { get { return _playerName; } }

    public void ApplyPhotonPlayer(PhotonPlayer photonPLayer)
    {
        PhotonPlayers = photonPLayer;
        PlayerName.text = photonPLayer.NickName;
    }
}
