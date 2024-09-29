using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Translation
{
    [CreateAssetMenu(menuName = "Translation/LanguageOption")]
    public class TranslationLanguageOption : ScriptableObject
    {
        [SerializeField]
        private string[] options; 

        public string[] Options { get { return (string[])options.Clone(); } }

        public bool IsLanguageInTheList(string language) 
            => options.Contains(language);
    }
}