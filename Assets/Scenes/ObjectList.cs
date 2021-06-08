using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ObjectList : MonoBehaviour
{
    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }
}
