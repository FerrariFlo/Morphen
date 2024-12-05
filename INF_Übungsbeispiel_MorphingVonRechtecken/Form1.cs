namespace INF_Übungsbeispiel_MorphingVonRechtecken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtX1.Focus();
        }

        private void btnMorphing_Click(object sender, EventArgs e)
        {
            try
            {
                // Eingabewerte einlesen
                double x1 = Convert.ToDouble(txtX1.Text);
                double y1 = Convert.ToDouble(txtY1.Text);
                double width1 = Convert.ToDouble(txtBreite1.Text);
                double height1 = Convert.ToDouble(txtHöhe1.Text);

                double x2 = Convert.ToDouble(txtX2.Text);
                double y2 = Convert.ToDouble(txtY2.Text);
                double width2 = Convert.ToDouble(txtBreite2.Text);
                double height2 = Convert.ToDouble(txtHöhe2.Text);

                int steps = (int)nudSteps.Value;

                // ListBox leeren
                lstAusgabe.Items.Clear();

                // Morphing berechnen
                for (int i = 0; i <= steps; i++)
                {
                    double t = (double)i / steps;

                    // Interpolation
                    double x = x1 + t * (x2 - x1);
                    double y = y1 + t * (y2 - y1);
                    double width = width1 + t * (width2 - width1);
                    double height = height1 + t * (height2 - height1);

                    // Ausgabe formatieren und in die ListBox schreiben
                    string rectangle = $"Rechteck {i + 1}: X={x:F2}, Y={y:F2}, Breite={width:F2}, Höhe={height:F2}";
                    lstAusgabe.Items.Add(rectangle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler bei der Eingabe: {ex.Message}");
            }


        }
        private void nudSteps_Enter(object sender, EventArgs e)
        {
            nudSteps.Select(0, nudSteps.Text.Length); // Markiert den gesamten Text
        }
    }
}
