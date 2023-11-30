using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAuth()
        {
            var application = FlaUI.Core.Application.Launch("C:\\Users\\mamok\\OneDrive\\Рабочий стол\\Курсовая работа 4 курс\\Курсач\\Futurum\\Futurum\\bin\\Debug\\Futurum.exe");
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            Thread.Sleep(5000);
            var mainwindow = application.GetMainWindow(new UIA3Automation());
            mainwindow.FindFirstDescendant(conditionFactory.ByAutomationId("TextBoxLogin")).AsTextBox().Enter("Anton");
            Thread.Sleep(500);
            mainwindow.FindFirstDescendant(conditionFactory.ByAutomationId("PasswordBox")).AsTextBox().Enter("123456");
            Thread.Sleep(500);
            mainwindow.FindFirstDescendant(conditionFactory.ByAutomationId("ButtonLogin")).AsButton().Click();
            Thread.Sleep(500);
        }
        [TestMethod]
        public void TestMethodAddUser()
        {
            var application = FlaUI.Core.Application.Launch("C:\\Users\\mamok\\OneDrive\\Рабочий стол\\Курсовая работа 4 курс\\Курсач\\Futurum\\Futurum\\bin\\Debug\\Futurum.exe");
            var mainwindow = application.GetMainWindow(new UIA3Automation());
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            Thread.Sleep(5000);
            Mouse.Position = new Point(550, 422);
            Thread.Sleep(1000);
            Mouse.Click();
            Thread.Sleep(1000);
            Mouse.Position = new Point(940, 295);
            Thread.Sleep(1000);
            Mouse.Click();
            Thread.Sleep(1000);
            Mouse.Position = new Point(1140, 465);
            Thread.Sleep(1000);
            Mouse.Click();
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_N);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_T);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_C);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_N);
            Thread.Sleep(500);
            Mouse.Position = new Point(1140, 500);
            Mouse.Click();
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_N);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_T);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_C);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_N);
            Thread.Sleep(500);
            Mouse.Position = new Point(1140, 535);
            Mouse.Click();
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_8);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_9);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_0);
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_2);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_3);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_4);
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_5);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_6);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_7);
            Thread.Sleep(500);
            Mouse.Position = new Point(1140, 570);
            Mouse.Click();
            Thread.Sleep(1000);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(200);
            Keyboard.Press(VirtualKeyShort.KEY_1);
            Thread.Sleep(500);
            Mouse.Position = new Point(1178, 604);
            Thread.Sleep(500);
            Mouse.Click();
            Mouse.Position = new Point(1220, 768);
            Thread.Sleep(500);
            Mouse.Click();
            Thread.Sleep(500);
            Mouse.Position = new Point(1225, 770);
            Mouse.Click();
        }
        [TestMethod]
        public void TestMethodEditUser()
        {
            var application = FlaUI.Core.Application.Launch("C:\\Users\\mamok\\OneDrive\\Рабочий стол\\Курсовая работа 4 курс\\Курсач\\Futurum\\Futurum\\bin\\Debug\\Futurum.exe");
            var mainwindow = application.GetMainWindow(new UIA3Automation());
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            Thread.Sleep(5000);
            Mouse.Position = new Point(550, 422);
            Thread.Sleep(1000);
            Mouse.Click();
            Thread.Sleep(1000);
            Mouse.Position = new Point(900, 390);
            Mouse.RightClick();
            Thread.Sleep(1000);
            Mouse.Position = new Point(936, 430);
            Mouse.Click();
            Thread.Sleep(500);
            Mouse.Position = new Point(1178, 604);
            Thread.Sleep(500);
            Mouse.Click();
            Mouse.Position = new Point(1284, 765);
            Thread.Sleep(500);
            Mouse.Click();
            Thread.Sleep(500);
            Mouse.Position = new Point(1225, 770);
            Mouse.Click();
        }
        [TestMethod]
        public void TestMethodDeleteUser()
        {
            var application = FlaUI.Core.Application.Launch("C:\\Users\\mamok\\OneDrive\\Рабочий стол\\Курсовая работа 4 курс\\Курсач\\Futurum\\Futurum\\bin\\Debug\\Futurum.exe");
            var mainwindow = application.GetMainWindow(new UIA3Automation());
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            Thread.Sleep(5000);
            Mouse.Position = new Point(550, 422);
            Thread.Sleep(1000);
            Mouse.Click();
            Thread.Sleep(1000);
            Mouse.Position = new Point(900, 390);
            Mouse.RightClick();
            Thread.Sleep(1000);
            Mouse.Position = new Point(930, 458);
            Mouse.Click();
            Thread.Sleep(1000);
            Mouse.Position = new Point(870, 550);
            Mouse.Click();
        }
    }
}
