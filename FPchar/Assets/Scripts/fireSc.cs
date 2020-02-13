using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSc : MonoBehaviour
{

    private static int dtime = PlayerMov.Dtime;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(remove());
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(dtime);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }

}
