using UnityEngine;

public class Move
{
    private MoveSO _moveSO;
    private int _pp;
    public Move(MoveSO pMove, int pPP)
    {
        _moveSO = pMove;
        _pp = pPP;
    }

    public int PP { get { return _pp; } }
    public MoveSO MoveSO { get { return _moveSO; } }
}
