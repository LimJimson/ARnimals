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

        if (enabledFoodPrefabs.Length == 0)
        {
            Debug.LogWarning("No enabled foodPrefabs to spawn.");
            return;
        }

        if (healthManager.GetHealth()  == 1) 
        {
            foods[30].SetActive(true);
        }
        else if (healthManager.GetHealth() > 1) 
        {
            foods[30].SetActive(false);
        }

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