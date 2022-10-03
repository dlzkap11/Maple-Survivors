using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnerPosition;
    public GameObject target;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curSpawnDelay += Time.deltaTime;


        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }


    }

    void SpawnEnemy()//적 생성
    {
        int ranPosition = Random.Range(0, 5);//스폰지역 랜덤범위

        Instantiate(target, spawnerPosition[ranPosition].position, spawnerPosition[ranPosition].rotation);
    }
}