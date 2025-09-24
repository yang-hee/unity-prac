using UnityEngine;

public class BasketController : MonoBehaviour
{

    // 필요한 오디오의 개수만큼 변수 선언
    public AudioClip appleSE;
    public AudioClip bombSE;

    // AudioSource를 넣을 변수 선언
    AudioSource aud;

    // 감독 오브젝트를 넣을 director
    GameObject director;

    private void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    // 충돌 상대는 OnTriggerEnter의 매개변수로 전달된다. => other
    // 충돌되면 Destroy 이용하여 충돌된 물체 삭제.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            // 감독 오브젝트에서 GameDirector Class의 GetApple 메서드를 호출함.
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
            Debug.Log("사과 잡았다");
        } else
        {
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
            Debug.Log("폭탄이다");
        }
        Destroy(other.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 스크린 좌표를 월드 좌표로 변형하는 과정
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Physics.Raycast를 통해 광선이 stage 오브젝트에 닿았는지 확인
            // out : 메서드 내 값을 채워 out에 변수로 반환해주세요!
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);

            }
        }
    }
}
