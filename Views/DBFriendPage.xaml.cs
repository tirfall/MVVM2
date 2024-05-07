using MVVM.Models;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Microsoft.Maui.Controls;

namespace MVVM.Views;

public partial class DBFriendPage : ContentPage
{
	public DBFriendPage()
	{
		InitializeComponent();
        Loaded += DBFriendPage_Loaded;
	}

    private void DBFriendPage_Loaded(object sender, EventArgs e)
    {
        Friend friend = (Friend)BindingContext;
        pilt.Source = ImageSource.FromStream(() => new MemoryStream(friend.Img));
    }

    private void SaveFriend(object sender, EventArgs e)
    {
        Friend friend = (Friend)BindingContext;
        if (new string[] {friend.Name,friend.Email,friend.Phone,friend.Age}.All(x => !string.IsNullOrEmpty(x)))
            App.Database.SaveItem(friend);
        Navigation.PopAsync();
    }

    private void DeleteFriend(object sender, EventArgs e)
    {
        Friend friend = (Friend)BindingContext;
        App.Database.DeleteItem(friend.Id);
        Navigation.PopAsync();
    }

    private void Cancel(object sender, EventArgs e) =>
        Navigation.PopAsync();

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await CrossMedia.Current.Initialize();
        MediaFile new_image = await CrossMedia.Current.PickPhotoAsync();
        Friend friend = (Friend)BindingContext;
        Stream stream = await ((StreamImageSource)ImageSource.FromStream(new_image.GetStream)).Stream(CancellationToken.None);
        byte[] image = new byte[stream.Length];
        stream.Read(image, 0, image.Length);
        friend.Img = image;
        App.Database.SaveItem(friend);
        pilt.Source = ImageSource.FromStream(new_image.GetStream);
    }
}