using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCircleAndCylinderClasses
{

    public class Circle
    {
        private double radius;
        private string color;

        public Circle()
        {
            radius = 1.0;
            color = "red";
        }
        public Circle(double radius)
        {
            this.radius = radius;
            color = "red";
        }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;

        }

        public double getRadius()
        {
            return radius;
        }

        public virtual double getArea()
        {
            return 3.14 * (radius * radius); 
                //Math.PI * Math.Sqrt(radius);
        }

        public string getColor()
        {

            return color;
        }

        public void setRadius(double radius)
        {
            this.radius = radius;
        }

        public void setColor(string color)
        {

            this.color = color;
        }

        public override string ToString()
        {
            return "Circle[radius=" + radius + " color=" + color + "]";
        }

    }

    public class Cylinder : Circle {
        // datove slozky
        private double height;
        // constructory
        public Cylinder(): base()  {
            height = 1.0;            
        }

        public Cylinder(double height) : base() {
            this.height = height;
        }

        public Cylinder(double radius, double height) : base(radius) {
            this.height = height;

        }
        //verejne metody

        public double getHeight() {

            return height;
        }

        public double getVolume() {

            return base.getArea() * height;
        }

        //metodu get area dedim circla, ale musim ji overridnout bo cylinder ma jinou areu
        //nemusim pouzit ani override ani virtual, ale kompilator bude posilat upozorneni
        // v c sharp by se spravne melo do metody rodice(kterou prekryvam) uvest virtual a tu co vytvarim v decku ktera prekryva uvest override
        // jave je trochu jinak viz skripta str 24
        // base. se odkazuju na getareu ze circlu, spis je to dulezite u predchozi metody, kde je potreba ukazat ze nechci getArea z Cylidru ale getArea z Circlu
        //krasne popisky, jetli to bude nekdy nekdo cist ... tak se asi posere ... navic jsou to mozna blbosti :) ucim se ...
        public override double getArea() {

            return (base.getArea() * 2) + (2 * Math.PI * getRadius() * height);
        }

        public override string ToString()
        {
            return "Cylinder: subclass of " +   base.ToString() +  " height " + height;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Cylinder c1 = new Cylinder();
            Console.WriteLine("Cylinder:" + "\n"
                + " radius=" + c1.getRadius() + "\n"
                + " height=" + c1.getHeight() + "\n"
              //tady by nemelo byt base area ale area, kdyz uz sem vytvoril prekrytou metodu, ktera nepocita plochu podstavy, ale celeho cylindru
              //no plochu podstavy uz ted asi nezavolam
                + " base area=" + c1.getArea() + "\n"
                + " volume=" + c1.getVolume());

            Cylinder c2 = new Cylinder(10.0);
            Console.WriteLine("Cylinder:" + "\n"
                + " radius=" + c2.getRadius() + "\n"
                + " height=" + c2.getHeight() + "\n"
                + " base area=" + c2.getArea() + "\n"
                + " volume=" + c2.getVolume());

            Console.WriteLine(c2);

            Circle cc1 = new Circle();
            Console.WriteLine(cc1);



            Console.ReadLine();

        }
    }
}
