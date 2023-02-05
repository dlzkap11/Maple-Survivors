using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int weaponLevel; //����

    private float hammerSpeed; //��ġ�ӵ�
    private float spinSpeed; //ȸ���ӵ�
    private Vector3 vec;

    [SerializeField]
    GameObject player;
    
    void Start()
    {
        hammerSpeed = 0.5f;
        spinSpeed = weaponLevel * 0.3f;
    }

    void Update()
    {
        vec = player.transform.position;
        transform.Rotate(Vector3.forward * hammerSpeed); //�ظ� ��ü ȸ��
        transform.RotateAround(vec, Vector3.forward, spinSpeed); //�÷��̾� �߽��� ȸ��
    }
    
}
