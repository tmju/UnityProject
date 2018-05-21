﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ItemMakerCreater : MonoBehaviour { //Itemmakerとレフトカウントを作成するクラス
	[SerializeField]
	Meditator meditator;
	[SerializeField]
	StageUIMaker UImaker;
	[SerializeField]
	GameObject[] instancepos;

	public void makeItemMaker () //この処理に関してはUIマネージャーに移譲したほうがベターかもしれない
	{
		PrefabContainer prefabcontainer = meditator.getprefabcontainer ();
		ItemDataManager itemdatamanager = meditator.getitemdatamanager ();
		MapEditorUIManager uimanager = meditator.getUImanager ();

		GameObject leftcountprefab = prefabcontainer.getobjectleftCount ();
		GameObject dragobjectmakerprefab = prefabcontainer.getdragobjectmaker ();
		//アイテムの残数を表示する部分

		for (int i = 0; i < Config.dragbuttonNum; i++) {
			GameObject instanceOB = Instantiate (dragobjectmakerprefab, instancepos[i].transform.position, Quaternion.identity, instancepos[i].transform) as GameObject;
			ItemMaker MakerObject = instanceOB.GetComponent<ItemMaker> ();
			MakerObject.setMyObjectKind (itemdatamanager.getDragitemkind (i));
			MakerObject.setObjectLeftCount (itemdatamanager.getDragitemleft (i));
			MakerObject.changeMyTexture (i);
			UImaker.makestageUI (MakerObject.getMyKind (), MakerObject.ObjectLeftCount, (int) StageUIMaker.displayposition.rightupper + i);
		}
	}
}