using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Smin : MonoBehaviour
{
    // Update is called once per frame
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,45,0)*Time.deltaTime);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(PV.IsMine)
            {
                PlayerMov.Speed = PlayerMov.Speed / 1.4f;
                PhotonNetwork.Destroy(gameObject);
            }
    }
        else if (other.gameObject.CompareTag("fire"))
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
    
}
