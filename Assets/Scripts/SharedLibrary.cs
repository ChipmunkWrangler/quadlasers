using System.Collections.Generic;
using UnityEngine;

public struct SharedLibrary
{
	public static void InformSubscribers(IEnumerable<GameObject> subscribers, string msgName, object param = null) {
		foreach (var subscriber in subscribers) {
			subscriber.SendMessage (msgName, param);
		}
	}
}