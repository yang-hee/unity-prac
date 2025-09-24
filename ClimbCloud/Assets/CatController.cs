using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // 스마트폰용 
    float threshold = 0.2f;

    private void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //// 스페이스바 입력이 들어오고 플레이어 캐릭터의 위아래 이동이 0일때 점프.
        //if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.linearVelocity.y == 0)
        //{
        //    this.rigid2D.AddForce(transform.up * this.jumpForce);
        //}

        //int key = 0;
        //// 좌우 방향 판별을 위한 key 값 설정. 오른쪽 버튼은 양수 1 / 왼쪽 버튼은 음수 1
        //// 코드가 한줄로 끝날 경우에는 {} 생략 가능하다
        //if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 터치 입력이 들어오고 캐릭터의 위아래(y방향) 이동이 없을때 점프
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;

        // 가속도 센서 -0.2f ~ 0.2f 정지
        // 가속도 센서 > 0.2f 오른쪽 이동
        // 가속도 센서 < -0.2f 왼쪽 이동
        if (Input.acceleration.x > this.threshold) key = 1;
        if (Input.acceleration.x < -this.threshold) key = -1; 

        // 고양이의 속도
        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        //AddForce 사용하여 플레이어의 이동 속도가 maxWalkSpeed를 초과하지 않도록 한다.
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 이 코드에 지정되어 있는 오브젝트의 방향을 설정해준다.
        // key의 값이 1(오른쪽 방향키 입력) 일경우 원배율
        // key의 값이 -1(왼쪽 방향키 입력) 일경우 좌우반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (this.rigid2D.linearVelocity.y == 0)
        {
            // 고양이의 속도에 맞춰 애니메이션 속도 변경.
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 고양이가 바닥끝까지 떨어지면 게임 재실행.
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
