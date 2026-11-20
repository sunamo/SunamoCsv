namespace SunamoCsv.Data;

public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    /// <summary>
    /// The address 1 street.
    /// </summary>
    public string Address1Street
    {
        get => address1Street;
        set
        {
            address1Street = value;
            OnPropertyChanged("Address1Street");
        }
    }

    /// <summary>
    /// The address 1 city.
    /// </summary>
    public string Address1City
    {
        get => address1City;
        set
        {
            address1City = value;
            OnPropertyChanged("Address1City");
        }
    }

    /// <summary>
    /// The address 1 PO box.
    /// </summary>
    public string Address1POBox
    {
        get => address1POBox;
        set
        {
            address1POBox = value;
            OnPropertyChanged("Address1POBox");
        }
    }

    /// <summary>
    /// The address 1 region.
    /// </summary>
    public string Address1Region
    {
        get => address1Region;
        set
        {
            address1Region = value;
            OnPropertyChanged("Address1Region");
        }
    }

    /// <summary>
    /// The address 1 postal code.
    /// </summary>
    public string Address1PostalCode
    {
        get => address1PostalCode;
        set
        {
            address1PostalCode = value;
            OnPropertyChanged("Address1PostalCode");
        }
    }

    /// <summary>
    /// The address 1 country.
    /// </summary>
    public string Address1Country
    {
        get => address1Country;
        set
        {
            address1Country = value;
            OnPropertyChanged("Address1Country");
        }
    }

    /// <summary>
    /// The address 1 extended address.
    /// </summary>
    public string Address1ExtendedAddress
    {
        get => address1ExtendedAddress;
        set
        {
            address1ExtendedAddress = value;
            OnPropertyChanged("Address1ExtendedAddress");
        }
    }

    /// <summary>
    /// The organization 1 type.
    /// </summary>
    public string Organization1Type
    {
        get => organization1Type;
        set
        {
            organization1Type = value;
            OnPropertyChanged("Organization1Type");
        }
    }

    /// <summary>
    /// The organization 1 name.
    /// </summary>
    public string Organization1Name
    {
        get => organization1Name;
        set
        {
            organization1Name = value;
            OnPropertyChanged("Organization1Name");
        }
    }

    /// <summary>
    /// The organization 1 yomi name.
    /// </summary>
    public string Organization1YomiName
    {
        get => organization1YomiName;
        set
        {
            organization1YomiName = value;
            OnPropertyChanged("Organization1YomiName");
        }
    }

    /// <summary>
    /// The organization 1 title.
    /// </summary>
    public string Organization1Title
    {
        get => organization1Title;
        set
        {
            organization1Title = value;
            OnPropertyChanged("Organization1Title");
        }
    }

    /// <summary>
    /// The organization 1 department.
    /// </summary>
    public string Organization1Department
    {
        get => organization1Department;
        set
        {
            organization1Department = value;
            OnPropertyChanged("Organization1Department");
        }
    }

    /// <summary>
    /// The organization 1 symbol.
    /// </summary>
    public string Organization1Symbol
    {
        get => organization1Symbol;
        set
        {
            organization1Symbol = value;
            OnPropertyChanged("Organization1Symbol");
        }
    }

    /// <summary>
    /// The organization 1 location.
    /// </summary>
    public string Organization1Location
    {
        get => organization1Location;
        set
        {
            organization1Location = value;
            OnPropertyChanged("Organization1Location");
        }
    }

    /// <summary>
    /// The organization 1 job description.
    /// </summary>
    public string Organization1JobDescription
    {
        get => organization1JobDescription;
        set
        {
            organization1JobDescription = value;
            OnPropertyChanged("Organization1JobDescription");
        }
    }

    /// <summary>
    /// The website 1 type.
    /// </summary>
    public string Website1Type
    {
        get => website1Type;
        set
        {
            website1Type = value;
            OnPropertyChanged("Website1Type");
        }
    }

    /// <summary>
    /// The website 1 value.
    /// </summary>
    public string Website1Value
    {
        get => website1Value;
        set
        {
            website1Value = value;
            OnPropertyChanged("Website1Value");
        }
    }

    /// <summary>
    /// The custom field 1 type.
    /// </summary>
    public string CustomField1Type
    {
        get => customField1Type;
        set
        {
            customField1Type = value;
            OnPropertyChanged("CustomField1Type");
        }
    }

    /// <summary>
    /// The custom field 1 value.
    /// </summary>
    public string CustomField1Value
    {
        get => customField1Value;
        set
        {
            customField1Value = value;
            OnPropertyChanged("CustomField1Value");
        }
    }

    /// <summary>
    /// The custom field 2 type.
    /// </summary>
    public string CustomField2Type
    {
        get => customField2Type;
        set
        {
            customField2Type = value;
            OnPropertyChanged("CustomField2Type");
        }
    }

    /// <summary>
    /// The custom field 2 value.
    /// </summary>
    public string CustomField2Value
    {
        get => customField2Value;
        set
        {
            customField2Value = value;
            OnPropertyChanged("CustomField2Value");
        }
    }

    /// <summary>
    /// The property changed.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
