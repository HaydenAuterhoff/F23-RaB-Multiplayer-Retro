using Fusion;
using UnityEngine;

public class PickUpHandler_Network : NetworkBehaviour
{
    [SerializeField]
    public GameObject pickup;



    //public static void PickupActive(Changed<PickUpHandler_Network> change)
    //{
    //    change.Behaviour.pickup.SetActive(true);
    //}
}