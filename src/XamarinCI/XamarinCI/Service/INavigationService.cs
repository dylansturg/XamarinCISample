using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCI.Service
{
	public interface INavigationService
	{
		Task PushPageAsync(Page nextPage);
		Task<Page> PopPageAsync();
	}
}

