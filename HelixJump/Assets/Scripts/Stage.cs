using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    [Range(1, 11)]
    [SerializeField] int _partCount = 11;
    public int partCount {  get { return _partCount; } set {  _partCount = value; } }

    [Range(0, 11)]
    [SerializeField] int _deathPartCount = 1;
    public int deathPartCount { get { return _deathPartCount; } set { _deathPartCount = value; } }
}

[CreateAssetMenu(fileName = "New Stage")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stageLevelPartColor = Color.white;
    public Color stageBallColor = Color.white;

    public List<Level> levels = new List<Level>();
}
