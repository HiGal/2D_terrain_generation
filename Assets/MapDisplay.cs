using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    // public void drawNoiseMap(float[,] noiseMap)
    // {
    //     int width = noiseMap.GetLength(0);
    //     int height = noiseMap.GetLength(1);

    //     Texture2D texture = new Texture2D(width, height);

    //     Color[] colorMap = new Color[width * height];
    //     for(int y=0; y<height; y++)
    //     {
    //         for (int x = 0; x < width; x++)
    //         {
    //             colorMap[y*width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
    //         }
    //     }
    //     texture.SetPixels(colorMap);
    //     texture.Apply();
    //     textureRender.sharedMaterial.mainTexture = texture;
	// 	textureRender.transform.localScale = new Vector3 (width, 1, height);
    // }

    public void drawTexture(Texture2D texture){
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width,1, texture.height);
    }
}
