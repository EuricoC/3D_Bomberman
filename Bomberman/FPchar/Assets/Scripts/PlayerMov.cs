using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Player Speed
    private static float speed = 3;

    //total time before bomb explodes
    private static int dtime = 4;

    //range of explosion
    private static int xplodrange = 2;
    
    //bomb limit
    private static int blimit = 1;
    
    //number of bombs down
    private static int bplaced = 0;
    
    //ability to kick
    private static bool kick = false;

    public static bool Kick
    {
        get => kick;
        set => kick = value;
    }

    public static int Blimit
    {
        get => blimit;
        set => blimit = value;
    }

    public static int Bplaced
    {
        get => bplaced;
        set => bplaced = value;
    }

    public static float Speed
    {
        get => speed;
        set => speed = value;
    }

    public static int Dtime
    {
        get => dtime;
        set => dtime = value;
    }

    public static int Xplodrange
    {
        get => xplodrange;
        set => xplodrange = value;
    }

    public GameObject bomb;
    private Bomb bombscript;
    private Animator animator;
    private PhotonView PV;
    // public Camera cam;
    
    private Vector3 bplace;
    private Vector3 mymov;
    private float bx;
    private float bz;

    private float abx;
    private float abz;
    
    
    private void Awake()

    {
        PV = GetComponent<PhotonView>();
        
        if (!PV.IsMine && GetComponent("PlayerMov") != null)
        {
            Destroy(GetComponent("PlayerMov"));
        }
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;

        bombscript = bomb.GetComponent<Bomb>();
        
        bombscript.Dtime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        if (translation > 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (translation < 0)
        {
            animator.SetBool("walkB", true);
        }
        else
        {
            animator.SetBool("walkB", false);
        }

        if (straffe < 0)
        {
            animator.SetBool("StrL", true);
        }
        else
        {
            animator.SetBool("StrL", false);
        }

        if (straffe > 0)
        {
            animator.SetBool("StrR", true);
        }
        else
        {
            animator.SetBool("StrR", false);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("space"))
        {

            if (bplaced < blimit)
            {
                bx = (float) Mathf.Floor(transform.position.x);
                bz = (float) Mathf.Floor(transform.position.z);

                abx = bx + 0.5f;
                abz = bz + 0.5f;

                bplace = new Vector3(abx, 0.15f, abz);
                PhotonNetwork.Instantiate("Bomb", bplace, transform.localRotation);

                bplaced += 1;
                Debug.Log(bplaced + " " + blimit);
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            Destroy(GetComponent("PlayerMov"));

            animator.SetBool("Dead", true);
            //StartCoroutine(kill());
            //Destroy(gameObject, 4.0f);
            PhotonNetwork.Destroy(gameObject);
        }
    }

    // private IEnumerator kill()
    // {
    //     Debug.Log("Inside");
    //     yield return new WaitForSeconds(0f);
    //     Debug.Log("just waited");
    //     PhotonNetwork.Destroy(gameObject);
    // }
}
