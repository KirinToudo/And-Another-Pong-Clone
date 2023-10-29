using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    //...
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)
            || m_IsGameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private static GameplayManager s_Instance = null;
    public static GameplayManager Instance => s_Instance;

    public enum PlayerType
    {
        P1 = 0,
        P2
    }

    [Header("Score")]
    [SerializeField] private UnityEngine.UI.Text[] m_UITextScore = new UnityEngine.UI.Text[2];
    [SerializeField] private int m_EndGameScore;

    [Header("Game")]
    [SerializeField] private GameObject m_GameGroup;

    [Header("Game Over")]
    [SerializeField] private GameObject m_GameOverGroup;
    [SerializeField] private UnityEngine.UI.Text m_UITextWinner;

    private int[] m_Score;
    private bool m_IsGameOver;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else if (s_Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        m_Score = new int[2];
        ResetScore();
    }

    public void ResetScore()
    {
        m_Score[0] = 0;
        m_Score[1] = 0;
        m_IsGameOver = false;

        UpdateUITextScore();
        SetGameOver(false);
    }

    public void IncScore(PlayerType player)
    {
        int index = (int)player;
        ++m_Score[index];
        UpdateUITextScore();

        if (m_Score[index] == m_EndGameScore)
            GameOver();
    }

    private void UpdateUITextScore()
    {
        m_UITextScore[0].text = m_Score[0].ToString();
        m_UITextScore[1].text = m_Score[1].ToString();
    }

    private void GameOver()
    {
        m_UITextWinner.text = "JOGADOR" + ((int)GetWinner() + 1) + " GANHOU!";
        SetGameOver(true);
    }

    private void SetGameOver(bool isGameOver)
    {
        m_IsGameOver = isGameOver;
        m_GameGroup.SetActive(!m_IsGameOver);
        m_GameOverGroup.SetActive(isGameOver);
    }

    public PlayerType GetWinner()
    {
        return m_Score[0] > m_Score[1] ? PlayerType.P1 : PlayerType.P2;
    }
}
