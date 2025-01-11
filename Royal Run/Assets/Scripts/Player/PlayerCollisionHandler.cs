using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    const string hitString = "Hit";
    float cooldownTimer = 0f;

    LevelGeneretor levelGeneretor;
    PlayerController playerController;

    void Start() {
        levelGeneretor = FindAnyObjectByType<LevelGeneretor>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other) {
       if(cooldownTimer < collisionCooldown) return;

       levelGeneretor.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount); 
       playerController.AdjustMoveSpeed(adjustChangeMoveSpeedAmount);

       animator.SetTrigger(hitString);
       cooldownTimer = 0f;
    }
}
