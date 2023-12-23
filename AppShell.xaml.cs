namespace AIPFoodLookup
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CatagoriesPage), typeof(CatagoriesPage));
        }
    }
}
