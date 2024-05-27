using UnityEngine;
using System.Runtime.InteropServices;

public class Link : MonoBehaviour
{
	public void OpenLinkJSPlugin()
	{
#if !UNITY_EDITOR
		openWindow("https://yandex.ru/games/developer?name=Ramzi_Games");
#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}