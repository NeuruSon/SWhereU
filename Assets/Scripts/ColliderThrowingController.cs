using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderThrowingController : MonoBehaviour
{
    public string tag_crashCollider;
    public Vector3 v3_direction;
    public string num_stage;
    GameObject gCon;
    Camera cam;

    void Start()
    {
        gCon = GameObject.Find(num_stage);
        cam = GameObject.Find("Cam_"+num_stage).GetComponent<Camera>();
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        transform.localRotation = cam.transform.localRotation;
        GetComponent<Rigidbody>().AddForce(dir * 1000);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(tag_crashCollider)
            || col.gameObject.CompareTag("Floor"))
        {
            switch (num_stage)
            {
                case "01":
                    //ex
                    break;
                case "04":
                    gCon.GetComponent<Game04Controller>().crashed(col.gameObject.CompareTag(tag_crashCollider), gameObject, col.gameObject);
                    break;
                case "05":
                    gCon.GetComponent<Game05Controller>().crashed(col.gameObject.CompareTag(tag_crashCollider), gameObject, col.gameObject);
                    break;
                default:
                    break;

            }
        }
    }
}
