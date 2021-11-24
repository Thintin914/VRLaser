using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRLeftHand : MonoBehaviour
{
    public VRRightHand rightHand;
    public SteamVR_Action_Boolean zoom, menu;
    public GameObject playerMenu;
    private GameObject cam;
    private Vector3 finalPosition, finalDirection;

    private void Awake()
    {
        cam = Camera.main.gameObject;
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("PlayerMenu");
        }
        gameObject.layer = LayerMask.NameToLayer("PlayerMenu");
    }

    private void Update()
    {
            if (rightHand.holdingObject != null && rightHand.holdingObjectInteraction == VRRightHand.HoldingObjectType.pickup)
            {
                if (zoom.stateDown) {
                    rightHand.PushHoldingObject();
                }
            }
            if (menu.stateDown)
            {
                finalPosition = cam.transform.position + cam.transform.forward * 0.55f + cam.transform.up * -0.2f;
                finalDirection = (finalPosition - cam.transform.position).normalized;
                playerMenu.transform.position = finalPosition;
                playerMenu.transform.rotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            }
    }
}
