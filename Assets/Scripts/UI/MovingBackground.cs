using Codice.CM.Common;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private Vector2 m_direction;
    [SerializeField] private float m_speed = 0.1f;

    [SerializeField] private RawImage m_rawImage;
    private Rect m_rect;

    private void Awake()
    {
        m_rect = m_rawImage.uvRect;
    }

    private void Update()
    {
        var offset = m_direction.normalized * m_speed * Time.deltaTime;

        m_rect.x += offset.x;
        m_rect.y += offset.y;

        m_rawImage.uvRect = m_rect;
    }
}