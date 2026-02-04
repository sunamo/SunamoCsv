namespace SunamoCsv.Data;

public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    /// <summary>Gets or sets the address street</summary>
    public string Address1Street
    {
        get => address1Street;
        set
        {
            address1Street = value;
            OnPropertyChanged("Address1Street");
        }
    }

    /// <summary>Gets or sets the address city</summary>
    public string Address1City
    {
        get => address1City;
        set
        {
            address1City = value;
            OnPropertyChanged("Address1City");
        }
    }

    /// <summary>Gets or sets the address PO Box</summary>
    public string Address1POBox
    {
        get => address1POBox;
        set
        {
            address1POBox = value;
            OnPropertyChanged("Address1POBox");
        }
    }

    /// <summary>Gets or sets the address region</summary>
    public string Address1Region
    {
        get => address1Region;
        set
        {
            address1Region = value;
            OnPropertyChanged("Address1Region");
        }
    }

    /// <summary>Gets or sets the address postal code</summary>
    public string Address1PostalCode
    {
        get => address1PostalCode;
        set
        {
            address1PostalCode = value;
            OnPropertyChanged("Address1PostalCode");
        }
    }

    /// <summary>Gets or sets the address country</summary>
    public string Address1Country
    {
        get => address1Country;
        set
        {
            address1Country = value;
            OnPropertyChanged("Address1Country");
        }
    }

    /// <summary>Gets or sets the address extended information</summary>
    public string Address1ExtendedAddress
    {
        get => address1ExtendedAddress;
        set
        {
            address1ExtendedAddress = value;
            OnPropertyChanged("Address1ExtendedAddress");
        }
    }

    /// <summary>Gets or sets the organization type</summary>
    public string Organization1Type
    {
        get => organization1Type;
        set
        {
            organization1Type = value;
            OnPropertyChanged("Organization1Type");
        }
    }

    /// <summary>Gets or sets the organization name</summary>
    public string Organization1Name
    {
        get => organization1Name;
        set
        {
            organization1Name = value;
            OnPropertyChanged("Organization1Name");
        }
    }

    /// <summary>Gets or sets the phonetic organization name (Yomi)</summary>
    public string Organization1YomiName
    {
        get => organization1YomiName;
        set
        {
            organization1YomiName = value;
            OnPropertyChanged("Organization1YomiName");
        }
    }

    /// <summary>Gets or sets the organization title/position</summary>
    public string Organization1Title
    {
        get => organization1Title;
        set
        {
            organization1Title = value;
            OnPropertyChanged("Organization1Title");
        }
    }

    /// <summary>Gets or sets the organization department</summary>
    public string Organization1Department
    {
        get => organization1Department;
        set
        {
            organization1Department = value;
            OnPropertyChanged("Organization1Department");
        }
    }

    /// <summary>Gets or sets the organization symbol</summary>
    public string Organization1Symbol
    {
        get => organization1Symbol;
        set
        {
            organization1Symbol = value;
            OnPropertyChanged("Organization1Symbol");
        }
    }

    /// <summary>Gets or sets the organization location</summary>
    public string Organization1Location
    {
        get => organization1Location;
        set
        {
            organization1Location = value;
            OnPropertyChanged("Organization1Location");
        }
    }

    /// <summary>Gets or sets the organization job description</summary>
    public string Organization1JobDescription
    {
        get => organization1JobDescription;
        set
        {
            organization1JobDescription = value;
            OnPropertyChanged("Organization1JobDescription");
        }
    }

    /// <summary>Gets or sets the website type</summary>
    public string Website1Type
    {
        get => website1Type;
        set
        {
            website1Type = value;
            OnPropertyChanged("Website1Type");
        }
    }

    /// <summary>Gets or sets the website URL</summary>
    public string Website1Value
    {
        get => website1Value;
        set
        {
            website1Value = value;
            OnPropertyChanged("Website1Value");
        }
    }

    /// <summary>Gets or sets the first custom field type</summary>
    public string CustomField1Type
    {
        get => customField1Type;
        set
        {
            customField1Type = value;
            OnPropertyChanged("CustomField1Type");
        }
    }

    /// <summary>Gets or sets the first custom field value</summary>
    public string CustomField1Value
    {
        get => customField1Value;
        set
        {
            customField1Value = value;
            OnPropertyChanged("CustomField1Value");
        }
    }

    /// <summary>Gets or sets the second custom field type</summary>
    public string CustomField2Type
    {
        get => customField2Type;
        set
        {
            customField2Type = value;
            OnPropertyChanged("CustomField2Type");
        }
    }

    /// <summary>Gets or sets the second custom field value</summary>
    public string CustomField2Value
    {
        get => customField2Value;
        set
        {
            customField2Value = value;
            OnPropertyChanged("CustomField2Value");
        }
    }

    /// <summary>Occurs when a property value changes</summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}