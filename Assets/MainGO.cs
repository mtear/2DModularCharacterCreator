using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainGO : MonoBehaviour {

	public Button btnanimations, btnskincolor, btnnoses, btneyes, btndetail,
		btnhair, btnbrow, btnmouth, btnshirt, btnpants, btnhelm;

	int anim_index = 0, skin_index=0, nose_index=0, eye_index=0, detail_index=0, hair_index=0, brow_index=0, mouth_index=0,
		shirt_index=0, pants_index=0, helm_index=0;

	public GameObject gamecharacter, gamecharactermini;

	Animator animator, animatormini;

	string[] statenames = {"Idle", "Walking", "Punching"};
	string[] skinnames = {"Light Skin", "Tan 1 Skin", "Dark Skin"};
	string[] nosenames = { "No Nose", "Small Nose 1", "Wide Nose", "Big Nose", "Pig Nose", "Small Nose 2", "Reptile Nose", "Manga Nose", "Round Nose" };
	string[] eyenames = { "Manga Eye Blue", "Manga Eye Brown", "Manga Eye Green", "Dot Eyes", "Cat Eyes", "Cartoon Eyes", "FG Eyes", "Luffy Eyes", "Goku Eyes" };
	string[] detailnames = { "No Detail", "Soul Patch", "Cheek Scar", "Gold Earring", "Rose Cheeks", "Eye Patch", "Moustache", "Beard", "Glasses" };
	string[] hairnames = {
		"No Hair",
		"Ponytail Brown",
		"Ponytail Blond",
		"Ponytail Black",
		"Ponytail White",
		"Hero Hair Brown",
		"Hero Hair Blond",
		"Hero Hair Black",
		"Hero Hair White",
		"Short Hair Brown",
		"Short Hair Blond",
		"Short Hair Black",
		"Short Hair White",
		"Soul Hair Brown",
		"Soul Hair Blond",
		"Soul Hair Black",
		"Soul Hair White",
		"Pirate Hair Brown",
		"Pirate Hair Blond",
		"Pirate Hair Black",
		"Pirate Hair White"
	};
	string[] brownames = { "Regular Brows", "Thick Regular Brows", "Aged Brows", "Sad Brows", "Thin Brows", "Raised Brows", "Stick Brows" };
	string[] mouthnames = {"Basic Mouth", "Happy Mouth", "Fearful Mouth", "Anxious Mouth", "Grinning Mouth", "Puckered Mouth", "Big Snile Mouth", "Big Grin Mouth"};
	string[] shirtnames = { "No Shirt", "Rebel Shirt", "Bounty Hunter Shirt"};
	string[] pantnames = { "No Pants", "Rebel Pants"};
	string[] helmnames = { "No Helm", "Shogun Helm", "Bounty Hunter Helm" };

	string[] skinids = {"male_skin1", "male_skin2", "male_skin4"};
	string[] noseids = {"nose2", "nose1", "nose3", "nose4", "nose5", "nose6", "nose7", "nose8", "nose9"};
	string[] eyeids = {"eye1_blue", "eye1_brown", "eye1_green", "eye2", "eye3", "eye4", "eye5", "eye6", "eye7"};
	string[] detailids = {"detail2", "detail1_black", "detail3", "detail4", "detail5", "detail6", "detail7", "detail8", "detail9"};
	string[] hairids = {"hair2", "hair1_brown", "hair1_blond", "hair1_black", "hair1_white", "hair3_brown", "hair3_blond", 
		"hair3_black", "hair3_white", "hair4_brown", "hair4_blond", "hair4_black", "hair4_white", "hair5_brown", "hair5_blond", "hair5_black", "hair5_white",
		"hair6_brown", "hair6_blond", "hair6_black", "hair6_white"};
	string[] browids = {"brow1_black", "brow2", "brow3", "brow4", "brow5", "brow6", "brow7"};
	string[] mouthids = {"mouth1", "mouth2", "mouth3", "mouth4", "mouth5", "mouth6", "mouth7", "mouth8"};
	string[] shirtids = {"shirt2", "shirt1", "shirt3"};
	string[] pantids = {"pants2", "pants1"};
	string[] helmids = { "helm2", "helm1", "helm3"};

	Text animationtext, skintext, nosetext, eyetext, detailtext, hairtext, browtext, mouthtext, shirttext, pantstext, helmtext;

	// Use this for initialization
	void Start () {
		animator = gamecharacter.GetComponent<Animator> ();
		animatormini = gamecharactermini.GetComponent<Animator> ();

		animationtext = btnanimations.GetComponentInChildren<Text> ();
		animationtext.text = "Idle";

		nosetext = btnnoses.GetComponentInChildren<Text> ();
		skintext = btnskincolor.GetComponentInChildren<Text> ();
		eyetext = btneyes.GetComponentInChildren<Text> ();
		detailtext = btndetail.GetComponentInChildren<Text> ();
		hairtext = btnhair.GetComponentInChildren<Text> ();
		browtext = btnbrow.GetComponentInChildren<Text> ();
		mouthtext = btnmouth.GetComponentInChildren<Text> ();
		shirttext = btnshirt.GetComponentInChildren<Text> ();
		pantstext = btnpants.GetComponentInChildren<Text> ();
		helmtext = btnhelm.GetComponentInChildren<Text> ();

		ChangeSkinColor (gamecharacter, skinids[skin_index]);
		ChangeSkinColor (gamecharactermini, skinids[skin_index]);
		UpdateButtonLabels ();
	}

	void UpdateButtonLabels(){
		nosetext.text = nosenames[nose_index];
		skintext.text = skinnames[skin_index];
		eyetext.text = eyenames[eye_index];
		detailtext.text = detailnames[detail_index];
		hairtext.text = hairnames[hair_index];
		browtext.text = brownames[brow_index];
		mouthtext.text = mouthnames[mouth_index];
		shirttext.text = shirtnames[shirt_index];
		pantstext.text = pantnames[pants_index];
		helmtext.text = helmnames[helm_index];
	}

	void ChangeSkinColor(GameObject gameobject, string skin){
		var subSprites = Resources.LoadAll<Sprite> (skin);
		
		foreach (var renderer in gameobject.GetComponentsInChildren<Image>()) {
			if(renderer.sprite == null) continue;
			string spriteName = renderer.sprite.name;
			var newSprite = Array.Find(subSprites, item => item.name == spriteName);
			if(newSprite){
				renderer.sprite = newSprite;
				float w = newSprite.bounds.size.x * 100;
				float h = newSprite.bounds.size.y * 100;
				float px = newSprite.pivot.x;
				float py = newSprite.pivot.y;
				float npx = px/w;
				float npy = py/h;
				renderer.rectTransform.sizeDelta = new Vector2 (w, h);
				renderer.GetComponent<RectTransform>().pivot = new Vector2(npx, npy);
			}
		}

		if (gameobject != gamecharactermini)
			ChangeSkinColor (gamecharactermini, skin);
	}

	public void btnanimations_click(){
		anim_index++;
		if (anim_index == statenames.Length)
			anim_index = 0;
		animator.SetTrigger (anim_index.ToString ());
		animatormini.SetTrigger (anim_index.ToString ());
		animationtext.text = statenames [anim_index];
	}

	public void btnskincolors_click(){
		skin_index++;
		if (skin_index == skinnames.Length) {
			skin_index = 0;
		}
		ChangeSkinColor (gamecharacter, skinids[skin_index]);
		skintext.text = skinnames [skin_index];
	}

	public void btnnose_click(){
		nose_index++;
		if (nose_index == noseids.Length) {
			nose_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + noseids [nose_index]);
		nosetext.text = nosenames [nose_index];
	}

	public void btneyes_click(){
		eye_index++;
		if (eye_index == eyeids.Length) {
			eye_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + eyeids [eye_index]);
		eyetext.text = eyenames [eye_index];
	}

	public void btndetail_click(){
		detail_index++;
		if (detail_index == detailids.Length) {
			detail_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + detailids [detail_index]);
		detailtext.text = detailnames [detail_index];
	}

	public void btnhair_click(){
		hair_index++;
		if (hair_index == hairids.Length) {
			hair_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + hairids [hair_index]);
		hairtext.text = hairnames [hair_index];
	}

	public void btnbrow_click(){
		brow_index++;
		if (brow_index == browids.Length) {
			brow_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + browids [brow_index]);
		browtext.text = brownames [brow_index];
	}

	public void btnmouth_click(){
		mouth_index++;
		if (mouth_index == mouthids.Length) {
			mouth_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + mouthids [mouth_index]);
		mouthtext.text = mouthnames [mouth_index];
	}

	public void btnshirt_click(){
		shirt_index++;
		if (shirt_index == shirtids.Length) {
			shirt_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + shirtids [shirt_index]);
		shirttext.text = shirtnames [shirt_index];
	}

	public void btnpants_click(){
		pants_index++;
		if (pants_index == pantids.Length) {
			pants_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + pantids [pants_index]);
		pantstext.text = pantnames [pants_index];
	}

	public void btnhelm_click(){
		helm_index++;
		if (helm_index == helmids.Length) {
			helm_index = 0;
		}
		ChangeSkinColor (gamecharacter, "male_" + helmids [helm_index]);
		helmtext.text = helmnames [helm_index];
	}

	public void randomize_click(){
		System.Random r = new System.Random ();

		skin_index = r.Next (skinids.Length);
		ChangeSkinColor(gamecharacter, skinids[skin_index]);
		nose_index = r.Next (noseids.Length);
		ChangeSkinColor(gamecharacter, "male_" + noseids[nose_index]);
		eye_index = r.Next (eyeids.Length);
		ChangeSkinColor(gamecharacter, "male_" + eyeids[eye_index]);
		detail_index = r.Next (detailids.Length);
		ChangeSkinColor(gamecharacter, "male_" + detailids[detail_index]);
		hair_index = r.Next (hairids.Length);
		ChangeSkinColor(gamecharacter, "male_" + hairids[hair_index]);
		brow_index = r.Next (browids.Length);
		ChangeSkinColor(gamecharacter, "male_" + browids[brow_index]);
		mouth_index = r.Next (mouthids.Length);
		ChangeSkinColor(gamecharacter, "male_" + mouthids[mouth_index]);
		/*shirt_index = r.Next (shirtids.Length);
		ChangeSkinColor(gamecharacter, "male_" + shirtids[shirt_index]);
		pants_index = r.Next (pantids.Length);
		ChangeSkinColor(gamecharacter, "male_" + pantids[pants_index]);
		helm_index = r.Next (helmids.Length);
		ChangeSkinColor(gamecharacter, "male_" + helmids[helm_index]);*/

		UpdateButtonLabels ();
	}
}
