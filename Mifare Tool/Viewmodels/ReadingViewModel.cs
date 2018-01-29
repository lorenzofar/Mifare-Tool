using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mifare_Tool.Models;
using Mifare_Tool.Utils;
using System.Collections.Generic;
using Template10.Mvvm;

namespace Mifare_Tool.Viewmodels
{
    public class ReadingViewModel : ViewModelBase
    {
        public ReadingViewModel()
        {
            Messenger.Default.Register<CardEvent>(this, message =>
            {
                cardStatus = message.isCardPresent;
                Read.RaiseCanExecuteChanged();
            });
            Messenger.Default.Register<KeyEvent>(this, message =>
            {
                keyStatus = message.isKeyPresent;
                Read.RaiseCanExecuteChanged();
            });
        }

        //Manage the setting of a key set

        private bool _cardStatus;
        public bool cardStatus
        {
            get { return _cardStatus; }
            set { Set(ref _cardStatus, value); }
        }

        private bool _keyStatus;
        public bool keyStatus
        {
            get { return _keyStatus; }
            set { Set(ref _keyStatus, value); }
        }

        private IReadOnlyList<Sector> _sectors = null;
        public IReadOnlyList<Sector> sectors
        {
            get { return _sectors; }
            set { Set(ref _sectors, value); }
        }

        private RelayCommand _Read;
        public RelayCommand Read
        {
            get
            {
                if (_Read == null)
                    _Read = new RelayCommand(async () =>
                    {
                        sectors = await CardManager.ReadCard();
                    }, () => cardStatus && !string.IsNullOrWhiteSpace(App.defaultKeyPath));
                return _Read;
            }
        }


    }

}
