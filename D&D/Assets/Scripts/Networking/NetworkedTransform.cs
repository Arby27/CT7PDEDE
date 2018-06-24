using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedTransform : Photon.MonoBehaviour {

    [SerializeField]
    private GameObject _networkTransform;
    private GameObject NetworkTransform { get { return _networkTransform; } }

    private Vector3 targetPos;
    private Quaternion targetRot;

    public PhotonView photonView;

    private void Update()
    {
        if (photonView.isMine)
        {
            _networkTransform = NetworkTransform;
        }
      /*  else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 500 * Time.deltaTime);
        }*/
    }

    private void OnPhotonSerialzeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            targetPos = (Vector3)stream.ReceiveNext();
            targetRot = (Quaternion)stream.ReceiveNext();
        }
    }

}
