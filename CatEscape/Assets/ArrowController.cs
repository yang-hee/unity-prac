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
        // �� �����Ӹ��� ��� ����
        transform.Translate(0, -0.1f, 0);

        // ȭ�� ������ ������ �� ������Ʈ ����
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // ȭ�� �߽� ��ǥ => �ڱ� �ڽ��� ��ǥ.(��ũ��Ʈ�� ����� ������Ʈ�� ��ǥ!)
        Vector2 p1 = transform.position;
        // �÷��̾� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position;
        // p2���� p1���� ���ϴ� dir ���͸� ����
        Vector2 dir = p1 - p2;

        // p1�� p2�� �Ÿ�(��Ÿ��� �̿��� d ���ϱ�)
        float d = dir.magnitude;
        // ȭ���� �ݰ�
        float r1 = 0.5f;
        // �÷��̾��� �ݰ�
        float r2 = 1.0f;

        // �� ������Ʈ ������ �Ÿ� �� �� ������Ʈ�� �������� ���� �պ��� ������? �浹.
        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            // �浹 �� ȭ�� ����
            Destroy(gameObject);
        }


    }
}
