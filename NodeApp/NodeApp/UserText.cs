using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NodeApp
{    
    [Serializable()]
    public class UserText
    {
        [NonSerialized]
        public TextBox TextBox;
    }
}
