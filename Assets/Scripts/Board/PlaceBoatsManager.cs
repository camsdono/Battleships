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
        public float gridXOffset, gridYOffset;
        private float oppositeXOffset, oppositeYOffset;
        public float rotationAngle;

        private void Awake()
        {
            _shipManager = GetComponent<ShipManager>();
            _uiManager = GetComponent<UIManager>();
            _manager = GetComponent<GameManager>();

            for (int i = 0; i < _shipManager.ships.Length; i++)
            {
                //Makes the build buttons appear and work.
                GameObject ShipPlaceButton = Instantiate(ShipBuildObject);
                ShipPlaceButton.transform.SetParent(ButtonLocation);
                ShipPlaceButton.transform.position = new Vector3(-2, i + offset, 0);
                ShipPlaceButton.GetComponent<BuildObject>().shipID = i;
            }

            oppositeXOffset = gridYOffset;
            oppositeYOffset = gridXOffset;
        }
        
        private void Update()
        {
            if (_manager.isBuild)
            {
                SelectGrid();
                RotateShip();
            }
        }

        public void SelectGrid()
        {
            if (ship != null)
            {
                if (!isGhost)
                {
                    //Makes the boat appear on screen and also to set it as a ghost.
                    pendingBoat = Instantiate(ship.shipObject);
                    isGhost = true;
                }
                else
                {
                    // Gets current Mouse Position
                    MousePosition = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(MousePosition);
                    Vector3 worldPos2D = new Vector3(worldPos.x, worldPos.y, -5);

                    if (pendingBoat != null)
                    {
                        // Changes position of boat based upon mouse
                        pendingBoat.transform.position = new Vector3(RoundToNearestFloat(worldPos2D.x), RoundToNearestFloatY(worldPos2D.y), worldPos2D.z);
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        isGhost = false;
                        ship = null;
                        pendingBoat = null;
                    }
    
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        //Cancels building
                        isGhost = false;
                        ship = null;
                        Destroy(pendingBoat);
                        pendingBoat = null;
                    }
                }
            }
        }

        float RoundToNearestFloat(float posX)
        {
            float xDiff = posX % gridXOffset;
            posX -= xDiff;
            if (xDiff > (gridXOffset / 2))
            {
                posX += gridXOffset;
            }

            return posX;
        }

        float RoundToNearestFloatY(float posY)
        {
            float yDiff = posY % gridYOffset;
            posY -= yDiff;
            if (yDiff > (gridYOffset / 2))
            {
                posY += gridYOffset;
            }

            return posY;
        }

        public void RotateShip()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Rotate The Boats Position;
                pendingBoat.transform.Rotate(0, 0, rotationAngle);
            }
        }

        public void PlaceShip(int shipID)
        {
            ship = _shipManager.ships[shipID];
        }
    }
}

