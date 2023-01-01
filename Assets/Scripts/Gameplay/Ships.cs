using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    
    public class Ships
    {
        [Header("Number of ships:")]
        public string NameOfShip;
        public int NumberOfHoles;
        public GameObject shipObject;
    }
}