Shader "Custom/Sprites" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _TransparentColor ("Transparent Color", Color) = (1,1,1,1)
        _Threshold ("Threshhold", Float) = 0.01
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Lighting Off
		CGPROGRAM
		#pragma surface surf Standard

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _TransparentColor;
        half _Threshold;
		fixed4 _Color;

		UNITY_INSTANCING_CBUFFER_START(Props)
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            half3 transparent_diff = c.xyz - _TransparentColor.xyz;
            half transparent_diff_squared = dot(transparent_diff,transparent_diff);
            if(transparent_diff_squared < _Threshold)
            	discard;

			o.Albedo = c.rgb;
			o.Emission = c.rgb * 0.75;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
