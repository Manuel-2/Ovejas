using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] string GameSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
