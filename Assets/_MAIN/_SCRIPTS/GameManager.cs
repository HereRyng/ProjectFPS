using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //-------------[Timer]--------------//
    private float spawnerCooldownNow;
    [SerializeField] private float timeCooldown = 3;
    public static GameManager instance;
    [SerializeField] private List<Pickup> _potionPrefabs;
    private Spawner<Pickup> _potionSpawner = new Spawner<Pickup>();
    [SerializeField] private Transform parentSpawner;
    private List<ICommand> _events = new List<ICommand>();
    /// <UICANVAS_LOSE>
    [SerializeField] private GameObject canvasDeath;
    [SerializeField] private GameObject canvasWin;
    public bool IsGameOver { get; private set; }
    /// </UICANVAS_LOSE>
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        EnemyBoss.OnDieBoss += WinGame;
        PlayerController.OnGameOver += GameOver;
        spawnerCooldownNow = timeCooldown;

    }
    private void Update()
    {
        Restart();
        ///EVENT QUEUE
        if (_events.Count > 0)
        {
            for (int i = _events.Count - 1; i >= 0; i--)
            {
                _events[i].Do();
                _events.RemoveAt(i);
            }
        }

        SpawnerPotions();
    }
    public void AddCommand(ICommand command)
    {
        _events.Add(command);
    }
    public void SpawnerPotions()
    {
        spawnerCooldownNow -= Time.deltaTime;
        if (spawnerCooldownNow <= 0)
        {

            spawnerCooldownNow = timeCooldown;
            Pickup p = _potionSpawner.Create(_potionPrefabs[Random.Range(0, _potionPrefabs.Count)], parentSpawner);

            var random = Random.insideUnitSphere * 70;
            random.y = 0f;
            var positionInitial = transform.position;
            positionInitial.y = -1.35f;
            p.transform.position = positionInitial + random;
        }
    }
    public void GameOver()
    {
        IsGameOver = true;
        canvasDeath.SetActive(true);
    }

    public void WinGame()
    {
        canvasWin.SetActive(true);
    }
    private void OnDestroy()
    {
        PlayerController.OnGameOver -= GameOver;
        EnemyBoss.OnDieBoss -= WinGame;
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && IsGameOver)
        {
            canvasDeath.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
