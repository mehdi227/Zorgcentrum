using System.Globalization;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects; 
public record RijksRegisterNr {
    public string Value { get; set; }
    private RijksRegisterNr(string value) {
        Value = value;
    }
    public static Result<RijksRegisterNr> Create(string value) {
        if (IsRrnStructuurGeldig(value)) {
            return Result<RijksRegisterNr>.Failure(Error.Create("Dit is geen geldig rijksregister nummer."));
        }
        return Result<RijksRegisterNr>.Succes(new RijksRegisterNr(value));
    }
    public static bool IsRrnStructuurGeldig(string value) {
        //structuur controle
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length != 11 ||
            !value.All(c => c is >= '0' and <= '9')) {
            return false;
        }
        //eerste 6 digits
        string datePart = value[..6];

        int year = int.Parse(datePart[..2]);
        int month = int.Parse(datePart.Substring(2, 2));
        int day = int.Parse(datePart.Substring(4, 2));

        bool valid1900 = IsValidDate(1900 + year, month, day);
        bool valid2000 = IsValidDate(2000 + year, month, day);

        return valid1900 || valid2000;
    }
    public static bool IsValidDate(int year, int month, int day) {
        return month >= 1 && month <= 12 &&
            day >= 1 &&
            day <= DateTime.DaysInMonth(year,month);
    }
}
