using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMovement : MonoBehaviour
{
    private SpawnerController spawnerController;
    private AnimalsSO animalSo;
    private List<Transform> wayPaths;
    private int wayPathsIndex = 0;

    private void Awake()
    {
        spawnerController = FindObjectOfType<SpawnerController>();
        animalSo = spawnerController.currentAnimal();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Saving all the paths into a variable
        //Getting the first path position to my position
        wayPaths = animalSo.GetAnimalPaths();
        transform.localPosition = wayPaths[wayPathsIndex].localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnimals();
    }

    //Going through all the paths to move the caracter
    private void MoveAnimals()
    {
        if(wayPathsIndex < wayPaths.Count)
        {
            Vector3 target = wayPaths[wayPathsIndex].localPosition;
            target.y = 0;
            float speed = animalSo.GetAnimalSpeed() * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed);
            
            Vector3 direction = (target - transform.localPosition).normalized;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, animalSo.GetAnimalSpeedRotation() * Time.deltaTime);
            }

            if (Vector3.Distance(transform.localPosition, target) < 0.1f)
            {
                wayPathsIndex++;
            }

        }
        else
        {
            wayPathsIndex = 0;
        }
    }

}
