Shader "Unlit/Mask"
{
    Properties
    {
        [Enum(CompareFunction)] _StencilComp("Stencil Comp", int) = 3
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }

        Pass
        {
            ZWrite Off
            Stencil{
                Comp[_StencilComp]
            }              
        }
    }
}
