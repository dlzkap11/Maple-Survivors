using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expMarble : MonoBehaviour
{
    public int exp; //����ġ

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Exp += exp; //����ġ ����

            Destroy(gameObject);
            Debug.Log("Get Exp : " + exp); //Log
        }
    }
}
