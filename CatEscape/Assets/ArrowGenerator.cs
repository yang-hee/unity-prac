using UnityEngine;

public class ArrowGenerator : MonoBehaviour {
    // 화살 프리팹 선언
    public GameObject arrowPrefab;

    float span = 1.0f;
    float delta = 0;

    private void Update()
    {
        // Time.deltaTime = 앞 프레임과 현재 프레임 사이의 시간 차이
        this.delta += Time.deltaTime;

        // 프레임의 시간차이를 누적한 값이 span 값(1.0f)을 넘으면 delta를 0으로
        // arrowPrefab 하나 생성 -> 화살 하나 생성
        // 위치는 Random 적용한 px 값에 생성.
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }

}
