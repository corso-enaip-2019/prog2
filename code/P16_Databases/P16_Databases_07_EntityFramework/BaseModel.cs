using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P16_Databases_07_EntityFramework
{
    public class BaseModel : INotifyPropertyChanged
    {
        protected void SetAndRaise<T>(T value, ref T field, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(value, field))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
