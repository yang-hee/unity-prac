using UnityEngine;
using UnityEngine.UI;


// 1. 바구니 컨트롤러에서 득점 증감 상황을 받는다
// 2. 감독에서 UI를 갱신한다!
public class GameDirector: MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;

    // 제한 시간
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
        // 이름이 Time인 오브젝트 찾아서 timerText에 저장.
        // 이름이 Point인 오브젝트 찾아서 pointText에 저장.
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.pointText = GameObject.Find("ItemGenerator");
    }

    private void Update()
    {
        // Time.deltaTime 흐른 시간
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

            // "F1" => 소수점 한자리까지 표시
            this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        // 점수 뒤에 point 표시. 50point 같은 형식
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "point";
    }
}
