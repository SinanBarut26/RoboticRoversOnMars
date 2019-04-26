namespace ConsoleApp
{
    public static class Extensions
    {
        //public static Direction NextDirection(this RobotInfo currentInfo, Turn turn, PlateauArea plateauArea)
        //{
        //    return turn == Turn.Right
        //        ? (Direction)((currentInfo.direction.GetHashCode() + 1) % 4)
        //        : (Direction)((currentInfo.direction.GetHashCode() + 4 - 1) % 4);
        //}

        public static RobotInfo Move(this RobotInfo current)
        {
            switch (current.direction)
            {
                case Direction.Nort:
                    current.robot_y++;
                    break;
                case Direction.East:
                    current.robot_x++;
                    break;
                case Direction.South:
                    current.robot_y--;
                    break;
                case Direction.West:
                    current.robot_x--;
                    break;
            }
            return current;
        }

        public static RobotInfo NextDirection(this RobotInfo currentInfo, char turn)
        {
            currentInfo.direction = turn == 'R'
                ? (Direction)((currentInfo.direction.GetHashCode() + 1) % 4)
                : (Direction)((currentInfo.direction.GetHashCode() + 4 - 1) % 4);
            return currentInfo;
        }
    }
}
