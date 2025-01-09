using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    LevelGeneretor levelGeneretor;

    public void Init(LevelGeneretor levelGeneretor) {
       this.levelGeneretor = levelGeneretor;
    }
    protected override void OnPickup()
    {
        levelGeneretor.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
