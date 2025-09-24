using UnityEngine;

public class CatContoller : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }
 

}
