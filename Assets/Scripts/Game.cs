using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private CameraFollow _camera;

    [SerializeField]
    private Player _player;

    private Canvas _menuCanvas;

    [SerializeField]
    private GameObject _objectForUI;

    [SerializeField]
    private GameScore _gameScore;

    [SerializeField]
    private Wall _walls;

    [SerializeField]
    private GameRoad _road;

    private Vector3 _direction = new Vector3(-1,0,0);

    private ScoreFiller _scorePanel;
    private Transform _failPanel;


    private float _speed = 0.1f;
    private int _maxScore = 100;

    private bool _isNeedStop = false;

    private void Start()
    {
        _menuCanvas = _objectForUI.transform.Find("MenuCanvas").GetComponent<Canvas>();
        _scorePanel = _menuCanvas.transform.Find("ScorePanel").GetComponent<ScoreFiller>();
        _failPanel = _menuCanvas.transform.Find("FailPanel");


        _gameScore.SetNewLevel(_maxScore);
        _road.Initialize(_player);
        _player.Initialize(new Vector2(_road.Size.x / 2, 0));
        _walls.Initialize(_player, _road);
        _camera.SetPlayer(_player);
        _gameScore.LoseEvent += SetFailCanvas;
    }

    private void OnDestroy()
    {
        _gameScore.LoseEvent -= SetFailCanvas;
    }

    public void FinishReached()
    {
        _isNeedStop = true;
        _scorePanel.gameObject.SetActive(true);
        _scorePanel.SetProgress(_gameScore.Score, _maxScore);
    }

    private void FixedUpdate()
    {
        if(_player != null && !_isNeedStop)
        {
            _player.transform.Translate(_direction * _speed);
        }
    }

    public void SetFailCanvas()
    {
        _isNeedStop = true;
        _failPanel.gameObject.SetActive(true);
    }

}
