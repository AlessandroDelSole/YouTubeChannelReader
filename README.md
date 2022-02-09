# YouTube Channel Reader
A .NET library to retrieve information about YouTube channels and that is ready for WPF,UWP and Xamarin.Forms

Given a YouTube channel ID, you can alternatively:

- Create an instance of the YoutubeViewModel class, invoke the LoadYoutubeChannelAsync method and use the YoutubeItemCollection object, of type ObservableCollection, so that it can be used with XAML data-binding
- Create an instance of the YouTubeService class, invoke the QueryVideosAsync method and use the Items collection for purposes outside of XAML

Only public information is retrieved.

## Example

The SampleApp included project shows how to query a channel and display information
