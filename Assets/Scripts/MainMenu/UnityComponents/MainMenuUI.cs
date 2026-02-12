using UnityEngine;
using UnityEngine.UI;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Text m_playerCountText;
    [SerializeField] private Text m_timeToMoveText;

    [SerializeField] private Slider m_playerCountSlider;
    [SerializeField] private Slider m_timeToMoveSlider;

    private EcsWorld m_world;

    private void Start()
    {
        m_world = new EcsWorld();

        m_playerCountSlider.onValueChanged.AddListener(OnPlayerCountChanged);
        m_playerCountSlider.onValueChanged.AddListener(PlayerCountTextUpdate);
      
        m_timeToMoveSlider.onValueChanged.AddListener(OnTimeToMoveChanged);
        m_timeToMoveSlider.onValueChanged.AddListener(TimeToMoveTextUpdate);
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

    public void PlayerCountTextUpdate(float text) =>
         m_playerCountText.text = ((int)text).ToString();

    public void TimeToMoveTextUpdate(float text) =>
        m_timeToMoveText.text = ((int)text).ToString();

    public void OnPlayButtonClicked() =>
        SceneManager.LoadScene(SceneNames.GAMEPLAY);
}