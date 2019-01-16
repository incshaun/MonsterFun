Shader "Unlit/ToonShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		LightDirection ("LightDirection", Vector) = (0,1,1,0)
		kd ("kd", vector) = (1, 0, 0, 1)
		ks ("ks", vector) = (0, 1, 0, 1)
		gloss ("gloss", float) = 15.0
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 nor : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 LightDirection;
			float4 kd;
			float4 ks;
			float gloss;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				o.nor = normalize (mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal));
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);

				// Changes.
				float IL = 1.0;
				float3 N = i.nor;
				float4 L = LightDirection;
				col = kd * IL * max (0, dot (N, L));

				float diffuseDot = max (0, dot (N, L));
				if (diffuseDot < 0.5)
				{
				  col = kd * 0.3;
				}
				else
					{
					if (diffuseDot < 0.6)
					{
					  col = kd * 0.0;
					}
					else
					{
					  col = kd * 0.9;
					}
				}

				float3 V = float3 (0, 0, -1); // view direction is constant in view coordinates.
				float3 R = reflect (L, N);
//				col = col + float4 (ks * IL * pow (max (0, dot (V, R)), gloss));

				float specularDot = pow (max (0, dot (V, R)), gloss);
				if (specularDot < 0.6)
				{
				  // no specular contribution, just diffuse layer.
				}
				else
				{
					if (specularDot < 0.8)
					{
					  col = col * 0.0; // black border
					}
					else
					{
					  col = col + ks * 0.7;
					}
				}

				return col;
			}
			ENDCG
		}
	}
}
