using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   [SerializeField] float checkpointintTimeExtension = 5f;
   GameManager gameManager;
   const string playerString = "Player";

   void Start(){
    gameManager = FindAnyObjectByType<GameManager>();
   }

   void OnTriggerEnter(Collider other) {
       if (other.CompareTag(playerString)){
            gameManager.IncreaseTime(checkpointintTimeExtension);
       }
   }
}
