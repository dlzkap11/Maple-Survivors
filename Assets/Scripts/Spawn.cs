using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float maxSpawnDelay; //스폰까지 걸리는 시간
    public float curSpawnDelay; //딜레이시간
    public float radius; //원 반지름
    public float timer; //타이머
    
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>().time; //시간 동기화
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        //스폰 중점
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
        }
    }
    Vector3 GetRandomPosition()
    {

        Vector3 playerPosition = transform.position;

        float a = playerPosition.x;
        float b = playerPosition.y;

        float x = Random.Range(-radius + a, radius + a); //x축
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));//y-b 제곱근
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1; //y-b 음수값

        float y = y_b + b; //y축

        Vector3 randomPosition = new Vector3(x, y, 0);


        return randomPosition;
    }
    void SpawnEnemy()
    {
        //타이머 미설정으로 인한 임시 시간

        if (timer < 5f) //5초 전
        {
            Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 3f); //스폰 딜레이(랜덤)

            curSpawnDelay = 0; //스폰 딜레이 초기화
        }
        else if (timer > 5f) //5초 후
        {
            Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 0.1f); //스폰 딜레이(랜덤)

            curSpawnDelay = 0; //스폰 딜레이 초기화
        }

    }
}
