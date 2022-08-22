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
        // Java pluginine eriþilmesi
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
            //Java plugininden WifiStrenght fonksiyonuna eriþilmesi
            int result = _pluginInstance.Call<int>("WifiStrength");
            //Java plugininden WifiStrenght fonksiyonunda döndürülen deðere eriþilmesi
            dBmResult = result;
            
            
        }

    }

    public static void WifiSpeed()
    {
        if (_pluginInstance != null)
        {
            //Java plugininden WifiSpeed fonksiyonuna eriþilmesi
            int result = _pluginInstance.Call<int>("WifiSpeed");
            //Java plugininden WifiSpeed fonksiyonunda döndürülen deðere eriþilmesi
            speedResult = result;

        }

    }


}
