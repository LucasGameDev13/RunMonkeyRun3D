using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List<AnimalsSO> animalsSO = new List<AnimalsSO>();
    private AnimalsSO currentAnimalSO;


    // Start is called before the first frame update
    void Start()
    {
        SpawnerCurrentAnimalSO();
    }

    public AnimalsSO currentAnimal()
    {
        return currentAnimalSO;
    }

    private void SpawnerCurrentAnimalSO()
    {
        for(int i = 0; i < animalsSO.Count; i++)
        {
            currentAnimalSO = animalsSO[i];

            Instantiate(currentAnimalSO.GetAnimalPrefab(), currentAnimalSO.GetAnimialPathsFirstPosition().localPosition, Quaternion.identity, transform);
        }
    }

}
