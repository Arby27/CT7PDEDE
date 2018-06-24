using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedCamera : Photon.MonoBehaviour {

    [SerializeField]
    private GameObject _networkCameraTransform;
    private GameObject NetworkCameraTransform { get { return _networkCameraTransform; } }

    [SerializeField]
    private Camera _camera;
    private Camera camera { get { return _camera; } }


    public PhotonView photonView;

    private void Start()
    {
        if (!photonView.isMine)
        {
            camera.enabled = false;
        }
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            _networkCameraTransform = NetworkCameraTransform;
        }
    }
}
