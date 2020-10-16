using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] realFoods;
    public GameObject[] fakeFoods;

    public ChangeActiveChild[] parents;

    public int amountOfFakeFoods = 2;

    private void Start()
    {
        Randomize();
    }

    public void Randomize()
    {
        Debug.LogWarning("--------------------------");

        var realFoods = new List<GameObject>(this.realFoods);
        var fakeFoods = new List<GameObject>(this.fakeFoods);
        for(int i = 0; i < parents.Length; i++)
        {
            var realFoodIndex = Random.Range(0, realFoods.Count);

            Debug.LogWarning($"{i + 1}: {realFoods[realFoodIndex].name}");

            Instantiate(realFoods[realFoodIndex], parents[i].transform);
            realFoods.RemoveAt(realFoodIndex);

            for(int f = 0; f < amountOfFakeFoods; f++)
            {
                var fakeFoodIndex = Random.Range(0, fakeFoods.Count);

                Instantiate(fakeFoods[fakeFoodIndex], parents[i].transform);
                fakeFoods.RemoveAt(fakeFoodIndex);
            }

            parents[i].enabled = false;
            parents[i].activeChild = Random.Range(0, amountOfFakeFoods + 1);
            parents[i].enabled = true;
        }

        Debug.LogWarning("--------------------------");
    }

    private void Update()
    {
        bool complete = true;
        for(int i = 0; i < parents.Length; i++)
        {
            if(!realFoods.Any(food => food.name == parents[i].transform.GetChild(parents[i].activeChild).name))
            {
                complete = false;
                break;
            }
        }

        if(complete)
        {
            Randomize();
            FindObjectOfType<Timer>().enabled = false;
            FindObjectOfType<Character>().GetComponent<Animator>().SetTrigger("walkAway");
        }
    }
}
