using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        var client = IO.Socket("http://localhost:9600");

        client.On(Socket.EVENT_CONNECT, () =>
        {
            Console.WriteLine("Connected to the server");

            // Request the list of available personalities
            client.Emit("list_personalities");
        });

        client.On("personalities_list", response =>
        {
            // Assuming the response is a JSON array
            JArray jsonResponse = JArray.Parse(response.ToString());
            var personalities = jsonResponse.ToObject<string[]>();
            Console.WriteLine("Available Personalities: " + string.Join(", ", personalities));


            // Select a personality and send a text generation request
            var selectedPersonality = personalities[0];
            var prompt = "Once upon a time...";
            client.Emit("generate_text", new
            {
                personality = selectedPersonality,
                prompt = prompt
            });
        });

        client.On("text_generated", response =>
        {
            // Assuming the response is a JSON object
            JObject jsonResponse = JObject.Parse(response.ToString());
            var generatedText = jsonResponse["text"].ToString();
            Console.WriteLine("Generated Text: " + generatedText);

            // Do something with the generated text
        });

        client.On(Socket.EVENT_DISCONNECT, () =>
        {
            Console.WriteLine("Disconnected from the server");
        });

        await Task.Delay(-1); // Keep the client running
    }
}
