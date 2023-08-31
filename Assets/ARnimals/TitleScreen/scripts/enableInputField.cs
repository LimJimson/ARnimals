using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enableInputField : MonoBehaviour
{
    public Animator animator;
    public TMP_InputField input;
    public Button continueBtn;
    public Button optionsBtn;
    
    void Start()
    {
        input.interactable = false;
        StartAnimationAndEnableButton();

    }

    public void StartAnimationAndEnableButton()
    {
        Debug.Log("StartAnimationAndEnableButton method called!");
        // Set the animation trigger to start the animation
        animator.SetTrigger("AnimationStart");

        // Start a coroutine to wait for the animation to finish
        StartCoroutine(WaitForAnimationFinish());
    }

    IEnumerator WaitForAnimationFinish()
    {
        // Wait until the animation is finished
        Debug.Log("WaitForAnimationFinish coroutine called!");
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle_input_field"))
        {
            yield return null;
        }

        Debug.Log("Animation has finished!");
        // Enable the button after the animation is finished
        input.interactable = true;
        continueBtn.interactable = true;
        optionsBtn.interactable = true;
    }
}
