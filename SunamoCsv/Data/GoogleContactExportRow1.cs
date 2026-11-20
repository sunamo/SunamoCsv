namespace SunamoCsv.Data;

public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    /// <summary>
    /// The initials.
    /// </summary>
    public string Initials
    {
        get => initials;
        set
        {
            initials = value;
            OnPropertyChanged("Initials");
        }
    }

    /// <summary>
    /// The nickname.
    /// </summary>
    public string Nickname
    {
        get => nickname;
        set
        {
            nickname = value;
            OnPropertyChanged("Nickname");
        }
    }

    /// <summary>
    /// The short name.
    /// </summary>
    public string ShortName
    {
        get => shortName;
        set
        {
            shortName = value;
            OnPropertyChanged("ShortName");
        }
    }

    /// <summary>
    /// The maiden name.
    /// </summary>
    public string MaidenName
    {
        get => maidenName;
        set
        {
            maidenName = value;
            OnPropertyChanged("MaidenName");
        }
    }

    /// <summary>
    /// The birthday.
    /// </summary>
    public string Birthday
    {
        get => birthday;
        set
        {
            birthday = value;
            OnPropertyChanged("Birthday");
        }
    }

    /// <summary>
    /// The gender.
    /// </summary>
    public string Gender
    {
        get => gender;
        set
        {
            gender = value;
            OnPropertyChanged("Gender");
        }
    }

    /// <summary>
    /// The location.
    /// </summary>
    public string Location
    {
        get => location;
        set
        {
            location = value;
            OnPropertyChanged("Location");
        }
    }

    /// <summary>
    /// The billing information.
    /// </summary>
    public string BillingInformation
    {
        get => billingInformation;
        set
        {
            billingInformation = value;
            OnPropertyChanged("BillingInformation");
        }
    }

    /// <summary>
    /// The directory server.
    /// </summary>
    public string DirectoryServer
    {
        get => directoryServer;
        set
        {
            directoryServer = value;
            OnPropertyChanged("DirectoryServer");
        }
    }

    /// <summary>
    /// The mileage.
    /// </summary>
    public string Mileage
    {
        get => mileage;
        set
        {
            mileage = value;
            OnPropertyChanged("Mileage");
        }
    }

    /// <summary>
    /// The occupation.
    /// </summary>
    public string Occupation
    {
        get => occupation;
        set
        {
            occupation = value;
            OnPropertyChanged("Occupation");
        }
    }

    /// <summary>
    /// The hobby.
    /// </summary>
    public string Hobby
    {
        get => hobby;
        set
        {
            hobby = value;
            OnPropertyChanged("Hobby");
        }
    }

    /// <summary>
    /// The sensitivity.
    /// </summary>
    public string Sensitivity
    {
        get => sensitivity;
        set
        {
            sensitivity = value;
            OnPropertyChanged("Sensitivity");
        }
    }

    /// <summary>
    /// The priority.
    /// </summary>
    public string Priority
    {
        get => priority;
        set
        {
            priority = value;
            OnPropertyChanged("Priority");
        }
    }

    /// <summary>
    /// The subject.
    /// </summary>
    public string Subject
    {
        get => subject;
        set
        {
            subject = value;
            OnPropertyChanged("Subject");
        }
    }

    /// <summary>
    /// The notes.
    /// </summary>
    public string Notes
    {
        get => notes;
        set
        {
            notes = value;
            OnPropertyChanged("Notes");
        }
    }

    /// <summary>
    /// The language.
    /// </summary>
    public string Language
    {
        get => language;
        set
        {
            language = value;
            OnPropertyChanged("Language");
        }
    }

    /// <summary>
    /// The photo.
    /// </summary>
    public string Photo
    {
        get => photo;
        set
        {
            photo = value;
            OnPropertyChanged("Photo");
        }
    }

    /// <summary>
    /// The group membership.
    /// </summary>
    public string GroupMembership
    {
        get => groupMembership;
        set
        {
            groupMembership = value;
            OnPropertyChanged("GroupMembership");
        }
    }

    /// <summary>
    /// The e mail 1 type.
    /// </summary>
    public string EMail1Type
    {
        get => eMail1Type;
        set
        {
            eMail1Type = value;
            OnPropertyChanged("EMail1Type");
        }
    }

    /// <summary>
    /// The e mail 1 value.
    /// </summary>
    public string EMail1Value
    {
        get => eMail1Value;
        set
        {
            eMail1Value = value;
            OnPropertyChanged("EMail1Value");
        }
    }

    /// <summary>
    /// The phone 1 type.
    /// </summary>
    public string Phone1Type
    {
        get => phone1Type;
        set
        {
            phone1Type = value;
            OnPropertyChanged("Phone1Type");
        }
    }

    /// <summary>
    /// The phone 1 value.
    /// </summary>
    public string Phone1Value
    {
        get => phone1Value;
        set
        {
            phone1Value = value;
            OnPropertyChanged("Phone1Value");
        }
    }

    /// <summary>
    /// The address 1 type.
    /// </summary>
    public string Address1Type
    {
        get => address1Type;
        set
        {
            address1Type = value;
            OnPropertyChanged("Address1Type");
        }
    }

    /// <summary>
    /// The address 1 formatted.
    /// </summary>
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
