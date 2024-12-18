namespace FlightsMonitoring
{
    static class Program
    {
        static void Main()
        {
        FlightQueryHandler queryHandler = new("./flights_data.json");

        string flightsByAirline = queryHandler.GetFlightsByAirline("WizAir");
        Console.WriteLine("Flights By Airline: " + flightsByAirline);

        string flightsByDelayedStatus = queryHandler.GetFlightsByDelayedStatus();
        Console.WriteLine("Flights By Delayed Status: " + flightsByDelayedStatus);

        DateOnly departureDay = new(2023, 1, 27);

        string flightsByDepartureDay = queryHandler.GetFlightsByDepartureDay(departureDay);
        Console.WriteLine($"Flights By Departure Day {departureDay}: " + flightsByDepartureDay);

        string flightsByDepartureAndArrivalTime= queryHandler.GetFlightsByDepartureAndArrivalTime(new DateTime(2023, 3, 3, 6, 15, 25), new DateTime(2023, 3, 3, 10, 29, 25));
        Console.WriteLine("Flights By Departure And Arrival Time: " + flightsByDepartureAndArrivalTime);

        int hoursAgo = 1;

        string GetArrivedFlightsByHoursAgo = queryHandler.GetArrivedFlightsByHoursAgo(hoursAgo);
        Console.WriteLine($"Flights By Hours Ago {hoursAgo}: " + GetArrivedFlightsByHoursAgo);
        }
    }
}