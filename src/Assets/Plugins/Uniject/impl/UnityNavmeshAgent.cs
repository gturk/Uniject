using System;
using Uniject;
using UnityEngine;

namespace Uniject.Impl {
    public class UnityNavmeshAgent : UnityComponent, INavmeshAgent {
        private NavMeshAgent agent;
		private IGameObject obj;
        public UnityNavmeshAgent(IGameObject obj) : base(obj)
		{
            this.obj = obj;
            this.agent = obj.GetComponent<NavMeshAgent>();
			if (null == this.agent) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have a NavMeshAgent but none was found");
            }
        }

        public void Stop() {
            agent.Stop();
        }

		public void onPlacedOnNavmesh() {
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            agent.autoRepath = false;
		}

        public void setDestination (Vector3 target) {
            agent.SetDestination (target);
        }

        public void setSpeedMultiplier (float multiplier) {
            agent.speed = multiplier;
        }

        public ObstacleAvoidanceType obstacleAvoidanceType {
            get { return agent.obstacleAvoidanceType; }
            set { agent.obstacleAvoidanceType = value; }
        }

        public float BaseOffset {
            get { return agent.baseOffset; }
            set { agent.baseOffset = value; }
        }

        public bool Enabled {
            get { return agent.enabled; }
            set { agent.enabled = value; }
        }

        public float radius {
            get { return agent.radius; }
            set { agent.radius = value; }
        }
    }
}

