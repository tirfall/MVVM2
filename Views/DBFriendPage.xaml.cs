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
        nimii.Text = "dfsd";
    }
}