using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Player_destroy playerhealth;
    public float timer = 0.0f;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((playerhealth.nowHealth <= 0) || Mathf.Round(timer) == 180)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
