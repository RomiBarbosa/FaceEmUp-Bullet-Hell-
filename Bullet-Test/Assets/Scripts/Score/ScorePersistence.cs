using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;
public class ScorePersistence : MonoBehaviour
{

    public List<PlayerData> players;

    private void Start()
    {
       //InitializeTable();
        LoadHighscore();
        PlayerPrefs.SetInt("Highscore", players[0].score);
        //InitializeTable();
    }

    public int getHighScore()
    {
        return players[0].score;
    }

    public void InitializeTable()
    {
        players.Clear();

        for (int i = 0; i < 5; i++)
        {
            SaveHighscore("non", 0);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, players);
        file.Close();

    }
    public bool IsNewHighscore(int score)
    {
        var bottom = players[4].score;
        return players.Where((s)=> s.score>= bottom).Any((a) => a.score < score);
    }

    public void SaveHighscore(string name, int score)
    {
        players.Add(new PlayerData(score, name));
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, players);
        PlayerPrefs.SetInt("Highscore", players[0].score);
        file.Close();
    }

    public List<PlayerData> LoadHighscore()
    {
        players.Clear();

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            var data = bf.Deserialize(file);
            List<PlayerData> list_data = data as List<PlayerData>;

            players = list_data;

            file.Close();
            OrderByScore();
           
        }
       
        return players;
    }

    public void OrderByScore()
    {
        var p = players.OrderByDescending((s) => s.score);
        players = p.ToList();
       
    }

   
}

[Serializable]
public class PlayerData
{
    public int score;
    public string name;

    public PlayerData(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}
