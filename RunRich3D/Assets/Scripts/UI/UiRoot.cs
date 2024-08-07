using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class UiRoot
    {
        [field: SerializeField] public Canvas StartCanvas { get; private set; }
        [field: SerializeField] public Canvas GameplayCanvas { get; private set; }
    }
}