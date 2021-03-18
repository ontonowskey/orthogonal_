namespace AntonovKursovoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Chebyshev's methode
        {
            string method = "Чебышева";
            textBoxRes.Clear();
            dataGridView1.Rows.Clear();
            int.TryParse(textBoxN.Text, out int n);
            if (int.TryParse(textBoxR.Text, out int r) && r <= 2 && r >= 1)
            {
                double x = double.Parse(textBoxX1.Text); // x1
                double o = 1;
                if (r == 2)
                {
                    o = Math.Round(Math.Sin((n + 1) * Math.Acos(x)) / Math.Sin(Math.Acos(x)),2);
                }
                else
                   o =Math.Round( Math.Cos(n * Math.Acos(x)),2);
                dataGridView1.Rows.Add(method, x, o);
            }
            else
                textBoxRes.Text = "Неверно указан R!";

        }

        private void button2_Click(object sender, EventArgs e) //Ermit's methode
        {
            string method = "Эрмита";
            textBoxRes.Clear();
            dataGridView1.Rows.Clear();
            if (int.TryParse(textBoxN.Text, out int n) && n >= 2)
            {
                double u = double.Parse(textBoxX3.Text); // шаг
                double j = double.Parse(textBoxX2.Text); // x2
                double x = double.Parse(textBoxX1.Text); // x1
                double a = 1, b = 2 * x, h = 1;
                for (double i = x; i < j; i = u + x)
                {
                    h = 2 * x * b - 2 * i * a;
                    a = b;
                    b = h;
                    dataGridView1.Rows.Add(method, x, h);
                }
            }
            else
                textBoxRes.Text = "Неверно указан N!";
        }

        private void button3_Click(object sender, EventArgs e) //Legaundre's methode
        {
            string method = "Лежандра";
            dataGridView1.Rows.Clear();
            textBoxRes.Clear();
            if (int.TryParse(textBoxN.Text, out int n) && n >= 2)
                {
                double u = double.Parse(textBoxX3.Text); // шаг
                double x2 = double.Parse(textBoxX2.Text); // x2
                double x1 = double.Parse(textBoxX1.Text); // x1
                for (double x = x1; x <= x2; x += u)
                    {
                    double p = 1, a = 1, b = x;
                    for (int i = 1; i < n; i++)
                    {
                        p = ((2 * i + 1) * x * b - i * a) / (i + 1);
                        a = b;
                        b = p;
                    }
                    dataGridView1.Rows.Add(method, x, p);
                    }
                }
                else
                    textBoxRes.Text = "Неверно указан N!";
        }

        private void button4_Click(object sender, EventArgs e) // Lagger's methode
        {
            string method = "Лаггера";
            dataGridView1.Rows.Clear();
            textBoxRes.Clear();
            if (int.TryParse(textBoxN.Text, out int n) && n >= 2)
            {
                dataGridView1.Rows.Clear();
                double u = double.Parse(textBoxX3.Text); // step
                double x1 = double.Parse(textBoxX1.Text); // x1
                double x2 = double.Parse(textBoxX2.Text); // x2
                for (double x = x1; x <= x2; x += u)
                {
                    double l = 1, a = 1, b = 1 - x;
                    for (int i = 1; i < n; i++)
                    {
                        l = ((2 * i + 1 - x) * b - i * a) / (i + 1);
                        a = b;
                        b = l;
                    }
                    dataGridView1.Rows.Add(method, x, l);
                }
            }
            else
                textBoxRes.Text = "Неверно указан N!";
        }

        private void button5_Click(object sender, EventArgs e) //Exit button
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxN.Clear();
            textBoxR.Clear();
            textBoxRes.Clear();
            textBoxX1.Clear();
            textBoxX2.Clear();
            textBoxX3.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
