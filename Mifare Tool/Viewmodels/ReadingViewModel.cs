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
        }

        private bool _cardStatus;
        public bool cardStatus
        {
            get { return _cardStatus; }
            set { Set(ref _cardStatus, value); }
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
                    _Read = new RelayCommand(async() =>
                    {
                        sectors = await CardManager.ReadCard();
                    }, () => cardStatus);
                return _Read;
            }
        }


    }

}
