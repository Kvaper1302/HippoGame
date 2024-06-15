using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScenesManager : MonoBehaviour
{
    public static MyScenesManager Instance;
    
    private void Awake()
    {
        Instance = this;    
    }

    public enum Scene
    {
        MainGame,
        HippoGame
    }
    
    public void LoadSceneWithNumber(Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }

    public void LoadHippoGame()
    {
        SceneManager.LoadSceneAsync(Scene.HippoGame.ToString());
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(Scene.MainGame.ToString());
    }
}
