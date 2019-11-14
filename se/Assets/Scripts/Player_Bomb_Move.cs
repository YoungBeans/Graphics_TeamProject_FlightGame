using UnityEngine;

public class Player_Bomb_Move : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날라가는 속도
    public float DestroyYPos;   // 미사일이 사라지는 지점

    void Update()
    {
        // 매 프레임마다 폭탄이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        // 만약에 폭탄의 위치가 DestroyYPos를 넘어서면
        if (transform.position.y >= DestroyYPos)
        {
            // 폭탄을 제거
            Destroy(gameObject);
        }
    }
}
