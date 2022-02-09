using System;
using YouTubeChannelReader.ViewModel;

namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var youtube = new YouTubeViewModel("UCWYpwlelrWvjZDBxXnVyYag");

            youtube.LoadYoutubeChannelAsync().Wait();

            foreach(var item in youtube.YoutubeItemCollection)
            {
                Console.WriteLine($"{item.Title}, {item.ThumbnailUrl}, {item.Link}");
            }

            Console.ReadLine();
        }
    }
}
