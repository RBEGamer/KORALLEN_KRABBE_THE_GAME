// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Riff"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float3 worldPos;
		};

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float temp_output_3_0 = (-0.5 + (ase_worldPos.y - 0.0) * (1.0 - -0.5) / (5.0 - 0.0));
			o.Albedo = lerp( float4(0.06487889,0.2293134,0.5514706,1) , float4(0.2403222,0.6181608,0.9338235,1) , temp_output_3_0 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=10001
287;590;1220;1004;1175.333;863.4122;1.6;True;True
Node;AmplifyShaderEditor.WorldPosInputsNode;2;-821.5,-233.6003;Float;False;0;4;FLOAT3;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TFHCRemap;3;-496.5007,-253.1005;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;5.0;False;3;FLOAT;-0.5;False;4;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;6;-206.5683,-603.8671;Float;False;Constant;_ColorStart;Color Start;0;0;0.06487889,0.2293134,0.5514706,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;7;-207.9019,-425.9999;Float;False;Constant;_ColorEnd;Color End;0;0;0.2403222,0.6181608,0.9338235,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;8;146.8537,-306.9668;Float;False;3;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.NoiseGeneratorNode;9;-272.7346,-62.8127;Float;False;Simplex2D;1;0;FLOAT2;1,1;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;0.06711817,-123.2121;Float;True;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;482.0999,-226.2001;Float;False;True;2;Float;ASEMaterialInspector;0;Standard;Riff;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;Relative;0;;-1;-1;-1;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;2;2
WireConnection;8;0;6;0
WireConnection;8;1;7;0
WireConnection;8;2;3;0
WireConnection;10;0;3;0
WireConnection;10;1;9;0
WireConnection;0;0;8;0
ASEEND*/
//CHKSM=B9C7EAAD130A0D02936824A78D763AA82D315781