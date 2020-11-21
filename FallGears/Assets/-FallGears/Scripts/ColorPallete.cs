using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ColorPallete : ScriptableObject
{
    public Color Main;
    public Color MainDark;
    public Color MainHighlight;
    public Color Secondary;
    public Color SecondaryDark;
    public Color SecondaryHighlight;
    public Color Obstacles;
    public Color ObstaclesDark;
    public Color ObstaclesHighlight;
}
