using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //레벨

    private float hammerSpeed; //망치속도
    private float spinSpeed; //회전속도
    private Vector3 vec;

    [SerializeField]
    GameObject player;
    
    void Start()
    {
        hammerSpeed = 0.5f;
        spinSpeed = weaponLevel * 0.3f;
    }

    void Update()
    {
        vec = player.transform.position;
        transform.Rotate(Vector3.forward * hammerSpeed); //해머 자체 회전
        transform.RotateAround(vec, Vector3.forward, spinSpeed); //플레이어 중심을 회전
    }
    
}
