﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;

namespace Exemple_2
{

    public class GitHubUser
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
        public string name { get; set; }
        public object company { get; set; }
        public string blog { get; set; }
        public string location { get; set; }
        public object email { get; set; }
        public object hireable { get; set; }
        public string bio { get; set; }
        public int public_repos { get; set; }
        public int public_gists { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    
        public void CallGithubUzer( )
        {
            Console.WriteLine("Please Enter Uzer Name 'Pargev' ");
           string Name = Console.ReadLine();
            Console.Clear();
            try
            {
                if(Name=="Pargev")
                {
                    Console.WriteLine("login: {0}",login);
                    Console.WriteLine("id: {0}", id);
                    Console.WriteLine("node_id: {0}", node_id);
                    Console.WriteLine("avatar_url: {0}", avatar_url);
                    Console.WriteLine("gravatar_id: {0}", gravatar_id);
                    Console.WriteLine("url: {0}", url);
                    Console.WriteLine("followers_url: {0}", followers_url);
                    Console.WriteLine("following_url: {0}", following_url);
                    Console.WriteLine("gists_url: {0}", gists_url);
                    Console.WriteLine("starred_url: {0}", starred_url);
                    Console.WriteLine("organizations_url: {0}", organizations_url);
                    Console.WriteLine("repos_url: {0}", repos_url);
                    Console.WriteLine("events_url: {0}", events_url);
                    Console.WriteLine("received_events_url: {0}", received_events_url);
                    Console.WriteLine("type: {0}", type);
                    Console.WriteLine("site_admin: {0}", site_admin);
                    Console.WriteLine("name: {0}", name);
                    Console.WriteLine("company: {0}", company);
                    Console.WriteLine("blog: {0}", blog);
                    Console.WriteLine("location: {0}", location);
                    Console.WriteLine("email: {0}", email);
                    Console.WriteLine("hireable: {0}", hireable);
                    Console.WriteLine("bio: {0}", bio);
                    Console.WriteLine("public_repos: {0}", public_repos);
                    Console.WriteLine("public_gists: {0}", public_gists);
                    Console.WriteLine("followers: {0}", followers);
                    Console.WriteLine("following: {0}", following);
                    Console.WriteLine("created_at: {0}", created_at);
                    Console.WriteLine("updated_at: {0}", updated_at);

                }


            }
            catch (Exception e)
            {

                Console.WriteLine("Please Enter Name 'Pargev!'");
            }
        }
    }

    class Program
    {
        static string GetDataFromURL(object url)
        {
            var webRequest = WebRequest.Create(url as string) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                Thread.Sleep(1000);

                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    return contributorsAsJson;
                }
            }

        }
        public async static Task<string> GetDataFromUrl(string Url)
        {
            //Task<string> task = new Task<string>(GetDataFromURL, Url);
            //task.Start();
            //await task;
            return await Task<string>.Factory.StartNew(GetDataFromURL, Url);
            Thread.Sleep(1000);

            //GitHubUser rootobject = JsonConvert.DeserializeObject<GitHubUser>(Url);
            //Console.WriteLine(rootobject.blog);
            //Console.WriteLine(rootobject);
            //File.WriteAllText("person.json", Url);
        }



        static void Main(string[] args)
        {
            string Url = "https://api.github.com/users/Pargev1993";
            
           // Task<string> d =new Task<string>( GetDataFromURL,Url);
           // d.Start();
            
            Task<string> s = GetDataFromUrl(Url);

            while (!s.IsCompleted)
            {
                Console.ForegroundColor = (ConsoleColor)new Random().Next(1, 15);
                Console.Write("Loading");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(200);
                }
                Console.Clear();
            }
            Console.WriteLine("Opertion Complated!!");
            Console.ForegroundColor=ConsoleColor.White;
            GitHubUser gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(s.Result);
            gitHubUser.CallGithubUzer();
           

            ///Task<string> d = Method(Url);
            //d.Wait();
            //GitHubUser gitHubUser = new GitHubUser();
           // gitHubUser.CallGithubUzer();


            //Type type = typeof(GitHubUser);
            //FieldInfo[] fileInfo = type.GetFields(BindingFlags.GetField);
            //foreach (var item in fileInfo)
            //{
            //    Console.WriteLine(item.Name);
            //}





            Console.ReadLine();




        }
    }
}
