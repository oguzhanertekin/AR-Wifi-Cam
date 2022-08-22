package com.example.wifiplugin;
import android.app.Activity;
import android.content.Context;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Build;
import androidx.annotation.RequiresApi;


public class WifiPlugin{


    public int WifiStrength(){
        WifiManager wifiManager = (WifiManager) unityActivity.getApplicationContext().getSystemService(Context.WIFI_SERVICE);
        WifiInfo wifiInfo = wifiManager.getConnectionInfo();
        return wifiInfo.getRssi();
    }

    @RequiresApi(api = Build.VERSION_CODES.R)
    public int WifiSpeed(){
        WifiManager wifiManager = (WifiManager) unityActivity.getApplicationContext().getSystemService(Context.WIFI_SERVICE);
        WifiInfo wifiInfo = wifiManager.getConnectionInfo();
        return wifiInfo.getMaxSupportedRxLinkSpeedMbps();
    }

    private static Activity unityActivity;
    public static void receiveUnityActivity(Activity tActivity){
        unityActivity=tActivity;
    }



}

