using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetAvarageColor : MonoBehaviour
{

    [SerializeField]private RenderTexture texture;
    private Texture2D texture2d;
    private Color32[] colorList;
    public Vector2 textureSize;
    public float CheckLigthValue()
    {
        texture2d = ToTexture2D(texture);
        colorList = texture2d.GetPixels32();
        int r = 0, g = 0, b = 0;
        foreach (Color32 c in colorList)
        {
            r += c.r;
            g += c.g;
            b += c.b;
        }
        Color avaerage = new Color(r / colorList.Count(), g / colorList.Count(), b / colorList.Count());
        float h, s, v;
        Color.RGBToHSV(avaerage, out h, out s, out v);
        return(v);
    }
    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D((int)textureSize.x, (int)textureSize.y, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
