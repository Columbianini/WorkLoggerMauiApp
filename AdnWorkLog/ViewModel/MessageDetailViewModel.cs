using AdnWorkLog.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.ViewModel
{
    [QueryProperty(nameof(CurrentLogMessage), "Message")]
    public partial class MessageDetailViewModel: ObservableObject
    {
        [ObservableProperty]
        ManualLogMessage currentLogMessage;
    }
}
