using StdNounou.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeApprentice
{
	[RequireComponent(typeof(Button))]
	public class UISceneLoader : MonoBehaviour
	{
		[SerializeField] private Button button;
        [SerializeField] private List<string> scenesToLoad;

        private void Reset()
        {
            button = this.GetComponent<Button>();
        }

        private void Awake()
        {
            button.onClick.AddListener(LoadScenes);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(LoadScenes);
        }

        private void LoadScenes()
        {
            ScenesHandler.Instance.LoadSceneAsync(scenesToLoad);
        }
    } 
}