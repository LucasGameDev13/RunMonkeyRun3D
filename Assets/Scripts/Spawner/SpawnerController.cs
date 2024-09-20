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
        //Calling the animals only one time
        SpawnerCurrentAnimalSO();
    }

    //Saving each animalSO inside of a variable
    public AnimalsSO currentAnimal()
    {
        return currentAnimalSO;
    }

    //Spawner animals on the scene
    private void SpawnerCurrentAnimalSO()
    {
        for(int i = 0; i < animalsSO.Count; i++)
        {
            currentAnimalSO = animalsSO[i];

            Instantiate(currentAnimalSO.GetAnimalPrefab(), currentAnimalSO.GetAnimialPathsFirstPosition().localPosition, Quaternion.identity, transform);
        }
    }
}
