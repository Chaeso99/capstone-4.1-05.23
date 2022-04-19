using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public int enemy_hp = 10;
    public float speed = 10f;//몬스터 속도
    public float destroy_time = 0.1f;//최종도착과 디스폰 사이 시간
    public Transform[] fruits = new Transform[fruitsindex];//
    public int fruitspawnrandom = 20;

    private static int fruitsindex = 3;
    private Transform target;//Transform
    private int wavepointIndex = 0;//TwoWaypoints의 인덱스

    void Start()
    {
        target = TwoWaypoints.tpoints[0];//첫번째 TwoWaypoint 설정
    }
    //이 이후는 OneWaypoints라는 scrpit 참조하시면 됨
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        /*
        destroy_time += Time.deltaTime;

        if (destroy_time >= 3)
        {
            SpawnFruit();

            Destroy(gameObject);
        }
        */
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= TwoWaypoints.tpoints.Length - 1)
        {
            Destroy(gameObject, destroy_time);
            return;
        }

        wavepointIndex++;
        target = TwoWaypoints.tpoints[wavepointIndex];

    }

    private void SpawnFruit()
    {
        int random = UnityEngine.Random.Range(0, 100);

        if (random < fruitspawnrandom)
        {
            int fruit_random = UnityEngine.Random.Range(0, 2);

            Instantiate(fruits[fruit_random], transform.position, transform.rotation);
        }
    }
}