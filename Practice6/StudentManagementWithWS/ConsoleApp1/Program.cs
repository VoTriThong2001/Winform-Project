﻿using System;
using System.Net.Http;

namespace TestStudentWS
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44322/api/");
                var responseTask = client.GetAsync("Students?hutechClass=19DTHQA2");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    Console.WriteLine(readTask.Result);
                }
            }
        }
    }
}
