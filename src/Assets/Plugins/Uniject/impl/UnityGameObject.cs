using System.Collections.Generic;
using System;
using UnityEngine;
using Uniject;
using Uniject.Impl;
using System.Linq;

namespace Uniject{
	public class UnityGameObject : TestableGameObject, IGameObject
	{
		private List<IComponent> components = new List<IComponent>();
		
		public IUnityBridgeComponent Bridge { get { return bridge; } }
		private UnityBridgeComponent bridge;
		
		public ITransform Transform { get; private set; }
		
		public readonly GameObject GameObject;
		
		public UnityGameObject(GameObject gameObject) : base(new UnityTransform(gameObject))
		{
			this.GameObject = gameObject;
			this.bridge = gameObject.AddComponent<UnityBridgeComponent>();
			this.bridge.GameObject = this;
//			this.Transform = gameObject.transform.ToUniject();
		}
		
		public void RegisterComponent(IComponent component) {
			components.Add(component);
			component.Awake();
		}
		
		public bool destroyed { get; private set; }
		
		public void Update() {
			if (Active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.Update();
				}
			}
		}
		
		public void DontDestroyOnLoad ()
		{
			GameObject.DontDestroyOnLoad (GameObject);
		}
		
		public void OnGUI() {
			if (Active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.OnGUI();
				}
			}
		}
		
		public IEnumerable<IComponent> GetComponents()
		{
			return components;
		}
		
		public T[] GetComponentsInChildren<T> () where T : class
		{
			return typeof(GameObject).GetMethod("GetComponentsInChildren", new Type[0]).MakeGenericMethod(new [] { typeof(T) }).Invoke(GameObject, new object[0]) as T[];
		}
		
		public T GetComponentInChildren<T> () where T : class
		{
			return typeof(GameObject).GetMethod("GetComponentInChildren", new Type[0]).MakeGenericMethod(new [] { typeof(T) }).Invoke(GameObject, new object[0]) as T;
		}
		
		public void CollisionEnter(Collision c) {
			for (int t = 0; t < components.Count; t++) {
//				components[t].CollisionEnter(c);
			}
		}
		
		public override void Destroy() {
			if (!destroyed) {
				foreach (IComponent component in this.components) {
					component.OnDestroy();
				}
				destroyed = true;
			}
			GameObject.Destroy (this.GameObject);
		}
		
		public virtual bool Active {
			get { return GameObject.activeSelf; }
			set { GameObject.SetActive(value); }
		}
		
		public string Name {
			get { return GameObject.name; }
			set { GameObject.name = value; }
		}
		
		public T GetComponent<T>() where T : class
		{
			for (int t = 0; t < components.Count; t++) {
				IComponent component = components[t];
				if (component is T) {
					return component as T;
				}
			}
			
			if (GameObject != null)
			{
				var component = GameObject.GetComponents(typeof(T)).FirstOrDefault() as T;
				
				if (component != null)
				{
					return component;
				}
			}
			
			return null;
		}
		
		
//		public int layer {
//		}

		#region implemented abstract members of TestableGameObject

		public override void setActiveRecursively (bool active)
		{
			GameObject.SetActiveRecursively(active);
		}

		public override bool active {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override string name {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override int layer {
			get { return GameObject.layer; }
			set { GameObject.layer = value; }
		}

		#endregion
	}
}
