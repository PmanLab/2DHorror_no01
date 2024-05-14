using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public enum gameScene
    {
        GAME = 0,
        PAUSE,
        GAMEOVER,
        MAX_SCENE,
    };

    public static gameScene currentScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void SetScene(gameScene scene)
    {
        currentScene = scene;
    }
}
