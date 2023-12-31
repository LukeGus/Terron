using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class NetworkDisabler : NetworkBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject weaponManagerObject;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputSystemUIInputModule inputSystemUIInputModule;
    [SerializeField] private EventSystem eventSystem;
    
    public override void OnNetworkSpawn()
    {
        cameraHolder.SetActive(IsOwner);
        base.OnNetworkSpawn();
        
        if (!IsOwner)
        {
            playerObject.GetComponent<MovementManager>().enabled = false;
            playerObject.GetComponent<MovementModule>().enabled = false;
            playerObject.GetComponent<CrouchModule>().enabled = false;
            playerObject.GetComponent<SprintModule>().enabled = false;
            playerObject.GetComponent<SlideModule>().enabled = false;
            playerObject.GetComponent<HealthModule>().enabled = false;
            playerInput.enabled = false;
            inputSystemUIInputModule.enabled = false;
            eventSystem.enabled = false;
            
            DisableWeaponManagers(weaponManagerObject);
        }    
    }
    
    private void DisableWeaponManagers(GameObject parentObject)
    {
        WeaponManager weaponManager = parentObject.GetComponent<WeaponManager>();
        if (weaponManager != null)
        {
            weaponManager.enabled = false;
        }

        foreach (Transform child in parentObject.transform)
        {
            DisableWeaponManagers(child.gameObject);
        }
    }
}
