using Newtonsoft.Json;

namespace FlightsMonitoring
{
    public class FlightInformationSystem
    {
        public List<Flight> DeserializeFlightInformation(string filePath)
        {
            string jsonFlights = File.ReadAllText(filePath);
            var flightsList = JsonConvert.DeserializeObject<FlightsList>(jsonFlights);
            return flightsList?.Flights ?? new List<Flight>();
        }
        public string SerializeFlightInformation(List<Flight> flightsList)
        {
            return JsonConvert.SerializeObject(flightsList, Formatting.Indented);
        }
    }
}