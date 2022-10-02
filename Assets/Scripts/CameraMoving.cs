using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject target;
    Transform tr;

    void Start()
    {
        tr = target.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(tr.position.x , tr.position.y, -10);
    }
}
