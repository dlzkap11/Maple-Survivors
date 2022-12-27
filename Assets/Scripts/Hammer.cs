using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //레벨
    public float dmg;

    private float spinSpeed; //회전속도
    
    void Start()
    {
        dmg = 10 * weaponLevel;
    }

    void Update()
    {
        
    }
}
