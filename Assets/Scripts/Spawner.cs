using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public static Spawner instance;
    public Food[] allFoods;
    public float timer;
    public float speed;
    public GameObject hitPoint;

    internal int currentFood;
    private double currentFoodTimer;
    internal int foodCount = 0;
    private float distance;
    private float delay;

    internal int allFoddCount;


    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        distance = Mathf.Abs(hitPoint.transform.position.x - transform.position.x);
        delay = distance / speed;
        
        if (SongEditor.instance.spaceTimeStack.Count > 0)
        {
            currentFoodTimer = SongEditor.instance.spaceTimeStack.Pop() - delay;
            currentFood = SongEditor.instance.foodTypeStack.Pop();
            allFoddCount = SongEditor.instance.count;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Spawner.instance.foodCount);
        //
        if(tutorial.readFlag==-1)
        { return; }
        timer += Time.deltaTime;
 
        if (timer > currentFoodTimer && foodCount < allFoddCount)
        {
            Food foodClone = Instantiate(allFoods[currentFood], this.transform.position, new Quaternion());
            foodClone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            foodClone.typeOfFood = currentFood;
            timer = 0;
           
            foodCount++;
            if (SongEditor.instance.spaceTimeStack.Count > 0)
            {
                currentFoodTimer = SongEditor.instance.spaceTimeStack.Pop(); ;
                currentFood = SongEditor.instance.foodTypeStack.Pop();

            }
            
        }
    }
}
