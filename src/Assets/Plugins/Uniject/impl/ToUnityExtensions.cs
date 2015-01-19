using System;
using UnityEngine;
using Uniject.Impl;

namespace Uniject{

	public static class ToUnityExtensions
	{
		public static UnityEngine.Vector3 ToUnity(this Vector3 v)
		{
			return new UnityEngine.Vector3(v.x, v.y, v.z);
		}
		
		public static UnityEngine.Quaternion ToUnity(this Quaternion q)
		{
			return new UnityEngine.Quaternion(q.x, q.y, q.z, q.w);
		}
		

		public static UnityEngine.Color ToUnity(this Color c)
		{
			return new UnityEngine.Color(c.r, c.g, c.b, c.a);
		}
		
		public static UnityEngine.Rect ToUnity(this Rect r)
		{
			return new UnityEngine.Rect(r.x, r.y, r.width, r.height);
		}
		
		public static UnityEngine.Transform ToUnity(this ITransform t)
		{
			return (t as UnityTransform).UTransform;
		}
	}
}
