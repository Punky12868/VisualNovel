using PixelCrushers.DialogueSystem.VisualNovelFramework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class QuickSaveAndLoad : MonoBehaviour
{
	[System.Serializable]
	public class StringEvent : UnityEngine.Events.UnityEvent<string> { }

	public StringEvent onSetDetails = new StringEvent();

	public UnityEngine.Events.UnityEvent onLoadGame = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent onSaveGame = new UnityEngine.Events.UnityEvent();

	[HideInInspector] public int currentSlotNum = -1;
	[HideInInspector] public int quickSaveSlot = 0;

	public SaveHelper saveHelper;
	public SaveGamePanel saveGamePanel;

	//----------------LOAD-----------------
	public void SelectLoadSlot(int slotNum)
	{
		quickSaveSlot = slotNum;
		saveHelper.currentSlotNum = slotNum;
		LoadCurrentSlot();
	}
	private void LoadCurrentSlot()
	{
		StartCoroutine(LoadCoroutine());
	}
	private IEnumerator LoadCoroutine()
	{
		if (Debug.isDebugBuild) Debug.Log("Dialogue System Menus: Loading game in slot " + quickSaveSlot);
		yield return null;
		onLoadGame.Invoke();
	}
	public void LoadCurrentSlotNow()
	{
		saveHelper.LoadGame(quickSaveSlot);
	}
	public void LoadCurrentSlotNowCustom(int i)
	{
		quickSaveSlot = i;
		saveHelper.currentSlotNum = i;
		saveHelper.LoadGame(i);
	}
	//----------------SAVE-----------------

	public void SelectSaveSlot(int slotNum)
	{
		quickSaveSlot = slotNum;
		FindObjectOfType<TakeAndDisplayScreenshot>().TakePhotoOnSave(slotNum - 1);
		ConfirmSave();
	}

	private void ConfirmSave()
	{
		StartCoroutine(SaveCoroutine());
	}

	private IEnumerator SaveCoroutine()
	{
		if (Debug.isDebugBuild) Debug.Log("Dialogue System Menus: Saving game in slot " + quickSaveSlot);
		yield return null;
		onSaveGame.Invoke();
		saveHelper.SaveGame(quickSaveSlot);
	}
}
