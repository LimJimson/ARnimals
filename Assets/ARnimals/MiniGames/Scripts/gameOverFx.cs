using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverFx : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseParticleSystems;
    [SerializeField] private GameObject gameOverParticleSystems;
    [SerializeField] private GameObject confirmQuitCanvas;
    [SerializeField] private GameObject confirmExploreCanvas;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)  
        {
            if (gameOverCanvas.activeSelf) 
            {
                isGameOver = true;
                pauseParticleSystems.SetActive(false);
                gameOverParticleSystems.SetActive(true);
            }
            else if (isGameOver && confirmQuitCanvas.activeSelf) 
            {
                pauseParticleSystems.SetActive(false);
                gameOverParticleSystems.SetActive(true);
            }
            else if (isGameOver && confirmExploreCanvas.activeSelf)
            {
                pauseParticleSystems.SetActive(false);
                gameOverParticleSystems.SetActive(true);
            }
            else 
            {
                gameOverParticleSystems.SetActive(false);
                pauseParticleSystems.SetActive(true);
            }
        }
    }
}
