Shader "Custom/DeuteranomalyShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RedMultiplier("Red Multiplier", Range(0, 1.5)) = 0.5
        _GreenMultiplier("Green Multiplier", Range(0, 1.5)) = 0.5
        _BlueMultiplier("Blue Multiplier", Range(0, 1.5)) = 0.5
        _TValue("T Value", Range(0, 1)) = 0.2
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float _RedMultiplier;
            float _GreenMultiplier;
            float _BlueMultiplier;
            float _TValue;


            

            

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3x3 RGBtoLMS = (17.8824, 43.5161, 4.11935, 
                                    3.45565, 27.1554, 3.86714, 
                                    0.0299566, 0.184309, 1.46709);
                fixed3x3 iRGBtoLMS = (0.080944, -0.130504, 0.116721, 
                                     -0.010248, 0.054019, -0.113614, 
                                     -0.000365, -0.004121, 0.693511);
                fixed3x3 formula = (1, 0, 0, 
                                    0.494207, 0, 1.24827, 
                                    0, 0, 1);
                fixed3x3 unitMatrix = (1, 0, 0, 
                                       0, 1, 0, 
                                       0, 0, 1);
              
                fixed4 col = tex2D(_MainTex, i.uv);
                //col.rgb = col.rgb * 0.957237 + 0.0213814;
                //col.rgb = mul(RGBtoLMS, col.rgb);
                //col.rgb = mul(formula, col.rgb);
                //col.rgb = mul(iRGBtoLMS, col.rgb);


                ///////////////////////
                //col.rgb = mul(mul(mul(iRGBtoLMS, formula), RGBtoLMS), col.rgb);
                //col.rgb = mul(mul(mul(col.rgb, RGBtoLMS), formula), iRGBtoLMS);
                ///////////////////////

                //fixed3 lmsColor = mul(RGBtoLMS, col.rgb);
                //formula = formula * _TValue + unitMatrix * (1 - _TValue);
                //fixed3 lmsDColor = mul(formula, lmsColor);
                //fixed3 rgbFinalCol = mul(iRGBtoLMS, lmsDColor);

                ///////////////

                //---
                //fixed3x3 tempMat1 = mul(iRGBtoLMS, formula);
                //fixed3x3 tempMat2 = mul(tempMat1, RGBtoLMS);
                //fixed3 col3b = mul(tempMat2, col3);
                //---
                ///////////////
                //col3 = (tempMat2._11 * col3.r + tempMat2._12 * col3.g + tempMat2._13 * col3.b, tempMat2._21 * col3.r + tempMat2._22 * col3.g + tempMat2._23 * col3.b, tempMat2._31 * col3.r + tempMat2._32 * col3.g + tempMat2._33 * col3.b);
                //fixed3 deuterCol3 = mul(iRGBtoLMS, mul(formula, mul(RGBtoLMS, col)));
                //fixed3 deuterCol3b = mul(col, mul(RGBtoLMS, mul(formula, iRGBtoLMS)));
                ///////////////

                //col.r = rgbFinalCol.r;
                //col.g = rgbFinalCol.g;
                //col.b = rgbFinalCol.b;

                col.rgb.r = col.rgb.r * _RedMultiplier;
                col.rgb.g = col.rgb.g * _GreenMultiplier;
                col.rgb.b = col.rgb.b * _BlueMultiplier;

                return col;
            }
            ENDCG
        }
    }
}


