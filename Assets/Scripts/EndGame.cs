using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] string finalSceneName;
    public void LoadFinalScene()
    {
        SceneManager.LoadScene(finalSceneName);
    }
}
