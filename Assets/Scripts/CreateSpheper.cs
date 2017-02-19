using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSpheper : MonoBehaviour 
{
	public int maxNumberSpheper;
	public Text numberText;
	public Scrollbar scrollbar;

	public GameObject spheper;
	public int numberSpheres;

	public float y;
	public float xMax;
	public float xMin;

	public GameObject roof;

	private GameObject[] _sphepers;
	private Rigidbody[] _rbSphepers;
	private int activeSphepers;

	void Start () 
	{
		_sphepers = new GameObject[maxNumberSpheper];
		_rbSphepers = new Rigidbody[maxNumberSpheper];

		for(int i = 0; i < maxNumberSpheper; i++)
		{
			_sphepers[i] = Instantiate(spheper);
			_rbSphepers[i] = _sphepers[i].GetComponent<Rigidbody>();
			_sphepers[i].SetActive(false);
		}

		numberSpheres = (int)(maxNumberSpheper * scrollbar.value);
	}
	
	void Update () 
	{
		numberText.text = numberSpheres.ToString();
	}

	public void ChangeNumberSpheper()
	{
		numberSpheres = (int)(maxNumberSpheper * scrollbar.value);

		if (activeSphepers < numberSpheres)
		{
			for(int i = activeSphepers; i < numberSpheres; i++)
			{
				_sphepers[i].SetActive(true);
				_rbSphepers[i].MovePosition(new Vector3(Random.Range(xMin, xMax), Random.Range(y, y*3), 0));
			}
		}
		else
		{
			for(int i = numberSpheres; i < activeSphepers; i++)
			{
				_sphepers[i].SetActive(false);
			}
		}

		activeSphepers = numberSpheres;
	}

	public void Activate()
	{
		roof.SetActive(false);
	}

	public void Reset()
	{
		roof.SetActive(true);
		for(int i = 0; i < activeSphepers; i++)
		{
			_rbSphepers[i].MovePosition(new Vector3(Random.Range(xMin, xMax), Random.Range(y, y*3), 0));
		}
	}
}
