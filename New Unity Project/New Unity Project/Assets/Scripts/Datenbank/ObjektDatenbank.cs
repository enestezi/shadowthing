using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class ObjektDatenbank : MonoBehaviour 
{
	public struct Objekti
	{
		public string objTitel;
		public string objBeschreibung;
		public Sprite objIcon;
	}
	Objekti obj;

	public void LadeXML()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Objekt));
		using(var stream = new FileStream(Application.dataPath + "/Resources/Datenbank/TWS_SPF.xml", FileMode.Open))
		{
			Objekt objekt = (Objekt)serializer.Deserialize(stream) ;
			obj.objTitel = objekt.signatur;
		}

	}

	void Start()
	{
		LadeXML ();
		Debug.Log (obj.objTitel);
	}
//[XmlRoot("lidoWrap")]
//	public class ObjektContainer 
//	{
//
//		[XmlArray("lidoWrap")]
//		[XmlArrayItem("lido:lido")]
//		public List<Objekt> objekte = new List<Objekt>();
//
//		public static ObjektContainer Laden()
//		{
//			TextAsset _xml = Resources.Load<TextAsset>("Datenbank/TWS_SPF");
//
//			XmlSerializer serializer = new XmlSerializer(typeof(ObjektContainer));
//
//			StringReader reader = new StringReader(_xml.text);
//
//			ObjektContainer objekte = serializer.Deserialize(reader) as ObjektContainer;
//
//			reader.Close();
//
//			return objekte;
//		}
//	}

	

}

