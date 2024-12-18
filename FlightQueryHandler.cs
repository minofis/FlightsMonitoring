namespace FlightsMonitoring
{
    public class FlightQueryHandler
    {
        public List<Flight> Flights { get; set; }
        public FlightQueryHandler(string filePath)
        {
            FlightInformationSystem flightInformationSystem = new();
            Flights = flightInformationSystem.DeserializeFlightInformation(filePath);
        }
        public string GetFlightsByAirline(string airline)
        {
            List<Flight> sortedFlights = Flights
                .Where(f => f.Airline == airline)
                .OrderBy(f => f.DepartureTime)
                .ToList();

            if(sortedFlights.Any())
            {
                FlightInformationSystem flightInformationSystem = new();
                string flightsJson = flightInformationSystem.SerializeFlightInformation(sortedFlights);
                return flightsJson;
            }
            return "There are no flights by this airline";
            throw new ArgumentException("There are no flights by this airline");     
        }

        public string GetFlightsByDelayedStatus()
        {
            List<Flight> sortedFlights = Flights
                .Where(f => f.Status == FlightStatus.Delayed && f.DepartureTime > DateTime.Now)
                .OrderBy(f => f.DepartureTime - DateTime.Now)
                .ToList();

            if(sortedFlights.Any())
            {
                FlightInformationSystem flightInformationSystem = new();
                string flightsJson = flightInformationSystem.SerializeFlightInformation(sortedFlights);
                return flightsJson;
            }
            return "There are no flights by delayed status";
            throw new ArgumentException("There are no flights by delayed status");
        }

        public string GetFlightsByDepartureDay(DateOnly departureDay)
        {
            List<Flight> sortedFlights = Flights
                .Where(f => f.DepartureTime == departureDay.ToDateTime(TimeOnly.MinValue))
                .OrderBy(f => f.DepartureTime)
                .ToList();

            if(sortedFlights.Any())
            {
                FlightInformationSystem flightInformationSystem = new();
                string flightsJson = flightInformationSystem.SerializeFlightInformation(sortedFlights);
                return flightsJson;
            }
            return "There are no flights by this departure day";
            throw new ArgumentException("There are no flights by this departure day");
        }

        public string GetFlightsByDepartureAndArrivalTime(DateTime departureTime, DateTime arrivalTime)
        {
            List<Flight> sortedFlights = Flights
                .Where(f => 
                    f.DepartureTime == departureTime &&
                    f.ArrivalTime == arrivalTime &&
                    !string.IsNullOrEmpty(f.Destination))
                .OrderBy(f => f.DepartureTime)
                .ToList();

            if(sortedFlights.Any())
            {
                FlightInformationSystem flightInformationSystem = new();
                string flightsJson = flightInformationSystem.SerializeFlightInformation(sortedFlights);
                return flightsJson;
            }
            return "There are no flights by these departure and arrival time";
            throw new ArgumentException("There are no flights by these departure and arrival time");
        }

        public string GetArrivedFlightsByHoursAgo(int countOfHoursAgo)
        {
            DateTime timeOfArrive = DateTime.Now.AddHours(-countOfHoursAgo);

            List<Flight> sortedFlights = Flights
                .Where(f => f.ArrivalTime >= timeOfArrive && f.ArrivalTime <= DateTime.Now)
                .OrderBy(f => f.ArrivalTime)
                .ToList();

            if (sortedFlights.Any())
            {
                FlightInformationSystem flightInformationSystem = new();
                string flightsJson = flightInformationSystem.SerializeFlightInformation(sortedFlights);
                return flightsJson;
            }
            return "There are no flights arrived one hour ago";
            throw new ArgumentException("There are no flights arrived one hour ago");
        }
    }
}