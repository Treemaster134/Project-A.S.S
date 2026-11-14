using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string enterActionName;
    [SerializeField] private string startTriggerName;
    private bool ready = false;
    private InputAction pressEnter;
    private Animator anim;
    public void StartAnimationFinish()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void IntroFinished()
    {
        ready = true;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        pressEnter = InputSystem.actions.FindAction(enterActionName);
    }

    private void Update()
    {
        if (ready && pressEnter.IsPressed())
        {
            ready = false;
            anim.SetTrigger(startTriggerName);
        }
    }
}
