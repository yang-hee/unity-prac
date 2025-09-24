using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    // bamsongiPrefab 변수 선언
    // 프리팹을 담을 변수. 인스펙터에서 드래그해서 할당 가능.
    public GameObject bamsongiPrefab;

    public void Update()
    {
        // 마우스 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            // bamsongiPrefab을 씬에 새로 복제(Instantiate) 해서 bamsongi라는 변수에 담는다.
            // 밤송이 인스턴스 생성
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            // Ray => 광선 / 콜라이더 적용된 오브젝트와의 충돌을 감지한다.
            // ScreenPointToray 메서드에 탭한 좌표 전달 => 탭 좌표로 향하는 벡터 값 반환
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            // 새로 만든 오브젝트에서 BamsongiController 컴포넌트를 찾아 그 안의 Shoot(Vector3 force) 메서드를 호출.
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
        }
    }
}
