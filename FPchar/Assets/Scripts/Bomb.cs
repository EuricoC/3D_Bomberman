using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //total time before bomb explodes
    private int dtime = PlayerMov.Dtime;

    //range of explosion
    private int xplodrange = PlayerMov.Xplodrange;

    public GameObject fire;
    private bool exploded = false;
    public Rigidbody rb;
    private PhotonView PV;

    public int Xplodrange
    {
        get => xplodrange;
        set => xplodrange = value;
    }

    public int Dtime
    {
        get => dtime;
        set => dtime = value;

    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
        rb = GetComponent<Rigidbody>();
        
        Invoke("detonate", dtime);
    }

    private void detonate()
    {
        StartCoroutine(Propfire(Vector3.forward));
        StartCoroutine(Propfire(Vector3.right));
        StartCoroutine(Propfire(Vector3.back));
        StartCoroutine(Propfire(Vector3.left));
        Destroy(gameObject, 0.5f);
        exploded = true;

        if (PV.IsMine)
        {
            PlayerMov.Bplaced -= 1;
        }
    }
    
    private IEnumerator Propfire(Vector3 direction)
    {
        Vector3 firepos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        
        RaycastHit hit;

        Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit);
        
        int x = Mathf.CeilToInt(hit.distance);

        if (x >= xplodrange)
        {
            for (int i = 0; i < xplodrange; i++)
            {
                Instantiate(fire, firepos + (i * direction), Quaternion.identity);
                yield return new WaitForSeconds(.03f);
            }
        }
        else if (x < xplodrange)
        {
            x += 1;
            for (int i = 0; i < x; i++)
            {
                Instantiate(fire, firepos + (i * direction), Quaternion.identity);
                yield return new WaitForSeconds(.03f);
            }
        }
    }  
    

    void OnTriggerExit(Collider other)
    {
        GetComponent<SphereCollider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fire") && !exploded)
        {
            CancelInvoke("detonate");
            detonate();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            rb.AddForce(transform.forward * 1.0f);
        }
    }
}
