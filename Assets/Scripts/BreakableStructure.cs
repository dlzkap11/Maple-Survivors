using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStructure : MonoBehaviour
{
    public GameObject[] item; //����ǰ
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Debug.Log("Box has destroyed!");
            dropItem(); //����ǰ ���
        }
    }

    void dropItem()
    {
        int random_item = (int)Random.Range(0, item.Length);

        Instantiate(item[random_item], transform.position, Quaternion.identity);
        Debug.Log("Drop Item : " + item[random_item]);
        random_item = 0; //�ʱ�ȭ
    }
}
