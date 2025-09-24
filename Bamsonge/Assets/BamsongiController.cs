using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    // 해당 vector(Vector3 dir) 방향으로 힘을 가할 수 있는 메서드
    // BamsongiGenerator 에서 Shoot 메서드 실행. public으로 생성해야 함.
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // isKinematic : true일 경우 해당 오브젝트에 작용하는 힘을 무시한다. -> 땅으로 떨어지지 않음
    // 부딪혔을 때 파티클을 재생한다.
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }

    // (x, y, z) 방향.
    // z방향(앞, 화면 안쪽)으로 날아가도록 세팅
    // y방향. 중력으로 인해 지면으로 낙하하는 것을 방지.
    private void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
    }

}
