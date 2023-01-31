using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public float BulletSpeed = 10f; //�Ѿ� �ӵ�
    private Vector3 moveDir = Vector3.zero;

    private void OnBecameInvisible() //ȭ�� ������ ������ ����
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        transform.position += moveDir * Time.deltaTime * BulletSpeed;
    }
    public void setDir(Vector3 dir) //������ �ٶ� ����
    {
        moveDir = dir;
    }
}
