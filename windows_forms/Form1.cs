using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;

namespace windows_forms {
    public partial class ModeSelectForm : Form {
        private static readonly bool Testing = false;
        private static string WorkDir = ".\\"; // `.` is current directory

        private static string PythonExecutable = "python";
        private static string PythonFile = "popdisplay.py";
        private static string PythonVenvPath = "venv";
        private static string ConfigPath = "config.json";

        private static Dictionary<string, string>? MonitorConfigs;

        public class MonitorConfig() {
            [JsonProperty("name")]
            public required string name { get; set; }
        }

        private void LoadJsonConfig(string jsonPath) {
            string jsonString = File.ReadAllText(jsonPath);
            Dictionary<string, MonitorConfig>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, MonitorConfig>>(jsonString);
            if (dictionary == null) {
                return;
            }

            foreach (KeyValuePair<string, MonitorConfig> item in dictionary) {
                string key = item.Key;
                MonitorConfig monitorConfig = item.Value;

                if (MonitorConfigs == null) {
                    MonitorConfigs = new Dictionary<string, string>();
                }

                MonitorConfigs.Add(monitorConfig.name, key);
                ModeList.Items.Add(monitorConfig.name);
            }
        }

        public ModeSelectForm() {
            InitializeComponent();

            if (Testing) {
                WorkDir = "..\\..\\..\\..\\";
            }

            LoadJsonConfig($"{WorkDir}{ConfigPath}");
            if (MonitorConfigs == null) {
                MessageBox.Show("Edit `config.json` and add some monitor modes!", "Monitor config file is empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Process PythonScriptProcess(string venvPath, string pythonFile, string arguments) {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";

            // C param shows terminal after action is over while K does not
            string instantClose = Testing ? "C" : "K";
            process.StartInfo.Arguments = $"/{instantClose} cd {WorkDir} && .\\{venvPath}\\Scripts\\activate.bat && {PythonExecutable} {pythonFile} {arguments}";

            process.StartInfo.WindowStyle = Testing ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = true;

            return process;
        }

        private void ModeList_SelectedIndexChanged(object sender, EventArgs e) { }

        private void ModeList_KeyDown(object sender, KeyEventArgs e) {
            if (MonitorConfigs == null) {
                return;
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right) {
                string? selectedItem = ModeList.SelectedItem?.ToString();
                if (selectedItem == null || selectedItem == ": keep current") {
                    Application.Exit();
                    return;
                }

                string mode = $"-j {MonitorConfigs[selectedItem]}";
                PythonScriptProcess(PythonVenvPath, PythonFile, mode)
                    .Start();

                Application.Exit();
            }
        }
    }
}
