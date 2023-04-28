namespace Reports.Repositories;

public class ConfigurationSettings
{
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string BaseUrl { get; set; }


    public void ValidateConfiguration()
    {
        if (string.IsNullOrEmpty(ConsumerKey))
            throw new ArgumentException("ConsumerKey has not been set in app settings");

        if (string.IsNullOrEmpty(ConsumerSecret))
            throw new ArgumentException("ConsumerSecret has not been set in app settings");

        if (string.IsNullOrEmpty(BaseUrl))
            throw new ArgumentException("BaseUrl has not been set in app settings");
    }
}