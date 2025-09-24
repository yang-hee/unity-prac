using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        this.player = GameObject.Find("player_0");    
    }

    private void Update()
    {
        // 매 프레임마다 등속 낙하
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나왔을 때 오브젝트 삭제
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 화살 중심 좌표 => 자기 자신의 좌표.(스크립트가 적용된 오브젝트의 좌표!)
        Vector2 p1 = transform.position;
        // 플레이어 중심 좌표
        Vector2 p2 = this.player.transform.position;
        // p2에서 p1으로 향하는 dir 벡터를 구함
        Vector2 dir = p1 - p2;

        // p1과 p2의 거리(피타고라스 이용한 d 구하기)
        float d = dir.magnitude;
        // 화살의 반경
        float r1 = 0.5f;
        // 플레이어의 반경
        float r2 = 1.0f;

        // 두 오브젝트 사이의 거리 가 각 오브젝트의 반지름의 값의 합보다 작으면? 충돌.
        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            // 충돌 시 화살 삭제
            Destroy(gameObject);
        }


    }
}
