using UnityEngine;
using System;

public class ReSkinAnimation : MonoBehaviour 
{
	void OnEnable()
	{
		EventManager.Instance.RegistriereEventListener ("AUSSEHEN", AussehenListener); //das ist delegate so kann man das machen
	}

	void OnDisable()
	{
		EventManager.Instance.EntferneEventListener ("AUSSEHEN", AussehenListener); 
	}

	public string spriteGruppe;

	void LateUpdate () {

		var subSprites = Resources.LoadAll<Sprite>("Sprites/Sammlung/" + spriteGruppe);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
			var newSprite = Array.Find(subSprites, item => item.name == spriteName);

			if (newSprite)
				renderer.sprite = newSprite;
		}
	}

	void AussehenListener(string eventName, string parameter = "")
	{
		if (eventName == "Wechsel") {
			spriteGruppe = parameter;
		}
	}
}
