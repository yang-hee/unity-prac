using UnityEngine;
using UnityEngine.UI;


// 1. �ٱ��� ��Ʈ�ѷ����� ���� ���� ��Ȳ�� �޴´�
// 2. �������� UI�� �����Ѵ�!
public class GameDirector: MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;

    // ���� �ð�
    float time = 30.0f;

    int point = 0;

    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    private void Start()
    {
        // �̸��� Time�� ������Ʈ ã�Ƽ� timerText�� ����.
        // �̸��� Point�� ������Ʈ ã�Ƽ� pointText�� ����.
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.pointText = GameObject.Find("ItemGenerator");
    }

    private void Update()
    {
        // Time.deltaTime �帥 �ð�
        this.time -= Time.deltaTime;
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (10 <=this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (20 <=this.time && this.time <30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

            // "F1" => �Ҽ��� ���ڸ����� ǥ��
            this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        // ���� �ڿ� point ǥ��. 50point ���� ����
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "point";
    }
}
