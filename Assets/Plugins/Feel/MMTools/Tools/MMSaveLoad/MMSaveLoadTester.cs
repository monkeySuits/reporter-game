using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
    [System.Serializable]
    public class Flags
    {
        public string name;
        public bool active;
        public bool done;
    }

    [System.Serializable]
    public class ItemsInLevel
    {
        public string name;
        public bool acquired;
    }
    [System.Serializable]
    public class LevelProgressObject
    {
        public List<Flags> progressionFlags;
        public List<ItemsInLevel> itemsInLevel;
    }

    /// <summary>
    /// A test object to store data to test the MMSaveLoadManager class
    /// </summary>
    [System.Serializable]
    public class MMSaveLoadSaveObject
    {
        public List<LevelProgressObject> levels; // List of Chapters
        public int curLevel; // The chapter in the story
        public int curLevelIndex; // The index of the last scene you were on

        // Player position (vectors are not serializable)
        public float posX;
        public float posY;
        public float posZ;

        public LevelProgressObject GetCurrentLevel { get { return levels[curLevel]; } } // Getter of the current level
    }

    /// <summary>
    /// A simple class used in the MMSaveLoadTestScene to test the MMSaveLoadManager class
    /// </summary>
    public class MMSaveLoadTester : MMPersistentSingleton<MMSaveLoadTester>
    {
        [Header("Saved object")]
        /// a test object containing a list of strings to save and load
        public MMSaveLoadSaveObject SaveObject;

        [Header("Save settings")]
        /// the chosen save method (json, encrypted json, binary, encrypted binary)
        public MMSaveLoadManagerMethods SaveLoadMethod = MMSaveLoadManagerMethods.Binary;
        /// the name of the file to save
        public string FileName = "SaveObject";
        /// the name of the destination folder
        public string FolderName = "MMTest/";
        /// the extension to use
        public string SaveFileExtension = ".testObject";
        /// the key to use to encrypt the file (if needed)
        public string EncryptionKey = "ThisIsTheKey";

        /// Test button
        [MMInspectorButton("Save")]
        public bool TestSaveButton;
        /// Test button
        [MMInspectorButton("Load")]
        public bool TestLoadButton;
        /// Test button
        [MMInspectorButton("Reset")]
        public bool TestResetButton;

        public int saveIndex;

        protected IMMSaveLoadManagerMethod _saveLoadManagerMethod;

        protected override void Awake () {
            base.Awake();
            // Load();
        }

        /// <summary>
        /// Saves the contents of the saveObject into a file
        /// </summary>
        public virtual void Save()
        {
            InitializeSaveLoadMethod();
            MMSaveLoadManager.Save(SaveObject, FileName+saveIndex+SaveFileExtension, FolderName);
        }

        /// <summary>
        /// Loads the saved data
        /// </summary>
        public virtual void Load()
        {
            InitializeSaveLoadMethod();
            SaveObject = (MMSaveLoadSaveObject)MMSaveLoadManager.Load(typeof(MMSaveLoadSaveObject), FileName+saveIndex+SaveFileExtension, FolderName);
        }

        /// <summary>
        /// Resets all saves by deleting the whole folder
        /// </summary>
        protected virtual void Reset()
        {
            MMSaveLoadManager.DeleteSaveFolder(FolderName);
        }

        /// <summary>
        /// Creates a new MMSaveLoadManagerMethod and passes it to the MMSaveLoadManager
        /// </summary>
        protected virtual void InitializeSaveLoadMethod()
        {
            switch(SaveLoadMethod)
            {
                case MMSaveLoadManagerMethods.Binary:
                    _saveLoadManagerMethod = new MMSaveLoadManagerMethodBinary();
                    break;
                case MMSaveLoadManagerMethods.BinaryEncrypted:
                    _saveLoadManagerMethod = new MMSaveLoadManagerMethodBinaryEncrypted();
                    (_saveLoadManagerMethod as MMSaveLoadManagerEncrypter).Key = EncryptionKey;
                    break;
                case MMSaveLoadManagerMethods.Json:
                    _saveLoadManagerMethod = new MMSaveLoadManagerMethodJson();
                    break;
                case MMSaveLoadManagerMethods.JsonEncrypted:
                    _saveLoadManagerMethod = new MMSaveLoadManagerMethodJsonEncrypted();
                    (_saveLoadManagerMethod as MMSaveLoadManagerEncrypter).Key = EncryptionKey;
                    break;
            }
            MMSaveLoadManager.saveLoadMethod = _saveLoadManagerMethod;
        }
    }
}
