using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("TelaInicial");
        SceneManager.UnloadSceneAsync("Rpetir");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            SceneManager.LoadScene("Gamee");
            SceneManager.UnloadSceneAsync("TelaInicial");
            SceneManager.UnloadSceneAsync("Rpetir");
        }
    }
}
