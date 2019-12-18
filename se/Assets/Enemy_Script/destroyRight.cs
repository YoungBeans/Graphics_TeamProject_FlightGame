using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyRight : MonoBehaviour
{
    public GameObject ParticleFXExplosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -600f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*
       if (other)
            if (gameObject.transform.position.x > 600f)
            {
                Destroy(gameObject);
                //this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
            }*/
        if (other.CompareTag("Player") || other.CompareTag("Player Missile") || other.CompareTag("Player Bomb"))
        {
            Debug.Log("기체 파괴");
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
            scoreManager.score += 200;
            Destroy(gameObject);
        }
    }
}
