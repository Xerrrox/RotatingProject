using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneController : ScriptableObject
{

    public void Reload ()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(scene.name);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);        
    }

    public void LoadNextLevel ()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(scene.name);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);       
    }
}
