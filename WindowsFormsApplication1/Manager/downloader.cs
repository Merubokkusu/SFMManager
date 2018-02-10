using HtmlAgilityPack;
using SourceFilmMakerManager.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using WindowsFormsApplication1;

namespace SourceFilmMakerManager {

    public static class downloader {
        public static string SFMLabURL;
        public static List<string> DownloadURLs = new List<string>();
        public static string DownloadServer = ConfigurationManager.AppSettings["Download_Server"];
        public static string FileURL;
        public static string fileName = "Download";
        public static string Source = "";
        public static string Author = "";
        private static Stopwatch sw = new Stopwatch();

        public static void Download(string fileDownload) {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                try {
                var web = new HtmlWeb();
                var doc = web.Load(fileDownload);
                Console.WriteLine("Link is " + fileDownload);
                Source = "SFMLab";
                modMan.fileLink = fileDownload;
                var div = doc.DocumentNode.SelectSingleNode("(//div[@class='panel__body panel__body--flags'])");
                var divAuthor = doc.DocumentNode.SelectSingleNode("(//span[@class='text-primary'])");
                var divAuthor2 = doc.DocumentNode.SelectSingleNode("(//span[@class='text-warning'])");

                if (divAuthor != null) {
                    Author = divAuthor.InnerText;
                    }
                    else if(divAuthor2 != null) {
                        Author = divAuthor2.InnerText;
                    }

                if (div != null) {
                    var links = div.Descendants("a").Where(x => x.Attributes.Contains("href"));

                    foreach (var link in links) {
                        DownloadURLs.Add(link.Attributes["href"].Value);
                    }
                }

                if (DownloadServer == "1") {
                    FileURL = "https://sfmlab.com" + DownloadURLs[0];
                    
                }
                if (DownloadServer == "2") {
                    FileURL = "https://sfmlab.com" + DownloadURLs[1];
                }
                if (DownloadServer == "3") {
                    FileURL = "https://sfmlab.com" + DownloadURLs[2];
                }
                Console.WriteLine("FileURL is " + FileURL);

                var web2 = new HtmlWeb();
                var doc2 = web2.Load(FileURL);
                var div2 = doc2.DocumentNode.SelectSingleNode("(//div[@class='panel__body'])");
                if (DownloadServer != "1") {

                    if (div2 != null) {
                    var filelink = div2.Descendants("a").Where(x => x.Attributes.Contains("href"));

                    foreach (var link in filelink) {
                        FileURL = link.Attributes["href"].Value;
                        fileName = Path.GetFileName(FileURL);
                    }
                }
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(FileURL), @"SFM/Download/" + fileName);
                    Form1.Download_Start = true;
                }
                else {
                    if (div2 != null) {
                        var filelink = div2.Descendants("a").Where(x => x.Attributes.Contains("href"));

                        foreach (var link in filelink) {
                            FileURL = link.Attributes["href"].Value;
                        }
                    }
                    //EU Downloader
                    var file_Url = "https://sfmlab.com" + FileURL;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(file_Url);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                        var fn = response.Headers["Content-Disposition"].Split(new string[] { "=" }, StringSplitOptions.None)[1];
                        fn = fn.Trim('"');
                        fileName = fn;
                        string basePath = @"SFM\Download\"; // Change accordingly...
                        var responseStream = response.GetResponseStream();
                        Form1.Download_Start = true;
                        using (var fileStream = File.Create(Path.Combine(basePath, fn))) {
                           responseStream.CopyTo(fileStream);  
                        }
                        Completed_EU();
                        
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("An error occured in Downloader: " + ex.Message);
                Console.WriteLine(ex.ToString());
            }
            DownloadURLs.Clear();
            });
            bw.RunWorkerAsync();
        }
            
            //Download End

        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            //  progressBar.Value = e.ProgressPercentage;
        }
        private static void Completed_EU() {
            Form1.Download_End = true;
            modMan.Source = Source;
            modMan.Author = Author;
            modMan.Extract(@"SFM/Download/" + fileName);
            fileName = otherCodes.GetRandomString();
            Source = "?";
            Author = "?";
        }

        private static void Completed(object sender, AsyncCompletedEventArgs e) {
            Form1.Download_End = true;
            modMan.Source = Source;
            modMan.Author = Author;
            modMan.Extract(@"SFM/Download/" + fileName);
            fileName = otherCodes.GetRandomString();
            Source = "?";
            Author = "?";
        }
    }
}