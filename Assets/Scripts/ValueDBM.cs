using UnityEngine;
using TMPro;


public class ValueDBM : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dBmValue;


    void Start()
    {
        //Java plugininden �a��r�lan dBm(Sinyal G�c�) de�erinin bast�r�lmas�
        if (WifiPlugin.speedResult <= 0) { dBmValue.text = " "; }
        else { dBmValue.text = WifiPlugin.dBmResult.ToString() + " dBm"; }
    }
}

