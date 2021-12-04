﻿using Locallies.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Static class used to manage translations anywhere
 * Responsible for loading files and returning translations
*/

namespace Locallies.Core {
    public static class LocalizationManager {
        // triggers localization on all elements at scene
        public static event Action<bool> MassLocalizationEvent = delegate { };

        // localized data
        private static Dictionary<string, string> textDictionary;
        private static Dictionary<string, Sprite> sheetDictionary;
        private static string missingKey = "Localized string not found!";
        private static string missingSprite;

        // loads data from Localization File
        public static void LoadLanguage(Language language) {
            // loads data from file
            LanguageText languageText = new LanguageText();
            LanguageSheet languageSheet = new LanguageSheet();

            bool success = LanguageParser.ReadLanguage(language, out languageText, out languageSheet);

            if (success) {
                // creates and populates dictionary
                if (languageText != null) {
                    textDictionary = new Dictionary<string, string>();
                    foreach (LanguageString item in languageText.items) {
                        textDictionary.Add(item.key, item.value);
                    }

                    Debug.Log("Text loaded! Dictionary contains " + textDictionary.Count + " lines!");
                }

                if (languageSheet != null) {
                    sheetDictionary = new Dictionary<string, Sprite>();
                    foreach (LanguageSprite item in languageSheet.items) {
                        sheetDictionary.Add(item.key, item.value);
                    }

                    Debug.Log("Sheet loaded! Dictionary contains " + sheetDictionary.Count + " sprites!");
                }

                // mass localization
                MassLocalize();
            }
            else {
                // error debug
                Debug.LogError("Cannot find Localization File!!");
            }
        }

        // localizes all elements listening to event
        public static void MassLocalize() {
            MassLocalizationEvent(true);
        }

        // gets value from dictionary or returns missing key message
        public static string LocalizeString(string key) {
            // loads Default Language if no dictionary
            if (textDictionary == null) {
                LoadLanguage(DefaultLanguage.instance.Language);
            }

            textDictionary.TryGetValue(key, out string result);
            result = String.IsNullOrEmpty(result) ? missingKey : result;

            return result;
        }

        public static Sprite LocalizeSprite(string key) {
            // loads Default Language File if no dictionary
            if (sheetDictionary == null) {
                LoadLanguage(DefaultLanguage.instance.Language);
            }

            sheetDictionary.TryGetValue(key, out Sprite result);
            if (result == null) {
                sheetDictionary.TryGetValue(missingSprite, out result);
            }

            return result;
        }
    }
}