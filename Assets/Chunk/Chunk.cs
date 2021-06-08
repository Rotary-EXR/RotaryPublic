using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Chunk : NetworkBehaviour
{
    [SyncVar]
    public GameObject stone;
    public GameObject dirt;
    public GameObject coal;
    public GameObject grass;
    public GameObject herbe;
    public GameObject gravel;
    public GameObject tree;

    public float amp = 14f;
    public float freq = 10f;

    public int cols = 4;
    public int rows = 4;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "A chunk start load");
        GenerateChunk();
    }

    void GenerateChunk()
    {//

        
        int haut = 1;
        for (int x = 0; x < cols; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                float y1 = Mathf.PerlinNoise(x / freq, z / freq) * amp;
                int y = (int)Mathf.Round(y1);
                //Ground
                int b = Random.Range(0, 140);
                int c = Random.Range(0, 60);
                int a = Random.Range(0, 2);
                if (a == 0)
                {
                    var Grass = (GameObject)Instantiate(grass, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Grass);
                    StaticBatchingUtility.Combine(Grass);
                    if (c == 5)
                    {
                        var Herbe = (GameObject)Instantiate(herbe, new Vector3(x, y + 2, z), Quaternion.identity);
                        NetworkServer.Spawn(Herbe);
                    }

                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "Load world");

                }
                if (a == 1)
                {
                    var Dirt = (GameObject)Instantiate(dirt, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Dirt);
                    StaticBatchingUtility.Combine(Dirt);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "Load world");

                }
                if (a == 2)
                {
                    var Grass = (GameObject)Instantiate(grass, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Grass);
                    StaticBatchingUtility.Combine(Grass);
                    if (c == 8)
                    {
                        var Herbe = (GameObject)Instantiate(herbe, new Vector3(x, y + 2, z), Quaternion.identity);
                        NetworkServer.Spawn(Herbe);
                    }
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "Load world");
                }

                if (b == 10)
                {
                    var Tree = (GameObject)Instantiate(tree, new Vector3(x, y + 2, z), Quaternion.identity);
                    NetworkServer.Spawn(Tree);
                    StaticBatchingUtility.Combine(Tree);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "Load world");
                }

                //underground

                for (int yh = 0; yh < haut; yh++)
                {
                    //int b = Random.Range(0, 5);
                    int ba = 0;
                    if (ba == 0)
                    {
                        var Stone1 = (GameObject)Instantiate(stone, new Vector3(x, y - yh, z), Quaternion.identity);
                        NetworkServer.Spawn(Stone1);
                        StaticBatchingUtility.Combine(Stone1);
                    }
                    //          if (b == 1)
                    //          {
                    //              
                    //          }
                    //          if (b == 2)
                    //          {

                    //        }
                    //      if (b == 3)
                    //    {

                    //  }
                    //if (b == 4)
                    //{

                    //}
                    //if (b == 5)
                    //{

                    //}
                }


                // yield return null;
            }
            //yield return null;
        }
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "World is loaded");
    }
}
