using UnityEngine;
using TMPro;


public class ValueDBM : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dBmValue;


    void Start()
    {
        //Java plugininden çaðýrýlan dBm(Sinyal Gücü) deðerinin bastýrýlmasý
        if (WifiPlugin.speedResult <= 0) { dBmValue.text = " "; }
        else { dBmValue.text = WifiPlugin.dBmResult.ToString() + " dBm"; }
    }
}

