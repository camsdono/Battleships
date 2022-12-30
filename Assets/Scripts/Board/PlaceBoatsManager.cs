using System;
using Gameplay;
using UnityEngine;

namespace Board
{
    public class PlaceBoatsManager : MonoBehaviour
    {
        private ShipManager _shipManager;

        private void Start()
        {
            _shipManager = GetComponent<ShipManager>();
        }
    }
}

