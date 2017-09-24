// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33048,y:32649,varname:node_3138,prsc:2|emission-7241-RGB,clip-9040-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31954,y:32736,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_TexCoord,id:2081,x:31759,y:32852,varname:node_2081,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:8376,x:31906,y:33224,varname:node_8376,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5969-OUT;n:type:ShaderForge.SFN_Tex2d,id:5707,x:31570,y:33224,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_5707,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df1e22493e4fe274f9cfb8317a0f3f79,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5510,x:32747,y:32928,varname:node_5510,prsc:2|A-5291-OUT,B-6850-OUT;n:type:ShaderForge.SFN_Distance,id:1997,x:32382,y:32834,varname:node_1997,prsc:2|A-8087-OUT,B-2081-V;n:type:ShaderForge.SFN_Vector1,id:8087,x:32172,y:32834,varname:node_8087,prsc:2,v1:0.5;n:type:ShaderForge.SFN_OneMinus,id:5291,x:32560,y:32834,varname:node_5291,prsc:2|IN-1997-OUT;n:type:ShaderForge.SFN_Multiply,id:6850,x:32414,y:33023,varname:node_6850,prsc:2|A-8376-OUT,B-9839-OUT;n:type:ShaderForge.SFN_Slider,id:9839,x:32349,y:33213,ptovrint:False,ptlb:Noise Intensity,ptin:_NoiseIntensity,varname:node_9839,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1111111,max:1;n:type:ShaderForge.SFN_Step,id:9040,x:32747,y:33059,varname:node_9040,prsc:2|A-7646-OUT,B-5510-OUT;n:type:ShaderForge.SFN_Slider,id:7646,x:32734,y:33212,ptovrint:False,ptlb:Lightning Width,ptin:_LightningWidth,varname:node_7646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8888889,max:1;n:type:ShaderForge.SFN_Desaturate,id:5969,x:31740,y:33224,varname:node_5969,prsc:2|COL-5707-RGB;n:type:ShaderForge.SFN_Panner,id:90,x:31966,y:33018,varname:node_90,prsc:2,spu:0,spv:1|UVIN-2081-UVOUT,DIST-2451-OUT;n:type:ShaderForge.SFN_Sin,id:2451,x:31771,y:33006,varname:node_2451,prsc:2|IN-5310-OUT;n:type:ShaderForge.SFN_Multiply,id:5310,x:31619,y:33006,varname:node_5310,prsc:2|A-2081-V,B-6375-OUT;n:type:ShaderForge.SFN_Vector1,id:6375,x:31421,y:33065,varname:node_6375,prsc:2,v1:225;n:type:ShaderForge.SFN_ComponentMask,id:1637,x:32141,y:33018,varname:node_1637,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-90-UVOUT;proporder:7241-5707-9839-7646;pass:END;sub:END;*/

Shader "Shader Forge/Lightningh" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Noise ("Noise", 2D) = "white" {}
        _NoiseIntensity ("Noise Intensity", Range(0, 1)) = 0.1111111
        _LightningWidth ("Lightning Width", Range(0, 1)) = 0.8888889
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _NoiseIntensity;
            uniform float _LightningWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                clip(step(_LightningWidth,((1.0 - distance(0.5,i.uv0.g))+((dot(_Noise_var.rgb,float3(0.3,0.59,0.11))*2.0+-1.0)*_NoiseIntensity))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _NoiseIntensity;
            uniform float _LightningWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                clip(step(_LightningWidth,((1.0 - distance(0.5,i.uv0.g))+((dot(_Noise_var.rgb,float3(0.3,0.59,0.11))*2.0+-1.0)*_NoiseIntensity))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
