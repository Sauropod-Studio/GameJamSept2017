// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32861,y:32721,varname:node_4013,prsc:2|diff-3185-OUT,spec-5990-OUT,gloss-6605-OUT,emission-4039-OUT,voffset-2117-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32144,y:32280,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.9586205,c3:1,c4:1;n:type:ShaderForge.SFN_Fresnel,id:4753,x:32166,y:33101,varname:node_4753,prsc:2|EXP-5983-OUT;n:type:ShaderForge.SFN_Slider,id:2754,x:31516,y:33101,ptovrint:False,ptlb:RimPower,ptin:_RimPower,varname:node_2754,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:7981,x:31833,y:33101,varname:node_7981,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:4|IN-2754-OUT;n:type:ShaderForge.SFN_Multiply,id:5983,x:31998,y:33101,varname:node_5983,prsc:2|A-7981-OUT,B-7981-OUT,C-7981-OUT;n:type:ShaderForge.SFN_Multiply,id:4039,x:32349,y:33055,varname:node_4039,prsc:2|A-38-OUT,B-4753-OUT;n:type:ShaderForge.SFN_Slider,id:38,x:32009,y:33025,ptovrint:False,ptlb:RimLighting,ptin:_RimLighting,varname:node_38,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3760684,max:1;n:type:ShaderForge.SFN_Transform,id:2273,x:31936,y:32634,varname:node_2273,prsc:2,tffrom:3,tfto:0|IN-1945-OUT;n:type:ShaderForge.SFN_Vector3,id:1945,x:31739,y:32634,varname:node_1945,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Dot,id:7123,x:32144,y:32596,varname:node_7123,prsc:2,dt:4|A-3487-OUT,B-2273-XYZ;n:type:ShaderForge.SFN_NormalVector,id:3487,x:31936,y:32476,prsc:2,pt:False;n:type:ShaderForge.SFN_Blend,id:4196,x:32349,y:33205,varname:node_4196,prsc:2,blmd:6,clmp:True|DST-4039-OUT;n:type:ShaderForge.SFN_Slider,id:5990,x:32391,y:32724,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_5990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:6605,x:32391,y:32817,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_6605,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5128205,max:1;n:type:ShaderForge.SFN_Color,id:5749,x:32144,y:32446,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_5749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:3185,x:32355,y:32446,varname:node_3185,prsc:2|A-5749-RGB,B-1304-RGB,T-7123-OUT;n:type:ShaderForge.SFN_Time,id:4011,x:32250,y:33402,varname:node_4011,prsc:2;n:type:ShaderForge.SFN_FragmentPosition,id:575,x:32469,y:33537,varname:node_575,prsc:2;n:type:ShaderForge.SFN_Add,id:6905,x:32683,y:33433,varname:node_6905,prsc:2|A-255-OUT,B-575-XYZ;n:type:ShaderForge.SFN_Multiply,id:16,x:33556,y:33387,varname:node_16,prsc:2|A-8055-OUT,B-2476-OUT,C-5962-OUT,D-8745-OUT;n:type:ShaderForge.SFN_Slider,id:5962,x:33399,y:33617,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_5962,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7350428,max:1;n:type:ShaderForge.SFN_Slider,id:4908,x:31937,y:33537,ptovrint:False,ptlb:Offset Freq,ptin:_OffsetFreq,varname:node_4908,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:3611,x:33022,y:33433,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3611,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1838-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1838,x:32849,y:33433,varname:node_1838,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6905-OUT;n:type:ShaderForge.SFN_Desaturate,id:2476,x:33214,y:33433,varname:node_2476,prsc:2|COL-3611-RGB;n:type:ShaderForge.SFN_NormalVector,id:8055,x:33214,y:33283,prsc:2,pt:False;n:type:ShaderForge.SFN_Divide,id:255,x:32469,y:33402,varname:node_255,prsc:2|A-4011-T,B-9059-OUT;n:type:ShaderForge.SFN_RemapRange,id:2117,x:33719,y:33387,varname:node_2117,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.01|IN-16-OUT;n:type:ShaderForge.SFN_RemapRange,id:9059,x:32250,y:33537,varname:node_9059,prsc:2,frmn:0,frmx:1,tomn:1,tomx:100|IN-4908-OUT;n:type:ShaderForge.SFN_Vector1,id:8745,x:33384,y:33467,varname:node_8745,prsc:2,v1:-1;proporder:1304-2754-38-5990-6605-5749-5962-4908-3611;pass:END;sub:END;*/

Shader "Shader Forge/Planet" {
    Properties {
        _Color ("Color", Color) = (0,0.9586205,1,1)
        _RimPower ("RimPower", Range(0, 1)) = 1
        _RimLighting ("RimLighting", Range(0, 1)) = 0.3760684
        _Specular ("Specular", Range(0, 1)) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0.5128205
        _Color2 ("Color2", Color) = (0.5,0.5,0.5,1)
        _Offset ("Offset", Range(0, 1)) = 0.7350428
        _OffsetFreq ("Offset Freq", Range(0, 1)) = 1
        _Noise ("Noise", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _RimPower;
            uniform float _RimLighting;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float _Offset;
            uniform float _OffsetFreq;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4011 = _Time + _TimeEditor;
                float2 node_1838 = ((node_4011.g/(_OffsetFreq*99.0+1.0))+mul(unity_ObjectToWorld, v.vertex).rgb).rg;
                float4 _Noise_var = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_1838, _Noise),0.0,0));
                v.vertex.xyz += ((v.normal*dot(_Noise_var.rgb,float3(0.3,0.59,0.11))*_Offset*(-1.0))*0.01+0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = lerp(_Color2.rgb,_Color.rgb,0.5*dot(i.normalDir,mul( float4(float3(0,1,0),0), UNITY_MATRIX_V ).xyz.rgb)+0.5);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_7981 = (_RimPower*3.5+0.5);
                float node_4039 = (_RimLighting*pow(1.0-max(0,dot(normalDirection, viewDirection)),(node_7981*node_7981*node_7981)));
                float3 emissive = float3(node_4039,node_4039,node_4039);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _RimPower;
            uniform float _RimLighting;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float _Offset;
            uniform float _OffsetFreq;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4011 = _Time + _TimeEditor;
                float2 node_1838 = ((node_4011.g/(_OffsetFreq*99.0+1.0))+mul(unity_ObjectToWorld, v.vertex).rgb).rg;
                float4 _Noise_var = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_1838, _Noise),0.0,0));
                v.vertex.xyz += ((v.normal*dot(_Noise_var.rgb,float3(0.3,0.59,0.11))*_Offset*(-1.0))*0.01+0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = lerp(_Color2.rgb,_Color.rgb,0.5*dot(i.normalDir,mul( float4(float3(0,1,0),0), UNITY_MATRIX_V ).xyz.rgb)+0.5);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _Offset;
            uniform float _OffsetFreq;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4011 = _Time + _TimeEditor;
                float2 node_1838 = ((node_4011.g/(_OffsetFreq*99.0+1.0))+mul(unity_ObjectToWorld, v.vertex).rgb).rg;
                float4 _Noise_var = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_1838, _Noise),0.0,0));
                v.vertex.xyz += ((v.normal*dot(_Noise_var.rgb,float3(0.3,0.59,0.11))*_Offset*(-1.0))*0.01+0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
