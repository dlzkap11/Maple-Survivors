using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //레벨

    private float spinSpeed; //회전속도
    private Vector3 vec;

    [SerializeField]
    GameObject player;
    
    void Start()
    {
        spinSpeed = weaponLevel * 0.5f;
    }

    void Update()
    {
        vec = player.transform.position;
        transform.Rotate(Vector3.back * spinSpeed); //해머 자체 회전
        transform.RotateAround(vec, Vector3.back, spinSpeed); //플레이어 중심을 회전
    }
    
}
