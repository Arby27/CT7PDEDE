using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayout : MonoBehaviour {

    [SerializeField]
    private GameObject _roomlist;
    GameObject RoomList { get { return _roomlist; } }

    private List<RoomListing> _roomListButtons = new List<RoomListing>();
    private List<RoomListing> RoomListButons { get { return _roomListButtons; } }

    void OnReceivedRoomListUpdate()
    {
        Debug.Log("room recieved");
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        foreach (RoomInfo room in rooms)
        {
            RoomReceived(room);
        }
        RemoveOldRooms();
    }

    void RoomReceived(RoomInfo room)
    {
        int index = RoomListButons.FindIndex(x => x.RoomName.text == room.Name);
     
        if (index == -1)
        {
            if (room.IsVisible && room.PlayerCount < room.MaxPlayers)
            {

                GameObject roomListObj = Instantiate(RoomList);
                roomListObj.transform.SetParent(transform, false);
                RoomListing roomListing = roomListObj.GetComponent<RoomListing>();
                roomListing.SetRoomName(room.Name);
                roomListing.upToDate = true;
                index = (RoomListButons.Count - 1);
                
            }
        }

        if (index != -1)
        {
            RoomListing roomListing = RoomListButons[index];
            roomListing.SetRoomName(room.Name);
            roomListing.upToDate = true;
        }
    }

    void RemoveOldRooms()
    {
        List<RoomListing> removeRooms = new List<RoomListing>();
        foreach (RoomListing roomLisintg in RoomListButons)
        {
            if (!roomLisintg.upToDate)
            {
                removeRooms.Add(roomLisintg);
            }
            else
            {
                roomLisintg.upToDate = false;
            }
        }

        foreach (RoomListing roomListing in removeRooms)
        {
            GameObject roomListingObj = roomListing.gameObject;
            RoomListButons.Remove(roomListing);
            Destroy(roomListingObj);
        }
    }

}
