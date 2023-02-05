using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStructure : MonoBehaviour
{
    public GameObject[] item; //전리품
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Debug.Log("Box has destroyed!");
            dropItem(); //전리품 드랍
        }
    }

    void dropItem()
    {
        int random_item = (int)Random.Range(0, item.Length);

        Instantiate(item[random_item], transform.position, Quaternion.identity);
        Debug.Log("Drop Item : " + item[random_item]);
        random_item = 0; //초기화
    }
}
