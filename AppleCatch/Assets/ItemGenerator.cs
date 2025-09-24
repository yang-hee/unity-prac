using UnityEngine;

public class ItemGenerator: MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    
    // �������� �������� �ӵ�. 1�ʸ��� �ѹ���
    float span = 1.0f;
    float delta = 0;

    // Ȯ������ 10���� 2�� 2�� ���.
    int ratio = 2;

    // �������� �ӵ����� �ֱ����� ����
    float speed = -0.03f;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }


    private void Update()
    {
        // Time.deltaTime = �����Ӱ� ������ ������ �ð� ����
        // 1�ʰ� �Ѿ�� ��� ������ ����. -> 1�� ���� ��� �Ѱ��� ����!
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            GameObject item;
            // 10���� 2�� Ȯ���� ��ź�� �����ϱ� ����. 10���� 2�� 10�� dice�� ǥ��.
            int dice = Random.Range(1, 11);
            
            // 10���� 2�� 2�� ���. �ֻ����� ��(dice)�� 2 �����̸� ��ź�� ����� �ʰ��ϸ� ��� ����.
            if(dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            } else
            {
                item = Instantiate(applePrefab);
            } 
            // ������ġ�� ��� ��ġ
            // Range(x, y) => x <= a < b
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
