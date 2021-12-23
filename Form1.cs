using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    // комментарий на предупреждение см ниже  перед методом  Equials
    class RationalNuber
    {
        public int UpperVal { get; }
        public int LowerVal { get; }

        public RationalNuber(int upperVal, int lowerVal)
        {
            UpperVal = upperVal;
            LowerVal = lowerVal;
        }

        internal static RationalNuber Construct(int upperVal, int lowerVal) 
        {
            return new RationalNuber(upperVal, lowerVal);
        }

        public override string ToString()
        {
            return UpperVal.ToString()+'/'+LowerVal.ToString();
        }

        public override int GetHashCode()
        {
            return UpperVal.GetHashCode();
        }

        //я что какя - то шутка 
        // а на override  ругается
        public bool Equials (object o) 
        {
            if (o.GetType() != this.GetType()) return false;

            RationalNuber num = (RationalNuber)o;
            return ((this.UpperVal == num.UpperVal) && (this.LowerVal == num.LowerVal));
        }

        public static RationalNuber operator +(RationalNuber num1, RationalNuber num2) 
        {
            if (num1.LowerVal == num2.LowerVal)
            {
                return new RationalNuber(num1.UpperVal + num2.UpperVal, num2.LowerVal);
            }
            else 
            {
                return new RationalNuber((num1.UpperVal * num2.LowerVal) + (num2.UpperVal * num1.LowerVal), (num1.LowerVal * num2.LowerVal));
            }
        }
        public static RationalNuber operator ++(RationalNuber num1) 
        {
            return new RationalNuber(num1.UpperVal + num1.UpperVal, num1.LowerVal);
        }

        public static RationalNuber operator -(RationalNuber num1, RationalNuber num2) 
        {
            if (num1.LowerVal == num2.LowerVal)
            {
                return new RationalNuber(num1.UpperVal - num2.UpperVal, num2.LowerVal);
            }
            else
            {
                return new RationalNuber((num1.UpperVal * num2.LowerVal) - (num2.UpperVal * num1.LowerVal), (num1.LowerVal * num2.LowerVal));
            }
        }
        public static RationalNuber operator --(RationalNuber num1) 
        {
            return new RationalNuber(num1.UpperVal - num1.UpperVal, num1.LowerVal);
        }
        public static RationalNuber operator *(RationalNuber num1, RationalNuber num2)
        {
            return new RationalNuber(num1.UpperVal * num2.UpperVal, num1.LowerVal * num2.LowerVal);
        }
        public static RationalNuber operator / (RationalNuber num1, RationalNuber num2) 
        {
            return new RationalNuber(num1.UpperVal * num2.LowerVal, num1.LowerVal * num2.UpperVal);
        }
        public static bool operator == (RationalNuber num1, RationalNuber num2) 
        {
            if ((num1.UpperVal == num2.UpperVal) && (num1.LowerVal == num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
        public static bool operator != (RationalNuber num1, RationalNuber num2) 
        {
            if ((num1.UpperVal != num2.UpperVal) && (num1.LowerVal != num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
        public static bool operator >=(RationalNuber num1, RationalNuber num2)
        {
            if ((num1.UpperVal >= num2.UpperVal) && (num1.LowerVal <= num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
        public static bool operator <=(RationalNuber num1, RationalNuber num2) 
        {
            if ((num1.UpperVal <= num2.UpperVal) && (num1.LowerVal >= num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
        public static bool operator >(RationalNuber num1, RationalNuber num2) 
        {
            if ((num1.UpperVal > num2.UpperVal) && (num1.LowerVal < num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
        public static bool operator <(RationalNuber num1, RationalNuber num2)
        {
            if ((num1.UpperVal > num2.UpperVal) && (num1.LowerVal < num2.LowerVal))
            {
                return true;
            }
            else return false;
        }
    }

    class Book 
    {
        internal string name { get; }
        internal string author { get; }
        internal string publisher { get; }

        public Book (string name, string author, string publisher) 
        {
            name = this.name;
            author = this.author;
            publisher = this.publisher;
        }
    }

    delegate void sortBookdel();
    class BookContainer
    {
        internal string name;
        internal Book[] bookArray;

        public void Add(Book book)
        {
            bookArray.Append(book);
        }
        // не совсем понял что от меня хотят ведь нельзя написать method(delegate del){}
        internal delegate void Sort();   
    }
}
