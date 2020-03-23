using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Interface;
using System;
using System.Collections.Generic;

namespace Ecomsolutions.Core.Model
{
    /// <summary>
    /// Map that has closes a route whenever a robot is falling off the edge at that route
    /// </summary>
    public class MartianMap : IMap
    {
        /// <summary>
        /// Routes that are closed for navigation for any kind of units
        /// </summary>
        private readonly HashSet<Position> closedRoutes = new HashSet<Position>();

        /// <summary>
        /// Max X-Y coordinates
        /// </summary>
        public Coordinates MaxCoordinates { get; }


        /// <summary></summary>
        /// <param name="x">Maximal X coordenate for the map</param>
        /// <param name="y">Maximal Y coordinate for the map</param>
        public MartianMap(int x, int y) : this(new Coordinates(x, y)) { }

        /// <summary></summary>
        /// <param name="coordinates">Maximal coordenates for the map</param>
        public MartianMap(Coordinates coordinates)
        {
            if (coordinates.X < 0 || coordinates.Y < 0) 
                throw new ArgumentException("Martian map coordinates cannot be less than 0");

            MaxCoordinates = new Coordinates(coordinates.X, coordinates.Y);
        }

        public NavigationResult Navigate(Position navigateToPosition)
        {
            // if the navigation can't be done, because there's a "scent" of a lost robot - return "failure"
            if (closedRoutes.Contains(navigateToPosition))
                return NavigationResult.Failure;

            // if the navigation request is not out of the map's range - return "success"
            if (CheckIfThePositionIsValid(navigateToPosition))
                return NavigationResult.Success;

            // the robot has fallen out of the map
            // 1. close the navigation path for the next robots
            // 2. return the "Lost" result
            closedRoutes.Add(navigateToPosition);
            return NavigationResult.Lost;
        }

        /// <summary>
        /// Checks if a position is valid for a unit to drop off
        /// </summary>
        public bool CheckIfThePositionIsValid(Position position)
        {
            return
                position.X >= 0
                &&
                position.X <= MaxCoordinates.X
                &&
                position.Y >= 0
                &&
                position.Y <= MaxCoordinates.Y;
        }
    }
}
