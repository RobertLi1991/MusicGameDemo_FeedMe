using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;

public class JsonWindowEditor : EditorWindow
{

    private int beatCount;
    private int beatFoodType;
    private int wholeCount;
    private float beatSpaceCount;
    private Beat levelBeats = new Beat();


    [MenuItem("Data/LevelData")]
    private static void ShowWindow()
    {
        var exportWindow = GetWindow<JsonWindowEditor>();
        exportWindow.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("JSON Exporter");
        GUILayout.Label("Level Data");

        //if (beatCount < wholeCount)
        //{
        if (GUI.Button(new Rect(5, 120, 50, 20), "Export"))
        {
            levelBeats.foodType = new int[] { 1, 0, 2, 2, 2, 2, 0, 1, 0, 1, 0, 0, 0, 2, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 2, 2, 1, 0, 0, 1, 2, 1, 0, 0, 2, 1, 0, 0, 1, 1, 1, 1, 2 };
            levelBeats.spaceTime = new double[] {10.1f,1.14f,1.48f,2.11f,2.35f,2.46f,0.29f,2.6f,0.24f,2.6f,0.71f,0.53f,1.3f,0.23f,
            4.40f,1.23f,0.66f,0.36f,1.4f,1.14f,1.27f,1.14f,1.18f,1.21f,1.28f,1.11f,1.25f,0.63f,0.54f,2.41f,5.97f,1.19f,1.23f,
            1.24f,5.95f,1.18f,1.21f,1.17f,2.41f,2.43f,2.36f,2.46f,1.37f};
            //        levelBeats.foodType[beatCount] = beatFoodType;
            //        levelBeats.spaceTime[beatCount] = beatSpaceCount;
            var JSONData = JsonConvert.SerializeObject(levelBeats);
            File.WriteAllText($"{Application.streamingAssetsPath}/LevelData/LevelData.json", JSONData);
        }
        //}       

    }
}
