using UnityEngine;

public class Coim : Pickup
{
    protected override void OnPickup()
    {
        Debug.Log("Add 100 points");
    }
}
