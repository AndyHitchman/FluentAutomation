using System;
using System.Collections.Generic;

namespace FluentAutomation.Interfaces
{
    public interface ICaptureProvider
    {
        IEnumerable<string> CssClasses(string selector);
        string Text(string selector);
        IEnumerable<string> Value(string selector);
        Uri Url();
        IEnumerable<string> SelectText(string selector);
    }
}