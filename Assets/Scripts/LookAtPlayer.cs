using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    

    
    void Update()
    {
        //Eklenen objelerin kameraya doðru bakmasýnýn saðlanmasý
        transform.LookAt(Camera.main.transform);
    }
}
