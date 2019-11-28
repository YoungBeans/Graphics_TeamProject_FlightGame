using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 24f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other)
            if (gameObject.transform.position.x < -24f)
            {
                Destroy(gameObject);
            }
        if (other.CompareTag("Player"))
        {
            Debug.Log("기체 파괴");
            Destroy(gameObject);
        }
    }
}
