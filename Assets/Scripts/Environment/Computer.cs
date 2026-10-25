using System;
using System.Collections.Generic;
using Environment.Tasks;
using UnityEngine;

namespace Environment {
    [Serializable]
    public class employeeData {
        public string name;
        public string department;
        public string latestEntry;
    }

    [Serializable]
    public class employeeArray {
        public employeeData[] employees;
    }
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private List<Task> tasks = new List<Task>();
        private IntQueue taskQueue = new IntQueue();
        private employeeData[] employees = null;

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
            Task task = tasks[nextIndex];
            task.Execute();

            if(task is jsonTask json) {
                employees = new employeeData[json.employees.Length];

                for(int i = 0; i < employees.Length; i++) {
                    employees[i] = json.employees[i];
                }
            }
        }
    }
}
