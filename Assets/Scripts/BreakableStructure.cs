using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStructure : MonoBehaviour
{
    public float HP;

    void OnHit(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Destroy(gameObject);
            dropItem(); //전리품 드랍
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            NormalBullet bullet = collision.gameObject.GetComponent<NormalBullet>();
            OnHit(bullet.dmg);
        }
    }

    void dropItem()
    {

    }
}
