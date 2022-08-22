using UnityEngine;
using TMPro;



public class ValueSpeed : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI speedValue;


    void Start()
    {
        //Java plugininden çaðýrýlan Mbps(Ýndirme hýzý) deðerinin bastýrýlmasý
        if (WifiPlugin.speedResult <= 0) { speedValue.text = "NO CONNECTION"; }
        else { speedValue.text = WifiPlugin.speedResult.ToString() + " Mbps"; }
    }

    
}


