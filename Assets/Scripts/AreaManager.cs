using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Acts kinda like small GameManager for now.
/// </summary>
public class AreaManager : MonoBehaviour
{
    private static AreaManager _instance;
    public static AreaManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("AreaManager instance is null!");

            return _instance;
        }
    }

    [SerializeField] TMP_Text text;
    List<Area> allAreas = new List<Area>();


    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        allAreas = FindObjectsOfType<Area>().ToList();

        int index = 0;
        foreach (var area in allAreas)
        {
            area.ID = index;
            index++;
        }
    }


    /// <summary>
    /// Returns rounded percent of areas filled.
    /// </summary>
    int GetScore()
    {
        var areas = allAreas.Where(a => a.isFilled).ToList();
        int score = Mathf.RoundToInt((float)areas.Count() / allAreas.Count * 100);
        return score;
    }

    public void UpdateScore()
    {
        text.text = $"Score: {GetScore()}%";
    }


    // Should be in a GameManager. But have no need for a larger system for now.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
