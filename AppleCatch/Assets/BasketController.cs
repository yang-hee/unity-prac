using UnityEngine;

public class BasketController : MonoBehaviour
{

    // �ʿ��� ������� ������ŭ ���� ����
    public AudioClip appleSE;
    public AudioClip bombSE;

    // AudioSource�� ���� ���� ����
    AudioSource aud;

    // ���� ������Ʈ�� ���� director
    GameObject director;

    private void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    // �浹 ���� OnTriggerEnter�� �Ű������� ���޵ȴ�. => other
    // �浹�Ǹ� Destroy �̿��Ͽ� �浹�� ��ü ����.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            // ���� ������Ʈ���� GameDirector Class�� GetApple �޼��带 ȣ����.
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
            Debug.Log("��� ��Ҵ�");
        } else
        {
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
            Debug.Log("��ź�̴�");
        }
        Destroy(other.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ��ũ�� ��ǥ�� ���� ��ǥ�� �����ϴ� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Physics.Raycast�� ���� ������ stage ������Ʈ�� ��Ҵ��� Ȯ��
            // out : �޼��� �� ���� ä�� out�� ������ ��ȯ���ּ���!
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);

            }
        }
    }
}
