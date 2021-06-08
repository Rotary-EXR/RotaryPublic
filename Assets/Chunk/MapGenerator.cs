using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class MapGenerator : NetworkBehaviour
{
    [SyncVar]
    //All game object (blocks, chunk ect)
    public GameObject stone;
    public GameObject dirt;
    public GameObject coal;
    public GameObject grass;
    public GameObject herbe;
    public GameObject gravel;
    public GameObject tree;
    public GameObject chunk;
    public GameObject chunk1;
    public GameObject chunk2;
    public GameObject chunk3;
    public GameObject house;
    public float amp = 14f;
    public float freq = 10f;
    public int posX = 0;
    public int posZ = 0;
    //====== OLD ==========
    //public int cols = 50;
    //public int rows = 50;
    // public int sol = 1;
    //=====================
    public override void OnStartServer()
    {
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "World start load"); //Log for server
        //GenerateTerrain(); //Old generation map
        GenerateTerrain2(); //Actuel et à venir
    }

    void GenerateTerrain()
    {//

      //DELETED CODE
    }
    void GenerateTerrain2()
    {//
        //lenght base map
        int cols = 110;
        int rows = 110;
        //int haut = 0;

        for (int x = 0; x < cols; x+=3)
        {
            //int az = Random.Range(0, 10);

            for (int z = 0; z < rows; z+=3)
            {
                int az = Random.Range(0, 10);
                int nb = Random.Range(0, 48);
                int ch = Random.Range(0, 3);
                float y1 = Mathf.PerlinNoise(x / freq, z / freq) * amp;
                int y = (int)Mathf.Round(y1);
                if (ch == 0)
                {
                    var Chunk = (GameObject)Instantiate(chunk, new Vector3(x, y + 1, z), Quaternion.identity); //instantiate for Local player a 3X3 prefab chunk

                    NetworkServer.Spawn(Chunk); // spawn for all
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "a chunk0 is loaded"); //for server log

                }
                if (ch == 1) //Aletrnate 1
                {
                    var Chunk1 = (GameObject)Instantiate(chunk1, new Vector3(x, y + 1, z), Quaternion.identity);
                    //var Chunk = (GameObject)Instantiate(chunk, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Chunk1);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "a chunk1 is loaded");
                    //StaticBatchingUtility.Combine(Grass);
                }
                if (ch == 2) //Alternate 2
                {
                    var Chunk2 = (GameObject)Instantiate(chunk2, new Vector3(x, y + 1, z), Quaternion.identity);
                    //var Chunk = (GameObject)Instantiate(chunk, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Chunk2);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "a chunk2 is loaded");
                    //StaticBatchingUtility.Combine(Grass);
                }
                if (ch == 3) //Alternate 3
                {
                    var Chunk3 = (GameObject)Instantiate(chunk3, new Vector3(x, y + 1, z), Quaternion.identity);
                    //var Chunk = (GameObject)Instantiate(chunk, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Chunk3);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "a chunk3 is loaded");
                    //StaticBatchingUtility.Combine(Grass);
                }
                if (nb == 6) //Tree (one prefab)
                {
                    var Tree = (GameObject)Instantiate(tree, new Vector3(x, y + 1, z), Quaternion.identity);
                    NetworkServer.Spawn(Tree);
                    StaticBatchingUtility.Combine(Tree);
                    UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "Load a Tree");
                }
                if (az == 1) //random amplitute
                {
                    amp = 13f;
                }

                if (az == 2) //random amplitute
                {
                    amp = 12f;
                }
                if (az == 3) //random amplitute
                {
                    amp = 11f;
                }
                if (az == 4) //random amplitute
                {
                    amp = 13f;
                }
                if (az == 5) //random amplitute
                {
                    amp = 14f;
                }
                if (az == 6) //random amplitute
                {
                    amp = 11f;
                }
                if (az == 7) //random amplitute
                {
                    amp = 10f;
                }
                if (az == 8) //random amplitute
                {
                    amp = 10f;
                }
                if (az == 9) //random amplitute
                {
                    amp = 10f;
                }

            }

        }
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + "World is loaded"); //Log When world is loaded
    }

}
