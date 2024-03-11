namespace test21 {
    public partial class Form1 : Form {
        string[] correctAnswers = { "A1", "B2", "A3", "A4", "B5", "B6", "A7", "A8"};
        List<string> answers;

        public Form1() {
            InitializeComponent();
            answers = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void groupBox1_Enter(object sender, EventArgs e) {
        }

        private void label10_Click(object sender, EventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e) {
            using (StreamWriter writer = File.CreateText(Environment.GetFolderPath( Environment.SpecialFolder.Desktop) + @"/save.txt")) {
                SaveRadioButtonAnswer(A1, writer);
                SaveRadioButtonAnswer(B1, writer);
                SaveRadioButtonAnswer(C1, writer);
                SaveRadioButtonAnswer(A2, writer);
                SaveRadioButtonAnswer(B2, writer);
                SaveRadioButtonAnswer(C2, writer);
                SaveRadioButtonAnswer(A3, writer);
                SaveRadioButtonAnswer(B3, writer);
                SaveRadioButtonAnswer(C3, writer);
                SaveRadioButtonAnswer(A4, writer);
                SaveRadioButtonAnswer(B4, writer);
                SaveRadioButtonAnswer(C4, writer);
                SaveRadioButtonAnswer(A5, writer);
                SaveRadioButtonAnswer(B5, writer);
                SaveRadioButtonAnswer(C5, writer);
                SaveRadioButtonAnswer(A6, writer);
                SaveRadioButtonAnswer(B6, writer);
                SaveRadioButtonAnswer(C6, writer);
                SaveRadioButtonAnswer(A7, writer);
                SaveRadioButtonAnswer(B7, writer);
                SaveRadioButtonAnswer(C7, writer);
                SaveRadioButtonAnswer(A8, writer);
                SaveRadioButtonAnswer(B8, writer);
                SaveRadioButtonAnswer(C8, writer);
                SaveTextBoxAnswer(textBox1, writer);
                SaveTextBoxAnswer(textBox2, writer);
                SaveTextBoxAnswer(textBox3, writer);
                SaveTextBoxAnswer(textBox4, writer);
                SaveTextBoxAnswer(textBox5, writer);
                MessageBox.Show("File saved to: " + @"/save.txt", "File Saved", MessageBoxButtons.OK);
                string resultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/results.txt";
                SaveResults(resultFilePath);
                MessageBox.Show("Din test resultat är sparat i: " + resultFilePath, "Results Saved", MessageBoxButtons.OK);

                this.Close();
            }
        }
        
        private void SaveRadioButtonAnswer(RadioButton radioButton, StreamWriter writer) {
            if (radioButton.Checked) {
                string radioButtonAnswer = radioButton.Name;
                writer.WriteLine("Radio Button Answer: " + radioButtonAnswer);
                answers.Add(radioButtonAnswer);
            }
        }
        private void SaveTextBoxAnswer(TextBox textBoxAnswer, StreamWriter writer) {
            string answer = textBoxAnswer.Text;
            writer.WriteLine("Text Answer: " + answer);
            answers.Add(answer);
        }
        private void SaveResults(string resultFilePath) {
            using (StreamWriter resultWriter = new StreamWriter(resultFilePath)) {
                for (int i = 0; i < correctAnswers.Length; i++) {
                    if (answers.Count > i && answers[i] == correctAnswers[i]) {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Rätt!");
                    }
                    else if (answers.Count > i) {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Fel. Rätta svaret är " + correctAnswers[i]);
                    }
                    else {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Fel. Du har inte svarat. Rätta svaret är " + correctAnswers[i]);
                    }
                }
            }
        }

        private void B8_CheckedChanged(object sender, EventArgs e) {

        }
    }
}
