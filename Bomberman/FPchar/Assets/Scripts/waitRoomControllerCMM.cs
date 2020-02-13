using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class waitRoomControllerCMM : MonoBehaviourPunCallbacks
{
    private PhotonView PV;

    [SerializeField] private int multiplayerSceneIndex;
    [SerializeField] private int menuSceneIndex;

    private int playerCount;
    private int roomSize;

    [SerializeField] private Text roomCountDisplay;
    public GameObject startButton;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        PlayerCountUpdate();
        if (PhotonNetwork.IsMasterClient && playerCount >= roomSize)
        {
            startButton.SetActive(true);
        }
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        roomCountDisplay.text = playerCount + "/" + roomSize;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerCountUpdate();
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCountUpdate();
        if (PhotonNetwork.IsMasterClient && playerCount < roomSize)
        {
            startButton.SetActive(false);
        }
    }
    
    public void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }
}
