using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviourPunCallbacks

{
    [SerializeField] private int waitingRoomSceneIndex;
    public static RoomController room;
    private PhotonView PV;

    public int currentScene;
    
    private void Awake()
    {
        if (RoomController.room == null)
        {
            RoomController.room = this;
        }
        else
        {
            if (RoomController.room != this)
            {
                Destroy(RoomController.room.gameObject);
                RoomController.room = this;
            }
        }
        //DontDestroyOnLoad(this.gameObject);

    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        //Debug.Log("joined Room");
        //StartGame();

        SceneManager.LoadScene(waitingRoomSceneIndex);
    }

    // private void StartGame()
    // {
    //     if (!PhotonNetwork.IsMasterClient)
    //         return;
    //     Debug.Log("Starting Game");
    //     PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    //
    // }
    
    
    
    // void Start()
    // {
    //     PV = GetComponent<PhotonView>();
    // }
    
}