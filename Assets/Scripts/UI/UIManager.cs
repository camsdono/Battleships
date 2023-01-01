using System;
using Board;
using Gameplay;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private GameManager manager;
        private ShipManager _ship;
        private PlaceBoatsManager _boatsManager;
        private Firing firing;
        public int tileIndex;

        private void Start()
        {
            manager = FindObjectOfType<GameManager>();
            firing = gameObject.AddComponent<Firing>();
            _ship = GetComponent<ShipManager>();
            _boatsManager = GetComponent<PlaceBoatsManager>();
        }

        private void Update()
        {
            tileIndex = manager.CurrentTileIndex;
        }

        public void FireButton()
        {
            firing.OnFiring(manager.tileObjects, tileIndex);
        }
    }
}