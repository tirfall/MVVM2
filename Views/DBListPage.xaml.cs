using MVVM.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MVVM.Views;

public partial class DBListPage : ContentPage
{
	public DBListPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        friendsList.ItemsSource = App.Database.GetItems();
        base.OnAppearing();
    }
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Friend selectedFriend = e.SelectedItem as Friend;
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext= selectedFriend;
        await Navigation.PushAsync(friendPage);
    }

    private async void CreateFriend(object sender, EventArgs e)
    {
        Friend friend = new Friend();
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext= friend;
        await Navigation.PushAsync(friendPage);
    }

}