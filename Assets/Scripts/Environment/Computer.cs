using System.Collections.Generic;
using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {

        [SerializeField]
        private List<Task> tasks = new List<Task>();

        private IntQueue taskQueue = new IntQueue();

        private void Start() {
            for(int i = 0; i < tasks.Count; i++) {
                taskQueue.enqueue(i);
            }
        }
        public void OnInteract() {
            if(taskQueue.isEmpty()) {
                Debug.Log("Computer: no tasks left in the queue.");
                return;
            }

            int nextIndex = taskQueue.dequeue();
            tasks[nextIndex].Execute();
        }
    }
}
