using TMPro.EditorUtilities;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "jsonTask", menuName = "jsonTask")]
    public class jsonTask : Task {
        [SerializeField]
        private TextAsset jsonFile = null;
        public employeeData[] employees;

        public override void Execute() {
            if (!jsonFile) {
                Debug.LogError("jsonTask: json file not set");
                return;
            }

            employees = JsonUtility.FromJson<employeeArray>(jsonFile.text).employees;

            for (int i = 0; i < employees.Length; i++) {
                Debug.Log("Employee inserted: " + employees[i].name);
            }
        }
    }
}
