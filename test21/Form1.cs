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
                SaveRadioButtonAnswer(A1, writer, 1);
                SaveRadioButtonAnswer(B1, writer, 1);
                SaveRadioButtonAnswer(C1, writer, 1);
                SaveRadioButtonAnswer(A2, writer, 2);
                SaveRadioButtonAnswer(B2, writer, 2);
                SaveRadioButtonAnswer(C2, writer, 2);
                SaveRadioButtonAnswer(A3, writer, 3);
                SaveRadioButtonAnswer(B3, writer, 3);
                SaveRadioButtonAnswer(C3, writer, 3);
                SaveRadioButtonAnswer(A4, writer, 4);
                SaveRadioButtonAnswer(B4, writer, 4);
                SaveRadioButtonAnswer(C4, writer, 4);
                SaveRadioButtonAnswer(A5, writer, 5);
                SaveRadioButtonAnswer(B5, writer, 5);
                SaveRadioButtonAnswer(C5, writer, 5);
                SaveRadioButtonAnswer(A6, writer, 6);
                SaveRadioButtonAnswer(B6, writer, 6);
                SaveRadioButtonAnswer(C6, writer, 6);
                SaveRadioButtonAnswer(A7, writer, 7);
                SaveRadioButtonAnswer(B7, writer, 7);
                SaveRadioButtonAnswer(C7, writer, 7);
                SaveRadioButtonAnswer(A8, writer, 8);
                SaveRadioButtonAnswer(B8, writer, 8);
                SaveRadioButtonAnswer(C8, writer, 8);
                SaveTextBoxAnswer(textBox1, writer, 9);
                SaveTextBoxAnswer(textBox2, writer, 10);
                SaveTextBoxAnswer(textBox3, writer, 11);
                SaveTextBoxAnswer(textBox4, writer, 12);
                SaveTextBoxAnswer(textBox5, writer, 13);
                MessageBox.Show("File saved to: " + @"/save.txt", "File Saved", MessageBoxButtons.OK);
                string resultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/results.txt";
                SaveResults(resultFilePath);
                MessageBox.Show("Din test resultat är sparat i: " + resultFilePath, "Results Saved", MessageBoxButtons.OK);

                this.Close();
            }
        }

        private void SaveRadioButtonAnswer(RadioButton radioButton, StreamWriter writer, int questionNumber) {
            if (radioButton.Checked) {
                string radioButtonAnswer = radioButton.Name;
                writer.WriteLine("Fråga " + questionNumber + " (Flervals fråga): " + radioButtonAnswer);
                answers.Add(radioButtonAnswer);
            }
        }
        private void SaveTextBoxAnswer(TextBox textBoxAnswer, StreamWriter writer, int questionNumber) {
            string answer = textBoxAnswer.Text;
            writer.WriteLine("Fråga " + questionNumber + " (Text fråga): " + answer);
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
