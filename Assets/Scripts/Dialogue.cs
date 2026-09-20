using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dialogue
{
    public Line[] lines;
}

[System.Serializable]
public class Line
{
    public string sentence;
    public float duration;
}
