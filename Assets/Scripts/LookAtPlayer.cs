using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    

    
    void Update()
    {
        //Eklenen objelerin kameraya do�ru bakmas�n�n sa�lanmas�
        transform.LookAt(Camera.main.transform);
    }
}
