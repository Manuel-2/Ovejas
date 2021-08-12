using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] string GameSceneName;
    [SerializeField] Animator animator;
    [SerializeField] string sleepTrigger;
    public void StartGame()
    {
        //call the animation{
        animator.SetTrigger(sleepTrigger);
    }

    public void AnimationEnded()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
