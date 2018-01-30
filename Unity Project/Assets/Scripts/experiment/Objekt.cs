using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
[XmlRoot("lidoWrap")]
public class Objekt 
{
	[XmlElement("lido:lidoRecID")]
	public string signatur;

	[XmlElement("lido:appellationValue")]
	public string titel;

	[XmlElement("lido:measurementValue")]
	public string masse;

	[XmlElement("lido:descriptiveNoteValue")]
	public string objektBeschreibung;
}
