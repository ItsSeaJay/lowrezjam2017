// Pixel Boy filter by Michael @wtfmig
// Obtained from this Reddit post: http://preview.tinyurl.com/yak7rzxd
// Altered for custom width/height values by Callum John @ItsSeaJay
// Last Revision: 14:26 on 02/08/2017

// Libraries
using UnityEngine;
using System.Collections;

// Dependancies
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]

public class PixelBoy : MonoBehaviour
{
    [SerializeField]
    private int width = 128, height = 128;

    protected void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        } // End if (!SystemInfo.supportsImageEffects)
    } // End protected void Start()

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(width, height, -1);
        buffer.filterMode = FilterMode.Point;

        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    } // End void OnRenderImage(RenderTexture source, RenderTexture destination)
} // End public class PixelBoy : MonoBehaviour
