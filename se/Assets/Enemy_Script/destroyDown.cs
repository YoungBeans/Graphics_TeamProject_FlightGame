﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ParticleFXExplosion;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -1000f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other)
            if (gameObject.transform.position.y > 1000f)
            {
                Destroy(gameObject);
            }
            */
        if (other.CompareTag("Player")|| other.CompareTag("Player Missile") || other.CompareTag("Player Bomb"))
        {
            Debug.Log("기체 파괴");
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
            scoreManager.score += 100;

            Destroy(gameObject);
        }
    }
}
