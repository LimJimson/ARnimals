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

    [SerializeField] private GameObject[] powerUps;


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
        GameObject[] enabledFoods = foods.Where(food => food.activeSelf).ToArray();

        GameObject[] enabledPowerUps = powerUps.Where(powerUp => powerUp.activeSelf).ToArray();

        GameObject heart = powerUps[0];

        // Generate a random value between 0 and 1.
        float randomValue = Random.Range(0f, 1f);

        if (enabledFoods.Length == 0)
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

        Debug.Log("Random Value: " + randomValue);

        if (randomValue <= 0.05f)
        {

            Debug.Log("Available PowerUps: " + enabledPowerUps.Length);

            if (enabledPowerUps.Length <= 0) 
            {
                Debug.Log("Spawned Food through Powerup");
                SpawnRandomFoodOrPowerUp(enabledFoods);

            }
            else 
            {
                Debug.Log("Spawned PowerUp");
                SpawnRandomFoodOrPowerUp(enabledPowerUps);
            }
        }
        else
        {
            Debug.Log("Spawned Food");
            SpawnRandomFoodOrPowerUp(enabledFoods);
        }
    }

    private void SpawnRandomFoodOrPowerUp(GameObject[] arrayOfFoodsOrPowerUps) 
    {
        int randomIndex = Random.Range(0, arrayOfFoodsOrPowerUps.Length);
        GameObject spawnedObject = Instantiate(arrayOfFoodsOrPowerUps[randomIndex], spawnPoint.position, Quaternion.identity);
        Rigidbody2D spawnedObjectRigidbody = spawnedObject.GetComponent<Rigidbody2D>();

         // Get the original scale of the food object
        Vector3 originalScale = spawnedObject.transform.localScale;

        // Set the scale of the spawned spawnedObject to a minimized version of the original scale
        spawnedObject.transform.localScale = originalScale * 0.13f; // Adjust the scale factor as needed

        // Apply an initial force to make the spawnedObject fall
        spawnedObjectRigidbody.AddForce(Vector2.down * spawnForce, ForceMode2D.Impulse);

        Destroy(spawnedObject, 5f);    
    }
}