namespace Numeric_base_converter.Services;

public interface IConverter {
    public string To(string n, int destinyBase);
    public string From(string n, int fromBase);
}