using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // ����Ʈ���� 
    float threshold = 0.2f;

    private void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //// �����̽��� �Է��� ������ �÷��̾� ĳ������ ���Ʒ� �̵��� 0�϶� ����.
        //if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.linearVelocity.y == 0)
        //{
        //    this.rigid2D.AddForce(transform.up * this.jumpForce);
        //}

        //int key = 0;
        //// �¿� ���� �Ǻ��� ���� key �� ����. ������ ��ư�� ��� 1 / ���� ��ư�� ���� 1
        //// �ڵ尡 ���ٷ� ���� ��쿡�� {} ���� �����ϴ�
        //if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // ��ġ �Է��� ������ ĳ������ ���Ʒ�(y����) �̵��� ������ ����
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;

        // ���ӵ� ���� -0.2f ~ 0.2f ����
        // ���ӵ� ���� > 0.2f ������ �̵�
        // ���ӵ� ���� < -0.2f ���� �̵�
        if (Input.acceleration.x > this.threshold) key = 1;
        if (Input.acceleration.x < -this.threshold) key = -1; 

        // ������� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        //AddForce ����Ͽ� �÷��̾��� �̵� �ӵ��� maxWalkSpeed�� �ʰ����� �ʵ��� �Ѵ�.
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // �� �ڵ忡 �����Ǿ� �ִ� ������Ʈ�� ������ �������ش�.
        // key�� ���� 1(������ ����Ű �Է�) �ϰ�� ������
        // key�� ���� -1(���� ����Ű �Է�) �ϰ�� �¿����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (this.rigid2D.linearVelocity.y == 0)
        {
            // ������� �ӵ��� ���� �ִϸ��̼� �ӵ� ����.
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // ����̰� �ٴڳ����� �������� ���� �����.
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
