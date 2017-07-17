namespace RectangleIntersection
{
    class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double point1;
        private double point2;

        public Rectangle(string id, double width, double height, double point1, double point2)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.point1 = point1;
            this.point2 = point2;
        }

        public bool IsIntersected(Rectangle rectangle)
        {
            if (rectangle.point1 + rectangle.width >= this.point1
                && rectangle.point1 <= this.point1 + this.width
                && rectangle.point2 >= this.point2 - this.height
                && rectangle.point2 - rectangle.height <= this.point2)
            {
                return true;
            }

            return false;
        }
    }
}