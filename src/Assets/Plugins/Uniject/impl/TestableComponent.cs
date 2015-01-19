using System;

namespace Uniject {
    public class TestableComponent : IComponent {
        private IGameObject obj;

        public bool enabled { get; set; }

        public TestableComponent(IGameObject obj) {
            this.enabled = true;
            this.obj = obj;
            obj.RegisterComponent(this);
        }
        
        public IGameObject Obj {
            get { return obj; } 
        }

        public void OnUpdate() {
            if (enabled) {
                Update();
            }
        }

        public virtual void Update() {
        }

        public virtual void OnDestroy() {
        }

        public virtual void OnCollisionEnter(Collision collision) {
        }


		public void Awake ()
		{
		}

		public void OnGUI ()
		{
		}

		public void CollisionEnter (ICollision collision)
		{
		}

		public void StartCoroutine (string coroutine, params object[] args)
		{
			throw new NotImplementedException ();
		}

		public void StartCoroutine (System.Collections.IEnumerator coroutine)
		{
			throw new NotImplementedException ();
		}

		public void StartCoroutine (string coroutine)
		{
			throw new NotImplementedException ();
		}

		public void StopCoroutines ()
		{
			throw new NotImplementedException ();
		}

		public void StopCoroutine (string coroutine)
		{
			throw new NotImplementedException ();
		}

		public IGameObject GameObject {
			get {
				return obj;
			}
		}

    }
}

