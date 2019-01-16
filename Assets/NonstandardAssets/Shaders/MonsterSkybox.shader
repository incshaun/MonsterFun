Shader "Unlit/MonsterSkybox"
{
  Properties
  {
    GroundColour ("Ground Colour", Color) = (0.25, 0.2, 0.1, 1)
    SkyColour ("Sky Colour", Color) = (0.6, 0.6, 0.9, 1)
  }
  
  SubShader
  {
    Tags { "Queue" = "Background" "RenderType"="Background" "PreviewType" = "Skybox" }
    
    Pass
    {
      ZWrite Off
      Cull Off
      Fog { Mode Off }
      CGPROGRAM
      #pragma fragmentoption ARB_precision_hint_fastest
      #pragma vertex vert
      #pragma fragment frag

      #include "UnityCG.cginc"

      struct appdata
      {
        float4 vertex : POSITION;
      };

      struct v2f
      {
        float4 vertex : SV_POSITION;
        float4 orgposition : VECTOR;
      };

      float4 GroundColour;
      float4 SkyColour;

      v2f vert (appdata v)
      {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.orgposition = v.vertex;
        return o;
      }

      float4 frag (v2f i) : COLOR
      {
        float4 col;
        float factor = (1 + 10.0 * i.orgposition.y + 0.05 * sin (i.orgposition.x * 20.0)) / 2;
        factor = max (0, min (1, factor));
        col = (1 - factor) * GroundColour + factor * SkyColour;
        return col;
      }
      ENDCG
    }
  }
}
