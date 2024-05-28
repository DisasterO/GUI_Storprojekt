using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Provhaneraren {
    public partial class Form1 : Form {
        // Array to hold correct answers for each question
        string[] correctAnswers = { "A1", "B2", "A3", "A4", "B5", "B6", "A7", "A8" };
        // List to store user's answers
        List<string> answers;

        // Constructor to initialize the form
        public Form1() {
            InitializeComponent();
            // Initialize the list of user's answers
            answers = new List<string>();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
        }
        private void Form1_Load(object sender, EventArgs e) {
        }
        // Method to handle Button click event
        private void button1_Click(object sender, EventArgs e) {
            // Create a StreamWriter object to write to the results file
            // Here, we are using a StreamWriter to write data to a text file, specifically to store the test results.
            using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/results.txt")) {
                // Save user's answers for each question to the results file
                // For each group of radio button questions, we check if the user has selected an answer and write it to the results file.
                // Additionally, we add the user's answer to the list for further processing.
                for (int i = 1; i <= 8; i++) {
                    SaveRadioButtonAnswer(A1, writer, i);
                    SaveRadioButtonAnswer(B1, writer, i);
                    SaveRadioButtonAnswer(C1, writer, i);
                }

                // Save user's answers for text box questions
                for (int i = 9; i <= 13; i++) {
                    SaveTextBoxAnswer(GetTextBoxByQuestionNumber(i), writer, i);
                }

                // Add separator after user's answers
                writer.WriteLine("******************************");
            }

            // Path to save the results file
            string resultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/results.txt";

            // Save the results of the test
            SaveResults(resultFilePath);

            // Save predefined answers
            SaveResults1(resultFilePath);

            // Close the form after saving the results
            this.Close();
        }

        // Method to save user's answers for radio button questions
        private void SaveRadioButtonAnswer(RadioButton radioButton, StreamWriter writer, int questionNumber) {
            if (radioButton.Checked) {
                // If the radio button is checked, we extract its name, which corresponds to the answer, and save it to the results file.
                string radioButtonAnswer = radioButton.Name;
                writer.WriteLine($"Fråga {questionNumber} (Flervals fråga): {radioButtonAnswer}");
                // We also add the user's answer to the list for later comparison with correct answers.
                answers.Add(radioButtonAnswer);
            }
        }

        // Method to save user's answers for text questions
        private void SaveTextBoxAnswer(TextBox textBoxAnswer, StreamWriter writer, int questionNumber) {
            // For text box questions, we directly save the text entered by the user to the results file.
            string answer = textBoxAnswer.Text;
            writer.WriteLine($"Fråga {questionNumber} (Text fråga): {answer}");
            // We also add the user's answer to the list for later comparison with correct answers.
            answers.Add(answer);
        }

        // Method to save results of the test
        private void SaveResults(string resultFilePath) {
            using (StreamWriter resultWriter = new StreamWriter(resultFilePath, true)) {
                for (int i = 0; i < correctAnswers.Length; i++) {
                    // Loop through each question and compare user's answer with correct answer
                    // Here, we iterate through each question and compare the user's answer with the correct answer.
                    // We then write the result (whether the answer is correct or incorrect) to the results file.
                    if (answers.Count > i && answers[i] == correctAnswers[i]) {
                        resultWriter.WriteLine($"Fråga {i + 1}: Rätt!");
                    }
                    else if (answers.Count > i) {
                        resultWriter.WriteLine($"Fråga {i + 1}: Fel. Rätta svaret är {correctAnswers[i]}");
                    }
                    else {
                        resultWriter.WriteLine($"Fråga {i + 1}: Fel. Du har inte svarat. Rätta svaret är {correctAnswers[i]}");
                    }
                }
            }
        }

        // Method to save predefined answers
        private void SaveResults1(string resultFilePath) {
            using (StreamWriter resultWriter = new StreamWriter(resultFilePath, true)) {
                // Here, we write predefined answers for certain questions to the results file.
                // These answers serve as a reference for the user and are not compared with the user's responses.
                resultWriter.WriteLine("Fråga 9 Rätt Svar: Svaret på denna fråga är inte definitivt. Moore's lag, som säger att antalet transistorer på en integrerad krets fördubblas ungefär varannat år, har varit en stor drivkraft bakom teknologiska framsteg. Men det finns debatt om huruvida den kan fortsätta enligt samma takt, med tanke på de fysiska begränsningarna och utmaningarna med att minska storleken på transistorer ytterligare. Många tror att även om Moore's lag inte kan följas exakt, kommer teknologin ändå att fortsätta att utvecklas på ett exponentiellt sätt genom andra medel, som till exempel nya material eller arkitekturer.");
                resultWriter.WriteLine("Fråga 10 Rätt Svar: Open-source innebär att programvarukällkoden är tillgänglig för allmänheten för att användas, studeras, modifieras och distribueras fritt. Fördelarna med open-source inkluderar öppenhet, samarbete, flexibilitet och kostnadsbesparingar. Nackdelar kan innefatta säkerhetsrisker om koden inte granskas ordentligt, brist på support eller dokumentation, samt möjliga konflikter med licenser och immateriella rättigheter.");
                resultWriter.WriteLine("Fråga 11 Rätt Svar: En konsekvent kodningsstil är viktigt för att göra koden läsbar och underhållbar, särskilt i stora projekt med flera utvecklare. En enhetlig stil gör det lättare för andra att förstå koden, minimera misstag och förbättra samarbete. Det kan också bidra till att skapa konsistens i hela applikationen eller projektet och underlätta felsökning och debugging.");
                resultWriter.WriteLine("Fråga 12 Rätt Svar: Olika operativsystem har olika arkitekturer, API och funktioner. Därför måste applikationer anpassas och kompileras för varje operativsystem för att fungera korrekt och dra nytta av plattformspecifika funktioner. Det är också viktigt att ta hänsyn till användarupplevelsen och användargränssnittet, eftersom design och interaktion kan skilja sig åt mellan olika plattformar.");
                resultWriter.WriteLine("Fråga 13 Rätt Svar: AI har revolutionerat programmering på många sätt. Det har introducerat nya tekniker och verktyg som automatiserar uppgifter som tidigare var komplexa och tidskrävande, som maskininlärning för att förbättra prestanda eller hantera stora datamängder. Samtidigt har AI också skapat nya utmaningar, såsom etiska överväganden kring användningen av AI-algoritmer, och risken för att ersätta mänsklig arbetskraft i vissa områden.");
            }
        }

        // Method to get TextBox by question number
        private TextBox GetTextBoxByQuestionNumber(int questionNumber) {
            switch (questionNumber) {
                case 9:
                    return textBox1;
                case 10:
                    return textBox2;
                case 11:
                    return textBox3;
                case 12:
                    return textBox4;
                case 13:
                    return textBox5;
                default:
                    return null;
            }
        }
    }
}
