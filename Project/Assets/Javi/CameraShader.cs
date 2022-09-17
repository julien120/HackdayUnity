using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{

    public Material CameraMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CameraMaterial== null)
        {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, CameraMaterial);
    }
}
/*
float3x3 RGBtoLMS = float3x3(17.8824, 43.5161, 4.11935, 3.45565, 27.1554, 3.86714, 0.0299566, 0.184309, 1.46709);

float3x3 iRGBtoLMS = float3x3(0.080944, -0.130504, 0.116721, -0.010248, 0.054019, -0.113614, -0.000365, -0.004121, 0.693511);

float3x3 formula = float3x3(0, 2.02344, -2.52581, 0, 1, 0, 0, 0, 1);

fixed3 col3 = fixed3(col.r, col.g, col.b);

fixed3x3 tempMat1 = mul(iRGBtoLMS, formula);
fixed3x3 tempMat2 = mul(tempMat1, RGBtoLMS);
col3 = mul(tempMat2, col3);

col.r = col3.r;
col.g = col3.g;
col.b = col3.b;
return col;
 */
