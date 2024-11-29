using Android.App;
using Android.Content;
using Android.Widget;

[assembly: Dependency(typeof(Registr8.PlatformPickerService))]
namespace Registr8
{
    public class PlatformPickerService : Interfaces.IPlatformPickerService
    {
        public Task<int?> ShowPickerAsync(string title, List<PickerItem> items)
        {
            var tcs = new TaskCompletionSource<int?>();

            var context = Platform.CurrentActivity;
            var names = items.Select(item => item.Name).ToArray();

            var builder = new AlertDialog.Builder(context);
            builder.SetTitle(title);
            builder.SetItems(names, (sender, args) =>
            {
                tcs.SetResult(items[args.Which].ID);
            });

            builder.SetNegativeButton("Mégsem", (sender, args) =>
            {
                tcs.SetResult(null);
            });

            var dialog = builder.Create();
            dialog.Show();

            return tcs.Task;
        }
    }
}
