using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerT;
    private Vector3 camoffset;
    [Range(0.01f, 1.0f)]
    public float smfactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        camoffset = transform.position - playerT.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newpos = playerT.position + camoffset;
        transform.position = Vector3.Slerp(transform.position, newpos, smfactor);
    }
}
