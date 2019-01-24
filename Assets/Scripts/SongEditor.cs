using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using System.Linq;

public class SongEditor : MonoBehaviour {
    public static SongEditor instance;
    internal Stack<int> foodTypeStack = new Stack<int>();
    internal Stack<double> spaceTimeStack = new Stack<double>();
    internal int count;
    private Beat levelBeats = new Beat();
    // Use this for initialization
    public void Awake()
    {
        instance = this;
        ReadData();
    }
   
    void ReadData()
    {
        
        levelBeats.foodType = new int[] { 1, 0, 2, 2, 2, 2, 0, 1, 0, 1, 0, 0, 0, 2, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 2, 2, 1, 0, 0, 1, 2, 1, 0, 0, 2, 1, 0, 0, 1, 1, 1, 1, 2 };
        levelBeats.spaceTime = new double[] {10.1f,1.14f,1.48f,2.11f,2.35f,2.46f,0.29f,2.6f,0.24f,2.6f,0.71f,0.53f,1.3f,0.23f,
            4.40f,1.23f,0.66f,0.36f,1.4f,1.14f,1.27f,1.14f,1.18f,1.21f,1.28f,1.11f,1.25f,0.63f,0.54f,2.41f,5.97f,1.19f,1.23f,
            1.24f,5.95f,1.18f,1.21f,1.17f,2.41f,2.43f,2.36f,2.46f,1.37f};

        count = levelBeats.foodType.Length;
        for (int i = levelBeats.foodType.Length; i > 0; i--)
        {
            foodTypeStack.Push(levelBeats.foodType[i - 1]);
        }
        for (int i = levelBeats.spaceTime.Length; i > 0; i--)
        {
            spaceTimeStack.Push(levelBeats.spaceTime[i - 1]);
        }
        //string dataName = File.ReadAllText($"{Application.streamingAssetsPath}/LevelData/LevelData.json");
        //var readData = JsonConvert.DeserializeObject<Beat>(dataName);

        //count = readData.foodType.Length;
        //for (int i = readData.foodType.Length; i > 0; i--)
        //{
        //    foodTypeStack.Push(readData.foodType[i - 1]);
        //}
        //for (int i = readData.spaceTime.Length; i > 0; i--)
        //{
        //    spaceTimeStack.Push(readData.spaceTime[i - 1]);
        //}
    }
    public class Beat
    {


        public int[] foodType;
        public double[] spaceTime;

    }
}
