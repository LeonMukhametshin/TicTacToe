using UnityEngine;
using UnityEngine.UI;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;
using TicToe;

public class MainMenuUI : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Text m_playerCountText;
    [SerializeField] private Slider m_playerCountSlider;

    [Header("Timer")]
    [SerializeField] private Text m_timeToMoveText;
    [SerializeField] private Slider m_timeToMoveSlider;

    private EcsWorld m_world;

    private void Start()
    {
        m_world = MainMenuEcsStartup.world;

        m_playerCountSlider.onValueChanged.AddListener(OnPlayerCountChanged);
        m_playerCountSlider.onValueChanged.AddListener(PlayerCountTextUpdate);
      
        m_timeToMoveSlider.onValueChanged.AddListener(OnTimeToMoveChanged);
        m_timeToMoveSlider.onValueChanged.AddListener(TimeToMoveTextUpdate);

        OnPlayerCountChanged(2);
        OnTimeToMoveChanged(1);
    }

    private void OnPlayerCountChanged(float value)
    {
        var entity = m_world.NewEntity();
        entity.Get<PlayerCountChangedEvent>().value = (int)value;
    }

    private void OnTimeToMoveChanged(float value)
    {
        var entity = m_world.NewEntity();
        entity.Get<TimeToMoveChangedEvent>().value = (int)value;
    }

    private void PlayerCountTextUpdate(float text) =>
         m_playerCountText.text = ((int)text).ToString();

    private void TimeToMoveTextUpdate(float text) =>
        m_timeToMoveText.text = ((int)text).ToString();

    public void OnPlayButtonClicked() =>
        SceneManager.LoadScene(SceneNames.GAMEPLAY);
}