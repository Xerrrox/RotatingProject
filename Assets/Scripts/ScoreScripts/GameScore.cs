using UnityEngine;

[CreateAssetMenu]
public class GameScore : ScriptableObject
{
    public delegate void Losed();
    public event Losed LoseEvent;

    private int _score = 0;

    public int Score { get => _score; }

    public void MinusScore()
    {
        _score -= 10;
        if(_score < 0)
        {
            LoseEvent.Invoke();
        }
    }

    public void SetNewLevel(int maxScore)
    {
        _score = maxScore;
    }
}
