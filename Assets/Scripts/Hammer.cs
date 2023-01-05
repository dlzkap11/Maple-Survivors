using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //����

    public float dmg; //������

    private float spinSpeed; //ȸ���ӵ�
    
    void Start()
    {
        dmg = 10 * weaponLevel;
        spinSpeed = weaponLevel * 0.5f;
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.back, spinSpeed);
    }
    
}
