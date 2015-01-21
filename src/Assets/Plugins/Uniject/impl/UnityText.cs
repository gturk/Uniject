using System;
using UnityEngine.UI;
namespace Uniject
{
	public class UnityText : UnityComponent, IText
	{
		private Text txt;
		public UnityText (IGameObject obj) : base(obj) 
		{
            txt = obj.GetComponent<Text>();
            if (null == txt) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have a UnityEngine.UI.Text but none was found");
            }
		}

		public string text {
			get {
				return txt.text;
			}
			set {
				txt.text = value;
			}
		}
	}
}

