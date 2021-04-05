Shader "AllShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
       

	  
        _Ambient ("Intensity", Range(0., 1.)) = 0.1
        _AmbColor ("Color", color) = (1., 1., 1., 1.)
 
        [Header(Diffuse)]
        _Diffuse ("Val", Range(0., 1.)) = 1.
        _DifColor ("Color", color) = (1., 1., 1., 1.)
 
        [Header(Specular)]
        _Shininess ("Shininess", Range(0.1, 10)) = 1.
        _SpecColor ("Specular color", color) = (1., 1., 1., 1.)
 
    }
 
    SubShader
    {
		 Tags { "RenderType"="Opaque" }
        Pass
        {
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			
			#include "UnityCG.cginc"
			
			#pragma shader_feature _ALPHABLEND_ON
           	
            sampler2D _MainTex;
            
 
            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };
 
            v2f vert(appdata_base v)
            {
                v2f o;
                // World position
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
 
                // Clip position
                o.pos = mul(UNITY_MATRIX_VP, float4(o.worldPos, 1.));
 
                // Normal in WorldSpace
                o.worldNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
 
                o.uv = v.texcoord;
 
                return o;
            }
 
 
            fixed4 _LightColor0;
           
            // Diffuse
            float _Diffuse;
            fixed4 _DifColor;
 
            //Specular
            float _Shininess; 
            fixed4 _SpecColor;
           
            //Ambient
            float _Ambient;
            fixed4 _AmbColor;

 
            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
 
                // Light direction
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
 
                // Camera direction
                float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
 
                float3 worldNormal = normalize(i.worldNormal);
 
                // Compute ambient lighting
                float amb = _Ambient * _AmbColor;
 
                // Compute the diffuse lighting
                fixed4 NdotL = max(0., dot(worldNormal, lightDir) * _LightColor0);
                fixed4 dif = NdotL * _Diffuse * _LightColor0 * _DifColor;
 
                fixed4 light = dif + amb;
 
                // Compute the specular lighting
				 
                float3 refl = normalize(reflect(-lightDir, worldNormal));
                float RdotV = max(0., dot(refl, viewDir));
                fixed4 spec = pow(RdotV, _Shininess) * _LightColor0 * ceil(NdotL) * _SpecColor;
				//Debug.Log(_SpecColor);
                light += spec;

 
                c.rgb *= light.rgb;
 
 
                return c;
            }
 
            ENDCG
        }
    }
}