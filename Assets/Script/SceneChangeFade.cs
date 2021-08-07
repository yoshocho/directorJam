using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeFade : MonoBehaviour
{
    [SerializeField] Image m_fadePanel = default;

    [SerializeField] float m_fadeTime = 2f;
    public IEnumerator LoadSceneWithFade(float fadeTime ,string sceneName)
    {
        float timer = 0;
        Color panelColor = m_fadePanel.color;
        float alpha = 0;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            alpha += Time.deltaTime / m_fadeTime;
            panelColor.a = alpha;
            m_fadePanel.color = panelColor;
            yield return new WaitForEndOfFrame();

        }
        if (sceneName.Length > 0)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
