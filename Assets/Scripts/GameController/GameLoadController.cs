using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Calling the loading game with a delay of 3f
        Invoke("CallingCoroutine", 3f);
    }

    private void CallingCoroutine()
    {
        StartCoroutine("LoadingGame");
    }

    //Loading the scene before to move into it 
    IEnumerator LoadingGame()
    {
        AsyncOperation asyLoad = SceneManager.LoadSceneAsync("GamePlay");

        while(!asyLoad.isDone)
        {
            yield return null;
        }
    }
}
