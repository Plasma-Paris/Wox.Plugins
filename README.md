# Wox.Plugins

Plug-In list :
 - Translator
 - Synonym
 - Jrnl

## 	Translator

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Translator/Images/usage.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Translator/Images/exemple.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Translator/Images/settings.png)

###		 About 
Use MyMemory API or Yandex API for translate from many language to another

###		 Usage 
tr {source-language} {destination-language} {words} (ex: {0} en fr Hello everyone)

###		 Settings
```json
{
    "YandexApiKey": "***************************",
    "ApiName": "Yandex.Translate",
    "DefaultLanguages": [
        {
            "Source": "fr",
            "Destination": "en"
        },
        {
            "Source": "en",
            "Destination": "fr"
        }
    ]
}
```

## 	Synonym

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Synonym/Images/usage.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Synonym/Images/exemple.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Synonym/Images/settings.png)

###		 About 
Use Thesaurus Api for find synonymous for a predefined language in settings

###		 Usage 
sy {word}

###		 Settings
```json
{
    "ThesaurusApiKey": "***************************",
    "DefaultLanguage": "fr_FR"
}
```

## 	Jrnl
TODO
![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Jrnl/Images/usage.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Jrnl/Images/exemple.png)

![](https://github.com/Plasma-Paris/Wox.Plugins/raw/master/Wox.Plugin.Jrnl/Images/settings.png)

###		 About 
Use Jrnl command line tool for showing and editing Jrnl entries.
Jrnl (http://maebert.github.io/jrnl/) must be installed.

###		 Usage 
TODO

###		 Settings 
TODO

## 	TODO 
*Common* :
- Unit Test

*Wox.Plugin.Translator*
- Use WPF Best Practice for SettingsForm and SettingElements view model

*Wox.Plugin.Jrnl*
- Complete the README.md