using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintmeter : MonoBehaviour
{
    public float rb = 1f;
    public float colortimer = 0;
    public static string hintready = "n";
    public static string hintused = "n";
    public Transform hintglow;
    private ParticleSystem hintParticleSystem;

    void Start()
    {
        hintParticleSystem = hintglow.GetComponent<ParticleSystem>();
        var emissionModule = hintParticleSystem.emission;
        emissionModule.enabled = false;
    }

    void Update()
    {
        colortimer += Time.deltaTime;
        if ((colortimer >= .5) && (rb > 0))
        {
            rb -= .05f;
            colortimer = 0;
        }
        GetComponent<SpriteRenderer>().color = new Color(1, 1, rb);
        if (rb <= 0)
        {
            hintready = "y";
            var emissionModule = hintParticleSystem.emission;
            emissionModule.enabled = true;
        }
    }

    void OnMouseDown()
    {
        if (hintready == "y")
        {
            hintused = "y";
            hintready = "n";
            rb = 1f;
            var emissionModule = hintParticleSystem.emission;
            emissionModule.enabled = false;
        }
    }
}