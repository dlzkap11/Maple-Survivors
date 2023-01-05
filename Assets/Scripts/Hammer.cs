using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //레벨

    public float dmg; //데미지

    private float spinSpeed; //회전속도
    
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
