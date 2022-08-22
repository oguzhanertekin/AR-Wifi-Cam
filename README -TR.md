# AR Wifi Cam

![logo](https://user-images.githubusercontent.com/68961575/183023181-95774d0c-1382-4119-9fff-cfc5191e6c3c.png)

## Uygulama Tanımı

Uygulama **Augmented Reality (AR)** teknolojisini kullanarak telefonun bağlı olduğu internetin çekim gücünü ve indirme hızını algılayıp bunu AR teknolojisi sayesinde kamera üzerinden gerçek dünyaya eklediğimiz bir objenin üzerinde göstermektedir. Birden fazla obje ekleyebilme özelliği sayesinde uygulamanın kullanıldığı ortamda internetin çekim gücünün nerede ne kadar olduğu tespit edilebilmektedir. 

## Uygulama Kullanımı

Uygulama ilk çalıştığı zaman kamera izni için bir pencere açılacaktır. Kamera iznini verdikten sonra direkt olarak kamera açılacaktır. Kamera açıldıktan sonra, telefonu fazla sarsmadan yavaşça ortam taratılmalı ve uygulamanın yüzeyleri taraması sağlanmalıdır. Uygulama yüzeyleri taradıktan sonra telefonun ekranına her tıklandığında mevcut konuma bir adet obje ekleyecek ve bu objenin üstünde de internet çekim gücü ve indirme hızı bilgisi bulunacaktır. Eklenen objelerin renkleri sinyal kalitesine(dBm) bağlı olarak değişmektedir.
* dBm >= -50 yani sinyal kalitesi güçlü ise yeşil renkli
* -70<= dBm <-50 yani sinyal kalitesi orta ise sarı renkli
* dBm <-70 yani sinyal kalitesi zayıf ise kırmızı renkli obje oluşturmaktadır.

Hareket ederek tıklandığı zaman uzakta kalan objeler daha küçük bir şekilde gözükecektir. Yerleştirilen objeler sürekli olarak telefonun kamerasına doğru dönüş yapacağı için hareket edildiği zaman değerleri okumak bir sorun oluşturmayacaktır. Uygulama kullanılırken telefonun sarsılıp sallanmaması gerekmektedir. Aksi halde telefonun sensörü zemini algılamakta sorun yaşayacaktır.

## Uygulama Geliştirme Platformları
Unity geliştirme ortamının hazırlamak için:
[Doküman](https://github.com/oguzhanertekin/AR-Wifi-Cam/files/9394810/install.pdf)


Uygulama, bir oyun geliştirme platformu olan Unity’de geliştirilmiştir._**[Unity 2022.1.10f1 (Önerilen) (2022.1.10f1 ve üzeri versiyonları da desteklemektedir.)]** Unity, AR uygulamalar için **AR Foundation**_ adlı bir paket kullanmaktadır. 


AR Foundation, **Unity** içinde çok platformlu bir şekilde artırılmış gerçeklik platformlarıyla çalışmanıza olanak tanır. Bu paket, Unity geliştiricilerinin kullanması için bir arayüz sunar, ancak herhangi bir AR özelliğini uygulamaz. AR Foundation'ı bir hedef cihazda kullanmak için Unity tarafından resmi olarak desteklenen hedef platformlar için ayrı paketlere de ihtiyacınız var:
   *	[ARCore XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.arcore@4.1/manual/index.html) on Android
   *	[ARKit XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.arkit@4.1/manual/index.html) on iOS
   *	[Magic Leap XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.magicleap@6.0/manual/index.html) on Magic Leap
   *	[Windows XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.windowsmr@4.0/manual/index.html) on HoloLens



### **AR Foundation** Platform Özellik Desteği ve Desteklenen Platform Paketleri:
* [Geliştiriciler İçin.pdf](https://github.com/oguzhanertekin/AR-Wifi-Cam/files/9394817/ForDevelopers.pdf)

### AR Foundation paket kurulumu ve paket hakkında daha fazla bilgi için:
>* [Doküman](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.1/manual/index.html)

Uygulamada kullanılan objeler **Blender** platformunda oluşturulmuştur. Unity platformunda ise Material bileşeni ile objeler renklendirilmiştir. 
Kamerayla bulunulan ortamı taranması, taranılan yüzeylere objelerin eklenmesi, eklenilen objelerin her koşulda kameraya doğru bakması ve objelerin üstüne verilerin bastırılması ilgili **C#** scriptleri ile sağlanmıştır. Uygulamanın kullanıldığı cihazın internet sinyal gücü ve indirme hızı verilerine ulaşılmasını sağlayan yazılım **Android Studio** platformu üzerinden **Java** programlama dili ile yazılmıştır. Daha sonradan yazılan bu kod **Android Studio** üzerinden plugin olarak eklenmiştir ve **Unity’e** entegre edilmiştir. Bu plugin’deki değerlere de **C#** scriptlerine yazılan fonksiyonlarla erişilmiştir ve böylelikle güncel sinyal gücü ve indirme hızı objelerin üzerine eklenebilir hale getirilmiştir.

### Uygulamanın Android Platformlarda çalışması için gerekli cihaz izinleri:

```java
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.example.wifiplugin">
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"/>
<uses-permission android:name="android.permission.ACCESS_WIFI_STATE"/>
<uses-permission android:name="android.permission.INTERNET"/>
<uses-permission android:name="android.permission.CHANGE_WIFI_STATE"/>
</manifest>
```

### AR Destekleyen Cihazlar Listesi:

AR destekleyen cihazların listesine aşağıdaki linkten ulaşılabilir.
>[Desteklenen Cihazlar](https://developers.google.com/ar/devices)



## Uygulamanın Test Edildiği Cihazlar
Uygulama bu cihazlarda sorunsuz bir şekilde çalışmıştır.
* Samsung Galaxy A50 (SM-A505F)
* Samsung Galaxy A71 (SM-A715F)

(Android 11 ve üstü sürümler önerilmektedir.)

## Geliştiriciler 
* Oğuzhan Ertekin       _oertekin134@gmail.com_ 
* Ahmed Senih YILDIRIM  _ahmedsenihyildirim@gmail.com_
* Yurtkan Yurtoğulları  _yyurtogullari@gmail.com_

## Uygulamadan Görüntüler

![1k](https://user-images.githubusercontent.com/68961575/183061368-6923a3e1-4d6a-4b08-b5e5-0429e3303ad2.png) ![2k](https://user-images.githubusercontent.com/68961575/183061603-7df1604b-0100-42d4-a3dc-7b37685a3864.png)

# React Native Entegrasyonu
Entegrasyon için [React-Native-Unity](https://github.com/azesmway/react-native-unity) plugini kullanılmıştır.

## Plugin Kurulumu
```sh
npm install @azesmway/react-native-unity
yada
yarn add @azesmway/react-native-unity
```

## Unity
Entegre edilecek uygulamanın ana dizinine 'unity' isimli klasör oluşturup içine unity projesini kopyalayın ve projeyi Unity üzerinden yeniden Build edin.

## Android
1- Unity uygulamasını `[proje_dizini]/unity/builds/android` dizinine Export edin.
2. Aşağıdaki satırları `android/settings.gradle` dosyasına ekleyin:
   ```gradle
   include ':unityLibrary'
   project(':unityLibrary').projectDir=new File('..\\unity\\builds\\android\\unityLibrary')
   ```
3. Aşağıdaki satırları `android/build.gradle` dosyasına ekleyin:
    ```gradle
    allprojects {
      repositories {
        // this
        flatDir {
            dirs "${project(':unityLibrary').projectDir}/libs"
        }
    // ...
    ```
4. Aşağıdaki satırı `android/gradle.properties` dosyasına ekleyin:
    ```gradle
    unityStreamingAssets=.unity3d
    ```
5. Aşağıdaki satırı ``android/app/src/main/res/values/strings.xml`` dosyasına ekleyin:
    ```javascript
    <string name="game_view_content_description">Game view</string>
    ```
6. Sadece entegre versiyonun çalışması için ``<project_name>/unity/builds/android/unityLibrary/src/main/AndroidManifest.xml`` dosyasından, `<intent-filter>...</intent-filter>` kısmını silin.

7. Unity uygulamasının gerektirdiği izinleri React Native uygulamasının izinler kısmına ekleyin. [(Alternatif) Android Merge Maniest Files](https://developer.android.com/studio/build/manage-manifests#merge_priorities)

- Emulatörde genellikle çalışmıyor. Gerçek telefon ile denenmesi önerilir.

## Örnek React Native Kodu

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
