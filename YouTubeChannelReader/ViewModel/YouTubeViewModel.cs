using System.Collections.ObjectModel;
using System.Threading.Tasks;
using YouTubeChannelReader.Model;

namespace YouTubeChannelReader.ViewModel
{
    public class YouTubeViewModel : NotifyBase
    {
        private ObservableCollection<YouTubeItem> _youtubeItemCollection;

        public ObservableCollection<YouTubeItem> YoutubeItemCollection
        {
            get { return _youtubeItemCollection; }
            set { _youtubeItemCollection = value; OnPropertyChanged(); }
        }

        private string _channelID;
        public string ChannelID
        {
            get => _channelID;
        }

        public YouTubeViewModel(string channelId)
        {
            _channelID = channelId;
            YoutubeItemCollection = new ObservableCollection<YouTubeItem>();
        }

        public async Task LoadYoutubeChannelAsync()
        {
            try
            {
                var service = new Services.YouTubeService(ChannelID);
                var result = await service.QueryVideosAsync(new System.Threading.CancellationToken());
                YoutubeItemCollection = new ObservableCollection<YouTubeItem>(result);
            }
            catch
            {
                
            }
        }
    }
}
