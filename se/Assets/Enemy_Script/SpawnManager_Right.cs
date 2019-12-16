using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Right : MonoBehaviour

{



    Vector3[] positions = new Vector3[5];



    public GameObject enemy;



    public bool isSpawn = false;



    public float spawnDelay = 5f;

    float spawnTimer = 0f;



    float timeSpan;  //경과 시간을 갖는 변수
    float checkTime;  // 특정 시간을 갖는 변수

    // Use this for initialization

    void Start()
    {
        timeSpan = 0.0f;
        checkTime = 20f;  // 특정시간을 지정

    }

    void CreateEnemy() // 적이 나오는 지점을 카메라의 월드좌표로 정의한다

    {
        if (isSpawn == true)

        {

            if (spawnTimer > spawnDelay)

            {

                int rand = Random.Range(0, positions.Length);


                float randomX = 660f;


                //float randomY = 52f;
                float randomY = Random.Range(-300f, 900f);


                float viewPosZ = -100f;

                Instantiate(enemy, new Vector3(randomX, randomY, viewPosZ), Quaternion.identity);


                spawnTimer = 0f;

            }



            spawnTimer += Time.deltaTime;

        }


    }





    // Update is called once per frame

    void Update()

    {

        timeSpan += Time.deltaTime;  // 경과 시간을 계속 등록
        if (timeSpan > checkTime)  // 경과 시간이 특정 시간이 보다 커졋을 경우
        {
            CreateEnemy();
        }

    }



}

