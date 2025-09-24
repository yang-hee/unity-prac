using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    // �ش� vector(Vector3 dir) �������� ���� ���� �� �ִ� �޼���
    // BamsongiGenerator ���� Shoot �޼��� ����. public���� �����ؾ� ��.
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // isKinematic : true�� ��� �ش� ������Ʈ�� �ۿ��ϴ� ���� �����Ѵ�. -> ������ �������� ����
    // �ε����� �� ��ƼŬ�� ����Ѵ�.
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }

    // (x, y, z) ����.
    // z����(��, ȭ�� ����)���� ���ư����� ����
    // y����. �߷����� ���� �������� �����ϴ� ���� ����.
    private void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
    }

}
