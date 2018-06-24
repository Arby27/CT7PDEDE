using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork playerNetwork;
    public static string playerName;

    public GameObject[] spawnPoints = new GameObject[3];

    PhotonView photonView;
    int playerCurrent;

    private void Awake()
    {
        playerNetwork = this;
        photonView = GetComponent<PhotonView>();
        playerName = "player #" + Random.Range(1000, 9999);

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TableTop")
        {
            if (PhotonNetwork.isMasterClient)
            {
                MasterLoaded();
            }
            else
            {
                ClientLoaded();
            }
        }
    }

    void MasterLoaded()
    {
        playerCurrent = 1;
        photonView.RPC("RPC_LoadClients", PhotonTargets.Others);
    }


    void ClientLoaded()
    {
        photonView.RPC("RPC_LoadedScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    void RPC_LoadClients()
    {
        PhotonNetwork.LoadLevel(1);
    }

    [PunRPC]
    void RPC_LoadedScene()
    {
        playerCurrent++;
        if (playerCurrent == PhotonNetwork.playerList.Length)
        {
            Debug.Log("All Players Loaded");
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }


    [PunRPC]
    void RPC_CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PlayerObject"), spawnPoints[Random.Range(0,2)].transform.position,spawnPoints[0].transform.rotation,0);
    }

}
