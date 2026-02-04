namespace SunamoCsv.Data;

public partial class GoogleContactExportRow : INotifyPropertyChanged
{
    /// <summary>Gets or sets the initials</summary>
    public string Initials
    {
        get => initials;
        set
        {
            initials = value;
            OnPropertyChanged("Initials");
        }
    }

    /// <summary>Gets or sets the nickname</summary>
    public string Nickname
    {
        get => nickname;
        set
        {
            nickname = value;
            OnPropertyChanged("Nickname");
        }
    }

    /// <summary>Gets or sets the short name</summary>
    public string ShortName
    {
        get => shortName;
        set
        {
            shortName = value;
            OnPropertyChanged("ShortName");
        }
    }

    /// <summary>Gets or sets the maiden name</summary>
    public string MaidenName
    {
        get => maidenName;
        set
        {
            maidenName = value;
            OnPropertyChanged("MaidenName");
        }
    }

    /// <summary>Gets or sets the birthday</summary>
    public string Birthday
    {
        get => birthday;
        set
        {
            birthday = value;
            OnPropertyChanged("Birthday");
        }
    }

    /// <summary>Gets or sets the gender</summary>
    public string Gender
    {
        get => gender;
        set
        {
            gender = value;
            OnPropertyChanged("Gender");
        }
    }

    /// <summary>Gets or sets the location</summary>
    public string Location
    {
        get => location;
        set
        {
            location = value;
            OnPropertyChanged("Location");
        }
    }

    /// <summary>Gets or sets the billing information</summary>
    public string BillingInformation
    {
        get => billingInformation;
        set
        {
            billingInformation = value;
            OnPropertyChanged("BillingInformation");
        }
    }

    /// <summary>Gets or sets the directory server</summary>
    public string DirectoryServer
    {
        get => directoryServer;
        set
        {
            directoryServer = value;
            OnPropertyChanged("DirectoryServer");
        }
    }

    /// <summary>Gets or sets the mileage</summary>
    public string Mileage
    {
        get => mileage;
        set
        {
            mileage = value;
            OnPropertyChanged("Mileage");
        }
    }

    /// <summary>Gets or sets the occupation</summary>
    public string Occupation
    {
        get => occupation;
        set
        {
            occupation = value;
            OnPropertyChanged("Occupation");
        }
    }

    /// <summary>Gets or sets the hobby</summary>
    public string Hobby
    {
        get => hobby;
        set
        {
            hobby = value;
            OnPropertyChanged("Hobby");
        }
    }

    /// <summary>Gets or sets the sensitivity level</summary>
    public string Sensitivity
    {
        get => sensitivity;
        set
        {
            sensitivity = value;
            OnPropertyChanged("Sensitivity");
        }
    }

    /// <summary>Gets or sets the priority</summary>
    public string Priority
    {
        get => priority;
        set
        {
            priority = value;
            OnPropertyChanged("Priority");
        }
    }

    /// <summary>Gets or sets the subject</summary>
    public string Subject
    {
        get => subject;
        set
        {
            subject = value;
            OnPropertyChanged("Subject");
        }
    }

    /// <summary>Gets or sets the notes</summary>
    public string Notes
    {
        get => notes;
        set
        {
            notes = value;
            OnPropertyChanged("Notes");
        }
    }

    /// <summary>Gets or sets the language</summary>
    public string Language
    {
        get => language;
        set
        {
            language = value;
            OnPropertyChanged("Language");
        }
    }

    /// <summary>Gets or sets the photo</summary>
    public string Photo
    {
        get => photo;
        set
        {
            photo = value;
            OnPropertyChanged("Photo");
        }
    }

    /// <summary>Gets or sets the group membership</summary>
    public string GroupMembership
    {
        get => groupMembership;
        set
        {
            groupMembership = value;
            OnPropertyChanged("GroupMembership");
        }
    }

    /// <summary>Gets or sets the email type</summary>
    public string EMail1Type
    {
        get => eMail1Type;
        set
        {
            eMail1Type = value;
            OnPropertyChanged("EMail1Type");
        }
    }

    /// <summary>Gets or sets the email value</summary>
    public string EMail1Value
    {
        get => eMail1Value;
        set
        {
            eMail1Value = value;
            OnPropertyChanged("EMail1Value");
        }
    }

    /// <summary>Gets or sets the phone type</summary>
    public string Phone1Type
    {
        get => phone1Type;
        set
        {
            phone1Type = value;
            OnPropertyChanged("Phone1Type");
        }
    }

    /// <summary>Gets or sets the phone number</summary>
    public string Phone1Value
    {
        get => phone1Value;
        set
        {
            phone1Value = value;
            OnPropertyChanged("Phone1Value");
        }
    }

    /// <summary>Gets or sets the address type</summary>
    public string Address1Type
    {
        get => address1Type;
        set
        {
            address1Type = value;
            OnPropertyChanged("Address1Type");
        }
    }

    /// <summary>Gets or sets the formatted address</summary>
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