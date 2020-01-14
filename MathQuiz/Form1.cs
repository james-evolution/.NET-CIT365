using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer to generate random numbers.
        Random randomizer = new Random();

        // Get the current date.
        DateTime rawDate = DateTime.Now;

        // These integer variables store the numbers used for the addition function.
        int addend1;
        int addend2;

        // These integer variables store the numbers for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers for the division problem. 
        int dividend;
        int divisor;

        // The integer variable that keeps track of the remaining time.
        int timeLeft;

        public void StartTheQuiz()
        {

            // Format the date, cast to a string, and display it in the text of the dateLabel label.
            dateLabel.Text = rawDate.ToString("dd MMMM yyyy");

            // Change the background color to green.
            timeLabel.BackColor = Color.LightGreen;

            // Fill in the addition problem with 2 randomly generated numbers.
            // This will choose a number between 0 and 50.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two random numbers to strings so that they can be displayed in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Set 'sum' NumericUpDown control to a default value of zero.
            sum.Value = 0;

            // Fill in the subtraction problem.
            /* We provide two number arguments to the Next() method here to force the random value to be
             * positive, as it will pick between a range of 1 and 100. */
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // Check whether or not the user got the answers correct. Return true if true, false if false.
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && 
                (minuend - subtrahend == difference.Value) && 
                (multiplicand * multiplier == product.Value) && 
                (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Sum_ValueChanged(object sender, EventArgs e)
        {

        }
        private void difference_ValueChanged(object sender, EventArgs e)
        {

        }

        private void product_ValueChanged(object sender, EventArgs e)
        {

        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Start the quiz.
            StartTheQuiz();

            // Disable the start button after the quiz has begun.
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (CheckTheAnswer()) {
                // If CheckTheAnswer() returns true, then the user got the answer right. Stop the timer 
                // and show a MessageBox.
                timer1.Stop();
                timeLabel.BackColor = Color.Empty;
                timerBar.Value = 30; // Refill the timer bar.
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Fill progress bar by 1 unit out of 30.
                timerBar.PerformStep();

                // Change the value of the "Time Left" label to the value of the "timeLeft" variable.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user runs out of time, stop the timer, show a MessageBox, and fill in the answers.
                timer1.Stop();
                timerBar.Value = 30; // Refill the timer bar.
                timeLabel.BackColor = Color.Empty;
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time. Sorry!");

                // Fill in the fields with the correct answers.
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                // Change the answer fields to light green.
                sum.BackColor = Color.LightGreen;
                difference.BackColor = Color.LightGreen;
                product.BackColor = Color.LightGreen;
                quotient.BackColor = Color.LightGreen;

                // Re-enable the start button.
                startButton.Enabled = true;
            }

            if (timeLeft == 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            /* The 'sender' object refers to the object whose event is firing. In this case
             * it is the NumericUpDown control. We must specify this. NumericUpDown is an object,
             * but not every object is a NumericUpDown. We're casting "sender" to a NumericUpDown object
             * with the 'as' keyword, and assigning that value to our answerBox NumericUpDown
             * variable.
             */
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void TimerBar_Click(object sender, EventArgs e)
        {

        }
    }
}
