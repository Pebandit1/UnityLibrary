using System.Collections.Generic;
using UnityEngine;

namespace Translation
{
    [CreateAssetMenu(menuName = "Translation/Text")]
    public class TranslatedTextScriptableObject : ScriptableObject
    {
        [SerializeField]
        TranslationLanguageOption languageOption;

        [SerializeField]
        Dictionary<string, string> dic;

        private void OnValidate()
        {
            
        }
    }
}
