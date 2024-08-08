using System;
using UnityEngine;

[Serializable]
public class RichnessLevel
{
    [field: SerializeField] public int TargetValue { get; private set; }
    [field: SerializeField] public GameObject Skin { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public string Text { get; private set; }
}