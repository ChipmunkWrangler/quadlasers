using UnityEngine;

namespace AssemblyCSharp
{
	public struct SharedLibrary
	{
		static public void InformSubscribers(GameObject[] subscribers, string msgName, object param = null) {
			foreach (GameObject subscriber in subscribers) {
				subscriber.SendMessage (msgName, param);
			}
		}
	}

}

