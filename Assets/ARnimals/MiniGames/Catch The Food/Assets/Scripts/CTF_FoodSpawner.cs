using System.Linq;
using UnityEngine;

public class CTF_FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] foods;
    [SerializeField] private Transform spawnPoint;
    private float spawnInterval = 1f;
    private float spawnForce = 1f;
    [SerializeField] private CTF_GameManager gameManager;

    [SerializeField] private float spawnTimer;

    [SerializeField] private CTF_HealthManager healthManager;

    [SerializeField] private GameObject[] powerUps;

    private float powerUpProbability;

    private void Start() 
    {
        string selectedLevel = PlayerPrefs.GetString("CTF_SelectedLevel");
        spawnForcePerLvl(selectedLevel);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnFood();
            spawnTimer = 0f;
        }
    }

    private void spawnForcePerLvl(string selectedLevel) 
    {
        switch(selectedLevel) 
        {
            case "1":
                powerUpProbability = 0.083f; //25%
                spawnInterval = 1.3f;
                spawnForce = 15.0f;
                break;
            case "2":
                powerUpProbability = 0.067f; //20%
                spawnInterval = 1.2f;
                spawnForce = 17.0f;
                break;
            case "3":
                powerUpProbability = 0.05f; //15%
                spawnInterval = 1.1f;
                spawnForce = 19.0f;
                break;
            case "4":
                powerUpProbability = 0.033f; //10%
                spawnInterval = 1.0f;
                spawnForce = 21.0f;
                break;
            case "5":
                powerUpProbability = 0.017f; //5%
                spawnInterval = 0.9f;
                spawnForce = 23.0f;
                break;
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

        if (randomValue <= powerUpProbability)
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
            if (gameManager.InLuckState) 
            {
                GameObject[] correctFoods = System.Array.FindAll(enabledFoods, food => food.CompareTag("Correct"));
                SpawnRandomFoodOrPowerUp(correctFoods);
            }
            else 
            {
                Debug.Log("Spawned Food");
                SpawnRandomFoodOrPowerUp(enabledFoods);
            }
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