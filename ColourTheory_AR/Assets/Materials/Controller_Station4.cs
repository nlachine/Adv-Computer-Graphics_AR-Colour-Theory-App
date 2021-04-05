	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine.UI;

	public class Controller_Station4 : MonoBehaviour
	{
	 
		//---- Utility Scripts ----//
		[Header("Utility Scripts")]
		MaterialAnimations _materialAnimator;

		int currentStep = 1;    
		public GameObject gameUI;
		public GameObject spheres;
		public GameObject ambspheres;
		public GameObject ambspheres2;
		public GameObject difspheres;
		public GameObject difspheres2;
		public GameObject specspheres;
		public GameObject specspheres2;
		public GameObject allspheres;
		public GameObject allspheres2;
		public Material matamb1 ;
		public Material matamb2 ;
		public Material matdif1 ;
		public Material matdif2 ;
		public Material matspec1 ;
		public Material matspec2 ;
		public Material matall1 ;
		public Material matall2 ;

		public Canvas Station4_UI;
		public Slider ambSliderGame;
		public Slider difSliderGame;
		public Slider specSliderGame;
		public Slider ambSlider;
		public Slider difSlider;
		public Slider specSlider;
		public Button startButton;
		public Button nextButton;
		public Button prevButton;
		public GameObject headerTextBackground;
		public Text headerText;

		public Text hueDescription;
		public Text saturationDescription;
		public Text valueDescription;
		public Text tintDescription;
		public Text toneDescription;
		public Text shadeDescription;
		public GameObject StartUI;
		public GameObject textBackground;
		public GameObject CompleteUI;

		
		// Start is called before the first frame update
		void Start()
		{

			matamb1 = ambspheres.GetComponent<MeshRenderer>().material;
			matamb2 = ambspheres2.GetComponent<MeshRenderer>().material;
			matdif1 = difspheres.GetComponent<MeshRenderer>().material;
			matdif2 = difspheres2.GetComponent<MeshRenderer>().material;
			matspec1 = specspheres.GetComponent<MeshRenderer>().material;
			matspec2 = specspheres2.GetComponent<MeshRenderer>().material;
			matall1 = allspheres.GetComponent<MeshRenderer>().material;
			matall2 = allspheres2.GetComponent<MeshRenderer>().material;
			//getShader(rend.material.shader);
			
			//---- Get Utility Scripts ----//
			_materialAnimator = this.GetComponent<MaterialAnimations>();
		 

			//---- Set Default Parameters ----//
			setDefaults();

		}

		public void changeStep(bool increment)
		{

			if (increment)
			{
				currentStep++;
			}
			else
			{
				currentStep--;
			}

			switch (currentStep)
			{
				case 1: //Amb Example 
					HueStep();
					break;
				case 2: //Diff Example 
					SaturationStep();
					break;
				case 3: //Spec Example 
					ValueStep();
					break;
				case 4: //Instructions 
					TintStep();
					break;
				case 5: //Game
					GameStep();
					break;
				
			  
				default: //Otherwise
					break;
			}
		}

		void setDefaults()
		{
			currentStep = 1;
			ambspheres2.gameObject.SetActive(false);
			ambspheres.gameObject.SetActive(false);
			difspheres2.gameObject.SetActive(false);
			difspheres.gameObject.SetActive(false);
			specspheres2.gameObject.SetActive(false);
			specspheres.gameObject.SetActive(false);
			allspheres2.gameObject.SetActive(false);
			allspheres.gameObject.SetActive(false);
			
			StartUI.gameObject.SetActive(true);

			startButton.gameObject.SetActive(true);
			nextButton.gameObject.SetActive(false);
			prevButton.gameObject.SetActive(false);
			ambSlider.gameObject.SetActive(false);
			difSlider.gameObject.SetActive(false);
			specSlider.gameObject.SetActive(false);
			ambSliderGame.gameObject.SetActive(false);
			difSliderGame.gameObject.SetActive(false);
			specSliderGame.gameObject.SetActive(false);

			headerTextBackground.SetActive(false);
			textBackground.gameObject.SetActive(false);
			hueDescription.gameObject.SetActive(false); 
			saturationDescription.gameObject.SetActive(false);
			valueDescription.gameObject.SetActive(false);
			tintDescription.gameObject.SetActive(false);
			toneDescription.gameObject.SetActive(false);
			shadeDescription.gameObject.SetActive(false);
			//spheres.gameObject.SetActive(false);
			matall1.SetColor("_SpecColor",Color.red);
			matall1.SetColor("_DifColor",Color.blue);
			matall1.SetColor("_AmbColor",Color.white);
			
			matall2.SetColor("_SpecColor",Color.yellow);
			matall2.SetColor("_DifColor",Color.green);
			matall2.SetColor("_AmbColor",Color.white);
			
			matspec2.SetColor("_Color",Color.white);
			matamb1.SetColor("_AmbColor",Color.yellow);
			matdif1.SetColor("_Color",Color.yellow);
			matdif2.SetColor("_Color",Color.blue);
			matamb2.SetColor("_AmbColor",Color.blue);
			matspec1.SetColor("_Color",Color.white);
			matdif1.SetColor("_Color",Color.yellow); 
			matdif2.SetColor("_Color",Color.blue);
			matspec2.SetColor("_SpecColor",Color.blue);
			matspec1.SetColor("_SpecColor",Color.yellow);
			matdif1.SetColor("_Color",Color.yellow);
			matdif2.SetColor("_Color",Color.blue);
			CompleteUI.gameObject.SetActive(false);
		}



		public void HueStep()
		{
			ambSlider.gameObject.SetActive(true);

			StartUI.gameObject.SetActive(false);
			ambSliderGame.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(true);
			headerText.text = "HUE";
			ambspheres.gameObject.SetActive(true);
			ambspheres2.gameObject.SetActive(true);

			
			headerTextBackground.SetActive(true);
			textBackground.gameObject.SetActive(true);
			hueDescription.gameObject.SetActive(true);
			saturationDescription.gameObject.SetActive(false);
			valueDescription.gameObject.SetActive(false);
			tintDescription.gameObject.SetActive(false);
			toneDescription.gameObject.SetActive(false);
			shadeDescription.gameObject.SetActive(false);

			CompleteUI.gameObject.SetActive(false);
		}
		public void SaturationStep()
		{
			ambSlider.value = (0.0f);
			//ambSlider.gameObject.SetActive(false);
			difSlider.gameObject.SetActive(true);
			ambspheres.gameObject.SetActive(false);
			ambspheres2.gameObject.SetActive(false);
			ambSliderGame.gameObject.SetActive(false);
			difspheres2.gameObject.SetActive(true);
			difspheres.gameObject.SetActive(true);
			StartUI.gameObject.SetActive(false);
			difSliderGame.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(true);
			prevButton.gameObject.SetActive(true);
			headerText.text = "SATURATION";

			headerTextBackground.SetActive(true);
			textBackground.gameObject.SetActive(true);
			hueDescription.gameObject.SetActive(false);
			saturationDescription.gameObject.SetActive(true);
			valueDescription.gameObject.SetActive(false);
			tintDescription.gameObject.SetActive(false);
			toneDescription.gameObject.SetActive(false);
			shadeDescription.gameObject.SetActive(false);

			CompleteUI.gameObject.SetActive(false);
		}
		public void ValueStep()
		{
			difSlider.value = (0.0f);
			ambSlider.value = (0.0f);
			ambSlider.gameObject.SetActive(false);
			difSlider.gameObject.SetActive(false);
			specSlider.gameObject.SetActive(true);
			specspheres2.gameObject.SetActive(true);
			specspheres.gameObject.SetActive(true);
			difspheres2.gameObject.SetActive(false);
			difspheres.gameObject.SetActive(false);
			StartUI.gameObject.SetActive(false);
			specSliderGame.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(true);
			headerText.text = "VALUE"; 

			headerTextBackground.SetActive(true);
			textBackground.gameObject.SetActive(true);
			hueDescription.gameObject.SetActive(false);
			saturationDescription.gameObject.SetActive(false);
			valueDescription.gameObject.SetActive(true);
			tintDescription.gameObject.SetActive(false);
			toneDescription.gameObject.SetActive(false);
			shadeDescription.gameObject.SetActive(false);

			CompleteUI.gameObject.SetActive(false);
		}




		public void GameStep()
		{

			allspheres2.gameObject.SetActive(true);
			allspheres.gameObject.SetActive(true);
			Station4_UI.gameObject.SetActive(false);
			ambSliderGame.gameObject.SetActive(true);
			difSliderGame.gameObject.SetActive(true);
			specSliderGame.gameObject.SetActive(true);
			gameUI.gameObject.SetActive(true);
			prevButton.gameObject.SetActive(true);
		}
		public void TintStep()
		{
			specSlider.gameObject.SetActive(false);
			difSlider.gameObject.SetActive(false);
			StartUI.gameObject.SetActive(false);
			specspheres2.gameObject.SetActive(false);
			specspheres.gameObject.SetActive(false);
			startButton.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(true);
			headerText.text = "TINT";
			specSliderGame.gameObject.SetActive(false);

			headerTextBackground.SetActive(true);
			textBackground.gameObject.SetActive(true);
			hueDescription.gameObject.SetActive(false);
			saturationDescription.gameObject.SetActive(false);
			valueDescription.gameObject.SetActive(false);
			tintDescription.gameObject.SetActive(true);
			toneDescription.gameObject.SetActive(false);
			shadeDescription.gameObject.SetActive(false);

			CompleteUI.gameObject.SetActive(false);
		}

		public void OnSliderChange1()
		{
			matamb2.SetFloat("_Ambient", ambSlider.value);
			matamb1.SetFloat("_Ambient", ambSlider.value);


			if(currentStep == 2){
				
				matdif2.SetFloat("_Diffuse", ambSlider.value);

				matdif1.SetFloat("_Diffuse", ambSlider.value);
			}

		}

		
		
		public void OnSliderChange2()
		{
		if(currentStep == 2){

				matdif2.SetFloat("_Metallic", difSlider.value);
				
				matdif1.SetFloat("_Metallic", difSlider.value);
		}
		}
		
		public void OnSliderChange3()
		{
		if(currentStep == 3){

				matspec2.SetFloat("_Shininess", specSlider.value);
				matspec1.SetFloat("_Shininess", specSlider.value);
		}
		}
		
		
		public void OnSliderChangeAmb()
		{

			matall1.SetFloat("_Ambient", ambSliderGame.value);
			matall2.SetFloat("_Ambient", ambSliderGame.value);
			
		}

		public void OnSliderChangeDif()
		{

				matall1.SetFloat("_Diffuse", difSliderGame.value);
				matall2.SetFloat("_Diffuse", difSliderGame.value);
			

			//Debug.Log(ambSliderGame.value);

		}
			public void OnSliderChangeSpec()
		{
			
				matall1.SetFloat("_Shininess", specSliderGame.value);
				matall2.SetFloat("_Shininess", specSliderGame.value);
			
			


		}

		void Update()
		{
			// need to somehow update the material and replace teh material that is in teh scene 
		//	rend.material.SetFloat("_Ambient", ambSliderGame.value);
		//	Debug.Log(rend.material.GetFloat("_Ambient"));

		}
	}
