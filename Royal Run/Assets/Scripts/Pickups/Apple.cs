using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    [SerializeField] float playerSpeedIncreaseAmount = 2f;
    LevelGeneretor levelGeneretor;
    PlayerController playerController;

    public void Init(LevelGeneretor levelGeneretor, PlayerController playerController) {
       this.levelGeneretor = levelGeneretor;
       this.playerController = playerController;
    }
    protected override void OnPickup()
    {
        levelGeneretor.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        playerController.AdjustMoveSpeed(playerSpeedIncreaseAmount);
    }
}
