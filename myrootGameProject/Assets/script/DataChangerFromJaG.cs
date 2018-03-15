﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DataChangerFromJaG : MonoBehaviour {
	int timelimitElementNum = 1;
	int requiredkillcountElementNum = 2;

	int itemkindElementNum = 2;
	int itemcountElementNum = 3;
	//構造体は値渡しなのですごく注意が必要な気がする。
	//このクラスの呼ばれるタイミングについては、ボタンタップ→UIマネージャーが指示→CSVマネージャーがジャグデータとってくる→UIマネージャーの命令でそのデータを変換する→Datamanagerに渡すという流れ

	public int[,]parsejagtodoubledata(int[][] jagdata,int ElementNum) {//要素番号を入れる点に注意。
		int[,] getdata = new int[jagdata.Length, jagdata[0].Length];
		for (int j = 0; j < getdata.GetLength(1); j++) {
			for (int i = 0; i < getdata.GetLength(0); i++) {
				getdata[j / jagdata[0].Length, j % jagdata[0].Length] = jagdata[j][ElementNum];
			}
		}
		return getdata;
	}

	public clearconditiondata[] parsejagtodobleClearconditiondatas(int[][] jagdata) {

		clearconditiondata[] getdata = new clearconditiondata[jagdata.Length];
		for (int j = 0; j < getdata.GetLength(1); j++) {
			for (int i = 0; i < getdata.GetLength(0); i++) {
				getdata[j].timelimit = jagdata[j][timelimitElementNum];
				getdata[j].RequiredKillCount = jagdata[j][requiredkillcountElementNum];
			}
		}
		return getdata;
	}

	public dragitemdata[,] parsejagtodobledragitemdatadatas(int[][] jagdata) {

		dragitemdata[,] getdata = new dragitemdata[jagdata.Length, jagdata[0].Length];
		int xlength = jagdata[0].Length;
		for (int i = 0; i < getdata.GetLength(0); i++) {
			for (int j = 0; j < getdata.GetLength(1); j++) {
				getdata[j % xlength, j / xlength].itemkind = jagdata[i][itemkindElementNum];
				getdata[j % xlength, j / xlength].itemcount = jagdata[i][itemcountElementNum];
				Debug.Log(String.Format("{0}{1}{2}{3}",i,j, jagdata[i][itemkindElementNum], jagdata[i][itemcountElementNum]));
			}
		}
		return getdata;
	}
	//csvからデータを読み込んで、datachangefromjagclassクラスのメソッドを使って変換。そのデータをデータマネージャーに上書きする。
}
