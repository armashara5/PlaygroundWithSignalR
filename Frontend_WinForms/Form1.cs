using Backend;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Frontend_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            const string message_from_winForm = "I am the message from winform app";
            //using (var client = new HttpClient())
            //{
            //    var content = new StringContent(message_from_winForm);
            //    var response = await client.PostAsync("https://localhost:7088/DevzWeb/PostTestMessage", content);
            //    var responseString = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(responseString);
            //}

            // Create an HttpClient instance
            HttpClient client = new HttpClient();

            // Set the base address
            client.BaseAddress = new Uri("https://localhost:7088/");

            // Set the accept header to JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Create a PageContent object with the message you want to send
            PageContent message = new PageContent { Text = message_from_winForm,/* TextFormat = "Plain"*/ };

            // Send a POST request to the endpoint
            HttpResponseMessage response = await client.PostAsJsonAsync("DevzWeb/PostTestMessage", message);

            // Check the response status code and read the content
            if (response.IsSuccessStatusCode)
            {
                // Read the response as a PageContent object
                string result = await response.Content.ReadAsAsync<string>();

                // Do something with the result
                Console.WriteLine(result);
                //Console.WriteLine(result.text);
                //Console.WriteLine(result.textFormat);
            }
            else
            {
                // Handle the error
                Console.WriteLine(response.StatusCode);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            const string message_from_winForm = "I am the message from winform app";
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7088/PageContentHub")
                .Build();
            hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                MessageBox.Show($"I am showing the following message as incoming message from hubconnection {message}");
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("SendMessage", message_from_winForm);
        }
    }
}