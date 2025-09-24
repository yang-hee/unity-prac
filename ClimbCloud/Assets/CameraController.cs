using UnityEngine;

public class CameraController : MonoBehaviour 
{
    GameObject player;

    private void Start()
    {
        this.player = GameObject.Find("cat_0");
    }

    private void Update()
    {
        // 고양이의 Position을 불러온다 x, y, z축
        Vector3 playerPos = this.player.transform.position;

        // 카메라의 포지션을 맞춰서 이동한다.
        // 고양이의 이동범위는 y축(위, 아래)이므로 x축과 z축은 그대로 카메라의 포지션으로 유지. y축만 고양이를 따라 이동.
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
}
