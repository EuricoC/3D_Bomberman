using System;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.Cockpit.Forms;
using UnityEngine;
using Random = UnityEngine.Random;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject quickstartButton;
    [SerializeField] private GameObject quickcancelButton;
    [SerializeField] private int RoomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickstartButton.SetActive(true);
    }

    public void QuickStart()
    {
        quickstartButton.SetActive((false));
        quickcancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize};
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room, try again");
        CreateRoom();
    }

    public void QuickCancel()
    {
        quickcancelButton.SetActive(false);
        quickstartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}