using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class FTA_MoveAnimal : MonoBehaviour
{
    public FTA_GameManager gameManager;
    [SerializeField] private float moveDuration = 0.3f;
    private Vector2 startPosition;
    private RectTransform rectTransform;
    [SerializeField] private GameObject clickedAnimal;
    private ParticleSystem trailEffects;

    private void Start()
    {
        trailEffects = clickedAnimal.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (clickedAnimal.GetComponent<Image>().color.a == 0 && trailEffects.particleCount <= 0) 
        {
            clickedAnimal.SetActive(false);
        }  
    }

    private IEnumerator guidePopUp(GameObject myGameObject, Vector2 endPosition, Image image)
    {
        rectTransform = myGameObject.GetComponent<RectTransform>();
        startPosition = new Vector2(myGameObject.transform.localPosition.x, myGameObject.transform.localPosition.y);

        float currentTime = 0f;

        while (currentTime < moveDuration)
        {
            currentTime += Time.unscaledDeltaTime;
            float t = currentTime / moveDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            rectTransform.localScale = Vector2.Lerp(new Vector2(1, 1), new Vector2(0.7f, 0.7f), t);
            yield return null;
        }

        rectTransform.localScale = new Vector2(0.7f, 0.7f);
        rectTransform.anchoredPosition = endPosition;
        image.color = new Color(1.0f, 1.0f, 1.0f);
        gameManager.checkIfAllFound();
        myGameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    public void moveAnimal() 
    {
        if (gameManager.isCorrect) 
        {
            gameManager.isCorrect = false;
            StartCoroutine(guidePopUp(clickedAnimal, gameManager.endPosition, gameManager.shadow));
        }
    }
}