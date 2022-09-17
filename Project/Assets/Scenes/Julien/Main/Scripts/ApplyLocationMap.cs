using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine.UI;

using Mapbox;

namespace Scene.MapBox
{
    public class ApplyLocationMap : MonoBehaviour
    {
        [SerializeField] private AbstractMap abstractMap;
        [SerializeField] private GameObject pin;
        [SerializeField] private Camera mainCamera;
        private Vector2d locationPos;
        public Vector2d LocaltionPos => locationPos;

        [SerializeField] private float latitude;
        [SerializeField] private float longitude;
        [SerializeField] private float altitude;

        /// <summary>
        /// 受け取った値を受けて、MapBoxの座標を変更する
        /// </summary>
        /// <param name="lat">経度</param>
        /// <param name="lng">緯度</param>
        public void ApplyLocation(double lat,double lng)
        {
            abstractMap.MapVisualizer.OnMapVisualizerStateChanged += (state) =>
            {
                if (state == ModuleState.Finished)
                {
                    locationPos = new Vector2d(lat, lng);
                    abstractMap.SetCenterLatitudeLongitude(locationPos);
                    mainCamera.transform.position = new Vector3((float)lat, mainCamera.transform.position.y, (float)lng);
                    Debug.Log(pin.transform.position+"軽度緯度"+ locationPos);
                }
            };
        }


        // ピンに座標を与える(困りごと)
        public void PutPinOnMap(double lat, double lng)
        {
            pin.transform.localPosition = new Vector3((float)lat, (float)lng, -10);
        }

        //現在地の座標を計算する
        public void CalcCurrentLocation()
        {

#if UNITY_EDITOR
            //TODO:現在地取得
            ApplyLocation(35.319213f, 139.546673f);
            pin.transform.localPosition = new Vector3(35.319213f, 139.546673f, -10);
            Debug.Log("unityエディター");
#endif

#if UNITY_IOS
            StartCoroutine(StartLocationService());
#endif
        }

        private IEnumerator StartLocationService()
        {
            // First, check if user has location service enabled
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log("GPS not enabled");
                yield break;
            }

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait <= 0)
            {
                Debug.Log("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
                yield break;
            }

            // Set locational infomations
            while (true)
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                altitude = Input.location.lastData.altitude;
                Debug.Log("緯度" + latitude + "経度" + longitude);

                ApplyLocation(ReturnLocation(latitude, longitude).Item1, ReturnLocation(latitude, longitude).Item2);

                yield return new WaitForSeconds(10);
            }
        }

        public (double,double) ReturnLocation(float latitude,float longitude)
        {
            return ((double)latitude, (double)longitude);
        }

    }
}