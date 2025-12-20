// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCsv.Data;
public partial class GoogleContactExportRow : INotifyPropertyChanged
{
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
}