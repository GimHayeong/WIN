using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class HandPhone
    {
        public virtual void Send()
        {
            //
        }

        public virtual void Receive()
        {
            //
        }
    }

    interface IMp3
    {
        void PlayMusic();
        void StopMusic();
    }

    interface ICamera
    {
        void TakePhoto();
        void ViewPhoto();
        void RemovePhoto();
    }

    class SmartPhone : HandPhone, IMp3, ICamera
    {
        public void PlayMusic()
        {
            //
        }

        public void StopMusic()
        {
            //
        }

        public void RemovePhoto()
        {
            //
        }
        public void TakePhoto()
        {
            //
        }

        public void ViewPhoto()
        {
            //
        }
    }
}
