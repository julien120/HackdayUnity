using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.MeshGeneration.Data;
using System.Globalization;

namespace Scenes.Julien
{
    public class CompassLink : MonoBehaviour
    {
        [SerializeField] private GameObject _rotationTarget;    //コンパスと動機して回転させるもの

        [SerializeField, Space(15f)] private float _intervalSeconds = 3.0f; //同期する周期
        [SerializeField] private LocationServiceStatus _status;

        private void Start()
        {
            StartCoroutine(InputGPSInfomation());
        }

        private IEnumerator InputGPSInfomation()
        {
            while (true)
            {
                switch (_status)
                {
                    //コンパスの有効化
                    case LocationServiceStatus.Stopped:
                        Input.compass.enabled = true;
                        Input.location.Start();
                        break;

                    //向きを反映
                    case LocationServiceStatus.Running:
                        var compassData = Input.compass.trueHeading;
                        _rotationTarget.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -compassData));
                        break;
                    default:
                        break;
                }

                yield return new WaitForSeconds(_intervalSeconds);
            }
        }
    }
}
