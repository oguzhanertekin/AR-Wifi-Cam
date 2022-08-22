using UnityEngine;
using TMPro;



public class ValueSpeed : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI speedValue;


    void Start()
    {
        //Java plugininden �a��r�lan Mbps(�ndirme h�z�) de�erinin bast�r�lmas�
        if (WifiPlugin.speedResult <= 0) { speedValue.text = "NO CONNECTION"; }
        else { speedValue.text = WifiPlugin.speedResult.ToString() + " Mbps"; }
    }

    
}


