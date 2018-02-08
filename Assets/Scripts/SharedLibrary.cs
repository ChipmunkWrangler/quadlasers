using UnityEngine;
using System;
using System.Collections.Generic;

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

