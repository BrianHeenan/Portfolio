////////////////
//Created 1/9/19 By Brian Heenan
//https://pastebin.com/nGq3rn1j
//
////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour


{
    #region Public Fields
    public static GameManager Instance;
    public GameData gameData = new GameData();
    public Scene openScene;
   
    //public Transform HealthBarPrefab;

    private string savePath;

    private void Start()
    {
       

       // HealthSystem healthSystem = new HealthSystem(100);
        //Transform healthBarTransform =  Instantiate(HealthBarPrefab, new Vector3(0, 10), Quaternion.identity);
       // HealthSystem healthBar = healthBarTransform.GetComponent<HealthSystem>();
       // healthSystem.Setup(healthSystem);
        
        
       
      //  Debug.Log("Health: " + healthSystem.GetHealth());
        //healthSystem.ModMaxHealth(10);
        
    }
    public string SavePath

    {
       get
        {
            if (savePath != null)
                return savePath;

            else
            {
                savePath = Application.persistentDataPath + "/SavedGames/";
                return savePath;
            }
        }
    }
    #endregion

    #region Private Field

    private const string FILE_EXTENSION = ".xml";
    private string saveFile;
    #endregion Private Feilds

    #region Public Method

    public void DeleteSaveFile(string saveFile)
    {
        if (File.Exists(SavePath + saveFile + FILE_EXTENSION))
        {
            File.Delete(SavePath + saveFile + FILE_EXTENSION);
        }
        else
        {
            Debug.LogError("Failed to delete non Existant File " + SavePath + saveFile + FILE_EXTENSION);
        }
    }
    public bool DoesFileExist(string testFileName)
    {
        foreach (GameData data in GetAllSaveFiles())
        {
            if (data.lastSaveFile == testFileName)
                return true;
        }
        return false;
    }
    public string GenerateNewSaveName()
    {
        int attempt = 0;
        string newSaveName = "";

        while (newSaveName == "")
        {
            string checkString = gameData.playerName;
            if (attempt != 0) checkString += attempt;
            if (!File.Exists(SavePath + checkString))
            {
                newSaveName = checkString;
            }
            attempt++;
        }
        return newSaveName;
    }
    public List<GameData> GetAllSaveFiles()
    {
        List<GameData> allSaves = new List<GameData>();
        foreach (string fileName in Directory.GetFiles(SavePath))
        {
            allSaves.Add(GetSaveFile(fileName));
        }
        return allSaves;
    }
    public int GetFlag(string flagName)
    {
        GameFlag flag = gameData.gameFlags.Find(XmlAnyAttributeAttribute => XmlAnyAttributeAttribute.flag == flagName);
        if (flag == null)
        {
            SetFlag(flagName, 0);
            return 0;

        }
        return flag.value;
    }
    public bool GetLevelCleared(int level)
    {
        return GetFlag("level" + level + "cleared") == 1 ? true : false;
    }




    public void LoadGame(string gameName)
    {
        CheckDirectory();
        String fullFilePath = SavePath + gameName + FILE_EXTENSION;
        if (File.Exists(fullFilePath))
        {
            Debug.Log("Deserializing" + fullFilePath);
            FileStream fs = File.Open(fullFilePath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));
            XmlReader reader = XmlReader.Create(fs);
            gameData = xmlSerializer.Deserialize(reader) as GameData;
            fs.Close();
            SceneManager.LoadSceneAsync(gameData.savedScene, LoadSceneMode.Single);
        }

        else
        {
            Debug.Log("Failed to save to file " + fullFilePath);

        }
    }
        public void SaveGame(string saveFile)
    {
        CheckDirectory();
        if (saveFile == null)
        {
            saveFile = GenerateNewSaveName();
        }

        this.saveFile = saveFile;
        UpdateSaveData(saveFile);

        string fullSavePath = savePath + saveFile + FILE_EXTENSION;

        FileStream fs;

        if (!File.Exists(fullSavePath))
        {
            fs = File.Create(fullSavePath);
        }
        else
        {
            fs = File.OpenWrite(fullSavePath);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        TextWriter textWriter = new StreamWriter(fs);
        serializer.Serialize(textWriter, gameData);
        fs.Close();

        Debug.Log("Game saved to " + fullSavePath);

    }
    private void UpdateSaveData(string saveFile)
    {
        gameData.lastSaveFile = saveFile;
        gameData.lastSaveTime = DateTime.Now.ToBinary();
        gameData.savedScene = SceneManager.GetActiveScene().name;
    }


    public void SetFlag(string flagName, int value)
    {
        GameFlag oldFlag = gameData.gameFlags.Find(x => x.flag == flagName);

        if (oldFlag != null)
        {
            oldFlag.value = value;
        }

        else
        {
            gameData.gameFlags.Add(new GameFlag(flagName, value));
        }
    }
    #endregion Public Methods
    #region Private Methods

    private bool IsNewFile(string saveFile)
    {
        return !File.Exists(SavePath + saveFile + FILE_EXTENSION);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            openScene = SceneManager.GetActiveScene();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    private void CheckDirectory()
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
    }
    private GameData GetSaveFile(string fullFilePath)
    {
        if (File.Exists(fullFilePath))
        {

            FileStream fs = File.Open(fullFilePath, FileMode.Open);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));
            XmlReader reader = XmlReader.Create(fs);
            GameData data = xmlSerializer.Deserialize(reader) as GameData;
            fs.Close();
            return data;
        }
        else
        {
            Debug.LogError("Failed to save File" + fullFilePath);
            return null;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckDirectory();
    }
    #endregion Private Methods
}
[Serializable]
public class GameFlag
{
    #region Publiv Fields
    public string flag;
    public int value;


    #endregion Public Fields
    #region Public Constructors
    public GameFlag()
    {

    }
    public GameFlag(string flag, int value)
    {
        this.flag = flag;
        this.value = value;
    }
    #endregion Public Constructor
}
[Serializable]
public class GameData
{
    #region Public Fields
    public int currentChapter;
    public List<GameFlag> gameFlags;
    public float health;
    public string playerName;
    [NonSerialized]
    public Vector3 playerPosition;
    public string lastSaveFile;
    public long lastSaveTime;
    public string savedScene;
    #endregion
    #region Public Constructors

    public GameData()
    {
    playerPosition = Vector3.zero;
    health = 100;
    playerName = "JohnDoe";
        currentChapter = 1;
        savedScene = "";
        gameFlags = new List<GameFlag>();
    }
    #endregion Public Constructors
    #region Public Properties

    public float PlayerPositionX
    {
        get
        {
            return playerPosition.x;
        }
        set
        {
            playerPosition.x = value;
        }
    }
    public float PlayerPositionY
    {
        get
        {
            return playerPosition.y;
        }
        set
        {
            playerPosition.y = value;
        }
    }
    public float PlayerPositionZ
    {
        get
        {
            return playerPosition.z;
        }
        set
        {
            playerPosition.z = value;
        }
    }
    #endregion Public Properties
}

