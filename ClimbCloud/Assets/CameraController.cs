using UnityEngine;

public class CameraController : MonoBehaviour 
{
    GameObject player;

    private void Start()
    {
        this.player = GameObject.Find("cat_0");
    }

    private void Update()
    {
        // ������� Position�� �ҷ��´� x, y, z��
        Vector3 playerPos = this.player.transform.position;

        // ī�޶��� �������� ���缭 �̵��Ѵ�.
        // ������� �̵������� y��(��, �Ʒ�)�̹Ƿ� x��� z���� �״�� ī�޶��� ���������� ����. y�ุ ����̸� ���� �̵�.
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
}
