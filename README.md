# AR Wifi Cam

![logo](https://user-images.githubusercontent.com/68961575/183023181-95774d0c-1382-4119-9fff-cfc5191e6c3c.png)

_Document written in Turkish for Turkish developers:_ [Document-TR](https://github.com/oguzhanertekin/AR-Wifi-Cam/blob/main/README%20-TR.md)

## Application Description

Using **Augmented Reality (AR)** technology, the application detects the shooting power and download speed of the internet to which the phone is connected, and shows this on an object that we add to the real world via the camera via AR technology. Thanks to the ability to add more than one object, it can be determined where and how much the signal strength of the wifi is in the environment where the application is used.

## Application Usage

The first time the app runs, a window will pop up for camera permission. After giving the camera permission, the camera will open directly. After the camera is turned on, the environment should be scanned slowly without shaking the phone too much and the application should be able to scan the surfaces. After scanning the application surfaces, each time the screen of the phone is clicked, an object will be added to the current location, and wifi signal strength/download speed information will be written on this object. The colors of the added objects change depending on the signal quality (dBm).
* dBm >= -50 ie green color if the signal quality is strong
* -70<= dBm <-50 ie yellow color if the signal quality is medium
* dBm <-70, that is, if the signal quality is weak, it creates a red object.

When clicked by moving, distant objects will appear smaller. Since the placed objects will constantly turn towards the camera of the phone, it will not be a problem to read the values when moving. The phone should not be shaken while using the application. Otherwise, the phone's sensor will have trouble detecting the ground.

## Application Development Platforms
To prepare the Unity development environment:
[Document](https://github.com/oguzhanertekin/AR-Wifi-Cam/files/9394810/install.pdf)



The application is developed on Unity, a game development platform._**[Unity 2022.1.10f1 (Recommended) (Also supports versions 2022.1.10f1 and above.)]** Unity uses a package called **AR Foundation**_ for AR apps.


AR Foundation allows you to work with augmented reality platforms in a multiplatform way within **Unity**. This package provides an interface for Unity developers to use, but does not implement any AR features. To use AR Foundation on a target device, you also need separate packages for target platforms officially supported by Unity:
* [ARCore XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.arcore@4.1/manual/index.html) on Android
* [ARKit XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.arkit@4.1/manual/index.html) on iOS
* [Magic Leap XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.magicleap@6.0/manual/index.html) on Magic Leap
* [Windows XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.windowsmr@4.0/manual/index.html) on HoloLens
    


### **AR Foundation** Platform Feature Support and Supported Platform Packs:
* [For Developers.pdf](https://github.com/oguzhanertekin/AR-Wifi-Cam/files/9394817/ForDevelopers.pdf)


### For more information about AR Foundation package installation and package:
>* [Document](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.1/manual/index.html)

The objects used in the application were created on the **Blender** platform. On the Unity platform, objects are colored with the Material component.
Scanning the environment with the camera, adding objects to the scanned surfaces, pointing the added objects towards the camera under all conditions, and printing data on the objects are provided with the relevant **C#** scripts. The software that provides access to the wifi signal strength and download speed data of the device on which the application is used is written in **Java** programming language over the **Android Studio** platform. This code, which was written later, was added as a plugin via **Android Studio** and integrated into **Unity**. The values in this plugin are accessed with the functions written to the **C#** scripts, so that the current signal strength and download speed can be added to the objects.

### Device permissions required for the app to run on Android Platforms:

```java
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.example.wifiplugin">
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"/>
<uses-permission android:name="android.permission.ACCESS_WIFI_STATE"/>
<uses-permission android:name="android.permission.INTERNET"/>
<uses-permission android:name="android.permission.CHANGE_WIFI_STATE"/>
</manifest>
```

### AR Supported Devices List:

The list of devices supporting AR can be accessed from the link below.
>[Supported Devices](https://developers.google.com/ar/devices)



## Devices on which the App has been Tested
The app worked flawlessly on these devices.
* Samsung Galaxy A50 (SM-A505F)
* Samsung Galaxy A71 (SM-A715F)

(Android 11 and higher versions are recommended.)

## Developers
* Oğuzhan Ertekin _oertekin134@gmail.com_
* Ahmed Senih YILDIRIM _ahmedsenihyildirim@gmail.com_
* Yurtkan Yurtoğulları _yyurtogullari@gmail.com_

## Images from the application

![1k](https://user-images.githubusercontent.com/68961575/183061368-6923a3e1-4d6a-4b08-b5e5-0429e3303ad2.png) ![2k](https://user-images.githubusercontent.com/68961575/183061603-7df1604b-0100-42d4-a3dc-7b37685a3864.png)

# React Native Integration
[React-Native-Unity](https://github.com/azesmway/react-native-unity) plugin is used for integration.

## Plugin Installation
```sh
npm install @azesmway/react-native-unity
```
or
```
yarn add @azesmway/react-native-unity
```

## Unity
Create a folder named 'unity' in the main directory of the application to be integrated, copy the unity project into it and rebuild the project via Unity.

## Android

  1- Export Unity application to `[project_dir]/unity/builds/android` directory.

2. Add the following lines to the `android/settings.gradle` file:
    ```gradle
    include ':unityLibrary'
    project(':unityLibrary').projectDir=new File('..\\unity\\builds\\android\\unityLibrary')
    ```
    
3. Add the following lines to the `android/build.gradle` file:
    ```gradle
    allprojects {
      repositories {
        // this
        flatDir {
            dirs "${project(':unityLibrary').projectDir}/libs"
        }
    // ...
    ```
    
4. Add the following line to the `android/gradle.properties` file:
    ```gradle
    unityStreamingAssets=.unity3d
    ```
5. Add the following line to ``android/app/src/main/res/values/strings.xml``:
    ```javascript
    <string name="game_view_content_description">Game view</string>
    ```
    
6. Delete `<intent-filter>...</intent-filter>` from ``<project_name>/unity/builds/android/unityLibrary/src/main/AndroidManifest.xml`` so that only the integrated version works.

7. Add the permissions required by the Unity application to the permissions section of the React Native application. [(Alternative) Android Merge Maniest Files](https://developer.android.com/studio/build/manage-manifests#merge_priorities).

- Emulator usually not working. It is recommended to try with real phone.

## Example React Native Code
```js
import React, { useRef, useEffect } from 'react';
import UnityView from '@azesmway/react-native-unity';
import { View } from 'react-native';
interface IMessage {
  gameObject: string;
  methodName: string;
  message: string;
}
const Unity = () => {
  const unityRef = useRef<UnityView>(null);
  useEffect(() => {
    if (unityRef?.current) {
      const message: IMessage = {
        gameObject: 'gameObject',
        methodName: 'methodName',
        message: 'message',
      };
    }
  }, []);
  return (
    <View style={{ flex: 1 }}>
      <UnityView
        ref={unityRef}
        style={{ flex: 1 }}
      />
    </View>
  );
};
export default Unity;
```
