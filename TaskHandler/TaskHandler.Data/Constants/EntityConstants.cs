namespace TaskHandler.Data.Constants;

public static class EntityConstants
{
    public const int MoneyPrecision = 18;
    public const int MoneyScale = 2;

    public static class User
    {
        public const int FirstNameMaxLength = 50;
        public const int LastNameMaxLength = 50;
    }

    public static class Client
    {
        public const int NameMaxLength = 100;
        public const int EmailMaxLength = 256;
        public const int PhoneMaxLength = 30;
    }

    public static class Project
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }

    public static class ProjectTask
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }

    public static class TimeEntry
    {
        public const int DescriptionMaxLength = 500;
        public const int MinDurationMinutes = 1;
        public const int MaxDurationMinutes = 24 * 60;
        public const int SourceMaxLength = 20;
    }

    public static class WeeklyTemplate
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
