using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject player;
    public float maxSpawnDelay; //스폰까지 걸리는 시간
    public float curSpawnDelay; //딜레이시간
    public float radius; //원 반지름
    public float timer; //타이머
    //public Timer timer = new Timer(); //찐 타이머

    void Start()
    {
       
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
        

        if (timer < 5f) //5초 전
        {
            Instantiate(enemy[0], GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 3f); //스폰 딜레이(랜덤)

            curSpawnDelay = 0; //스폰 딜레이 초기화
        }
        else if (timer > 5f) //5초 후
        {
            Instantiate(enemy[1], GetRandomPosition(), Quaternion.identity);
            maxSpawnDelay = Random.Range(0f, 0.1f); //스폰 딜레이(랜덤)

            curSpawnDelay = 0; //스폰 딜레이 초기화
        }

    }
    
    void SpecialSpawnEnemy(Vector3 PlayerPosition) //원으로 나오거나 뭉탱이로 확 날라오는 몹 스폰 지역
    {

        float a = PlayerPosition.x;
        float b = PlayerPosition.y;

        float x;
        float y;
    }
    
}
