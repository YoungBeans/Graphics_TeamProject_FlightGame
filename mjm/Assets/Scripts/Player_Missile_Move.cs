using UnityEngine;

public class Player_Missile_Move : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날라가는 속도
    public float DestroyYPos;   // 미사일이 사라지는 지점

    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.y >= DestroyYPos)
        {
            // 미사일을 제거
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Enemy"일 경우
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("적 기체와 충돌");
            GetComponent<Collider>().enabled = false;
        }
    }
}