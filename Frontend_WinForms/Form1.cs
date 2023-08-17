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

        private async void button1_Click(object sender, EventArgs e)
        {
            const string message_from_winForm = "I am the message from winform app";
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7088/PageContentHub")
                .Build();
            hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine($"Received: {message}");
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("SendMessage", message_from_winForm);

        }
    }
}