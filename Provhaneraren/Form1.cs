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
                writer.WriteLine($"Fr�ga {questionNumber} (Flervals fr�ga): {radioButtonAnswer}");
                // We also add the user's answer to the list for later comparison with correct answers.
                answers.Add(radioButtonAnswer);
            }
        }

        // Method to save user's answers for text questions
        private void SaveTextBoxAnswer(TextBox textBoxAnswer, StreamWriter writer, int questionNumber) {
            // For text box questions, we directly save the text entered by the user to the results file.
            string answer = textBoxAnswer.Text;
            writer.WriteLine($"Fr�ga {questionNumber} (Text fr�ga): {answer}");
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
                        resultWriter.WriteLine($"Fr�ga {i + 1}: R�tt!");
                    }
                    else if (answers.Count > i) {
                        resultWriter.WriteLine($"Fr�ga {i + 1}: Fel. R�tta svaret �r {correctAnswers[i]}");
                    }
                    else {
                        resultWriter.WriteLine($"Fr�ga {i + 1}: Fel. Du har inte svarat. R�tta svaret �r {correctAnswers[i]}");
                    }
                }
            }
        }

        // Method to save predefined answers
        private void SaveResults1(string resultFilePath) {
            using (StreamWriter resultWriter = new StreamWriter(resultFilePath, true)) {
                // Here, we write predefined answers for certain questions to the results file.
                // These answers serve as a reference for the user and are not compared with the user's responses.
                resultWriter.WriteLine("Fr�ga 9 R�tt Svar: Svaret p� denna fr�ga �r inte definitivt. Moore's lag, som s�ger att antalet transistorer p� en integrerad krets f�rdubblas ungef�r varannat �r, har varit en stor drivkraft bakom teknologiska framsteg. Men det finns debatt om huruvida den kan forts�tta enligt samma takt, med tanke p� de fysiska begr�nsningarna och utmaningarna med att minska storleken p� transistorer ytterligare. M�nga tror att �ven om Moore's lag inte kan f�ljas exakt, kommer teknologin �nd� att forts�tta att utvecklas p� ett exponentiellt s�tt genom andra medel, som till exempel nya material eller arkitekturer.");
                resultWriter.WriteLine("Fr�ga 10 R�tt Svar: Open-source inneb�r att programvaruk�llkoden �r tillg�nglig f�r allm�nheten f�r att anv�ndas, studeras, modifieras och distribueras fritt. F�rdelarna med open-source inkluderar �ppenhet, samarbete, flexibilitet och kostnadsbesparingar. Nackdelar kan innefatta s�kerhetsrisker om koden inte granskas ordentligt, brist p� support eller dokumentation, samt m�jliga konflikter med licenser och immateriella r�ttigheter.");
                resultWriter.WriteLine("Fr�ga 11 R�tt Svar: En konsekvent kodningsstil �r viktigt f�r att g�ra koden l�sbar och underh�llbar, s�rskilt i stora projekt med flera utvecklare. En enhetlig stil g�r det l�ttare f�r andra att f�rst� koden, minimera misstag och f�rb�ttra samarbete. Det kan ocks� bidra till att skapa konsistens i hela applikationen eller projektet och underl�tta fels�kning och debugging.");
                resultWriter.WriteLine("Fr�ga 12 R�tt Svar: Olika operativsystem har olika arkitekturer, API och funktioner. D�rf�r m�ste applikationer anpassas och kompileras f�r varje operativsystem f�r att fungera korrekt och dra nytta av plattformspecifika funktioner. Det �r ocks� viktigt att ta h�nsyn till anv�ndarupplevelsen och anv�ndargr�nssnittet, eftersom design och interaktion kan skilja sig �t mellan olika plattformar.");
                resultWriter.WriteLine("Fr�ga 13 R�tt Svar: AI har revolutionerat programmering p� m�nga s�tt. Det har introducerat nya tekniker och verktyg som automatiserar uppgifter som tidigare var komplexa och tidskr�vande, som maskininl�rning f�r att f�rb�ttra prestanda eller hantera stora datam�ngder. Samtidigt har AI ocks� skapat nya utmaningar, s�som etiska �verv�ganden kring anv�ndningen av AI-algoritmer, och risken f�r att ers�tta m�nsklig arbetskraft i vissa omr�den.");
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
