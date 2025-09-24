using UnityEngine;

public class ArrowGenerator : MonoBehaviour {
    // ȭ�� ������ ����
    public GameObject arrowPrefab;

    float span = 1.0f;
    float delta = 0;

    private void Update()
    {
        // Time.deltaTime = �� �����Ӱ� ���� ������ ������ �ð� ����
        this.delta += Time.deltaTime;

        // �������� �ð����̸� ������ ���� span ��(1.0f)�� ������ delta�� 0����
        // arrowPrefab �ϳ� ���� -> ȭ�� �ϳ� ����
        // ��ġ�� Random ������ px ���� ����.
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }

}
