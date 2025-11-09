using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment5
{
    interface IShape
    {
        double Area { get; }
        void DisplayShapeInfo();
    }

    interface ICircle : IShape
    {
        double Radius { get; }
    }

    interface IRectangle : IShape
    {
        double Width { get; }
        double Height { get; }
    }

    class Circle : ICircle
    {
        public double Radius { get; set; }
        public double Area => Math.PI * Radius * Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle - Radius: {Radius}, Area: {Area:F2}");
        }
    }

    class Rectangle : IRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area => Width * Height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle - Width: {Width}, Height: {Height}, Area: {Area:F2}");
        }
    }

    interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string role);
    }

    class BasicAuthenticationService : IAuthenticationService
    {
        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "admin123" },
            { "user", "user123" }
        };

        private Dictionary<string, string> userRoles = new Dictionary<string, string>
        {
            { "admin", "Administrator" },
            { "user", "User" }
        };

        public bool AuthenticateUser(string username, string password)
        {
            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine($"User '{username}' authenticated successfully");
                return true;
            }
            Console.WriteLine($"Authentication failed for user '{username}'");
            return false;
        }

        public bool AuthorizeUser(string username, string role)
        {
            if (userRoles.ContainsKey(username) && userRoles[username] == role)
            {
                Console.WriteLine($"User '{username}' is authorized for role '{role}'");
                return true;
            }
            Console.WriteLine($"User '{username}' is NOT authorized for role '{role}'");
            return false;
        }
    }

    interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient}: {message}");
        }
    }

    class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }

    class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending Push Notification to {recipient}: {message}");
        }
    }

    interface IPayment
    {
        void Pay(decimal amount);
    }

    class PayPalPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal");
        }
    }

    class StripePayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Stripe");
        }
    }

    class CashPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Cash");
        }
    }

    class OrderService
    {
        private readonly IPayment payment;

        public OrderService(IPayment payment)
        {
            this.payment = payment;
        }

        public void PlaceOrder(decimal amount)
        {
            Console.WriteLine("Order placed");
            payment.Pay(amount);
        }
    }

    class ShapeBase
    {
        public double Width { get; }
        public double Height { get; }

        public ShapeBase(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public virtual double Area()
        {
            return Width * Height;
        }
    }

    class RectangleShape : ShapeBase
    {
        public RectangleShape(double width, double height) : base(width, height)
        {
        }
    }

    class SquareShape : ShapeBase
    {
        public SquareShape(double side) : base(side, side)
        {
        }
    }

    class CircleShape : ShapeBase
    {
        public double Radius { get; }

        public CircleShape(double radius) : base(radius * 2, radius * 2)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class LineShape : ShapeBase
    {
        public LineShape(double width, double height) : base(width, height)
        {
        }

        public override double Area()
        {
            return 0;
        }
    }

    interface IShapeComposition
    {
        string Description();
    }

    interface IHasArea : IShapeComposition
    {
        double Area();
    }

    interface IHasLength : IShapeComposition
    {
        double Length();
    }

    class RectangleBehavior : IHasArea
    {
        private double width;
        private double height;

        public RectangleBehavior(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area()
        {
            return width * height;
        }

        public string Description()
        {
            return $"Rectangle: {width} x {height}";
        }
    }

    class SquareBehavior : IHasArea
    {
        private double side;

        public SquareBehavior(double side)
        {
            this.side = side;
        }

        public double Area()
        {
            return side * side;
        }

        public string Description()
        {
            return $"Square: {side}";
        }
    }

    class CircleBehavior : IHasArea
    {
        private double radius;

        public CircleBehavior(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public string Description()
        {
            return $"Circle: radius {radius}";
        }
    }

    class LineBehavior : IHasLength
    {
        private double length;

        public LineBehavior(double length)
        {
            this.length = length;
        }

        public double Length()
        {
            return length;
        }

        public string Description()
        {
            return $"Line: {length}";
        }
    }

    class ShapeComposition
    {
        private IShapeComposition behavior;

        public ShapeComposition(IShapeComposition behavior)
        {
            this.behavior = behavior;
        }

        public bool HasArea => behavior is IHasArea;
        public bool HasLength => behavior is IHasLength;

        public double? Area()
        {
            if (behavior is IHasArea areaShape)
                return areaShape.Area();
            return null;
        }

        public double? Length()
        {
            if (behavior is IHasLength lengthShape)
                return lengthShape.Length();
            return null;
        }

        public override string ToString()
        {
            string result = behavior.Description();
            if (HasArea)
                result += $", Area: {Area():F2}";
            if (HasLength)
                result += $", Length: {Length():F2}";
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Question 1: IShape Interface ===");
            Circle circle = new Circle(5);
            Rectangle rect = new Rectangle(10, 5);
            circle.DisplayShapeInfo();
            rect.DisplayShapeInfo();

            Console.WriteLine("\n=== Question 2: Authentication Service ===");
            IAuthenticationService authService = new BasicAuthenticationService();
            authService.AuthenticateUser("admin", "admin123");
            authService.AuthorizeUser("admin", "Administrator");
            authService.AuthenticateUser("user", "wrongpass");

            Console.WriteLine("\n=== Question 3: Notification Service ===");
            INotificationService emailService = new EmailNotificationService();
            INotificationService smsService = new SmsNotificationService();
            INotificationService pushService = new PushNotificationService();

            emailService.SendNotification("user@example.com", "Welcome!");
            smsService.SendNotification("+123456789", "Your code is 1234");
            pushService.SendNotification("DeviceID123", "New message received");

            Console.WriteLine("\n=== Question 4: Payment System with Dependency Injection ===");
            OrderService paypalOrder = new OrderService(new PayPalPayment());
            paypalOrder.PlaceOrder(100.50m);

            OrderService stripeOrder = new OrderService(new StripePayment());
            stripeOrder.PlaceOrder(75.25m);

            OrderService cashOrder = new OrderService(new CashPayment());
            cashOrder.PlaceOrder(50.00m);

            Console.WriteLine("\n=== Question 5 Part 1: Inheritance-based Shapes ===");
            RectangleShape rectShape = new RectangleShape(10, 5);
            SquareShape squareShape = new SquareShape(7);
            CircleShape circleShape = new CircleShape(3.5);
            LineShape lineShape = new LineShape(10, 5);

            Console.WriteLine($"Rectangle Area: {rectShape.Area():F2}");
            Console.WriteLine($"Square Area: {squareShape.Area():F2}");
            Console.WriteLine($"Circle Area: {circleShape.Area():F2}");
            Console.WriteLine($"Line Area: {lineShape.Area():F2}");

            Console.WriteLine("\n=== Question 5 Part 3: Composition-based Shapes ===");
            List<ShapeComposition> shapes = new List<ShapeComposition>
            {
                new ShapeComposition(new RectangleBehavior(10, 5)),
                new ShapeComposition(new SquareBehavior(7)),
                new ShapeComposition(new CircleBehavior(3.5)),
                new ShapeComposition(new LineBehavior(12))
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

            double totalArea = shapes
                .Where(s => s.HasArea)
                .Sum(s => s.Area() ?? 0);

            Console.WriteLine($"\nTotal Area of all shapes: {totalArea:F2}");

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
