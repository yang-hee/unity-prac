using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    // bamsongiPrefab ���� ����
    // �������� ���� ����. �ν����Ϳ��� �巡���ؼ� �Ҵ� ����.
    public GameObject bamsongiPrefab;

    public void Update()
    {
        // ���콺 Ŭ�� ��
        if (Input.GetMouseButtonDown(0))
        {
            // bamsongiPrefab�� ���� ���� ����(Instantiate) �ؼ� bamsongi��� ������ ��´�.
            // ����� �ν��Ͻ� ����
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            // Ray => ���� / �ݶ��̴� ����� ������Ʈ���� �浹�� �����Ѵ�.
            // ScreenPointToray �޼��忡 ���� ��ǥ ���� => �� ��ǥ�� ���ϴ� ���� �� ��ȯ
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            // ���� ���� ������Ʈ���� BamsongiController ������Ʈ�� ã�� �� ���� Shoot(Vector3 force) �޼��带 ȣ��.
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
        }
    }
}
