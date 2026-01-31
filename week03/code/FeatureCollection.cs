public class FeatureCollection // Represents the root object of the USGS GeoJSON response
{
    public List<Feature> Features { get; set; } // List of earthquakes returned by the API
}

public class Feature // Represents a single earthquake entry
{
    public Properties Properties { get; set; }  // Contains the main data about the earthquake
}

public class Properties // Represents the properties of an earthquake
{
    public double? Mag { get; set; } // Represents the properties of an earthquake
    public string Place { get; set; } // Location where the earthquake happened
}