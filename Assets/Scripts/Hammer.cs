using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //����

    private float spinSpeed; //ȸ���ӵ�
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
        transform.RotateAround(vec, Vector3.back, spinSpeed);
    }
    
}
