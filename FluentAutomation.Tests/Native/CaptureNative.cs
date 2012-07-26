using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FluentAutomation.Tests
{
    public class CaptureNative : FluentTest
    {
        private static string testUrl = "http://automation.apphb.com/forms";

        public void CaptureTextFromHeader()
        {
            I.Open(testUrl);
            var actual = I.Capture.Text("form.form-test-01 h4");

            Assert.Equal("Sign up for our mailing list!", actual);
        }

        public void CaptureValueFromInput()
        {
            I.Open(testUrl);

            I.Enter("abcd").In("#form01-input01");

            var actual = I.Capture.Value("#form01-input01");
            Assert.Equal("abcd", actual.First());
        }

        public void CaptureTextFromCheckboxGroup()
        {
            I.Open(testUrl);
            var actual = I.Capture.Text("form.form-test-01 .controls:eq(2)");

            Assert.Equal("Cars Development Food", actual);
        }
    }
}
