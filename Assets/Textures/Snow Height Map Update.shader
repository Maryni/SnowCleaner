﻿Shader "Snow Height Map Update"
{
    Properties
    {
        //_DrawPosition ("Draw Position", Vector) = (-1,-1,0,0)
        _DrawBrush("Beush", 2D) = "white" {}
    }

        SubShader
    {
        Lighting Off
        Blend One Zero

        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0

            sampler2D _DrawBrush;
            float4 _DrawPosition;
            float _DrawAngle;


            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float4 previousColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy);
                //float4 drawColor = smoothstep(.02, .1, distance(IN.localTexcoord.xy, _DrawPosition));

                float2 pos = IN.localTexcoord.xy - _DrawPosition;


                float2x2 rot = float2x2(cos(_DrawAngle), -sin(_DrawAngle),
                                    sin(_DrawAngle), cos(_DrawAngle));

                pos = mul(rot, pos);
                pos /= 0.25;    //was /=0.1   it's scale trails at texture
                pos += float2(0.5, 0.5);

                float4 drawColor = tex2D(_DrawBrush, pos);

                return min(previousColor, drawColor);
            }
            ENDCG
        }
    }
}
