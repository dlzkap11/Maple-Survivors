using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meso : MonoBehaviour
{
    public int meso; //�޼�

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().stageMeso += meso; //�޼� ����

            Destroy(gameObject);
            Debug.Log("Get Meso : " + meso); //Log //dmdkdkkr
        }
    }
}
