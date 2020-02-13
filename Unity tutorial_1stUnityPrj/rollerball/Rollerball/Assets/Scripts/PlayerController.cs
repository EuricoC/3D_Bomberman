using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float mouseSpeed;
    private int count;
    
    public Text countText;
    public Text endText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();
        endText.text =  "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
       

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
            
        }
    }

    private void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X")*mouseSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, x);
        
    }

    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 8)
        {
            endText.text = "You Win";
        }
    }
}