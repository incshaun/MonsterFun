Shader "Unlit/NormalMapShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float3 tangent: TANGENT;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float3 tang: TANGENT;
				float3 binor: FLOAT3;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normal = normalize (mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal));
				o.tang = normalize (mul((float3x3)UNITY_MATRIX_IT_MV, v.tangent));
				o.binor = normalize (cross (o.normal, o.tang));
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			#include "UnityLightingCommon.cginc"

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = float4 (0.6, 0.6, 0.6, 1.0);
				float3 normalmap = 2 * tex2D(_MainTex, TRANSFORM_TEX (i.uv, _MainTex)) - 1;

       			float3x3 tangentSpaceTransform = float3x3 (i.tang, i.binor, i.normal);
       			i.normal += normalize (mul (normalmap, tangentSpaceTransform));

				half3 worldNormal = UnityObjectToWorldNormal (i.normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                col = col * nl * _LightColor0;
				return col;
			}
			ENDCG
		}
	}
}
