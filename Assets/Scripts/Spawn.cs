using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    
    public GameObject[] enemy;
    public GameObject player;
    public float maxSpawnDelay; //�������� �ɸ��� �ð�
    public float curSpawnDelay; //�����̽ð�
    public float radius; //�� ������
    public float timer; //Ÿ�̸�
    public bool IsSpawn = true;

    private void Start()
    {
       // GameManager.instance.pool.Get(1);
    }
    void Update()
    {
        if (!IsSpawn)
            return;
        curSpawnDelay += Time.deltaTime;

        //���� ����
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (curSpawnDelay > maxSpawnDelay)
        {
            Spawner();
        }

    }

    Vector3 GetRandomPosition()
    {
        Vector3 playerPosition = transform.position;

        float a = playerPosition.x;
        float b = playerPosition.y;

        float x = Random.Range(-radius + a, radius + a); //x��
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));//y-b ������
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1; //y-b ������

        float y = y_b + b; //y��

        Vector3 randomPosition = new Vector3(x, y, 0);


        return randomPosition;
    }
    void WaveSpawn()
    {
        Vector3 playerPosition = transform.position;

        float a = playerPosition.x;
        float b = playerPosition.y;

        float x = Random.Range(-radius + a, radius + a); //x��
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));//y-b ������
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1; //y-b ������

        float y = y_b + b; //y��

        Vector3 randomPosition = new Vector3(x, y, 0);


    }

    void Spawner()
    {
        GameObject test = GameManager.instance.pool.Get(3);
        test.transform.position = GetRandomPosition();
        maxSpawnDelay = Random.Range(0f, 3f);
        curSpawnDelay = 0;
    }
    void SpawnEnemy()
    {

        

        /*
        Instantiate(enemy[0], GetRandomPosition(), Quaternion.identity);         
        maxSpawnDelay = Random.Range(0f, 3f); //���� ������(����)         
        curSpawnDelay = 0; //���� ������ �ʱ�ȭ
        */


      
        //WaveSpawn();
 



        /*
        if (timer < 5f) //5�� ��
        {
            Instantiate(enemy[3], GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 3f); //���� ������(����)

            curSpawnDelay = 0; //���� ������ �ʱ�ȭ
        }
        else if (timer > 5f) //5�� ��
        {
            Instantiate(enemy[1], GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 0.1f); //���� ������(����)

            curSpawnDelay = 0; //���� ������ �ʱ�ȭ
        }
        */
    }
}
