namespace SunamoCsv.Data;

/// <summary>
/// Represents the google contact export row type.
/// </summary>
public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    private string additionalName = "";
    private string additionalNameYomi = "";
    private string address1City = "";
    private string address1Country = "";
    private string address1ExtendedAddress = "";
    private string address1Formatted = "";
    private string address1POBox = "";
    private string address1PostalCode = "";
    private string address1Region = "";
    private string address1Street = "";
    private string address1Type = "";
    private string billingInformation = "";
    private string birthday = "";
    private string customField1Type = "";
    private string customField1Value = "";
    private string customField2Type = "";
    private string customField2Value = "";
    private string directoryServer = "";
    private string eMail1Type = "";
    private string eMail1Value = "";
    private string familyName = "";
    private string familyNameYomi = "";
    private string gender = "";
    private string givenName = "";
    private string givenNameYomi = "";
    private string groupMembership = "";
    private string hobby = "";
    private string initials = "";
    private string language = "";
    private string location = "";
    private string maidenName = "";
    private string mileage = "";
    private string name = "";
    private string namePrefix = "";
    private string nameSuffix = "";
    private string nickname = "";
    private string notes = "";
    private string occupation = "";
    private string organization1Department = "";
    private string organization1JobDescription = "";
    private string organization1Location = "";
    private string organization1Name = "";
    private string organization1Symbol = "";
    private string organization1Title = "";
    private string organization1Type = "";
    private string organization1YomiName = "";
    private string phone1Type = "";
    private string phone1Value = "";
    private string photo = "";
    private string priority = "";
    private string sensitivity = "";
    private string shortName = "";
    private string subject = "";
    private string website1Type = "";
    private string website1Value = "";
    private string yomiName = "";

    /// <summary>
    /// The name.
    /// </summary>
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged("Name");
        }
    }

    /// <summary>
    /// The given name.
    /// </summary>
    public string GivenName
    {
        get => givenName;
        set
        {
            givenName = value;
            OnPropertyChanged("GivenName");
        }
    }

    /// <summary>
    /// The additional name.
    /// </summary>
    public string AdditionalName
    {
        get => additionalName;
        set
        {
            additionalName = value;
            OnPropertyChanged("AdditionalName");
        }
    }

    /// <summary>
    /// The family name.
    /// </summary>
    public string FamilyName
    {
        get => familyName;
        set
        {
            familyName = value;
            OnPropertyChanged("FamilyName");
        }
    }

    /// <summary>
    /// The yomi name.
    /// </summary>
    public string YomiName
    {
        get => yomiName;
        set
        {
            yomiName = value;
            OnPropertyChanged("YomiName");
        }
    }

    /// <summary>
    /// The given name yomi.
    /// </summary>
    public string GivenNameYomi
    {
        get => givenNameYomi;
        set
        {
            givenNameYomi = value;
            OnPropertyChanged("GivenNameYomi");
        }
    }

    /// <summary>
    /// The additional name yomi.
    /// </summary>
    public string AdditionalNameYomi
    {
        get => additionalNameYomi;
        set
        {
            additionalNameYomi = value;
            OnPropertyChanged("AdditionalNameYomi");
        }
    }

    /// <summary>
    /// The family name yomi.
    /// </summary>
    public string FamilyNameYomi
    {
        get => familyNameYomi;
        set
        {
            familyNameYomi = value;
            OnPropertyChanged("FamilyNameYomi");
        }
    }

    /// <summary>
    /// The name prefix.
    /// </summary>
    public string NamePrefix
    {
        get => namePrefix;
        set
        {
            namePrefix = value;
            OnPropertyChanged("NamePrefix");
        }
    }

    /// <summary>
    /// The name suffix.
    /// </summary>
    public string NameSuffix
    {
        get => nameSuffix;
        set
        {
            nameSuffix = value;
            OnPropertyChanged("NameSuffix");
        }
    }
}
