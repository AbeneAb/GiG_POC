using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Interface
{
    public interface ISelectionUpdateSender
    {
        void SendSelection (SelectionEvent customer);

    }
}
