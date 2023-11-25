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
    private void Start()
    {
      
    }
    private IEnumerator guidePopUp(GameObject myGameObject, Vector2 endPosition, Image image)
    {
        Debug.Log("MoveAnimal");
        rectTransform = myGameObject.GetComponent<RectTransform>();
        startPosition = new Vector2(myGameObject.transform.localPosition.x, myGameObject.transform.localPosition.y);
        Debug.Log("Animal Scale: " + myGameObject.transform.localScale);

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
        myGameObject.SetActive(false);
    }

    public void moveAnimal(GameObject myGameObject) 
    {
        if (gameManager.isCorrect) 
        {
            StartCoroutine(guidePopUp(myGameObject, gameManager.endPosition, gameManager.shadow));
        }
    }
}
