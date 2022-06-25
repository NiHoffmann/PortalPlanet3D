Shader "PortalTint" {


    Properties{
        _Color("Color", Color) = (1,1,1,.5)
    }


        SubShader{
            Tags {Queue = Overlay}
            ZTest Always
            Blend SrcAlpha OneMinusSrcAlpha
            Color[_Color]
            Pass {}
    }


}