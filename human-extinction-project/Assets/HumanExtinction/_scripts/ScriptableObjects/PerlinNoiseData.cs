﻿using UnityEngine;

namespace Atrahasis
{
    public enum TransformTarget
    {
        Position,
        Rotation,
        Both
    }

    [CreateAssetMenu(fileName = "PerlinNoiseData", menuName = "FirstPersonController/Data/PerlinNoiseData")]
    public class PerlinNoiseData : ScriptableObject
    {
        #region Variables
        public TransformTarget transformTarget;

        [Space]
        public float amplitude;
        public float frequency;
        #endregion

    }


}

