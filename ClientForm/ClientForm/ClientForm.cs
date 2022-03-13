using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class clientform : Form
    {
        public clientform()
        {
            InitializeComponent();
        }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        readonly HttpClient client = new HttpClient();

        private async void SendButton_Click(object sender, EventArgs e)
        {
            SendButton.Enabled = false;
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(textBox1.Text);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

                ClientTextBox.Text = responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            SendButton.Enabled = true;
        }
    }
}
