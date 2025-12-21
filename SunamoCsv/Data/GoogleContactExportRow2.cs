namespace SunamoCsv.Data;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    public string Address1Street
    {
        get => address1Street;
        set
        {
            address1Street = value;
            OnPropertyChanged("Address1Street");
        }
    }

    public string Address1City
    {
        get => address1City;
        set
        {
            address1City = value;
            OnPropertyChanged("Address1City");
        }
    }

    public string Address1POBox
    {
        get => address1POBox;
        set
        {
            address1POBox = value;
            OnPropertyChanged("Address1POBox");
        }
    }

    public string Address1Region
    {
        get => address1Region;
        set
        {
            address1Region = value;
            OnPropertyChanged("Address1Region");
        }
    }

    public string Address1PostalCode
    {
        get => address1PostalCode;
        set
        {
            address1PostalCode = value;
            OnPropertyChanged("Address1PostalCode");
        }
    }

    public string Address1Country
    {
        get => address1Country;
        set
        {
            address1Country = value;
            OnPropertyChanged("Address1Country");
        }
    }

    public string Address1ExtendedAddress
    {
        get => address1ExtendedAddress;
        set
        {
            address1ExtendedAddress = value;
            OnPropertyChanged("Address1ExtendedAddress");
        }
    }

    public string Organization1Type
    {
        get => organization1Type;
        set
        {
            organization1Type = value;
            OnPropertyChanged("Organization1Type");
        }
    }

    public string Organization1Name
    {
        get => organization1Name;
        set
        {
            organization1Name = value;
            OnPropertyChanged("Organization1Name");
        }
    }

    public string Organization1YomiName
    {
        get => organization1YomiName;
        set
        {
            organization1YomiName = value;
            OnPropertyChanged("Organization1YomiName");
        }
    }

    public string Organization1Title
    {
        get => organization1Title;
        set
        {
            organization1Title = value;
            OnPropertyChanged("Organization1Title");
        }
    }

    public string Organization1Department
    {
        get => organization1Department;
        set
        {
            organization1Department = value;
            OnPropertyChanged("Organization1Department");
        }
    }

    public string Organization1Symbol
    {
        get => organization1Symbol;
        set
        {
            organization1Symbol = value;
            OnPropertyChanged("Organization1Symbol");
        }
    }

    public string Organization1Location
    {
        get => organization1Location;
        set
        {
            organization1Location = value;
            OnPropertyChanged("Organization1Location");
        }
    }

    public string Organization1JobDescription
    {
        get => organization1JobDescription;
        set
        {
            organization1JobDescription = value;
            OnPropertyChanged("Organization1JobDescription");
        }
    }

    public string Website1Type
    {
        get => website1Type;
        set
        {
            website1Type = value;
            OnPropertyChanged("Website1Type");
        }
    }

    public string Website1Value
    {
        get => website1Value;
        set
        {
            website1Value = value;
            OnPropertyChanged("Website1Value");
        }
    }

    public string CustomField1Type
    {
        get => customField1Type;
        set
        {
            customField1Type = value;
            OnPropertyChanged("CustomField1Type");
        }
    }

    public string CustomField1Value
    {
        get => customField1Value;
        set
        {
            customField1Value = value;
            OnPropertyChanged("CustomField1Value");
        }
    }

    public string CustomField2Type
    {
        get => customField2Type;
        set
        {
            customField2Type = value;
            OnPropertyChanged("CustomField2Type");
        }
    }

    public string CustomField2Value
    {
        get => customField2Value;
        set
        {
            customField2Value = value;
            OnPropertyChanged("CustomField2Value");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propName)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
}