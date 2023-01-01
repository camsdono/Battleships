using System;
using Gameplay;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Board
{
    public class PlaceBoatsManager : MonoBehaviour
    {
        private ShipManager _shipManager;
        private UIManager _uiManager;
        private GameManager _manager;
        public GameObject ShipBuildObject;
        public Transform ButtonLocation;
        private float offset = 3f;
        private Ships ship;
        private bool isGhost;
        private GameObject pendingBoat;
        private Vector3 MousePosition;

        private void Awake()
        {
            _shipManager = GetComponent<ShipManager>();
            _uiManager = GetComponent<UIManager>();
            _manager = GetComponent<GameManager>();

            for (int i = 0; i < _shipManager.ships.Length; i++)
            {
                GameObject ShipPlaceButton = Instantiate(ShipBuildObject);
                ShipPlaceButton.transform.SetParent(ButtonLocation);
                ShipPlaceButton.transform.position = new Vector3(-2, i + offset, 0);
                ShipPlaceButton.GetComponent<BuildObject>().shipID = i;
            }
        }
        
        private void Update()
        {
            if (_manager.isBuild)
            {
                SelectGrid();
            }
        }

        public void SelectGrid()
        {
            if (ship != null)
            {
                if (!isGhost)
                {
                    pendingBoat = Instantiate(ship.shipObject);
                    isGhost = true;
                }
                else
                {
                    MousePosition = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(MousePosition);
                    Vector3 worldPos2D = new Vector3(worldPos.x, worldPos.y, -5);

                    if (pendingBoat != null)
                    {
                        pendingBoat.transform.position = worldPos2D;
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        isGhost = false;
                        ship = null;
                        Destroy(pendingBoat);
                        pendingBoat = null;
                    }
                }
            }
        }

        public void PlaceShip(int shipID)
        {
            ship = _shipManager.ships[shipID];
        }
    }
}

