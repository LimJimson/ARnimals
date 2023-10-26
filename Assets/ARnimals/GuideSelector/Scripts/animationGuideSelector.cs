using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationGuideSelector : MonoBehaviour
{
    public Animator blackPnlAnim;
    public GameObject blackPnl;
    
    public Animator HighlightBoyAnim;
    public GameObject HighlightBoy;

    public Animator HighlightGirlAnim;
    public GameObject HighlightGirl;

    public Animator CloudAnim;
    public GameObject Cloud;

    public Animator chooseGuide;

    public Button boyBtn;
    public Button girlBtn;

    AudioManager audioManager;

    void Start()
    {
        try { audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); } catch { }
        boyBtn.gameObject.SetActive(false);
        girlBtn.gameObject.SetActive(false);


        StartCoroutine(Animation());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Animation()
    {
        blackPnl.SetActive(true);
        // Wait until the animation is finished
        while (!blackPnlAnim.GetCurrentAnimatorStateInfo(0).IsName("blckPnl_idle"))
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);

        //Boy guide animation
        HighlightBoy.gameObject.SetActive(true);

        while (!HighlightBoyAnim.GetCurrentAnimatorStateInfo(0).IsName("idle_HighlightBoy"))
        {
            yield return null;
        }

        try { audioManager.PlayGuide(audioManager.GuideSelector[0]); } catch { }

        while (audioManager.guideSource.isPlaying)
        {
            yield return null;
        }

        boyBtn.gameObject.SetActive(true);
        HighlightBoyAnim.SetTrigger("fadeOut_boy");

        while (!HighlightBoyAnim.GetCurrentAnimatorStateInfo(0).IsName("idle_HighlightBoy2"))
        {
            yield return null;
        }
        HighlightBoy.SetActive(false);
        yield return new WaitForSeconds(1f);
       

        //Girl guide animation
        HighlightGirl.SetActive(true);

        while (!HighlightGirlAnim.GetCurrentAnimatorStateInfo(0).IsName("idle_HighlightGirl"))
        {
            yield return null;
        }

        try { audioManager.PlayGuide(audioManager.GuideSelector[1]); } catch { }

        while (audioManager.guideSource.isPlaying)
        {
            yield return null;
        }
        girlBtn.gameObject.SetActive(true);
        HighlightGirlAnim.SetTrigger("fadeOut_Girl");

        while (!HighlightGirlAnim.GetCurrentAnimatorStateInfo(0).IsName("idle_HighlightGirl2"))
        {
            yield return null;
        }
        HighlightGirl.SetActive(false);
        yield return new WaitForSeconds(1f);
        
        //cloud animation

        Cloud.SetActive(true);

        while (!CloudAnim.GetCurrentAnimatorStateInfo(0).IsName("idle_cloud"))
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);


        blackPnlAnim.SetTrigger("closePnl");

        while (!blackPnlAnim.GetCurrentAnimatorStateInfo(0).IsName("blckPnl_idle2"))
        {
            yield return null;
        }
        chooseGuide.SetTrigger("chooseGuide");
        blackPnl.SetActive(false);

        

    }

}
