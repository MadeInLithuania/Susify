using System;
using System.Windows.Forms;
using System.Media;
namespace Amogus_App
{
    public partial class formAmogus : Form
    {
        public formAmogus()
        {
            InitializeComponent();
        }

        private void formAmogus_Load(object sender, EventArgs e)
        {
            string path = "AMOGUS.wav";
            SoundPlayer player = new SoundPlayer
            {
                SoundLocation = path
            };
            player.Play();
        }
    }
}
