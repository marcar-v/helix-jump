using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    [Range(1, 11)]
    [SerializeField] int partCount = 11;

    [Range(0, 11)]
    [SerializeField] int deathPartCount = 1;
}

[CreateAssetMenu(fileName = "New Stage")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stageLevelPartColor = Color.white;
    public Color stageBallColor = Color.white;

    public List<Level> level = new List<Level>();
}
