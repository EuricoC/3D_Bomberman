using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class crateSc : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            int x = Random.Range(1, 250);
            
//            Debug.Log(x);
            if (x > 71 && x <= 79)
            {
                StartCoroutine(Powerup("Bplus"));
            }
            else if (x > 180 && x <= 188)
            {
                StartCoroutine(Powerup("Fplus"));
            }
            else if (x > 120 && x <= 128)
            {
                StartCoroutine(Powerup("Splus"));
            }
            else if (x > 0 && x <= 5)
            {
                StartCoroutine(Powerup("Sminus"));
            }
            
            Destroy(gameObject,4.1f);
        }
    }

    private IEnumerator Powerup(string x)
    {
        yield return new WaitForSeconds(4f);
        PhotonNetwork.Instantiate(x, transform.position, Quaternion.identity);
    }
}
