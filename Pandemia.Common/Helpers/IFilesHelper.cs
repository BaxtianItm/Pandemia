using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pandemic.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
        byte[] ReadFully2(Stream input);
    }
}