using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Serelezation2
{
	[Serializable]
	public class Program
	{		

		static void Main(string[] args)
		{
			var Group = new string[10];

			for (int i = 0; i < 10; i++)
			{
				Group[i] = "Group: " + i.ToString();
			}

			var XmlFormatter = new XmlSerializer(typeof(string[]));
			using (var file = new FileStream("Group.xml", FileMode.OpenOrCreate))
			{
				XmlFormatter.Serialize(file, Group);
			}
			using (var file = new FileStream("Group.xml", FileMode.OpenOrCreate))
			{
				var NewGroup = XmlFormatter.Deserialize(file) as string[]; 
			}
			foreach(string item in Group)
			{
				Console.WriteLine(item);
			}
		}
	}
}
