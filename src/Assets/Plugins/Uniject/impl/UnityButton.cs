using System;
using UnityEngine;
using UnityEngine.UI;

namespace Uniject
{
	public class UnityButton : UnityComponent, IButton
	{
		private Button btn;
		public UnityButton (IGameObject obj) : base(obj) 
		{
            btn = obj.GetComponent<Button>();
            if (null == btn) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have a UnityEngine.UI.Button but none was found");
            }
		}

		public void AddListener (IButtonListener listener)
		{
			btn.onClick.AddListener(() => listener.ClickCallback());
		}

		public void RemoveListener (IButtonListener listener)
		{
			btn.onClick.RemoveListener(() => listener.ClickCallback());
		}

	}
}