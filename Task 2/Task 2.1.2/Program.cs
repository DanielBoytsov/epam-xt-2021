using System;
using System.Collections.Generic;
using Task_2._1._2.Enums;
using System.Diagnostics;

namespace Task_2._1._2
{
    class Program
    {
        private static readonly List<Figure> Figures = new List<Figure>();

        private static Session _currentSession;
        static void JoinSession()
        {
            Console.WriteLine("Hello User , what is your name?");
            string username = Console.ReadLine();
            _currentSession = new Session(username);
            Console.WriteLine($"Hello {_currentSession.Name}!");
        }
        
        static void Main(string[] args)
        {
            JoinSession();
            while (true)
            {
                Console.WriteLine(@"Choose actions: " +
                                  "\n1. Add figure" +
                                  "\n2. Show your figures" +
                                  "\n3. Clear canvas" +
                                  "\n4. Change User" +
                                  "\n5. Exit");
                string action = Console.ReadLine();
                Enum.TryParse<Actions>(action, out Actions actionResult);
                ChooseAction(actionResult);
                if (actionResult == Actions.Exit)
                {
                    Console.WriteLine("Bye, I hope you'll coming back :)");
                    break;
                }
            }
        }

        public static void ChooseAction(Actions select)
        {
            switch (select)
            {
                case Actions.AddFigure: 
                    AddFigure();
                    break;
                case Actions.ShowYourFigures:
                    ShowFigures();
                    break;
                case Actions.ClearCanvas:
                    ClearCanvas();
                    break;
                case Actions.ChangeUser:
                    ChangUser();
                    break;
                case Actions.Exit:
                    break;
                default:
                        throw new InvalidOperationException("The selected action does not exist");
            }
        }
        public static void AddFigure()
        {
            Console.WriteLine("Choose figure: " +
                              "\n1.Circle" +
                              "\n2.Ring" +
                              "\n3.Square" +
                              "\n4.Rectangle" +
                              "\n5.Triangle" +
                              "\n6.Line");
            string figure = Console.ReadLine();
            Enum.TryParse<Figures>(figure, out Figures figureResult);
            Figures.Add(CreateFigure(figureResult));
        }

        public static void ShowFigures()
        {
            foreach (var item in Figures)
            {
                Console.WriteLine(item.GetInfo());
            }
        }

        public static void ClearCanvas()
        {
            Figures.Clear();
            Console.WriteLine("All figures removed");
        }

        public static void ChangUser()
        {
            Console.WriteLine("");
            JoinSession();
        }

        public static Figure CreateFigure(Figures type) => type switch
        {
            Enums.Figures.Circle => CreateCircleSignature(),
            Enums.Figures.Ring => CreateRingSignature(),
            Enums.Figures.Square => CreateSquareSignature(),
            Enums.Figures.Rectangle => CreateRectangleSignature(),
            Enums.Figures.Triangle => CreateTriangleSignature(),
            Enums.Figures.Line => CreateLineSignature(),
            _ => throw new InvalidOperationException("The selected figure does not exist"),
        };

        public static Figure CreateCircleSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the Radius");
            double.TryParse(Console.ReadLine(), out double r);
            Figure a = new Circle(x, y, r);
            Console.WriteLine("Circle successfully created");
            return a;
        }

        public static Figure CreateRingSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the InnerRadius");
            double.TryParse(Console.ReadLine(), out double innerRadius);
            Console.WriteLine("Put here the OuterRadius");
            double.TryParse(Console.ReadLine(), out double outerRadius);
            Figure a = new Ring(x, y, innerRadius, outerRadius);
            Console.WriteLine("Ring successfully created");
            return a;
        }

        public static Figure CreateSquareSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the Side Length");
            double.TryParse(Console.ReadLine(), out double sideLength);
            Figure a = new Square(x, y, sideLength);
            Console.WriteLine("Square successfully created");
            return a;
        }

        public static Figure CreateRectangleSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the WidthLength");
            double.TryParse(Console.ReadLine(), out double widthLength);
            Console.WriteLine("Put here the HeightLength");
            double.TryParse(Console.ReadLine(), out double heightLength);
            Figure a = new Rectangle(x, y, widthLength, heightLength);
            Console.WriteLine("Rectangle successfully created");
            return a;
        }

        public static Figure CreateTriangleSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the Angle Value");
            double.TryParse(Console.ReadLine(), out double angleValue);
            Console.WriteLine("Put here the First Side Length");
            double.TryParse(Console.ReadLine(), out double firstSideLength);
            Console.WriteLine("Put here the Second Side Length");
            double.TryParse(Console.ReadLine(), out double secondSideLength);
            Figure a = new Triangle(x, y, angleValue, firstSideLength, secondSideLength);
            Console.WriteLine("Triangle successfully created");
            return a;
        }

        public static Figure CreateLineSignature()
        {
            Console.WriteLine("Put here the X coordinate");
            double.TryParse(Console.ReadLine(), out double x);
            Console.WriteLine("Put here the Y coordinate");
            double.TryParse(Console.ReadLine(), out double y);
            Console.WriteLine("Put here the LineLength");
            double.TryParse(Console.ReadLine(), out double lineLength);
            Figure a = new Line(x, y, lineLength);
            Console.WriteLine("Line successfully created");
            return a;
        }
    }
}
 
