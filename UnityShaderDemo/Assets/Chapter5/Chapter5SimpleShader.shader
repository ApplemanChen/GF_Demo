Shader "Unity Shaders Book/Chapter5/Simple Shader" {

	SubShader{
		Pass{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag

			//使用一个结构体来定义定点信息输入
			struct a2v {
				//POSITION 语义告诉Unity,用模型空间的定点坐标填充vertext变量
				float4 vertex:POSITION;
				// NORMAL语义告诉Unity,用模型空间的法线方向填充normal变量
				float3 normal:NORMAL;
				//TEXTCOORD0语义告诉Unity,用模型的第一套文理左边填充textcoord变量
				float4 textcoord:TEXCOORD0;
			};

			//使用一个结构体定义顶点着色器的输出
			struct v2f {
				//pos中包含顶点在裁剪空间中的空间位置信息
				float4 pos:SV_POSITION;
				//COLOR0语义用于存储颜色信息
				fixed3 color : COLOR0;
			};


			v2f vert(a2v v){
				//声明输出结构
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP,v.vertex);

				o.color = v.normal*0.5 + fixed3(0.5,0.5,0.5);
				return o;
			}
			
			//顶点信息和片元通信
			fixed4 frag(v2f i) : SV_Target{
				return fixed4(i.color,1.0);
			}

			ENDCG
		}
	}

}