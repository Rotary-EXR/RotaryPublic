using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Return : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        

    }
  
}
