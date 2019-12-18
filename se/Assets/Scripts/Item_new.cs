using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_new : MonoBehaviour
{
    public float Speed = 3f;
    public GameObject party;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Pause();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * 99f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(party, transform.position, transform.rotation);
            scoreManager.score += 500;
            Destroy(gameObject);
        }
    }

    private void Pause()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -0.1f) Destroy(gameObject);
        if (pos.x > 1.1f) Destroy(gameObject);
        if (pos.y < -0.1f) Destroy(gameObject);
        if (pos.y > 1.1f) Destroy(gameObject);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
