using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParameter_", menuName = "PCG/SimpleRandomWalkData")]
public class SimpleRandomWalkSO : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomyEachIteration = true;
}
