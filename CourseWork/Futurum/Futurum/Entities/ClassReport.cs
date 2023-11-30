using System;
using System.Collections.Generic;

namespace Futurum.Entities
{
    public class ClassReport
    {
        static public List<Product> servicessold = new List<Product>();

        static public DateTime starttime, endtime;
        static public TimeSpan workingtime;
        static public string staffname;
        static public int cash = 0, credit_card = 0, total_amount = 0;
    }
}
