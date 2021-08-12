using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] string GameSceneName;
    public void ReloadScene()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
