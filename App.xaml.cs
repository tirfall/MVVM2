using MVVM.Views;

namespace MVVM
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new Shell { CurrentItem = new FriendsListPage() };
        }
    }
}
