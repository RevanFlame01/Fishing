using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public float y1;
    public float y2;
    public GameObject[] fishprefab;
    void Start()
    {
        StartCoroutine(createFish());
    }

   
    private IEnumerator createFish()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,1f));

        GameObject fish = Instantiate(fishprefab[Random.Range(0, fishprefab.Length)]);

        bool rightFish = Random.Range(0, 2) == 1;

        float y = Random.Range(y1, y2);
        float x;

        if (rightFish)
        {
            x = 2.8f;
            fish.GetComponent<Fish>().movment.x = Random.Range(-0.2f, -0.5f);
            
            fish.GetComponent<Transform>().Rotate(0, 180, 0);
        }
        else
        {
            x = -2.8f;
            fish.GetComponent<Fish>().movment.x = Random.Range(0.2f, 0.4f);
           
        }

        fish.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createFish());
    }
}
