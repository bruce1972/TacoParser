namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
           // string x = "34.073638,-84.677017,Taco Bell Acwort...";

           // cells[0] = "34.08368";
           // cells[1] = "84.677017";
           // cells[2] = "Taco Bell Acwort...";

          //  double lat = 34.073638;
           // double longitude = -84.677017;
            //string name = "Taco Bell Acwort...";

           // taco.Name = "Taco Bell Acwort...";


            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)

                //logger.LogError("Array Length is less than 3");
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]); 

            //if (!double.TryParse(cells[0], out lat))
            //{


            //    logger.LogInfo($"{cells[0]} was unable to converted to a double.");
            //}

            var longitude = double.Parse(cells[1]);

            //if (!double.TryParse(cells[1], out longitude))
            //{

            //    logger.LogInfo($"{ cells[0]} was unable to be converted to a double.");

            //}

            var name = cells[2];

            try
            {
                latitude = double.Parse(cells[0]);
                longitude = double.Parse(cells[1]);
            }
            catch
            {
                return null;
            }

            var taco = new TacoBell();
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude; 

            taco.Name = name;
            taco.Location = point; 


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return taco;
        }
    }
}