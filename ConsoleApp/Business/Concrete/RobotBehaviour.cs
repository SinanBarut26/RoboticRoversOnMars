﻿using ConsoleApp.Business.Interfaces;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Extensions;
using ConsoleApp.Utilities;

namespace ConsoleApp.Business.Concrete
{
    public class RobotBehaviour : IRobotBehaviour
    {
        private readonly IRobotInfo _robotInfo;
        private readonly IPlateauInfo _plateauInfo;
        public RobotBehaviour(IRobotInfo robotInfo, IPlateauInfo plateauInfo)
        {
            _robotInfo = robotInfo;
            _plateauInfo = plateauInfo;
        }
        public IRobotInfo ChangeDirection(char turn)
        {
            _robotInfo.direction = turn == 'R'
                 ? (Direction)((_robotInfo.direction.GetHashCode() + 1) % 4)
                 : (Direction)((_robotInfo.direction.GetHashCode() + 4 - 1) % 4);
            return _robotInfo;
        }

        public IRobotInfo Move()
        {
            switch (_robotInfo.direction)
            {
                case Direction.Nort:
                    if (_robotInfo.robot_y >= _plateauInfo.max_y)
                        throw new RobotException(ExceptionEnum.OutOfPlateau.GetExceptionEnum());
                    _robotInfo.robot_y++;
                    break;
                case Direction.East:
                    if (_robotInfo.robot_x >= _plateauInfo.max_x)
                        throw new RobotException(ExceptionEnum.OutOfPlateau.GetExceptionEnum());
                    _robotInfo.robot_x++;
                    break;
                case Direction.South:
                    if (_robotInfo.robot_y <= _plateauInfo.min_y)
                        throw new RobotException(ExceptionEnum.OutOfPlateau.GetExceptionEnum());
                    _robotInfo.robot_y--;
                    break;
                case Direction.West:
                    if (_robotInfo.robot_x <= _plateauInfo.min_x)
                        throw new RobotException(ExceptionEnum.OutOfPlateau.GetExceptionEnum());
                    _robotInfo.robot_x--;
                    break;
            }
            return _robotInfo;
        }

        public IRobotContact NextMove()
        {
            throw new System.NotImplementedException();
        }
    }
}