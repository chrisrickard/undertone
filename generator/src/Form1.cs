using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace UnderTone
{
    public partial class Form1 : Form
    {

        private Bitmap theImage;
        private Hashtable clut = new Hashtable();
        string hero_color;

        Hashtable colour_frequency = new Hashtable();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrabImage_Click(object sender, EventArgs e)
        {
            DialogResult result = chooseimage.ShowDialog();

            if (result == DialogResult.OK)
            {
                theImage = new Bitmap(chooseimage.FileName);
                image.Image = theImage;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generate_Click(object sender, EventArgs e)
        {

            this.clut.Clear();
            this.colour_frequency.Clear();

            this.LoadClut();
            this.RenderClut();
            this.GetHeroColor();

            output.Text = output.Text + "\r\n\r\n\r\n";

            this.RenderUnderTone();
        }


        /// <summary>
        /// 
        /// </summary>
        private void RenderClut()
        {
            System.Text.StringBuilder clut = new System.Text.StringBuilder();
            clut.Append("var utclut = new Array();\r\n");


            foreach (string key in this.clut.Keys)
            {
                clut.Append("utclut[" + this.clut[key] + "] = '" + key + "';\r\n");
            }

            output.Text = output.Text + clut.ToString();
        }



        /// <summary>
        /// 
        /// </summary>
        private void RenderUnderTone()
        {
            System.Text.StringBuilder build_output = new System.Text.StringBuilder();

            Color clr;
            build_output.Append("var image1 = new Array();\r\n");

            //whack in meta data...
            build_output.Append("image1.push(" + theImage.Width + ");\r\n");
            build_output.Append("image1.push(" + theImage.Height + ");\r\n");
            build_output.Append("image1.push(" + this.clut[this.hero_color] + ");\r\n");


            //loop through the entire imageB
            for (int y = 0; y < theImage.Height; y++)
            {
                for (int x = 0; x < theImage.Width; x++)
                {
                    clr = theImage.GetPixel(x, y);
                    string clr_hex = GetHex(clr);
                    build_output.Append("image1.push(" + this.clut[clr_hex] + ");\r\n");
                } 
            }

            output.Text = output.Text + build_output.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LoadClut()
        {
            Color clr;

            for (int y = 0; y < theImage.Height; y++)
            {
                for (int x = 0; x < theImage.Width; x++)
                {
                    clr = theImage.GetPixel(x, y);
                    string clr_hex = GetHex(clr);

                    if (!this.clut.Contains(clr_hex))
                    {
                        this.clut.Add(clr_hex, this.clut.Count);

                        this.colour_frequency.Add(clr_hex, 1);
                    }
                    else
                    {
                        int colour_number = (int)this.clut[clr_hex];

                        int current_frequency = (int)this.colour_frequency[clr_hex];
                        this.colour_frequency[clr_hex] = (current_frequency + 1);
                    }

                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string GetHex(Color clr)
        {
            string clr_hex = string.Format("0x{0:X8}", clr.ToArgb());
            clr_hex = clr_hex.Substring(clr_hex.Length - 6, 6);
            return clr_hex;
        }


        /// <summary>
        /// 
        /// </summary>
        public void GetHeroColor()
        {

            int  highest = 0;
            string hexcode = "";
            

            foreach (string color in this.colour_frequency.Keys)
            {
                int test_highest = (int)this.colour_frequency[color];
                if (test_highest > highest)
                {
                    highest = test_highest;
                    hexcode = color;
                }
            }

            this.hero_color = hexcode;
          //  this.hero_clut_key = 
        }


        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        
    }
}