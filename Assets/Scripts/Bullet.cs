using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int level;

    public void Init(float damage, int level)
    {
        this.damage = damage;
        this.level = level;
    }
}
