using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatGame : MonoBehaviour
{
    void Start()
    {
        //SceneManager.UnloadSceneAsync("TelaInicial");
        //SceneManager.UnloadSceneAsync("Rpetir");
        SceneManager.UnloadSceneAsync("Gamee");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            SceneManager.UnloadSceneAsync("FinalMenu");
            SceneManager.LoadScene("Gamee");

            //SceneManager.UnloadSceneAsync("Rpetir");
        }
    }
}
