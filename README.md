# Wox.Plugins

Plug-In list :
 - Translator
 - Synonym

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

## 	TODO 
*Common* :
	- Unit Test

*Wox.Plugin.Translator*
	- Use WPF Best Practice for SettingsForm and SettingElements view model
