using Photon.Pun;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 mouselook;
    private Vector2 smoothV;

    public float sensitivity;
    public float smoothing;
    
    private Vector2 md;

    private float mind = -50.0f;
    private float maxd = 50.0f;

    public GameObject character;
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();

        if(!PV.IsMine)
        {
            GetComponent<Camera>().enabled = false;
            GetComponent<AudioListener>().enabled = false;
        }
        
        if (!PV.IsMine && GetComponent("CameraMovement") != null)
        {
            Destroy(GetComponent("CameraMovement"));
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
        // if (!PV.IsMine)
        // {
        //     enabled = false;
        // }
        //PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        
        mouselook += smoothV;

        mouselook.y = Mathf.Clamp(mouselook.y, mind, maxd);

        transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouselook.x, character.transform.up);
    }
}
