using System.Linq;
using UnityEngine;

public class CTF_FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] foods;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnForce = 1f;

    [SerializeField] private float spawnTimer;

    [SerializeField] private CTF_HealthManager healthManager;

    [Header("Power Ups")]
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject pointsX2;
    [SerializeField] private GameObject shield;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnFood();
            spawnTimer = 0f;
        }
    }

    private void SpawnFood()
    {
        // Filter out disabled foodPrefabs
        GameObject[] enabledFoodPrefabs = foods.Where(foodPrefab => foodPrefab.activeSelf).ToArray();

        // Generate a random value between 0 and 1.
        float randomValue = Random.Range(0f, 1f);

        if (enabledFoodPrefabs.Length == 0)
        {
            Debug.LogWarning("No enabled foodPrefabs to spawn.");
            return;
        }

        if (healthManager.GetHealth() < 3) 
        {
            heart.SetActive(true);
        }
        else
        {
            heart.SetActive(false);
        }

        if (randomValue <= 0.15f)
        {
            // Decide which power-up to spawn based on a random value.
            float powerUpSelector = Random.Range(0f, 1f);
            if (powerUpSelector < 0.33f && heart.activeSelf == true)
            {
            
            GameObject spawnedHeart = Instantiate(heart, spawnPoint.position, Quaternion.identity);
            Rigidbody2D spawnedHeartRigidbody = spawnedHeart.GetComponent<Rigidbody2D>();

            // Get the original scale of the food object
            Vector3 originalScale = spawnedHeart.transform.localScale;

            // Set the scale of the spawned food to a minimized version of the original scale
            spawnedHeart.transform.localScale = originalScale * 0.13f; // Adjust the scale factor as needed

            // Apply an initial force to make the food fall
            spawnedHeartRigidbody.AddForce(Vector2.down * spawnForce, ForceMode2D.Impulse);

            Destroy(spawnedHeart, 5f);
            }
            else if (powerUpSelector < 0.66f)
            {
             GameObject spawnedX2Points = Instantiate(pointsX2, spawnPoint.position, Quaternion.identity);
            Rigidbody2D spawnedX2PointsRigidbody = spawnedX2Points.GetComponent<Rigidbody2D>();

            // Get the original scale of the food object
            Vector3 originalScale = spawnedX2Points.transform.localScale;

            // Set the scale of the spawned food to a minimized version of the original scale
            spawnedX2Points.transform.localScale = originalScale * 0.13f; // Adjust the scale factor as needed

            // Apply an initial force to make the food fall
            spawnedX2PointsRigidbody.AddForce(Vector2.down * spawnForce, ForceMode2D.Impulse);

            Destroy(spawnedX2Points, 5f);
            }
            else
            {

            GameObject spawnedShield = Instantiate(shield, spawnPoint.position, Quaternion.identity);
            Rigidbody2D spawnedShieldRigidbody = spawnedShield.GetComponent<Rigidbody2D>();

            // Get the original scale of the food object
            Vector3 originalScale = spawnedShield.transform.localScale;

            // Set the scale of the spawned food to a minimized version of the original scale
            spawnedShield.transform.localScale = originalScale * 0.13f; // Adjust the scale factor as needed

            // Apply an initial force to make the food fall
            spawnedShieldRigidbody.AddForce(Vector2.down * spawnForce, ForceMode2D.Impulse);

            Destroy(spawnedShield, 5f);
            }
        }
        else
        {
            int randomIndex = Random.Range(0, enabledFoodPrefabs.Length);
            GameObject food = Instantiate(enabledFoodPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
            Rigidbody2D foodRigidbody = food.GetComponent<Rigidbody2D>();

            // Get the original scale of the food object
            Vector3 originalScale = food.transform.localScale;

            // Set the scale of the spawned food to a minimized version of the original scale
            food.transform.localScale = originalScale * 0.13f; // Adjust the scale factor as needed

            // Apply an initial force to make the food fall
            foodRigidbody.AddForce(Vector2.down * spawnForce, ForceMode2D.Impulse);

            Destroy(food, 5f);
        }
    }

}