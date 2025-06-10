using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    const string GameObject_SUB = "/gameobject";
    //const string GameObject_COUNT_SUB = "/gameobject.count";

    private void Awake()
    {
        instance = this;
    }

    private void OnDisable()
    {
        SaveFile();
    }

    public void SaveFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + GameObject_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream stream = new FileStream(path, FileMode.Create);
        SaveProgress save = new SaveProgress(ManagerInvetori.Instance);

        formatter.Serialize(stream, save);

        stream.Close();
    }

    public void LoadFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + GameObject_SUB + SceneManager.GetActiveScene().buildIndex;

        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            //DataGameObject data = formatter.Deserialize(stream) as DataGameObject;
            SaveProgress save = formatter.Deserialize(stream) as SaveProgress;

            stream.Close();

            ManagerInvetori.Instance._inventoriSlot = save._slot;
            ManagerInvetori.Instance._bijiPlastik = save._bijiPlastikSave;
            ManagerInvetori.Instance._listItem = save._items.ToList();
            ManagerInvetori.Instance._upgradeArrayList = save._upgrade;
            ManagerInvetori.Instance._money = save._money;
            //Vector3 position = new Vector3(data._position[0], data._position[1], data._position[2]);
            //Quaternion rotation = new Quaternion(data._rotation[0], data._rotation[1], data._rotation[2], data._rotation[3]);

            //LoadPosition lp = _objectToSave[i].GetComponent<LoadPosition>();
            ////lp.LoadGameObjectPosition(data._isActive, position, rotation);

            //AITriggerSeeker._guccap = data._guccap;
            //Crowbar._isPickUp = data._crowbar;
            //Key._isPickUp = data._key;
            //CharacterMovement._isHavePearl = data._pearl;
            //CharacterMovement._headLampCondition = data._headLamp;
            //Pod._pearl = data._numberPearl;
        }
        else
        {
            Debug.LogError("Path not found in " + path);
        }
    }
}