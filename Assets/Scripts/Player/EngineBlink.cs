using UnityEngine;

public class EngineBlink : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Renderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Renderer.enabled = !m_Renderer.enabled;
    }
}
