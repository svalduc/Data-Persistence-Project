using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreData : MonoBehaviour
{
    public static ScoreData Instance;
    public int m_BestScore;
    public string m_PlayerName;
    public string m_BestPlayer;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteBestScore()
    {
        Score s = new Score();
        s.playerName = Instance.m_PlayerName;
        s.score = Instance.m_BestScore;

        string json = JsonUtility.ToJson(s);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Score s = JsonUtility.FromJson<Score>(json);

            m_BestPlayer = s.playerName;
            m_BestScore = s.score;
        }
    }

    [System.Serializable]
    class Score
    {
        public string playerName;
        public int score;
    }
}
