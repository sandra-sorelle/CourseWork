using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Futurum.Entities
{
    public  class Check
    {
        static public bool IsRussianLayout(char c)
        {
            string russianLayout = "йцукенгшщзхъфывапролджэячсмитьбюёЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
            return russianLayout.Contains(char.ToLower(c));
        }

        static public bool IsEnglishLayout(char c)
        {
            string englishLayout = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            return englishLayout.Contains(char.ToLower(c));
        }

        static public void PhoneCheck(TextCompositionEventArgs e, TextBox textBox)
        {
            foreach (char c in e.Text)
            {
                if (textBox.Text.Length == 0 && e.Text != "8")
                {
                    e.Handled = true;
                    return;
                }
                else if (textBox.Text.Length == 1 && e.Text != "9")
                {
                    e.Handled = true;
                    return;
                }
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
                if (textBox.Text.Length >= 11)
                {
                    e.Handled = true;
                }
            }
        }
        static public void WithoutRussianCheck(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (IsRussianLayout(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        static public void OnlyRussianCheck(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!IsRussianLayout(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        static public void OnlyEnglishCheck(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!IsEnglishLayout(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        static public void LoginCheck(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!IsEnglishLayout(c) && !char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        static public void OnlyDigitCheck(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
