using UnityEngine;

public class ItemGenerator: MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    
    // 아이템이 떨어지는 속도. 1초마다 한번씩
    float span = 1.0f;
    float delta = 0;

    // 확률에서 10분의 2의 2를 담당.
    int ratio = 2;

    // 떨어지는 속도감을 주기위한 변수
    float speed = -0.03f;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }


    private void Update()
    {
        // Time.deltaTime = 프레임과 프레임 사이의 시간 간격
        // 1초가 넘어가면 사과 프리팹 생성. -> 1초 마다 사과 한개씩 생성!
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            GameObject item;
            // 10분의 2의 확률로 폭탄을 생성하기 위해. 10분의 2의 10을 dice로 표현.
            int dice = Random.Range(1, 11);
            
            // 10분의 2의 2를 담당. 주사위의 눈(dice)이 2 이하이면 폭탄을 만들고 초과하면 사과 출현.
            if(dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            } else
            {
                item = Instantiate(applePrefab);
            } 
            // 랜덤위치에 사과 배치
            // Range(x, y) => x <= a < b
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
