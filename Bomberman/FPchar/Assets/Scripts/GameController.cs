using System;
using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PhotonView PV;
    private int npl;

    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        npl = GetPlayerCount();
        Vector3 pos1 = new Vector3(14.5f, 0f, -14.5f);
        Vector3 posC1 = new Vector3(pos1.x, 1.834f, pos1.z + 0.357f);
        
        Vector3 pos2 = new Vector3(-15.5f, 0f, -14.5f);
        Vector3 posC2 = new Vector3(pos2.x, 1.834f, pos2.z + 0.357f);
        
        Vector3 pos3 = new Vector3(-15.5f, 0f, 15.5f);
        Vector3 posC3 = new Vector3(pos3.x, 1.834f, pos3.z + 0.357f);
        
        Vector3 pos4 = new Vector3(14.5f, 0f, 15.5f);
        Vector3 posC4 = new Vector3(pos4.x, 1.834f, pos4.z + 0.357f);
        Debug.Log("Creating Player");

        if (npl == 1)
        {
            GameObject MyPlayer = PhotonNetwork.Instantiate("Player", pos1, Quaternion.identity);
            GameObject camera = PhotonNetwork.Instantiate("Camera", posC1, Quaternion.identity);
            PV = MyPlayer.GetComponent<PhotonView>();
            camera.transform.parent = MyPlayer.transform;
        }
        else if (npl == 2)
        {
            GameObject MyPlayer = PhotonNetwork.Instantiate("Player", pos2, Quaternion.identity);
            GameObject camera = PhotonNetwork.Instantiate("Camera", posC2, Quaternion.identity);
            PV = MyPlayer.GetComponent<PhotonView>();
            camera.transform.parent = MyPlayer.transform;
        }
        else if (npl == 3)
        {
            GameObject MyPlayer = PhotonNetwork.Instantiate("Player", pos3, Quaternion.identity);
            GameObject camera = PhotonNetwork.Instantiate("Camera", posC3, Quaternion.identity);
            PV = MyPlayer.GetComponent<PhotonView>();
            camera.transform.parent = MyPlayer.transform;
            MyPlayer.transform.Rotate(0,180,0);
        }
        else if (npl == 4)
        {
            GameObject MyPlayer = PhotonNetwork.Instantiate("Player", pos4, Quaternion.identity);
            GameObject camera = PhotonNetwork.Instantiate("Camera", posC4, Quaternion.identity);
            PV = MyPlayer.GetComponent<PhotonView>();
            camera.transform.parent = MyPlayer.transform;
            MyPlayer.transform.Rotate(0,180,0);
        }
    }


    public static int GetPlayerCount() 
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            return PhotonNetwork.CurrentRoom.PlayerCount;
        }
        return 0;
    }   
}
