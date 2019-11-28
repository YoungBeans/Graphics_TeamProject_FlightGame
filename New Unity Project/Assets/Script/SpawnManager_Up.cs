﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Up : MonoBehaviour

{



    Vector3[] positions = new Vector3[5];



    public GameObject enemy;



    public bool isSpawn = false;



    public float spawnDelay = 5f;

    float spawnTimer = 0f;



    // Use this for initialization

    void Start()
    {


    }

    void CreateEnemy() // 적이 나오는 지점을 카메라의 월드좌표로 정의한다

    {
        if (isSpawn == true)

        {

            if (spawnTimer > spawnDelay)

            {

                int rand = Random.Range(0, positions.Length);


                float randomX = Random.Range(-20f, 20f);


                float randomY = -55f;


                float viewPosZ = -830f;

                Instantiate(enemy, new Vector3(randomX, randomY, viewPosZ), Quaternion.identity);


                spawnTimer = 0f;

            }



            spawnTimer += Time.deltaTime;

        }


    }





    // Update is called once per frame

    void Update()

    {

        CreateEnemy();

    }



}

