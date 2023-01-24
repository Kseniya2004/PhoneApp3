using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneApp3
{
    public class PhonesListViewModel
    {
        public ObservableCollection<PhoneViewModel> Phones { get; set; }
        public ICommand MoveToTopCommand { protected set; get; }
        public ICommand MoveToBottomCommand { protected set; get; }
        public ICommand RemoveCommand { protected set; get; }
        public PhonesListViewModel()
        {
            Phones = new ObservableCollection<PhoneViewModel>
            {
                new PhoneViewModel { Title="Pixel 5", Price=55000, Company="Google", ListViewModel=this},
                new PhoneViewModel {Title="Xiaomi Mi 10", Price= 28000, Company="Xiaomi", ListViewModel=this},
                new PhoneViewModel {Title="iPhone 12 Pro", Price=30000, Company="Apple", ListViewModel=this },
                new PhoneViewModel {Title="Galaxy S 10", Price=60000, Company="Samsung", ListViewModel=this },
                new PhoneViewModel {Title="Huawei P40 Pro", Price=36000, Company="Huawei", ListViewModel=this }
            };

            MoveToTopCommand = new Command(MoveToTop);
            MoveToBottomCommand = new Command(MoveToBottom);
            RemoveCommand = new Command(Remove);
        }

        private void MoveToTop(object phoneObj)
        {
            PhoneViewModel phone = phoneObj as PhoneViewModel;
            if (phone == null) return;
            int oldIndex = Phones.IndexOf(phone);
            if (oldIndex > 0)
                Phones.Move(oldIndex, oldIndex - 1);
        }
        private void MoveToBottom(object phoneObj)
        {
            PhoneViewModel phone = phoneObj as PhoneViewModel;
            if (phone == null) return;
            int oldIndex = Phones.IndexOf(phone);
            if (oldIndex < Phones.Count - 1)
                Phones.Move(oldIndex, oldIndex + 1);
        }
        private void Remove(object phoneObj)
        {
            PhoneViewModel phone = phoneObj as PhoneViewModel;
            if (phone == null) return;

            Phones.Remove(phone);
        }
    }
}
