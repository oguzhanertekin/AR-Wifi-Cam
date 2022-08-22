using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiPlugin : MonoBehaviour
{
    public static AndroidJavaClass unityClass;
    public static AndroidJavaObject unityActivity;
    public static AndroidJavaObject _pluginInstance;
    public static int dBmResult;
    public static int speedResult;

    void Start()
    {
        
        InitializeUnityPlugin("com.example.wifiplugin.WifiPlugin");
    }



    public static void InitializeUnityPlugin(string pluginName)
    {
        // Java pluginine eri�ilmesi
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        _pluginInstance = new AndroidJavaObject(pluginName);
        if (_pluginInstance == null)
        {
            Debug.Log("Plugin Instance Error");
        }

        _pluginInstance.CallStatic("receiveUnityActivity", unityActivity);

    }

    public static void WifiStrength()
    {
        if (_pluginInstance != null)
        {
            //Java plugininden WifiStrenght fonksiyonuna eri�ilmesi
            int result = _pluginInstance.Call<int>("WifiStrength");
            //Java plugininden WifiStrenght fonksiyonunda d�nd�r�len de�ere eri�ilmesi
            dBmResult = result;
            
            
        }

    }

    public static void WifiSpeed()
    {
        if (_pluginInstance != null)
        {
            //Java plugininden WifiSpeed fonksiyonuna eri�ilmesi
            int result = _pluginInstance.Call<int>("WifiSpeed");
            //Java plugininden WifiSpeed fonksiyonunda d�nd�r�len de�ere eri�ilmesi
            speedResult = result;

        }

    }


}
