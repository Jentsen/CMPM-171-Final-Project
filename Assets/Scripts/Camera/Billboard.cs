using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    public Transform follow;
    
    private void LateUpdate()
    {
        transform.position = follow.position + new Vector3(0, 5, 0);
        transform.LookAt(transform.position + cam.forward);
    }
}