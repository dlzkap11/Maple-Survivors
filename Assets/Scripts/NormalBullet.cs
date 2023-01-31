using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public float BulletSpeed = 10f; //총알 속도
    private Vector3 moveDir = Vector3.zero;

    private void OnBecameInvisible() //화면 밖으로 나가면 삭제
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        transform.position += moveDir * Time.deltaTime * BulletSpeed;
    }
    public void setDir(Vector3 dir) //마지막 바라본 방향
    {
        moveDir = dir;
    }
}
