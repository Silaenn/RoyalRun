using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    LevelGeneretor levelGeneretor;

    private void Start() {
        levelGeneretor = FindAnyObjectByType<LevelGeneretor>();
    }
    protected override void OnPickup()
    {
        levelGeneretor.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
