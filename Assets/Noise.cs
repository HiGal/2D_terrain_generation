using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    public static float[,] GenerateNoiseMap(int width, int height, float scale,int seed, int octaves, float lacunarity, float persistance, Vector2 offset)
    {
        float[,] noiseMap = new float[width, height];
        System.Random rnd = new System.Random(seed); 
        
        Vector2[] octOffsets = new Vector2[octaves];



        for (int i = 0; i < octaves; i++)
        {
            float offsetX = rnd.Next(-100000, 100000) + offset.x;
            float offsetY = rnd.Next(-100000, 100000) + offset.y;
            octOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if(scale <= 0)
        {
            scale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float frequency = 1;
                float noiseHeight = 0;
                float amplitude = 1;
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (float) x/scale * frequency + octOffsets[i].x;
                    float sampleY = (float) y/scale * frequency + octOffsets[i].y;
                    float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY)*2 -1;
                    noiseHeight += perlinNoise * amplitude;

                    amplitude *= persistance;
					frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight) {
					maxNoiseHeight = noiseHeight;
				} else if (noiseHeight < minNoiseHeight) {
					minNoiseHeight = noiseHeight;
				}
                noiseMap[x, y] = noiseHeight;
                

                
            }
        }

        for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				noiseMap [x, y] = Mathf.InverseLerp (minNoiseHeight, maxNoiseHeight, noiseMap [x, y]);
			}
		}

        return noiseMap;
    }
}
