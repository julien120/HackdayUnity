using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{

    public Material CameraMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CameraMaterial == null)
        {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, CameraMaterial);
    }
}
