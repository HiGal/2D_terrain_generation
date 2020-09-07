using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public float scale;

    public bool autoUpdate;

    public int octaves;

    public float lacunarity;
    [Range(0,1)]
    public float persistance;
    public Vector2 offset;

    public TerrainType[] regions;

    public void generate_map()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(width, height, scale, octaves, lacunarity, persistance, offset);

        Color[] colorMap = new Color[width*height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if(currentHeight <= regions[i].height){
                        colorMap[y*width + x] = regions[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.drawTexture(TextureGenerator.GenerateTexture(colorMap, width, height));
    }

    void OnValidate()
    {
        if(width<1){
            width = 1;
        }

        if(height<1){
            height=1;
        }

        if(lacunarity < 1){
            lacunarity = 1;
        }
        
        if(octaves < 0){
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType {
	public string name;
	public float height;
	public Color color;
}
