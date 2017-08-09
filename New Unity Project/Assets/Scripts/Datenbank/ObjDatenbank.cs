using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class ObjektDatenbank 
{
	private static ObjektDatenbank instance;
	public static ObjektDatenbank Instance
	{
		get {
			if (instance == null)
				instance = new ObjektDatenbank ();
			return instance;
		}
	}


	public List <LidoObjekt> objekte = new List<LidoObjekt>();
	public int lidoObjAnzahl = 0;

	private LidoWrap xmlObj = null;

	public ObjektDatenbank ()
	{
		// die funktionen werden nur einmal gerufen. dadurch wird es verhindert dass die listen jedes szenenwechsel die liste neu füllt,bzw. gleiche objekte nochmal addiert
		LadeData ();
		ErzeugeObjDatenbak ();
	}

    public void LadeData ()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(LidoWrap));
		using(var stream = new FileStream(Application.dataPath + "/Resources/Datenbank/TWS_SPF.xml", FileMode.Open))
		{
			xmlObj = (LidoWrap)serializer.Deserialize(stream) ;
		}
			
		lidoObjAnzahl = xmlObj.Lido.Count;
	}

	public void ErzeugeObjDatenbak ()
	{
		// nur die nötige Elemente von LidoXML zum simple struct übertragen
		for (int i = 0; i < lidoObjAnzahl; i++) 
		{
			objekte.Add(new LidoObjekt(xmlObj.Lido [i].LidoRecID.Text, 
				xmlObj.Lido [i].DescriptiveMetadata.ObjectIdentificationWrap.TitleWrap.TitleSet.AppellationValue.Text,
				xmlObj.Lido [i].DescriptiveMetadata.ObjectIdentificationWrap.ObjectDescriptionWrap.ObjectDescriptionSet.DescriptiveNoteValue,
				xmlObj.Lido [i].DescriptiveMetadata.ObjectRelationWrap.SubjectWrap.SubjectSet.DisplaySubject,
				xmlObj.Lido [i].DescriptiveMetadata.EventWrap.EventSet [2].DisplayEvent));
		}
	}
}

public class LidoObjekt
{
	public string Signatur { get; set;}
	public string Titel { get; set;}
	public string Beschreibung { get; set;}
	public string InhBeschreibung { get; set;}
	public string ProvBeschreibung { get; set;}
	public Sprite Icon { get; set;}
	public GameObject PrefFigur { get; set;}

	public LidoObjekt(string signatur, string titel, string beschreibung, string inhBeschreibung, string provBeschreibung)
	{
		this.Signatur = signatur;
		this.Titel = titel;
		this.Beschreibung = beschreibung;
		this.InhBeschreibung = inhBeschreibung;
		this.ProvBeschreibung = provBeschreibung;
		this.Icon = Resources.Load<Sprite> ("Sprites/Thumbnails/" + signatur);
		this.PrefFigur = Resources.Load<GameObject> ("Prefab/Interaktiv/" + signatur);
	}
}