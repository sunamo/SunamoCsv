// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCsv.Data;

public class GoogleContactExportRow : INotifyPropertyChanged
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

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged("Name");
        }
    }

    public string GivenName
    {
        get => givenName;
        set
        {
            givenName = value;
            OnPropertyChanged("GivenName");
        }
    }

    public string AdditionalName
    {
        get => additionalName;
        set
        {
            additionalName = value;
            OnPropertyChanged("AdditionalName");
        }
    }

    public string FamilyName
    {
        get => familyName;
        set
        {
            familyName = value;
            OnPropertyChanged("FamilyName");
        }
    }

    public string YomiName
    {
        get => yomiName;
        set
        {
            yomiName = value;
            OnPropertyChanged("YomiName");
        }
    }

    public string GivenNameYomi
    {
        get => givenNameYomi;
        set
        {
            givenNameYomi = value;
            OnPropertyChanged("GivenNameYomi");
        }
    }

    public string AdditionalNameYomi
    {
        get => additionalNameYomi;
        set
        {
            additionalNameYomi = value;
            OnPropertyChanged("AdditionalNameYomi");
        }
    }

    public string FamilyNameYomi
    {
        get => familyNameYomi;
        set
        {
            familyNameYomi = value;
            OnPropertyChanged("FamilyNameYomi");
        }
    }

    public string NamePrefix
    {
        get => namePrefix;
        set
        {
            namePrefix = value;
            OnPropertyChanged("NamePrefix");
        }
    }

    public string NameSuffix
    {
        get => nameSuffix;
        set
        {
            nameSuffix = value;
            OnPropertyChanged("NameSuffix");
        }
    }

    public string Initials
    {
        get => initials;
        set
        {
            initials = value;
            OnPropertyChanged("Initials");
        }
    }

    public string Nickname
    {
        get => nickname;
        set
        {
            nickname = value;
            OnPropertyChanged("Nickname");
        }
    }

    public string ShortName
    {
        get => shortName;
        set
        {
            shortName = value;
            OnPropertyChanged("ShortName");
        }
    }

    public string MaidenName
    {
        get => maidenName;
        set
        {
            maidenName = value;
            OnPropertyChanged("MaidenName");
        }
    }

    public string Birthday
    {
        get => birthday;
        set
        {
            birthday = value;
            OnPropertyChanged("Birthday");
        }
    }

    public string Gender
    {
        get => gender;
        set
        {
            gender = value;
            OnPropertyChanged("Gender");
        }
    }

    public string Location
    {
        get => location;
        set
        {
            location = value;
            OnPropertyChanged("Location");
        }
    }

    public string BillingInformation
    {
        get => billingInformation;
        set
        {
            billingInformation = value;
            OnPropertyChanged("BillingInformation");
        }
    }

    public string DirectoryServer
    {
        get => directoryServer;
        set
        {
            directoryServer = value;
            OnPropertyChanged("DirectoryServer");
        }
    }

    public string Mileage
    {
        get => mileage;
        set
        {
            mileage = value;
            OnPropertyChanged("Mileage");
        }
    }

    public string Occupation
    {
        get => occupation;
        set
        {
            occupation = value;
            OnPropertyChanged("Occupation");
        }
    }

    public string Hobby
    {
        get => hobby;
        set
        {
            hobby = value;
            OnPropertyChanged("Hobby");
        }
    }

    public string Sensitivity
    {
        get => sensitivity;
        set
        {
            sensitivity = value;
            OnPropertyChanged("Sensitivity");
        }
    }

    public string Priority
    {
        get => priority;
        set
        {
            priority = value;
            OnPropertyChanged("Priority");
        }
    }

    public string Subject
    {
        get => subject;
        set
        {
            subject = value;
            OnPropertyChanged("Subject");
        }
    }

    public string Notes
    {
        get => notes;
        set
        {
            notes = value;
            OnPropertyChanged("Notes");
        }
    }

    public string Language
    {
        get => language;
        set
        {
            language = value;
            OnPropertyChanged("Language");
        }
    }

    public string Photo
    {
        get => photo;
        set
        {
            photo = value;
            OnPropertyChanged("Photo");
        }
    }

    public string GroupMembership
    {
        get => groupMembership;
        set
        {
            groupMembership = value;
            OnPropertyChanged("GroupMembership");
        }
    }

    public string EMail1Type
    {
        get => eMail1Type;
        set
        {
            eMail1Type = value;
            OnPropertyChanged("EMail1Type");
        }
    }

    public string EMail1Value
    {
        get => eMail1Value;
        set
        {
            eMail1Value = value;
            OnPropertyChanged("EMail1Value");
        }
    }

    public string Phone1Type
    {
        get => phone1Type;
        set
        {
            phone1Type = value;
            OnPropertyChanged("Phone1Type");
        }
    }

    public string Phone1Value
    {
        get => phone1Value;
        set
        {
            phone1Value = value;
            OnPropertyChanged("Phone1Value");
        }
    }

    public string Address1Type
    {
        get => address1Type;
        set
        {
            address1Type = value;
            OnPropertyChanged("Address1Type");
        }
    }

    public string Address1Formatted
    {
        get => address1Formatted;
        set
        {
            address1Formatted = value;
            OnPropertyChanged("Address1Formatted");
        }
    }

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