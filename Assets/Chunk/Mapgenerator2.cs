using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mapgenerator2 : NetworkBehaviour
{
    [SyncVar]
    public GameObject stone;
    public GameObject dirt;
    public GameObject coal;
    public GameObject grass;
    public GameObject gravel;

    public float amp = 14f;
    public float freq = 10f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    async void GenerateTerrain()
    {

        int cols = 92;
        int rows = 32;
        int haut = 16;
        for (int x = 64; x < cols; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                float y1 = Mathf.PerlinNoise(x / freq, z / freq) * amp;
                int y = (int)Mathf.Round(y1);

                int a = Random.Range(0, 2);
                if (a == 0)
                {
                    var Grass = (GameObject)Instantiate(grass, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Grass);
                }
                if (a == 1)
                {
                    var Dirt = (GameObject)Instantiate(dirt, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Dirt);
                }
                if (a == 2)
                {
                    var Grass = (GameObject)Instantiate(grass, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Grass);
                }
                for (int yh = 0; yh < haut; yh++)
                {
                    var Stone1 = (GameObject)Instantiate(stone, new Vector3(x, y - yh, z), Quaternion.identity);
                    NetworkServer.Spawn(Stone1);
                }



            }
        }
    }
}