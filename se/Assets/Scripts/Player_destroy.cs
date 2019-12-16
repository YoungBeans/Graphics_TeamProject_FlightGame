using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_destroy : MonoBehaviour
{
    public GameObject ParticleFXExplosion;
    public int maxHealth = 3;
    int nowHealth;
    bool isDie = false;
    bool isUnBeatTime = false;
    // Start is called before the first frame update
    void Start()
    {
        nowHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowHealth == 0)
            if (!isDie)
                Die();
    }
    
    void Die()
    {
        isDie = true;
        Debug.Log("주인공 파괴");
        Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
        Destroy(gameObject);

    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                c.a = 10.0f;
            else
                c.a = 0f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        c.a = 10.0f;

        isUnBeatTime = false;
        yield return null;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(15);

        string heart = "";
        for (int i = 0; i < nowHealth; i++)
            heart += "♥";
        GUILayout.Label(heart);

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Enemy Missile"))
        {
            nowHealth--;
            if (nowHealth > 1)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
            /*
            Debug.Log("주인공 파괴");
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
            Destroy(gameObject);
            */
        }
    }
}
